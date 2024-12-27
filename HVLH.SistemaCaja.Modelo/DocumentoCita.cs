using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVLH.SistemaCaja.Modelo
{
	[Table("TBL_CajaDocumentoCita")]
	public class DocumentoCita
	{
        public int Id { get; set; }
        public int IdDocumento { get; set; }
        public string IdCita { get; set; }
        public Documento Documento { get; set; }
    }
}
