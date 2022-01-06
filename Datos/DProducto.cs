using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class DProducto
    {
        public DataTable momodificarValorTotalVenta(int id_venta)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.modificar_valortotalventa", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_venta", NpgsqlDbType.Integer, 100).Value = id_venta;
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
        public DataTable RegistrarVentas(int cantidad, int id_producto, int id_venta, int id_cajero)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.registrar_ventacajerofactdetalle2", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad", NpgsqlDbType.Integer, 100).Value = cantidad;
                dataAdapter.SelectCommand.Parameters.Add("_id_producto", NpgsqlDbType.Integer, 100).Value = id_producto;
                dataAdapter.SelectCommand.Parameters.Add("_id_venta", NpgsqlDbType.Integer, 100).Value = id_venta;
                dataAdapter.SelectCommand.Parameters.Add("_id_cajero", NpgsqlDbType.Integer, 100).Value = id_cajero;
                dataAdapter.SelectCommand.Parameters.Add("session", NpgsqlDbType.Text, 100).Value ="" ;

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
        public DataTable obteneridventa(string fecha, string hora)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_id_venta", conection);
                dataAdapter.SelectCommand.Parameters.Add("_fecha", NpgsqlDbType.Text, 100).Value = fecha;
                dataAdapter.SelectCommand.Parameters.Add("_hora", NpgsqlDbType.Text, 100).Value = hora;
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

        public DataTable RegistrarVenta(int valor_total, int id_cajero, String dia, String hora)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.registrar_ventacajerofact", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_valor_total", NpgsqlDbType.Integer, 100).Value = valor_total;
                dataAdapter.SelectCommand.Parameters.Add("_id_cajero", NpgsqlDbType.Integer, 100).Value = id_cajero;
                dataAdapter.SelectCommand.Parameters.Add("_dia", NpgsqlDbType.Text, 100).Value = dia;
                dataAdapter.SelectCommand.Parameters.Add("_hora", NpgsqlDbType.Text, 100).Value = hora;
                dataAdapter.SelectCommand.Parameters.Add("session", NpgsqlDbType.Text, 100).Value = "";

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
        public DataTable obtenerProductos_Subsede(int usuario)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_productos_subsedes3", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_cajero", NpgsqlDbType.Integer, 100).Value = usuario;
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

        public DataTable obtenerNombreProducto(int codigo)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_nombre_producto", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer, 100).Value = codigo;

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


        public DataTable RegistrarProductos(EProducto producto)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.registrar_productos", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_precio", NpgsqlDbType.Double, 100).Value = producto.Precio;
                dataAdapter.SelectCommand.Parameters.Add("_descripcion", NpgsqlDbType.Text, 100).Value = producto.Descripcion;
                dataAdapter.SelectCommand.Parameters.Add("_imagen", NpgsqlDbType.Text, 100).Value = producto.Imagen;
                dataAdapter.SelectCommand.Parameters.Add("_categoria", NpgsqlDbType.Integer, 100).Value = producto.Categoria;
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
        public DataTable obtenerCategorias()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_categorias", conection);
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

        public DataTable recuperarProductos()
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.recuperar_productos", conection);
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

        public DataTable obtenerSede(int idSuperadmin)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_id_sede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_super", NpgsqlDbType.Integer, 100).Value = idSuperadmin;
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

        public DataTable AgregarProductos(EProducto producto)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.agregar_productos", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad", NpgsqlDbType.Integer, 100).Value = producto.Cantidad;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad_minima", NpgsqlDbType.Integer, 100).Value = producto.CantidadMinima;
                dataAdapter.SelectCommand.Parameters.Add("_id_producto", NpgsqlDbType.Integer, 100).Value = producto.IdProducto;
                dataAdapter.SelectCommand.Parameters.Add("_id_sede", NpgsqlDbType.Integer, 100).Value = producto.Sede;
                dataAdapter.SelectCommand.Parameters.Add("session", NpgsqlDbType.Text, 100).Value = producto.Session;

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
       
        public DataTable BorrarProductos(int codigoProducto, int idSede)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.borrar_productos_inventario", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_producto", NpgsqlDbType.Integer, 100).Value = codigoProducto;
                dataAdapter.SelectCommand.Parameters.Add("_id_sede", NpgsqlDbType.Integer, 100).Value = idSede;


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

        public DataTable obtenerProductosSede(int usuario)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_productos_sede", conection);
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
        public DataTable productos_sede_principal(int usuario)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_productos_de_sede", conection);
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
        public DataTable obtenerProductosBajasCantidadesSede(int usuario)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_productos_sede_bajos", conection);
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
        
        public void modificarCantidades(int cantidad, int cantidadmin, int idProducto, int id_usuario, int id_producto, String descripcio, int cantidad_minima)
        {
            int usuario_id = 55;
            DataTable user = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.modificar_cantidades", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_super", NpgsqlDbType.Integer).Value = usuario_id;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad", NpgsqlDbType.Integer).Value = cantidad;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad_minima", NpgsqlDbType.Integer).Value = cantidad_minima;
                dataAdapter.SelectCommand.Parameters.Add("_id_producto", NpgsqlDbType.Integer).Value = id_producto;

                conection.Open();
                dataAdapter.Fill(user);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("error producido", Ex.Data.ToString());
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
        }
        public DataTable obtenerPedidoscajero(int id_cajero)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_pedidos_subsede", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_cajero", NpgsqlDbType.Integer, 100).Value = id_cajero;
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
        public DataTable obtenerDetallePedidosSubsede(int idPedido)
        {
            DataTable detalle = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_detalle_pedido", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_pedido", NpgsqlDbType.Integer, 100).Value = idPedido;


                conection.Open();
                dataAdapter.Fill(detalle);
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
            return detalle;
        }
        public DataTable obtenerInventarioActual(int id_usuario)
        {
            DataTable prosede = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_inventario_actual_subsede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_cajero", NpgsqlDbType.Integer, 100).Value = id_usuario;

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
