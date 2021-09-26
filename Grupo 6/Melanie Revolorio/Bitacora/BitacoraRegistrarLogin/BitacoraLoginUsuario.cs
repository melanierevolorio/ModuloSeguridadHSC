using Conexion;
using Modelo.DTO;
using System;
using System.Data.Odbc;
using Dapper;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using BitacoraRegistrarLogin.ViewModel;

namespace BitacoraUsuario
{
    public class BitacoraLoginUsuario
    {
        private ConexionODBC ODBC = new ConexionODBC();

        public void guardarLoginUsuario(string IdUsuario, string IdAplicacion)
        {
            string host = Dns.GetHostName();
            string ip = "";
            IPAddress[] hostIPs = Dns.GetHostAddresses(host);
            for (int i = 0; i < hostIPs.Length; i++)
            {
                ip = hostIPs[i].ToString();
            }

            dtoBitacoraIniciarSesion modeloBitacora = new dtoBitacoraIniciarSesion();
            OdbcConnection conexionODBC = ODBC.abrirConexion();
            if (conexionODBC != null)
            {
                var sqlinsertar =
                "INSERT INTO bitacorausuario (pkId, host, ip, conexionFecha, conexionHora, conexionTiempo, fkIdUsuario, fkIdAplicacion) " +
                "VALUES (NULL, ?host?, ?ip?, ?conexionFecha?, ?conexionHora?, ?conexionTiempo?, ?fkIdUsuario?, ?fkIdAplicacion?);";
                var ValorDeVariables = new
                {
                    host = host,
                    ip = ip,
                    conexionFecha = modeloBitacora.conexionFecha,
                    conexionHora = modeloBitacora.conexionHora,
                    conexionTiempo = "EsTrabajoDeNavegador",
                    fkIdUsuario = IdUsuario,
                    fkIdAplicacion = IdAplicacion
                };
                conexionODBC.Execute(sqlinsertar, ValorDeVariables);
                ODBC.cerrarConexion(conexionODBC);
            }
        }

        public List<ViewModelBitacora> leerBitacoraLogin()
        {
            List<ViewModelBitacora> sqlresultado = new List<ViewModelBitacora>();
            OdbcConnection conexionODBC = ODBC.abrirConexion();
            if (conexionODBC != null)
            {
                string sqlconsulta = "SELECT A.pkId, A.host, A.ip, A.conexionFecha, A.conexionHora, A.conexionTiempo, B.nombre AS usuario, C.nombre AS aplicacion FROM bitacorausuario A JOIN usuario B ON A.fkIdUsuario = B.pkId JOIN aplicacion C ON A.fkIdAplicacion = C.pkId;";
                sqlresultado = conexionODBC.Query<ViewModelBitacora>(sqlconsulta).ToList();
                ODBC.cerrarConexion(conexionODBC);
            }
            return sqlresultado;
        }
    }
}