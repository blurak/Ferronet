using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Persistencia;
using Utilitarios;
using Utilitarios.Join;
using Utilitarios.Tablas;

namespace Logica
{
    public class LSubsede
    {
        DSubsede datos = new DSubsede();
        DPedido datosP = new DPedido();
       private EPedido antiguo = new EPedido();
        private EPedido nuevo = new EPedido();
        private LAuditoria auditoria = new LAuditoria();
        private DAOAuditoria audi = new DAOAuditoria();

        public DataTable ObtenerCajeroSub(int administrador)
        {
            DataTable y = datos.ObtenerCajeroSubsede(administrador);
                return y;
        }
        public DataTable obtenerPedidosSubsedeAdministrador(int idUsuario)
        {
            DataTable y = datosP.obtenerPedidosSubsede(idUsuario);
                return y;
        }
        public DataTable obtenerDetallesPedido(int idPedido)
        {
            DataTable y = datosP.obtenerDetallePedidosSubsede(idPedido);
            return y;
        }
        public DataTable ObtenerTotalVentasHoySubsede(int idSubsede, String fecha)
        {
            DataTable y = datos.ObtenerTotalVentasHoy(idSubsede, fecha);
          return y;
        }

        public DataTable totalVendidoSubsede(int id_subsede, String fechainicio, String fechafin)
        {
            DataTable y = datos.totalVendido(id_subsede,fechainicio,fechafin);
            return y;
        }
        public List<JoinDetalleDeVenta> ObtenerDetalleVenta(int idVenta)
        {
            DAOSubsede subsede = new DAOSubsede();
            return subsede.obtenerDetalleVentaAdministrador(idVenta);
            //DataTable y = datos.detalleVenta(idVenta);
            //return y;
        }

        public DataTable ObtenerVentasDiaSuperadministrador(int id_subsede, string fechainicio, string fechafin)
        {
            DSubsede datos = new DSubsede();
            DataTable y = datos.ObtenerVentasDiaSuper(id_subsede, fechainicio, fechafin);
            return y;
        }
       
        public DataTable ObtenerProductosSubsede(int administrador)
        {
            DSubsede datos = new DSubsede();
            DataTable y = datos.ObtenerProductosSubsede(administrador);
            return y;
        }

        public DataTable obtenerInventarioSede(int id_usuario)
        {
            DProducto datos = new DProducto();
            DataTable y = datos.obtenerInventarioActual(id_usuario);
            return y;
        }

