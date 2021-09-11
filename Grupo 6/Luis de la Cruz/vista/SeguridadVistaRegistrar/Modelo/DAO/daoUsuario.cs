using Dapper;
using Conexion;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using Modelo.DTO;

namespace Modelo.DAO
{
    public class daoEmpleado
    {
        private ConexionODBC ODBC = new ConexionODBC();

        public dtoPerfil agregarEmpleado(dtoPerfil modelo)
        {
            OdbcConnection conexionODBC = ODBC.abrirConexion();
            if (conexionODBC != null)
            {
                var sqlinsertar =
                "INSERT INTO empleado (pkId, nombre, estado) " +
                "VALUES (?id?, ?nombre?, ?estado?);";
                var ValorDeVariables = new
                {
                    id = modelo.pkId,
                    nombre = modelo.nombre,
                    estado = modelo.estado,
                };
                conexionODBC.Execute(sqlinsertar, ValorDeVariables);
                ODBC.cerrarConexion(conexionODBC);
            }
            return modelo;
        }

        public dtoPerfil modificarEmpleado(dtoPerfil modelo)
        {
            OdbcConnection conexionODBC = ODBC.abrirConexion();
            if (conexionODBC != null)
            {
                var sqlinsertar =
                "UPDATE perfil SET nombre = ?nombre?," +
                "estado = ?estado? " +
                "WHERE pkId = ?pkId?;";
                var ValorDeVariables = new
                {
                    nombre = modelo.nombre,
                    estado = modelo.estado,
                    pkId = modelo.pkId
                };
                conexionODBC.Execute(sqlinsertar, ValorDeVariables);
                ODBC.cerrarConexion(conexionODBC);
            }
            return modelo;
        }

        public dtoPerfil eliminarEmpleado(dtoPerfil modelo)
        {
            OdbcConnection conexionODBC = ODBC.abrirConexion();
            if (conexionODBC != null)
            {
                var sqlinsertar =
                "DELETE FROM perfil WHERE pkId = ?pkId?;";

                var ValorDeVariables = new
                {
                    pkId = modelo.pkId
                };
                conexionODBC.Execute(sqlinsertar, ValorDeVariables);
                ODBC.cerrarConexion(conexionODBC);
            }
            return modelo;
        }

        public List<dtoPerfil> mostrarEmpleado()
        {
            List<dtoPerfil> sqlresultado = new List<dtoPerfil>();
            OdbcConnection conexionODBC = ODBC.abrirConexion();
            if (conexionODBC != null)
            {
                string sqlconsulta = "SELECT * FROM empleado;";
                sqlresultado = conexionODBC.Query<dtoPerfil>(sqlconsulta).ToList();
                ODBC.cerrarConexion(conexionODBC);
            }
            return sqlresultado;
        }
    }
}