using System;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Data;
using Utilitarios;

namespace Datos
{
    public class DPedido
    {
        public DataTable modificarEstadoPedido(int id_cajero, int id_pedido)
        {

            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.modificar_cantidades", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_cajero", NpgsqlDbType.Integer, 100).Value = id_cajero;
                dataAdapter.SelectCommand.Parameters.Add("_id", NpgsqlDbType.Integer, 100).Value = id_pedido;

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
        public DataTable verificarCantidades(int id_producto, int id_subsede)
        {
            //usuario.validar_cantidades(_id_producto integer, _id_subsede integer)
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.validar_cantidades", conection);
                dataAdapter.SelectCommand.Parameters.Add("_id_producto", NpgsqlDbType.Integer, 100).Value = id_producto;
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = id_subsede;

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
        public DataTable ObtenerUbicacion(int idSubsede)
        {
            DataTable Usuario = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_ubicacion_subsede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = idSubsede;

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
        public DataTable RegistrarPedido(EPedido pedido)
        {
            DataTable Pedido = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.registrar_pedidos", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_tipo_de_entrega", NpgsqlDbType.Text, 100).Value = pedido.TipoEntrega;
                dataAdapter.SelectCommand.Parameters.Add("_direccion", NpgsqlDbType.Text, 100).Value = pedido.Direccion;
                dataAdapter.SelectCommand.Parameters.Add("_valor_total", NpgsqlDbType.Integer, 100).Value = pedido.ValorTotal;
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = pedido.IdSubsede;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer, 100).Value = pedido.IdUsuario;
                dataAdapter.SelectCommand.Parameters.Add("session", NpgsqlDbType.Text, 100).Value = pedido.Session;

                conection.Open();
                dataAdapter.Fill(Pedido);
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
            return Pedido;
        }

        public DataTable RegistrarDetallePedido(EPedido pedido)
        {
            DataTable Pedido = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.registrar_detalle_pedido", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad", NpgsqlDbType.Integer, 100).Value = pedido.Cantidad;
                dataAdapter.SelectCommand.Parameters.Add("_valor_unitario", NpgsqlDbType.Integer, 100).Value = pedido.Precio;
                dataAdapter.SelectCommand.Parameters.Add("_valor_total", NpgsqlDbType.Integer, 100).Value = pedido.ValorTotalProducto;
                dataAdapter.SelectCommand.Parameters.Add("_id_producto", NpgsqlDbType.Integer, 100).Value = pedido.IdProducto;
                dataAdapter.SelectCommand.Parameters.Add("_id_pedido", NpgsqlDbType.Integer, 100).Value = pedido.IdPedido;
                dataAdapter.SelectCommand.Parameters.Add("session", NpgsqlDbType.Varchar, 100).Value = pedido.Session;

                conection.Open();
                dataAdapter.Fill(Pedido);
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
            return Pedido;
        }

        public DataTable RestarCantidadesPedido(EPedido pedido)
        {
            DataTable Idpedido = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.restar_cantidades_pedido", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_cantidad", NpgsqlDbType.Integer, 100).Value = pedido.Cantidad;
                dataAdapter.SelectCommand.Parameters.Add("_id_producto", NpgsqlDbType.Integer, 100).Value = pedido.IdProducto;
                dataAdapter.SelectCommand.Parameters.Add("_id_subsede", NpgsqlDbType.Integer, 100).Value = pedido.IdSubsede;
                dataAdapter.SelectCommand.Parameters.Add("_session", NpgsqlDbType.Text, 100).Value = pedido.Session;

                conection.Open();
                dataAdapter.Fill(Idpedido);
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
            return Idpedido;
        }

        public DataTable InformacionPedidoTotalTipo(int idUsuario)
        {
            DataTable Idpedido = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_tipo_total", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer, 100).Value = idUsuario;

                conection.Open();
                dataAdapter.Fill(Idpedido);
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
            return Idpedido;
        }

        public DataTable ObtenerIdPedido(int idUsuario)
        {
            DataTable Idpedido = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_id_pedido", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer, 100).Value = idUsuario;

                conection.Open();
                dataAdapter.Fill(Idpedido);
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
            return Idpedido;
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
        public DataTable InformacionPedido(int idUsuario)
        {
            DataTable Idpedido = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.obtener_informacion_pedido", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer, 100).Value = idUsuario;

                conection.Open();
                dataAdapter.Fill(Idpedido);
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
            return Idpedido;
        }
        public DataTable obtenerPedidosSubsede(int idUsuario)
        {
            DataTable pedidos = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);

            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("usuario.pedidos_subsede", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.Add("_id_usuario", NpgsqlDbType.Integer, 100).Value = idUsuario;


                conection.Open();
                dataAdapter.Fill(pedidos);
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
            return pedidos;
        }

    }
}