        public String DevolverIdSubsedeAdministrador(String idAdministrador)
        {
            DAOSubsede datos = new DAOSubsede();
            ESubsede sub=datos.obtenerIdSubsede(int.Parse(idAdministrador));
            //DSubsede entrada = new DSubsede();
            //DataTable y=entrada.obtenerIdsedeAdministrador(int.Parse(idAdministrador));
            idAdministrador = String.Concat(sub.Id);
            return idAdministrador;
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
                if (rol.Equals("3"))
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

        public List<EEstadoPedido> ObtenerEstadoPedido(int idUsuario)
        {
            DAOSubsede a = new DAOSubsede();
            return a.ObtenerEstado(idUsuario);

        }

        public EPedido obtenerpedidoCajeo(EPedido usuario)
        {
            DAOSubsede datos = new DAOSubsede();
            EPedido solicion = new EPedido();
            solicion = datos.obtenerPedidocajero(usuario);
            return solicion;
        }

        public void ActualizarEstadoPedido(EPedido usuario)
        {

            DAOSubsede datos = new DAOSubsede();
            antiguo = datos.devolverPedido(usuario.IdPedido);
            datos.ActualizarEstadosPedido(usuario);
            nuevo = datos.devolverPedido(antiguo.IdPedido);
            audi.AuditoriaModificar(auditoria.AuditoriaModificarPedido(antiguo, nuevo));
        }

        public List<JoinProductoSubsede> ObtenerinventarioCajero(int idUsuario)
        {
            DAOSubsede a = new DAOSubsede();
            return a.ObtenerInventariSubsedeCajero(idUsuario);

        }
        public List<JoinProductosSubsede> ObtenerProductosSubsedeAdmin(int administrador)
        {
            DAOSubsede datos = new DAOSubsede();

            return datos.ObtenerProductosSubsede(administrador);
        }
        public List<EVenta> ObtenerVentasSubsedeAdmin(int administrador, string fecha)
        {
            DAOSubsede datos = new DAOSubsede();

            return datos.ObtenerVentaasDiaAdmin(administrador, fecha);
        }
        public List<EEstadoPedido> ObtenerPedidosAdmin(int administrador)
        {
            DAOSubsede datos = new DAOSubsede();

            return datos.ObtenerPedidosSubsedeAdmin(administrador);
        }

        public List<JoinProductosSubsede> ObtenerDetallePedidoAdmin(int id_venta)
        {
            DAOSubsede datos = new DAOSubsede();

            return datos.ObtenerDetallePedido(id_venta);
        }
        public List<EEstadoPedido> ObtenerCajeroAsignadoAdmin(int id_usuario)
        {
            DAOSubsede datos = new DAOSubsede();

            return datos.ObtenerCajeroAsignadoAdmin(id_usuario);
        }
        public int ObtenerTotalVendidoHoyAdmin(int id_usuario, String fechaHoy)
        {
            ESubsede b = new ESubsede();
            int idSubsede;
            DAOSubsede a = new DAOSubsede();
            b=a.obtenerIdSubsede(id_usuario);
            idSubsede = b.Id;
            int venta = 0;
            if (idSubsede == 0)
            {

            }
            else
            {
                DAOSede sede = new DAOSede();
                venta = sede.ObtenerTotalVendidoHoy(idSubsede, fechaHoy);
            }
            return venta;
        }
        public EProductoSede insertarproductosSubsede(EProductoSede entrada, int id_subsede, int cantidad, int cantidamin)
        {


            int cantidad_existente_sede;
            int cantidad_minima_sede;
            int producto_registrado;
            int id_producto;

            DAOSede a = new DAOSede();
            DAOSede b = new DAOSede();
            List<JoinProductosSubsede> c = new List<JoinProductosSubsede>();
            EProductoSubsede d = new EProductoSubsede();
            id_producto = entrada.Id_producto;
            EProductoSede o = new EProductoSede();
            o.MensajeAsignadoCorrectamente = entrada.MensajeAsignadoCorrectamente;
            o.MensajeProductoYaAsignado = entrada.MensajeProductoYaAsignado;
            o.MensajeCantidadInsuficiente = entrada.MensajeCantidadInsuficiente;            
            entrada = a.obtenerProductoSedeiva(entrada);
                c = b.obtenerProductosubsdedeCantidad(id_producto,id_subsede);
                var count = c.Count();
                producto_registrado = count;
                cantidad_existente_sede = entrada.Cantidad;
                cantidad_minima_sede = entrada.CantidadMinima;
                d.Cantidad = cantidad;
                d.IdProducto = id_producto;
                d.CantidadMinima = cantidamin;
                d.Id_subsede = id_subsede;
                d.Last = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            d.Session = entrada.Session;
            if (cantidad <= (cantidad_existente_sede - cantidad_minima_sede)){
                if (producto_registrado == 0)
                {
                    DAOSede x = new DAOSede();
                    DAOSede x2 = new DAOSede();
                    d.Activo = true;
                    x.registrarProductoSubsede(d);
                    x2.ModificarProductosedeiva(entrada, cantidad);
                    entrada.Mensaje = @"<script type='text/javascript'>alert('" + o.MensajeAsignadoCorrectamente + "');</script>";
                }
                else
                {
                   entrada.Mensaje = entrada.Mensaje = @"<script type='text/javascript'>alert('" + o.MensajeProductoYaAsignado + "');</script>";

                }


            }
            else
            {
                entrada.Mensaje = entrada.Mensaje = @"<script type='text/javascript'>alert('" + o.MensajeCantidadInsuficiente + "');</script>";
            }

            return entrada;

        }

    }
}
