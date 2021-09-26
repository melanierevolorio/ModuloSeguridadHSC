using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitacoraRegistrarLogin.ViewModel
{
    public class ViewModelBitacora
    {
        public int pkId { get; set; }
        public string host { get; set; }
        public string ip { get; set; }
        public DateTime conexionFecha { get; set; }
        public TimeSpan conexionHora { get; set; }
        public string conexionTiempo { get; set; }
        public string usuario { get; set; }
        public string aplicacion { get; set; }

        public ViewModelBitacora()
        {
        }
    }
}