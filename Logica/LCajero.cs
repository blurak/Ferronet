using System;
using Utilitarios;
using Datos;
using System.Data;
using Datos.Dataset;
using Utilitarios.Join;
using Datos.Persistencia;
using System.Collections.Generic;
using Utilitarios.Tablas;

namespace Logica
{
    public class LCajero
    {
        private EProductoSubsede antiguo = new EProductoSubsede();
        private EProductoSubsede nuevo = new EProductoSubsede();
        private LAuditoria auditoria = new LAuditoria();
        private DAOAuditoria audi = new DAOAuditoria();

        public void CambiarEstado(int id_producto, int usuario)
        {
            DPedido Datos = new DPedido();
            Datos.modificarEstadoPedido(usuario, id_producto);


        }

        public EVenta registrarVenta(EVenta encapsulado,String mensajeVentaHecha)
        { 
            var items = encapsulado.VentaSesion;
            int codigo; int cantidad;
            int acumulado = 0;
            Eventas venta = new Eventas();
            venta.IdUsusario = encapsulado.IdCajero;//
            venta.Dia = encapsulado.Dia;//
            venta.Hora = encapsulado.Hora;//
            venta.Session = encapsulado.Session;//
            venta.Diacompa = encapsulado.Diacompa;//
            venta.Last= Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));//
            DProducto o = new DProducto();
            DAOSede sede = new DAOSede();
            DAOProducto producto = new DAOProducto();
            EDetalleVenta detalleVenta = new EDetalleVenta();
            producto.insertarVenta(venta);
            //DataTable p = o.RegistrarVenta(0, encapsulado.IdCajero, encapsulado.Dia, encapsulado.Hora);
            venta=producto.obtenerIdVenta(encapsulado.Dia, encapsulado.Hora);

            //DataTable pm = o.obteneridventa(encapsulado.Dia, encapsulado.Hora);
            encapsulado.IdVenta = venta.Id;
            
            DataTable temporal = new DataTable();
            if (items != null)
            {
                foreach (DataRow dr in items.Rows)
                {
                    for (int rr = 0; rr < 1; rr++)
                    {
                        codigo = int.Parse((String)dr[rr].ToString());
                        String descripcion = (String)dr[rr + 1].ToString();
                        cantidad = int.Parse((String)dr[rr + 2].ToString());
                        int precio = int.Parse((String)dr[rr + 3].ToString());
                        int totalp = int.Parse((String)dr[rr + 4].ToString());
                        acumulado += precio * cantidad;

                        detalleVenta.Cantidad = cantidad;
                        detalleVenta.IdProducto = codigo;
                        detalleVenta.IdVenta = encapsulado.IdVenta;
                        detalleVenta.ValorTotal = precio * cantidad;
                        detalleVenta.ValorUnitario = precio;
                        detalleVenta.Last = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                        detalleVenta.Session = encapsulado.Session;

                        producto.insertarDetalleVenta(detalleVenta);

                        antiguo = sede.devolverProductoSubsede(producto.devolverSubsede(codigo).Id);
                        producto.modificarCantidadDeSub(codigo, cantidad);
                        nuevo = sede.devolverProductoSubsede(antiguo.Id);
                        audi.AuditoriaModificar(auditoria.AuditoriaModificarProductoSubsede(antiguo, nuevo));
                        // DProducto u = new DProducto();
                        //DataTable F = u.RegistrarVentas(cantidad, codigo, encapsulado.IdVenta, encapsulado.IdCajero);
                    }
                }

                 DProducto ome = new DProducto();
                // DataTable pme = ome.obteneridventa(encapsulado.Dia, encapsulado.Hora);
                venta = producto.obtenerIdVenta(encapsulado.Dia, encapsulado.Hora);
                //encapsulado.IdVenta =venta.
                venta.ValorTotal = acumulado;
                producto.modificarValorTotalVenta(venta);
                //DataTable pmee = ome.momodificarValorTotalVenta(encapsulado.IdVenta);
                encapsulado.Mensaje = @"<script type='text/javascript'>alert('"+mensajeVentaHecha+ + acumulado +"');</script>";
            }
            
