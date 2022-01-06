using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using Utilitarios;

namespace Datos
{
    public class DProveedores
    {
        public DataTable ObtenerCategorias()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_categoria", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                conection.Open();
                dataAdapter.Fill(Usuario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Usuario;
        }
        public DataTable RegistrarProoveedores(EProveedor datos)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.registrar_proveedores", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text, 100).Value = datos.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_correo", NpgsqlDbType.Text, 100).Value = datos.Correo;
                dataAdapter.SelectCommand.Parameters.Add("_telefono", NpgsqlDbType.Text, 100).Value = datos.Telefono;
                dataAdapter.SelectCommand.Parameters.Add("_categoria", NpgsqlDbType.Integer, 100).Value = datos.IdCategoria;
                dataAdapter.SelectCommand.Parameters.Add("_id_sede", NpgsqlDbType.Integer, 100).Value = datos.IdSede;
                dataAdapter.SelectCommand.Parameters.Add("session", NpgsqlDbType.Text, 100).Value = datos.Session;

                conection.Open();
                dataAdapter.Fill(Usuario);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return Usuario;
        }
        public DataTable obtenerProvee(int id_Sede)
        {
            DataTable provee = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_Proveedores_sede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_sede", NpgsqlDbType.Integer, 100).Value = id_Sede;
                conection.Open();
                dataAdapter.Fill(provee);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return provee;
        }
    }
}
