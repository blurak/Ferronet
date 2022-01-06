using System;
using System.Data;
using Utilitarios;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Web;

namespace Datos
{
    public class DSede
    {

        public DataTable ProductosProximosAterminar(int id_super)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.productos_proximos_terminar", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_super", NpgsqlDbType.Integer, 100).Value = id_super;


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
        public DataTable ModificarProductosProximosAterminar(int idProducto, int idRegistro, int idUsuario, int cantidad, int codigo_producto, String subsede, String producto, String categoria, int cantidadminima, String imagen, int codigo_registro)
        {

            int usuario = int.Parse(HttpContext.Current.Session["user_id"].ToString());
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.modificar_proximos", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_producto", NpgsqlDbType.Integer, 100).Value =codigo_registro;
                dataAdapter.SelectCommand.Parameters.Add("_registro", NpgsqlDbType.Integer, 100).Value = codigo_producto;
                dataAdapter.SelectCommand.Parameters.Add("_id_super", NpgsqlDbType.Integer, 100).Value = usuario;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad", NpgsqlDbType.Integer, 100).Value = cantidad;

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

        public DataTable obtenerSubsedes(int usuario)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_subsedes_super", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer, 100).Value = usuario;
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

        public DataTable AsignarProductosSubsede(EProducto producto, int idSuper)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.registrar_productos_de_subsede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad", NpgsqlDbType.Integer, 100).Value = producto.Cantidad;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad_minima", NpgsqlDbType.Integer, 100).Value = producto.CantidadMinima;
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = producto.Sede;
                dataAdapter.SelectCommand.Parameters.Add("_id_producto", NpgsqlDbType.Integer, 100).Value = producto.IdProducto;
                dataAdapter.SelectCommand.Parameters.Add("_id_super", NpgsqlDbType.Integer, 100).Value = idSuper;
                dataAdapter.SelectCommand.Parameters.Add("session", NpgsqlDbType.Varchar, 100).Value = producto.Session;

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

        public DataTable ObtenerCantidadProducto(int idUsuario, int producto)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_cantidad_de_productos", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer, 100).Value = idUsuario;
                dataAdapter.SelectCommand.Parameters.Add("_id_producto", NpgsqlDbType.Integer, 100).Value = producto;

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

        public DataTable BuscarProductoInventarioSede(String criterioDeBusqueda, int idSuper)
        {
            DataTable prosede = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.buscar_producto_inventario_sede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_criterio", NpgsqlDbType.Text, 100).Value = criterioDeBusqueda;
                dataAdapter.SelectCommand.Parameters.Add("_id_super", NpgsqlDbType.Integer, 100).Value = idSuper;
                conection.Open();
                dataAdapter.Fill(prosede);
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
            return prosede;
        }

        public DataTable obtenerCajeros()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_cajeros", conection);
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

        public DataTable obtenerAdministradores()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_administradores", conection);
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


        public DataTable RegistrarSubsede(ESubsede subsede)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.registrar_subsedes", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_nombre", NpgsqlDbType.Text, 100).Value = subsede.Nombre;
                dataAdapter.SelectCommand.Parameters.Add("_ubicacion", NpgsqlDbType.Text, 100).Value = subsede.Ubicacion;
                dataAdapter.SelectCommand.Parameters.Add("_id_admin", NpgsqlDbType.Integer, 100).Value = subsede.IdAdmin;
                dataAdapter.SelectCommand.Parameters.Add("_id_cajero", NpgsqlDbType.Integer, 100).Value = subsede.IdCajero;
                dataAdapter.SelectCommand.Parameters.Add("_id_sede", NpgsqlDbType.Integer, 100).Value = subsede.IdSede;
                dataAdapter.SelectCommand.Parameters.Add("session", NpgsqlDbType.Varchar, 100).Value = subsede.Session;

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

        public DataTable obtenerCajeroyAdminSubsede(int id_usuario)
        {
            DataTable prosede = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_subsedes_ids19", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer, 100).Value = id_usuario;

                conection.Open();
                dataAdapter.Fill(prosede);
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
            return prosede;
        }

        public DataTable buscarProductoConIdUsuario(int usuario)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.buscar_producto_inventario_sede", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer, 100).Value = usuario;
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

        public DataTable obtenerProsede(int id_sede)
        {
            DataTable prosede = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_Prodcutos_sede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_sede", NpgsqlDbType.Integer, 100).Value = id_sede;

                conection.Open();
                dataAdapter.Fill(prosede);
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
            return prosede;
        }
    }
}
