using Conexion;
using Dapper;
using Modelo.DTO;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;

namespace Modelo.DAO
{
    /// <summary>
    /// Clase utilizada para agregar, modificar, eliminar o mostrar los campos de usuario en la base de datos.
    /// </summary>
    class daoUsuario
    {
        private ConexionODBC ODBC = new ConexionODBC();

        /// <summary>
        /// Método que sirve para agregar nuevos usuario a la base de datos
        /// </summary>
        /// <param name="modelo">Recibe el modelo de usuario que se desea ingresar</param>
        /// <returns>Retorna el usuario ingresado para ser agregado a la tabla</returns>
        public dtoUsuario agregarUsuario(dtoUsuario modelo)
        {
            OdbcConnection conexionODBC = ODBC.abrirConexion();
            if (conexionODBC != null)
            {
                var sqlinsertar =
                "INSERT INTO Usuario (pkId, nombre, contraseña, estado) " +
                "VALUES (?pkId?, ?nombre?, ?contraseña?, ?estado?);";
                var ValorDeVariables = new
                {
                    pkId = modelo.pkId,
                    nombre = modelo.nombre,
                    contraseña = modelo.contraseña,
                    estado = "1"
                };
                conexionODBC.Execute(sqlinsertar, ValorDeVariables);
                ODBC.cerrarConexion(conexionODBC);
            }
            return modelo;
        }

        /// <summary>
        /// Método que sirve para obtener datos de un usuario en especifico
        /// </summary>
        /// <param name="usuario">Recibe el modelo de usuario que se desea ingresar</param>
        /// <returns>Retorna el usuario ingresado para ser agregado a la tabla</returns>
        public List<string> obtenerDatosDeUsuario(string usuario)
        {
            OdbcConnection conexionODBC = ODBC.abrirConexion();
            if (conexionODBC != null)
            {
                var sqlconsulta =
                "SELECT contraseña FROM Usuario WHERE nombre = ?nombre?;";
                var ValorDeVariables = new
                {
                    nombre = usuario,
                };
                var sqlresultado = conexionODBC.Query<string>(sqlconsulta, ValorDeVariables);
                if (sqlresultado.Count() > 0)
                {
                    ODBC.cerrarConexion(conexionODBC);
                    return sqlresultado.ToList();
                }
                ODBC.cerrarConexion(conexionODBC);
                return null;
            }
            return null;
        }

        /// <summary>
        /// Método que sirve para mostrar los usuarios
        /// </summary>
        /// <returns>Retorna la consulta a la base de datos que son los usuarios de la tablaUsuarios</returns>
        public List<dtoUsuario> mostrarUsuario()
        {
            OdbcConnection conexionODBC = ODBC.abrirConexion();
            List<dtoUsuario> sqlresultado = new List<dtoUsuario>();
            if (conexionODBC != null)
            {
                string sqlconsulta = "SELECT * FROM Usuario;";
                sqlresultado = conexionODBC.Query<dtoUsuario>(sqlconsulta).ToList();
                ODBC.cerrarConexion(conexionODBC);
            }
            return sqlresultado;
        }
    }
}