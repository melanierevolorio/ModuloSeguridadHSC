using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.DTO
{
    public class dtoAplicacion
    {
        public string pkId { get; set; }
        public string nombre { get; set; }
        public int estado { get; set; }
        public int fkIdReporteAsociado { get; set; }
    }
}