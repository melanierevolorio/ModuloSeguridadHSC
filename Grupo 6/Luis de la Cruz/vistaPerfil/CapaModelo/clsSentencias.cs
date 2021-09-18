using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using Dapper;

namespace CapaModelo
{
    class clsSentencias
    {


        public class dtoPerfil
        {
            public string pkId { get; set; }
            public string nombre { get; set; }
            public string estado { get; set; }

            public dtoPerfil()
            {
            }


            public dtoPerfil(string Id, string Nombre, string Estado)
            {
                pkId = Id;
                nombre = Nombre;
                estado = Estado;
            }
        }

        public class daoPerfil
        {
            private clsConexion ODBC = new clsConexion();

            public dtoPerfil agregarPerfil(dtoPerfil CapaModelo)
            {
                OdbcConnection conexionODBC = ODBC.conexion();
                if (conexionODBC != null)
                {
                    var sqlinsertar =
                    "INSERT INTO empleado (pkId, nombre, estado) " +
                    "VALUES (?id?, ?nombre?, ?estado?);";
                    var ValorDeVariables = new
                    {
                        id = CapaModelo.pkId,
                        nombre = CapaModelo.nombre,
                        estado = CapaModelo.estado,
                    };
                    conexionODBC.Execute(sqlinsertar, ValorDeVariables);
                    ODBC.desconexion(conexionODBC);
                }
                return CapaModelo;
            }

            public dtoPerfil modificarPerfil(dtoPerfil CapaModelo)
            {
                OdbcConnection conexionODBC = ODBC.conexion();
                if (conexionODBC != null)
                {
                    var sqlinsertar =
                    "UPDATE perfil SET nombre = ?nombre?," +
                    "estado = ?estado? " +
                    "WHERE pkId = ?pkId?;";
                    var ValorDeVariables = new
                    {
                        nombre = CapaModelo.nombre,
                        estado = CapaModelo.estado,
                        pkId = CapaModelo.pkId
                    };
                    conexionODBC.Execute(sqlinsertar, ValorDeVariables);
                    ODBC.desconexion(conexionODBC);
                }
                return CapaModelo;
            }

            public dtoPerfil eliminarPerfil(dtoPerfil CapaModelo)
            {
                OdbcConnection conexionODBC = ODBC.conexion();
                if (conexionODBC != null)
                {
                    var sqlinsertar =
                    "DELETE FROM perfil WHERE pkId = ?pkId?;";

                    var ValorDeVariables = new
                    {
                        pkId = CapaModelo.pkId
                    };
                    conexionODBC.Execute(sqlinsertar, ValorDeVariables);
                    ODBC.desconexion(conexionODBC);
                }
                return CapaModelo;
            }



        }
    }
}