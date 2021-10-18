using System;

namespace Model
{
	public abstract class AgenteBase
	{
		public int IdAgente { get; set; }
		public DateTime FechaContrato { get; set; }
		public int IdEstado { get; set; }
		public int IdAfiliado { get; set; }
	}
}