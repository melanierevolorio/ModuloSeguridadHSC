using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.DTO
{
    public class dtoBitacoraIniciarSesion //data transfer object
    {
        public int pkId { get; set; }
        public string host { get; set; }
        public string ip { get; set; }
        public DateTime conexionFecha { get; set; }
        public TimeSpan conexionHora { get; set; }
        public string conexionTiempo { get; set; }
        public int fkIdUsuario { get; set; }
        public int fkIdAplicacion { get; set; }

        public dtoBitacoraIniciarSesion()
        {
            DateTime fecha = DateTime.Now;
            string fechaSolita = fecha.ToString("yyyy-MM-dd");
            conexionFecha = DateTime.Parse(fechaSolita);

            conexionHora = new TimeSpan(conexionFecha.Hour, conexionFecha.Minute, conexionFecha.Second);
        }
    }
}