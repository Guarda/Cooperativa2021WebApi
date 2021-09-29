using System;

namespace Model
{
	public abstract class AfiliadoBase
	{
		public int IdAfiliado { get; set; }
		public int IdReferente { get; set; }
		public string NombreAfiliado { get; set; }
		public string ApellidoAfiliado { get; set; }
		public int Celular { get; set; }
		public int TelefonoDomicilio { get; set; }
		public string CorreoElectronico { get; set; }
		public string Cedula { get; set; }
		public string Direccion1 { get; set; }
		public string Direccion2 { get; set; }
		public DateTime FechaInscripcion { get; set; }
		public int Estado { get; set; }
		public int Cargo { get; set; }
	}
}