            return encapsulado;
        }

        public EVenta validarCantidades(string comando, EVenta encapsulado)
        {
            var items = encapsulado.VentaSesion;
            Boolean registrado=false;
            int codigo; int cantidad;
            DPedido datos = new DPedido();
            DataTable temporal = new DataTable();
            if (items == null && (encapsulado.Cantidad < encapsulado.CantidadDisponible | encapsulado.Cantidad == encapsulado.CantidadDisponible))
            {
                if (temporal.Columns.Count == 0) {
                    temporal.Columns.Add("codigo");
                    temporal.Columns.Add("descripcion");
                    temporal.Columns.Add("cantidad");
                    temporal.Columns.Add("precio");
                    temporal.Columns.Add("total");
                }

                DataRow fila;
                fila = temporal.NewRow();
                fila[0] = encapsulado.IdProducto;
                fila[1] = encapsulado.Descripcion;
                fila[2] = encapsulado.Cantidad;
                fila[3] = encapsulado.Precio;
                fila[4] = encapsulado.Precio * encapsulado.Cantidad;
                temporal.Rows.Add(fila);

                encapsulado.VentaSesion = temporal;
            }
            else
            {

                if (items.Columns.Count == 0)
                {
                    temporal.Columns.Add("codigo");
                    temporal.Columns.Add("descripcion");
                    temporal.Columns.Add("cantidad");
                    temporal.Columns.Add("precio");
                    temporal.Columns.Add("total");
                }
                if (encapsulado.Cantidad < encapsulado.CantidadDisponible | encapsulado.Cantidad == encapsulado.CantidadDisponible)
                {
                    foreach (DataRow dr in items.Rows)
                    {
                        for (int rr = 0; rr < 1; rr++)
                        {
                            codigo = int.Parse((String)dr[rr].ToString());
                            String descripcion = (String)dr[rr + 1].ToString();
                            cantidad = int.Parse((String)dr[rr + 2].ToString());
                            int precio = int.Parse((String)dr[rr + 3].ToString());
                            int totalp = int.Parse((String)dr[rr + 4].ToString());

                            if (temporal.Columns.Count == 0)
                            {
                                temporal.Columns.Add("codigo");
                                temporal.Columns.Add("descripcion");
                                temporal.Columns.Add("cantidad");
                                temporal.Columns.Add("precio");
                                temporal.Columns.Add("total");
                            }
                            DataRow fila;
                            if (codigo == encapsulado.IdProducto)
                            {
                                registrado = true;
                            }
                            fila = temporal.NewRow();
                            fila[0] = codigo;
                            fila[1] = descripcion;
                            fila[2] = cantidad;
                            fila[3] = precio;
                            fila[4] = totalp;
                            temporal.Rows.Add(fila);


                        }
                    }
                    if (registrado == true)
                    {

                    }
                    else
                    {
                        DataRow fila;
                        fila = temporal.NewRow();
                        fila[0] = encapsulado.IdProducto;
                        fila[1] = encapsulado.Descripcion;
                        fila[2] = encapsulado.Cantidad;
                        fila[3] = encapsulado.Precio;
                        fila[4] = encapsulado.Precio * encapsulado.Cantidad;
                        temporal.Rows.Add(fila);
                    }

                   encapsulado.VentaSesion = temporal;
                }
            }
            return encapsulado;
        }


        public DataTable Obtenerpedidocajero(int usuario)
        {
            DProducto datos = new DProducto();
            DataTable y = datos.obtenerPedidoscajero(usuario);
            return y;
        }
        public DataTable ObtenerDetallesPedidosSubsede(int usuario)
        {
            DProducto datos = new DProducto();
            DataTable y = datos.obtenerDetallePedidosSubsede(usuario);
            return y;
        }
        public DataTable ObtenerProductosSubsede(int usuario)
        {
            DProducto datos = new DProducto();
            DataTable y = datos.obtenerProductos_Subsede(usuario);
            return y;
        }
         public List<JoinProductoSubsede> obtenerProductosSubsede(int idUsuario)
        {
            DAOSubsede subsede = new DAOSubsede();
            return subsede.ObtenerProductosSubsedeCajero(idUsuario);
        }


        public String ValidarSiTieneSubsedeAsignada(int usuario)
        {
            DSubsede datos = new DSubsede();
            DataTable usu = datos.SubsedeAsignada(usuario);
            String mensaje = "";
            if (usu.Rows[0]["verificar_subsede"].ToString().Equals("si"))
            {
                mensaje = @"<script type='text/javascript'>UsuarioRegistrado();</script>";
            }
            if (usu.Rows[0]["verificar_subsede"].ToString().Equals("no"))
            {
                mensaje = @"<script type='text/javascript'>alert('Usted aun no tiene subsede asignada');window.location.href='IniciarSesion.aspx';</script>";
            }
            return mensaje;
        }

        public String ValidarSesion(String sesion, String rol)
        {
            String script = "";
            if (sesion.Equals(null))
            {
                script = @"<script type='text/javascript'>SesionNula();</script>";
            }
            else
            {
                if (rol.Equals("4"))
                {
                    //correcto
                }
                else
                {
                    script = @"<script type='text/javascript'>RolIncorrecto();</script>";
                }
            }
            return script;
        }


        public List<JoinPedidoCliente> obtenerPedidosCajeroP(int idUsuario)
        {
            DAOSubsede sub = new DAOSubsede();
            return sub.obtenerPedidosCajeros(idUsuario);
        }

        public List<JoinDetallepedidoProducto> obtenerDetallePedidoProductoP(int idPedido)
        {
            DAOSubsede sub = new DAOSubsede();
            return sub.obtenerDetallePedido(idPedido);
        }
    }
}
