using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Utilitarios;
using System.Data;
using Utilitarios.Join;
using Datos.Persistencia;
using Utilitarios.Tablas;

namespace Logica
{
    public class LCliente
    {
        private EProductoSubsede antiguo = new EProductoSubsede();
        private EProductoSubsede nuevo = new EProductoSubsede();
        private LAuditoria auditoria = new LAuditoria();
        private DAOAuditoria audi = new DAOAuditoria();
        private DAOCliente cli = new DAOCliente();
        private DAOSede sede = new DAOSede();
    
        public EPedido validarPedidoYDespachar(EPedido entrada,String lenguaje)
        {
            EDetallePedido detalle = new EDetallePedido();
            DAOCliente daots = new DAOCliente();
            int totalPedido = 0;
            var items =entrada.Pedido;
            if (items.Rows.Count == 0)
            {
                entrada.Mensaje = @"<script type='text/javascript'>alert('"+entrada.MensajeSinProductosEnELCarrito+" ');window.location.href='HacerPedidoCliente.aspx';</script>";

            }
            else
            {
                Boolean pedidoin = true;
                DataTable carrito = new DataTable();
                DataRow fila;
                DataTable dtb = new DataTable();

                dtb.Columns.Add("codigo");
                dtb.Columns.Add("descripcion");
                dtb.Columns.Add("precio");
                dtb.Columns.Add("cantidad");
                dtb.Columns.Add("disponibilidad");
                dtb.Columns.Add("total");
                carrito = dtb;
                foreach (DataRow dr in items.Rows)
                {
                    EProductoSubsede subpro = new EProductoSubsede();
                    String d = dr["codigo"].ToString();
                    String g = dr["disponibilidad"].ToString();
                    String descripcion = dr["descripcion"].ToString();
                    int precio = int.Parse(dr["precio"].ToString());
                    int cantidad = int.Parse(dr["cantidad"].ToString());
                    if (dr["disponibilidad"].ToString().Equals("X"))
                    {
                        pedidoin = false;
                        g = "X";
                        cantidad = 1;
                    }
                    else
                    {
                        subpro = sede.DevolverProductoSubsede(entrada.IdSubsede, int.Parse(d));

                        if ((subpro.Cantidad - subpro.CantidadMinima) < cantidad)
                        {
                            g = "X";
                            cantidad = 1;
                            subpro = null;
                            pedidoin = false;
                        }
                        else
                        {
                            g = "✓";
                        }
                    }
                    
                    subpro = null;
                   
                    fila = carrito.NewRow();
                    fila[0] = d;
                    fila[1] = descripcion;
                    fila[2] = precio;
                    fila[3] = cantidad;
                    fila[4] = g;
                    fila[5] = cantidad*precio;
                    carrito.Rows.Add(fila);
                }

                if (pedidoin == false)
                {
                    entrada.Mensaje = @"<script type='text/javascript'>alert('"+entrada.MensajeProductosNoDisponibles+"');</script>";
                    entrada.Pedido = carrito;
                   
                }
                else
                {
                    entrada.Pedido = null;       
                    String estado= daots.VerificarExistenciaDePedido(entrada.IdUsuario);
                    DPedido pe = new DPedido();
                    
                    //DataTable y = pe.RegistrarPedido(entrada);

                    if (estado != null)
                    {
                        entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajePedidoActivo + "');</script>";
                    }
                    else
                    {
                        entrada.Estado1 = "pendiente";
                        entrada.Last =Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                        entrada.Hora= Convert.ToDateTime( DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
                        daots.registrarPedido(entrada);
                        entrada.IdPedido = daots.obtenerIdPedido(entrada.IdUsuario);
                        
                        foreach (DataRow pr in items.Rows)
                        {
                           
                            int codigoProducto = int.Parse(pr["codigo"].ToString());
                            String descripcion = pr["descripcion"].ToString();
                            int precio = int.Parse(pr["precio"].ToString());
                            int cantidad = int.Parse(pr["cantidad"].ToString());

                            int total = int.Parse(pr["total"].ToString());
                            totalPedido += total;
                            entrada.Cantidad = cantidad;
                            entrada.Precio = precio;
                            entrada.ValorTotalProducto = total;
                            entrada.IdProducto = codigoProducto;

                            detalle.IdPedido = entrada.IdPedido;
                            detalle.Cantidad = cantidad;
                            detalle.ValorUnitario = precio;
                            detalle.ValorTotal = total;
                            detalle.IdProducto = codigoProducto;
                            detalle.Session = entrada.Session;
                            detalle.Last = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

                            daots.registrarDetallePedido(detalle);

                            //pe.RegistrarDetallePedido(entrada);

                            antiguo = cli.devolverProductoSubsede(entrada.IdSubsede, entrada.IdProducto);
                            daots.modificarCantidadesPedido(entrada);
                            nuevo = sede.devolverProductoSubsede(antiguo.Id);
                            audi.AuditoriaModificar(auditoria.AuditoriaModificarProductoSubsede(antiguo, nuevo));
                        }

                        daots.modificarValorTotalPedido(entrada.IdPedido,totalPedido);
                        entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajePedidoHecho + "');window.location.href = 'ConsultarPedidoCliente.aspx';</script>";
                        entrada.Pedido = null;
                    }

                    //if (y.Rows[0]["registrar_pedidos"].ToString().Equals("no"))
                    //{
                        

                        
                    //}
                    //else
                    //{
                    //    if (y.Rows[0]["registrar_pedidos"].ToString().Equals("si"))
                    //    {
                           
                    //        //DataTable z = pe.ObtenerIdPedido(entrada.IdUsuario);

                    //        //entrada.IdPedido = int.Parse(z.Rows[0]["obtener_id_pedido"].ToString());

                    //        foreach (DataRow pr in items.Rows)
                    //        {
                    //            int codigoProducto = int.Parse(pr["codigo"].ToString());
                    //            String descripcion = pr["descripcion"].ToString();
                    //            int precio = int.Parse(pr["precio"].ToString());
                    //            int cantidad = int.Parse(pr["cantidad"].ToString());
                    //            int total = int.Parse(pr["total"].ToString());

                    //            entrada.Cantidad = cantidad;
                    //            entrada.Precio = precio;
                    //            entrada.ValorTotalProducto = total;
                    //            entrada.IdProducto = codigoProducto;


                    //            pe.RegistrarDetallePedido(entrada);
                    //            pe.RestarCantidadesPedido(entrada);



                    //        }

                    //        entrada.Mensaje = @"<script type='text/javascript'>alert('"+entrada.MensajePedidoHecho+"');window.location.href = 'ConsultarPedidoCliente.aspx';</script>";
                    //        entrada.Pedido = null;
                    //    }

                    //}
                }

             }

                return entrada;
        }


        public Boolean validarDrop(String cadena)
        {
            Boolean valida = false;
            if (cadena.Equals("Seleccione")| cadena.Equals("Select"))
            {
                valida = false;
            }

            if (cadena.Equals("Domicilio") | cadena.Equals("Home"))
            {
                valida = true;

            }
            return valida;
        }


        public  EPedido  validarCantidades(String comando,EPedido entrada)
        {
            var items = entrada.Pedido;
            int codigo; int cantidad; int subsede;
            DPedido datos = new DPedido();
            DataTable temporal = new DataTable();

            foreach (DataRow dr in items.Rows)
            {
                for (int rr = 0; rr < 1; rr++)
                {

                    codigo = int.Parse((String)dr[rr].ToString());
                    String descripcion = (String)dr[rr + 1].ToString();
                    int precio = int.Parse((String)dr[rr + 2].ToString());
                    cantidad = int.Parse((String)dr[rr + 3].ToString());
                    int totalp = int.Parse((String)dr[rr + 5].ToString());
                    subsede = entrada.IdSubsede;
                    

                    if (codigo == entrada.Codigo)
                    {
                        DAOCliente daots = new DAOCliente();
                        String cantidadDisponible =daots.cantidadDisponible(entrada.Codigo, entrada.IdSubsede);


                        int tot = entrada.Cantidad * precio;
                        if (entrada.Cantidad > int.Parse(cantidadDisponible))
                        {
                            if (temporal.Columns.Count == 0)
                            {
                                temporal.Columns.Add("codigo");
                                temporal.Columns.Add("descripcion");
                                temporal.Columns.Add("precio");
                                temporal.Columns.Add("cantidad");
                                temporal.Columns.Add("disponibilidad");
                                temporal.Columns.Add("total");

                            }

                            tot = precio;
                            cantidad = 1;

                            DataRow fila;
                            fila = temporal.NewRow();
                            fila[0] = codigo;
                            fila[1] = descripcion;
                            fila[2] = precio;
                            fila[3] = cantidad;
                            fila[4] = "X";
                            fila[5] = tot;
                            temporal.Rows.Add(fila);
                        }
                        else
                        {
                            if (entrada.Cantidad == int.Parse(cantidadDisponible) | int.Parse(cantidadDisponible) > entrada.Cantidad)
                            {
                                if (temporal.Columns.Count == 0)
                                {
                                    temporal.Columns.Add("codigo");
                                    temporal.Columns.Add("descripcion");
                                    temporal.Columns.Add("precio");
                                    temporal.Columns.Add("cantidad");
                                    temporal.Columns.Add("disponibilidad");
                                    temporal.Columns.Add("total");

                                }
                                tot = precio * entrada.Cantidad;
                                DataRow fila;
                                fila = temporal.NewRow();
                                fila[0] = codigo;
                                fila[1] = descripcion;
                                fila[2] = precio;
                                fila[3] = entrada.Cantidad;
                                fila[4] = "✓";
                                fila[5] = tot;
                                temporal.Rows.Add(fila);
                                entrada.Total += tot;
                            }

                        }
                    }
                    else
                    {
                        if (temporal.Columns.Count == 0)
                        {
                            temporal.Columns.Add("codigo");
                            temporal.Columns.Add("descripcion");
                            temporal.Columns.Add("precio");
                            temporal.Columns.Add("cantidad");
                            temporal.Columns.Add("disponibilidad");
                            temporal.Columns.Add("total");

                        }
                        
                        DataRow fila;
                        fila = temporal.NewRow();
                        fila[0] = codigo;
                        fila[1] = descripcion;
                        fila[2] = precio;
                        fila[3] = cantidad;
                        fila[4] = "✓";
                        fila[5] = totalp;
                        temporal.Rows.Add(fila);
                        entrada.Total += totalp;
                    }

                }
            }

            entrada.Pedido = temporal;
            return entrada;

        }

        public DataTable InformacionPedido(int idUsuario)
        {
            DPedido datos = new DPedido();

            DataTable y;
            y = datos.InformacionPedido(idUsuario);
            return y;

        }

        public DataTable InformacionPedidoTotal(int idUsuario)
        {
            DPedido datos = new DPedido();

            DataTable y;
            y = datos.InformacionPedidoTotalTipo(idUsuario);
            return y;

        }

        public DataTable ObtenerIdPedidoCliente(int idUsuario)
        {
            DPedido datos = new DPedido();
            DataTable y;
            y = datos.ObtenerIdPedido(idUsuario);
            return y;

        }

        public EPedido devolverIdPedido(int idusuario)
        {
            EPedido entrada = new EPedido();
            try
            {
                DAOCliente datos = new DAOCliente();
               entrada.Cantidad= datos.obtenerIdPedido(idusuario);
            }
            catch (Exception)
            {
                entrada.Mensaje = @"<script type='text/javascript'>alert('no hay pedidos que mostrar'); window.location.href = 'HacerPedidoCliente.aspx';</script>";

            }

            return entrada;
        }
        //public EPedido pintarIdPedido(int idUsuario)
        //{
        //    //EPedido entrada = new EPedido();
        //    //DataTable z = ObtenerIdPedidoCliente(idUsuario);
        //    //if (z.Rows[0]["obtener_id_pedido"].ToString().Equals(""))
        //    //{
        //    //    entrada.Mensaje = @"<script type='text/javascript'>alert('no hay pedidos que mostrar'); window.location.href = 'HacerPedidoCliente.aspx';</script>";
        //    //}
        //    //else
        //    //{
        //    //    entrada.Cantidad = int.Parse(z.Rows[0]["obtener_id_pedido"].ToString());
        //    //}
        //    //return entrada;
        //}


        public DataTable obtenerSubs()
        {
            DCliente datos = new DCliente();
            DataTable y = datos.obtenerSubsedes();
            return y;
        }

        public DataTable ObtenerProductosSubPedido(int idSubsede, String criterio)
        {
            DCliente datos = new DCliente();
            DataTable y = datos.ObtenerProductosSubsedePedido(idSubsede,criterio);
            return y;
        }

        public EPedido agregarProducto(EPedido entrada,int idSubsedeDrop,object sesionIdSubsede)
        {
            if (sesionIdSubsede==null)
            {
                entrada.IdSubsede = idSubsedeDrop;
                var items = entrada.Pedido;
                if (items.Rows.Count == 0)
                {
                    AgregarItem(entrada.Codigo, entrada.Descripcion, entrada.Precio,entrada.Pedido);
                    entrada.Mensaje = @"<script type='text/javascript'>alert('"+entrada.MensajeProductoAgregado+"" + entrada.Descripcion + "');</script>";
                }
                else
                {

                    Boolean flag = false;
                    foreach (DataRow dr in items.Rows)
                    {
                        if (int.Parse(dr["codigo"].ToString()) == entrada.Codigo)
                        {
                            entrada.Mensaje = @"<script type='text/javascript'>alert('"+entrada.MensajeProductoYaAgregado+"" + entrada.Descripcion + "')</script>";
                            flag = true;
                            break;
                           
                        }
                    }
                    if (flag != true)
                    {
                        AgregarItem(entrada.Codigo, entrada.Descripcion, entrada.Precio,entrada.Pedido);
                        entrada.Mensaje = @"<script type='text/javascript'>alert('"+entrada.MensajeProductoAgregado+"" + entrada.Descripcion + "');</script>";


                    }
                }
            }
            else
            {

                if (entrada.IdSubsede != int.Parse(sesionIdSubsede.ToString()))
                {
                    entrada.IdSubsede = int.Parse(sesionIdSubsede.ToString());
                    entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeProductosDeDiferentesSedes + "');</script>";
                }
                else
                {
                    var items = entrada.Pedido;
                    if (items.Rows.Count == 0)
                    {
                        entrada.Pedido = AgregarItem(entrada.Codigo, entrada.Descripcion, entrada.Precio, entrada.Pedido);
                        entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeProductoAgregado +  ""+ entrada.Descripcion + "');</script>";


                    }
                    else
                    {

                        Boolean flag = false;
                        foreach (DataRow dr in items.Rows)
                        {
                            if (int.Parse(dr["codigo"].ToString()) == entrada.Codigo)
                            {
                                entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeProductoYaAgregado +""  + entrada.Descripcion + "')</script>";
                                flag = true;
                                break;
                            }
                        }
                        if (flag != true)
                        {
                            entrada.Pedido = AgregarItem(entrada.Codigo, entrada.Descripcion, entrada.Precio, entrada.Pedido);

                            entrada.Mensaje = @"<script type='text/javascript'>alert('" + entrada.MensajeProductoAgregado + "" + entrada.Descripcion + "');</script>";

                        }
                    }
                }
            }
            return entrada;
        }

        public void  verificarCantidades(Object grid)
        {
            
        }

        public DataTable AgregarItem(int cod, string des, double precio,DataTable pedido)
        {
            DataRow fila;
            DataTable carrito = new DataTable();
            double total;
            int cantidad = 1;
            String dis = "✓";
            total = precio * cantidad;
            carrito =pedido;
            fila = carrito.NewRow();
            fila[0] = cod;
            fila[1] = des;
            fila[2] = precio;
            fila[3] = cantidad;
            fila[4] = dis;
            fila[5] = total;
            carrito.Rows.Add(fila);

            pedido = carrito;
            return pedido;
        }
        public DataTable validarPost(Boolean page,DataTable tt) {
            DataTable y = new DataTable();
            if (page == false)
            {
                y = tt;
            }
            else
            {
                y = tt;
            }

            return y;
        }
        public EPedido cargaIncio(EPedido entrada,Int32 sub,DataTable ped)
        {
            if(sub.Equals(null)| ped.Rows.Count==0)
            {
                entrada.Mensaje =@"<script type='text/javascript'>alert('Aun no hay productos en el carrito');windows.href.location='HacerPedidoCliente.aspx'</script>";
            }
            else
            {
                var items = entrada.Pedido;
                if (items.Rows.Count == 0)
                {
                    entrada.Sesionsub= null;
                    entrada.Mensaje =@"<script type='text/javascript'>windows.href.location='HacerPedidoCliente.aspx'</script>";
                }

                DAOCliente daots = new DAOCliente();
                entrada.TipoEntrega= daots.obtenerUbicacion(entrada.IdSubsede);

                int totalp=0,cantidad,totalm=0;
                foreach (DataRow dr in items.Rows)
                {
                    for (int rr = 0; rr < 1; rr++)
                    {
                         
                         totalp = int.Parse((String)dr[rr + 5].ToString());
                         cantidad = int.Parse((String)dr[rr + 3].ToString());
                        totalm = totalp * cantidad;
                    }
                    entrada.ValorTotal += totalm;
                }

            }
            return entrada;
        }
        public EPedido validarHacerPedido(EPedido entrada)
        {
            DataTable dtb;
            if (entrada.Pedido==null)
            {
                entrada.Sesionsub=null;
                dtb = new DataTable();

                dtb.Columns.Add("codigo");
                dtb.Columns.Add("descripcion");
                dtb.Columns.Add("precio");
                dtb.Columns.Add("cantidad");
                dtb.Columns.Add("disponibilidad");
                dtb.Columns.Add("total");

               entrada.Pedido = dtb;
            }
            else
            {
                var items = entrada.Pedido;
                if (items.Rows.Count == 0)
                {
                    entrada.Sesionsub = null;
                }
                else
                {
                    dtb = new DataTable();
                    dtb.Columns.Add("codigo");
                    entrada.Sesionsub = dtb;
                }
            }


            return entrada;
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
                if (rol.Equals("1"))
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

        public List<JoinProductoSubsede> obtenerProductosCatalogo(int idSubsede,String criterio)
        {
            DAOCliente usuario = new DAOCliente();
            return usuario.obtenerProductosSubsede(idSubsede,criterio);
        }

        public List<JoinSubsedes> obtenerSubsedesDrop()
        {
            DAOCliente usuario = new DAOCliente();
            return usuario.obtenerSubsedes();
        }

        public List<JoinDetallePedidoCliente> obtenerInformacionPedido(int idUsuario)
        {
            DAOCliente datos = new DAOCliente();
            return datos.obtenerInformacioPedido(idUsuario);
           
        }

        public List<JoinPedidoCliente> obtenerTotalYTipoDeEntrega(int idUsuario)
        {
            DAOCliente datos = new DAOCliente();
           return datos.obtenerTotalPedidoYTipoDeEntrega(idUsuario);
        }
    }
}
