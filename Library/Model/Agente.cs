using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Agente : AgenteBase
    {
		public int IdReferente { get; set; }
		public string NombreAgente { get; set; }
		public string ApellidoAgente { get; set; }
		public int Celular { get; set; }
		public int TelefonoDomicilio { get; set; }
		public string CorreoElectronico { get; set; }
		public string Cedula { get; set; }
		public string Direccion1 { get; set; }
		public string Direccion2 { get; set; }
		public DateTime FechaInscripcion { get; set; }
		public int EstadoAfiliado { get; set; }
		public int IdCargo { get; set; }

		public string Estado { get; set; }
	}
}

