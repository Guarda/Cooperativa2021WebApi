using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AfiliadoActualizar
    {
        public Int32 IdAfiliado { get; set; }
        public String NombreAfiliado { get; set; }
        public String ApellidoAfiliado { get; set; }
        public Int32 IdReferente { get; set; }
        public Int32 Celular { get; set; }
        public Int32 TelefonoDomicilio { get; set; }
        public String CorreoElectronico { get; set; }
        public String Cedula { get; set; }
        public String Direccion1 { get; set; }
        public String Direccion2 { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdCargo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
    }
}
