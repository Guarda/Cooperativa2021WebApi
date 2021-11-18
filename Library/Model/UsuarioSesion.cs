using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UsuarioSesion
    {
        public Int32 IdAfiliado { get; set; }

        public String NombreAfiliado { get; set; }

        public Int32 IdAgente { get; set; }

        public String NombreUsuario { get; set; }

        public DateTime FechaExpiracion { get; set; }

        public String Token { get; set; }

    }
}
