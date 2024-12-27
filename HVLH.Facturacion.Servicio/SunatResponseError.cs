using System.Collections.Generic;

namespace HVLH.Facturacion.Servicio
{
    public class SunatResponseError
    {
        public int StatusCode { get; set; }
        public string cod { get; set; }
        public string msg { get; set; }
        public string exc { get; set; }
        public List<SunatResponseErrorDetalle> errors { get; set; }
    }
}