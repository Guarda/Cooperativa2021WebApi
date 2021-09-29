using System;

namespace Model
{
    public abstract class ServiciosBase
    {
		public int IdServicio { get; set; }
		public string NombreServicio { get; set; }
		public string DescripcionServicio { get; set; }
		public int Precio { get; set; }
		public string Plazo { get; set; }
		public int IdEstadoServicio { get; set; }
	}
}
