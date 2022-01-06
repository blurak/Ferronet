using System;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using Utilitarios;
namespace Datos
{
    public class DSubsede
    {
        public DataTable obtenerSubsedesSuper(int usuario)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_subsedes_super1", conection);
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

        public DataTable SubsedeAsignada(int usuario)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.verificar_subsede", conection);
                dataAdapter.SelectCommand.Parameters.Add("id_usuario", NpgsqlDbType.Integer, 100).Value = usuario;
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



        public DataTable ObtenerVentasDias(int idSubsede, string fecha)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_ventas_dia", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = idSubsede;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_hoy", NpgsqlDbType.Text, 100).Value = fecha;

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

        public DataTable detalleVenta(int idVenta)
        {
            DataTable detalleVentas = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_detalle_ventas", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_venta", NpgsqlDbType.Integer, 100).Value = idVenta;



                conection.Open();
                dataAdapter.Fill(detalleVentas);
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
            return detalleVentas;
        }

        public DataTable ObtenerTotalVentasHoy(int idSubsede, String fecha)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_total_vendido_hoy", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = idSubsede;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_hoy", NpgsqlDbType.Text, 100).Value = fecha;

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

       

       

        public DataTable obtenerProducotos_subsede(int id)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_subsedes_productos2", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = id;
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

        public DataTable ObtenerCajeroSubsede(int administrador)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_cajero_subsede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_administrador", NpgsqlDbType.Integer, 100).Value = administrador;

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


       

        public DataTable ObtenerVentasDiaSuper(int id_subsede, string fechainicio, string fechafin)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_VentasSuper", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = id_subsede;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_inicio", NpgsqlDbType.Text, 100).Value = fechainicio;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_fin", NpgsqlDbType.Text, 100).Value = fechafin;

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

        

        public DataTable totalVendido(int id_subsede, String fechainicio, String fechafin)
        {
            DataTable prosede = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_total_vendido", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = id_subsede;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_inicio", NpgsqlDbType.Text, 100).Value = fechainicio;
                dataAdapter.SelectCommand.Parameters.Add("_fecha_fin", NpgsqlDbType.Text, 100).Value = fechafin;


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
        public DataTable obtenerIdsedeAdministrador(int idAdmin)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_id_sede_admin", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_admin", NpgsqlDbType.Integer, 100).Value = idAdmin;

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

        public DataTable ObtenerProductosSubsede(int administrador)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_productos_subsede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_administrador", NpgsqlDbType.Integer, 100).Value = administrador;

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


    }
}
