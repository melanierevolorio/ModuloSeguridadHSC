using CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Rol
    {
        public static List<Perfiles> Listar()
        {
            List<Perfiles> rptListaRol = new List<Perfiles>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerRoles", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaRol.Add(new Perfiles()
                        {
                            IdRol = Convert.ToInt32(dr["IdRol"].ToString()),
                            Descripcion = dr["Descripcion"].ToString(),
                            Activo = Convert.ToBoolean(dr["Activo"].ToString())
                        });
                    }
                    dr.Close();

                    return rptListaRol;

                }
                catch (Exception ex)
                {
                    rptListaRol = null;
                    return rptListaRol;
                }
            }
        }

        public static bool Registrar(Perfiles oRol)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_RegistrarRol", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", oRol.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public static bool Editar(Perfiles oRol)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ModificarRol", oConexion);
                    cmd.Parameters.AddWithValue("IdRol", oRol.IdRol);
                    cmd.Parameters.AddWithValue("Descripcion", oRol.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oRol.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }

        public static bool Eliminar(int IdRol)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_EliminarRol", oConexion);
                    cmd.Parameters.AddWithValue("IdRol",IdRol);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }



    }
}
