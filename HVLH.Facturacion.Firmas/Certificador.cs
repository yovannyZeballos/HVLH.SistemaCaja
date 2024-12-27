using HVLH.Facturacion.Comun.Datos.Intercambio;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace HVLH.Facturacion.Firmas
{
    public class Certificador : ICertificador
    {
        public CodigoBarrasResponse GenerarCodigoQr(CodigoBarrasRequest request)
        {
            CodigoBarrasResponse codigoBarrasResponse = new CodigoBarrasResponse();
            QrCodeEncodingOptions codeEncodingOptions = new QrCodeEncodingOptions();
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            ImageConverter imageConverter = new ImageConverter();
            try
            {
                codeEncodingOptions.ErrorCorrection = ErrorCorrectionLevel.Q;
                codeEncodingOptions.QrVersion = new int?(7);
                codeEncodingOptions.Height = 300;
                codeEncodingOptions.Width = 300;
                codeEncodingOptions.Margin = 1;
                barcodeWriter.Format = BarcodeFormat.QR_CODE;
                barcodeWriter.Options = codeEncodingOptions;
                codigoBarrasResponse.CodigoBarrasBytes = (byte[])imageConverter.ConvertTo(barcodeWriter.Write(request.TextoCodigo), typeof(byte[]));
                codigoBarrasResponse.Exito = true;
            }
            catch (Exception ex)
            {
                codigoBarrasResponse.Exito = false;
                codigoBarrasResponse.MensajeError = ex.Message;
                codigoBarrasResponse.Pila = ex.StackTrace;
            }
            return codigoBarrasResponse;
        }

        public FirmadoResponse FirmarXml(FirmadoRequest request)
        {
            FirmadoResponse firmadoResponse = new FirmadoResponse();
            X509Certificate2 x509Certificate2 = new X509Certificate2();
            x509Certificate2.Import(Convert.FromBase64String(request.CertificadoDigital), request.PasswordCertificado, X509KeyStorageFlags.MachineKeySet);
            XmlDocument document = new XmlDocument();
            string base64String;
            using (MemoryStream memoryStream1 = new MemoryStream(Encoding.Convert(Encoding.UTF8, Encoding.UTF8, Convert.FromBase64String(request.TramaXmlSinFirma))))
            {
                document.PreserveWhitespace = true;
                document.Load((Stream)memoryStream1);
                int index = request.UnSoloNodoExtension ? 0 : 1;
                XmlNode xmlNode = document.GetElementsByTagName("ExtensionContent", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2").Item(index);
                if (xmlNode == null)
                    throw new InvalidOperationException("No se pudo encontrar el nodo ExtensionContent en el XML");
                xmlNode.RemoveAll();
                SignedXml signedXml = new SignedXml(document)
                {
                    SigningKey = x509Certificate2.PrivateKey
                };
                System.Security.Cryptography.Xml.Signature signature = signedXml.Signature;
                XmlDsigEnvelopedSignatureTransform signatureTransform = new XmlDsigEnvelopedSignatureTransform();
                Reference reference = new Reference(string.Empty);
                reference.AddTransform((Transform)signatureTransform);
                signature.SignedInfo.AddReference(reference);
                KeyInfo keyInfo = new KeyInfo();
                KeyInfoX509Data keyInfoX509Data = new KeyInfoX509Data((X509Certificate)x509Certificate2);
                keyInfoX509Data.AddSubjectName(x509Certificate2.Subject);
                keyInfo.AddClause((KeyInfoClause)keyInfoX509Data);
                signature.KeyInfo = keyInfo;
                signature.Id = "sign" + request.RucEmisor;
                signedXml.ComputeSignature();
                if (reference.DigestValue != null)
                    firmadoResponse.ResumenFirma = Convert.ToBase64String(reference.DigestValue);
                firmadoResponse.ValorFirma = Convert.ToBase64String(signedXml.SignatureValue);
                xmlNode.AppendChild((XmlNode)signedXml.GetXml());
                using (MemoryStream memoryStream2 = new MemoryStream())
                {
                    MemoryStream memoryStream3 = memoryStream2;
                    using (XmlWriter w = XmlWriter.Create((Stream)memoryStream3, new XmlWriterSettings()
                    {
                        Encoding = new UTF8Encoding(false)
                    }))
                        document.WriteTo(w);
                    base64String = Convert.ToBase64String(memoryStream2.ToArray());
                }
            }
            firmadoResponse.TramaXmlFirmado = base64String;
			firmadoResponse.Exito = true;

			return firmadoResponse;
        }

        public FirmadoResponse ObetenerValorFirma(string archivoXml)
        {
            FirmadoResponse firmadoResponse = new FirmadoResponse();
            XmlDocument xmlDocument = new XmlDocument();
            if (File.Exists(archivoXml))
            {
                xmlDocument.Load(archivoXml);
                XmlNodeList elementsByTagName1 = xmlDocument.GetElementsByTagName("DigestValue");
                XmlNodeList elementsByTagName2 = xmlDocument.GetElementsByTagName("SignatureValue");
                string innerText1 = elementsByTagName1[0].InnerText;
                string innerText2 = elementsByTagName2[0].InnerText;
                firmadoResponse.ValorFirma = innerText2;
                firmadoResponse.ResumenFirma = innerText1;
                firmadoResponse.Exito = true;
            }
            else
            {
                firmadoResponse.Exito = false;
                firmadoResponse.MensajeError = "No existe el archivo xml";
            }
            return firmadoResponse;
        }
    }
}
