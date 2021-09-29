using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Servicios : ServiciosBase
    {
        public int IdEstadoServicio { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
