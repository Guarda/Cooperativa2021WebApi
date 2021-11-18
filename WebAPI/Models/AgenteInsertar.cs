using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AgenteInsertar
    {
        public String NombreAgente { get; set; }
        public String ApellidoAgente { get; set; }        
        public Int32 IdAfiliado { get; set; }
        public DateTime FechaContrato { get; set; }
        public Int32 IdEstado { get; set; }
        public Int32 IdCargo { get; set; }
        
    }
}
