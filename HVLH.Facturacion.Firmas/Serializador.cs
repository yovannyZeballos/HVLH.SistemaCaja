using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using HVLH.Facturacion.Comun.Datos.Intercambio;
using Ionic.Zip;


namespace HVLH.Facturacion.Firmas
{
	public class Serializador : ISerializador
	{
		string ISerializador.GenerarXml<T>(T objectToSerialize)
		{
			var serializer = new XmlSerializer(objectToSerialize.GetType());
			string resultado;

			using (var memStr = new MemoryStream())
			{
				using (var stream = new StreamWriter(memStr))
				{
					serializer.Serialize(stream, objectToSerialize);
				}
				Encoding iso = Encoding.GetEncoding("UTF-8");
				var betterBytes = Encoding.Convert(iso, new UTF8Encoding(false), memStr.ToArray());
				resultado = Convert.ToBase64String(betterBytes);
			}
			return resultado;
		}

		string ISerializador.GenerarZip(string tramaXml, string nombreArchivo)
		{
			MemoryStream memoryStream1 = new MemoryStream(Convert.FromBase64String(tramaXml));
			MemoryStream memoryStream2 = new MemoryStream();
			string base64String;
			using (ZipFile zipFile = new ZipFile(nombreArchivo + ".zip"))
			{
				zipFile.AddEntry(nombreArchivo + ".xml", (Stream)memoryStream1);
				zipFile.Save((Stream)memoryStream2);
				base64String = Convert.ToBase64String(memoryStream2.ToArray());
			}
			memoryStream1.Close();
			memoryStream2.Close();
			return base64String;
		}

		EnviarDocumentoResponse ISerializador.GenerarDocumentoRespuesta(string constanciaRecepcion)
		{
			EnviarDocumentoResponse documentoResponse = new EnviarDocumentoResponse();
			using (MemoryStream memoryStream1 = new MemoryStream(Convert.FromBase64String(constanciaRecepcion)))
			{
				using (ZipFile zipFile = ZipFile.Read((Stream)memoryStream1))
				{
					foreach (ZipEntry entry in (IEnumerable<ZipEntry>)zipFile.Entries)
					{
						if (entry.FileName.EndsWith(".xml"))
						{
							using (MemoryStream memoryStream2 = new MemoryStream())
							{
								entry.Extract((Stream)memoryStream2);
								memoryStream2.Position = 0L;
								string end = new StreamReader((Stream)memoryStream2).ReadToEnd();
								try
								{
									XmlDocument xmlDocument = new XmlDocument();
									xmlDocument.LoadXml(end);
									XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
									nsmgr.AddNamespace("ar", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2");
									nsmgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
									nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
									documentoResponse.CodigoRespuesta = xmlDocument.SelectSingleNode("/ar:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:ResponseCode", nsmgr)?.InnerText;
									documentoResponse.MensajeRespuesta = xmlDocument.SelectSingleNode("/ar:ApplicationResponse/cac:DocumentResponse/cac:Response/cbc:Description", nsmgr)?.InnerText;
									documentoResponse.TramaZipCdr = constanciaRecepcion;
									documentoResponse.NombreArchivo = entry.FileName;
									documentoResponse.Exito = true;
								}
								catch (Exception ex)
								{
									documentoResponse.MensajeError = ex.Message;
									documentoResponse.Pila = ex.StackTrace;
									documentoResponse.Exito = false;
								}
							}
						}
					}
				}
			}
			return documentoResponse;
		}

		string ISerializador.GenerarHashZip(string tramaZip)
		{
			try
			{
				var sb = new StringBuilder();
				using (SHA256 hash = SHA256.Create())
				{
					Encoding encoding = Encoding.UTF8;
					byte[] result = hash.ComputeHash(Convert.FromBase64String(tramaZip));

					foreach (byte b in result)
					{
						sb.Append(b.ToString("x2"));
					}
				}
				return sb.ToString();
			}
			catch (Exception)
			{
				return "";
			}
		}
	}
}
