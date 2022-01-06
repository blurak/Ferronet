using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Utilitarios.Tablas;

namespace Datos.Persistencia
{
    public class DAOAuditoria
    {
        public void AuditoriaInsertarUsuario(PUsuario usuario)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = usuario.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "usuario";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = usuario.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + usuario.Id + ", " + "\"nombre_nuevo:\"" + usuario.Nombre + ", " + "\"usuario_nuevo:\"" + usuario.Usuario + ", " + "\"correo_nuevo:\"" + usuario.Correo + ", " + "\"clave_nuevo:\"" + usuario.Clave + ", " + "\"id_rol_nuevo:\"" + usuario.IdRol + ", " + "\"session_nuevo:\"" + usuario.Session + ", " + "\"last_modified_nuevo:\"" + usuario.Last + ", " + "\"estado_nuevo:\"" + usuario.Estado + ", " + "\"sesiones_activas_nuevo:\"" + usuario.SesionesActivas + ", " + "\"sessiones_maximas_nuevo:\"" + usuario.SesionesMaximas + ", " + "\"intentos_incorrectos_nuevo:\"" + usuario.IntentosIncorrectos + ", " + "\"baneo_nuevo:\"" + usuario.Baneo + ", " + "\"baneado_nuevo:\"" + usuario.Baneado + "}";
            auditoria.Pk = String.Concat(usuario.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarProducto(EProducto producto)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = producto.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "producto";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = producto.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + producto.IdProducto + ", " + "\"precio_nuevo:\"" + producto.Precio + ", " + "\"descripcion_nuevo:\"" + producto.Descripcion + ", " + "\"imagen_nuevo:\"" + producto.Descripcion + ", " + "\"id_categoria_nuevo:\"" + producto.Categoria + ", " + "\"session_nuevo:\"" + producto.Session + ", " + "\"last_modified_nuevo:\"" + producto.Last + "}";
            auditoria.Pk = String.Concat(producto.IdProducto);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }


        public void AuditoriaInsertarSubsede(ESubsede subsede)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = subsede.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "sub_sede";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = subsede.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + subsede.Id + ", " + "\"nombre_nuevo:\"" + subsede.Nombre + ", " + "\"ubicacion_nuevo:\"" + subsede.Ubicacion + ", " + "\"id_admin_nuevo:\"" + subsede.IdAdmin + ", " + "\"id_cajero_nuevo:\"" + subsede.IdCajero + ", " + "\"id_sede_nuevo:\"" + subsede.IdSede + ", " + "\"session_nuevo:\"" + subsede.Session + "\"last_modified_nuevo:\"" + subsede.Last +"}";
            auditoria.Pk = String.Concat(subsede.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarProductoSubsede(EProductoSubsede productoSubsede)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = productoSubsede.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "producto_subsede";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = productoSubsede.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + productoSubsede.Id + ", " + "\"cantidad_nuevo:\"" + productoSubsede.Cantidad + ", " + "\"cantidadmin_nuevo:\"" + productoSubsede.CantidadMinima + ", " + "\"id_producto_nuevo:\"" + productoSubsede.IdProducto + ", " + "\"session_nuevo:\"" + productoSubsede.Session + ", " + "\"last_modified_nuevo:\"" + productoSubsede.Last + ", " + "\"activo_nuevo:\"" + productoSubsede.Activo+ "}";
            auditoria.Pk = String.Concat(productoSubsede.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarProductoSede(EProductoSede productoSede)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = productoSede.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "producto_sede";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = productoSede.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + productoSede.Id + ", " + "\"cantidad_nuevo:\"" + productoSede.Cantidad + ", " + "\"cantidadmin_nuevo:\"" + productoSede.CantidadMinima + ", " + "\"id_producto_nuevo:\"" + productoSede.Id_producto + ", " + "\"id_sede_nuevo:\"" + productoSede.IdSede + ", " + "\"session_nuevo:\"" + productoSede.Session + ", " + "\"last_modified_nuevo:\"" + productoSede.Last +"\"activo_nuevo:\"" + productoSede.Activo + "}";
            auditoria.Pk = String.Concat(productoSede.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarProveedor(EProveedor proveedor)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = proveedor.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "proveedores";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = proveedor.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + proveedor.Id + ", " + "\"nombre_nuevo:\"" + proveedor.Nombre + ", " + "\"correo_nuevo:\"" + proveedor.Correo + ", " + "\"telefono_nuevo:\"" + proveedor.Telefono + ", " + "\"id_sede_nuevo:\"" + proveedor.IdSede + ", " + "\"session_nuevo:\"" + proveedor.Session + ", " + "\"last_modified_nuevo:\"" + proveedor.Last+ "\"id_categoria_nuevo:\"" + proveedor.IdCategoria + "}";
            auditoria.Pk = String.Concat(proveedor.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarVenta(Eventas venta)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = venta.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "ventas";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = venta.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + venta.Id + ", " + "\"id_subsede_nuevo:\"" + venta.IdSubsede + ", " + "\"session_nuevo:\"" + venta.Session + ", " + "\"last_modified_nuevo:\"" + venta.Last + ", " + "\"valor_total_nuevo:\"" + venta.ValorTotal + ", " + "\"id_usuario_nuevo:\"" + venta.IdUsusario + ", " + "\"hora_nuevo:\"" + venta.Hora + "\"dia_nuevo:\"" + venta.Dia  + "\"diacompa_nuevo:\"" + venta.Diacompa+"}";
            auditoria.Pk = String.Concat(venta.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarDetalleVenta(EDetalleVenta detalleVenta)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = detalleVenta.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "detalle_venta";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = detalleVenta.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + detalleVenta.Id + ", " + "\"valor_unitario_nuevo:\"" + detalleVenta.ValorUnitario + ", " + "\"id_producto_nuevo:\"" + detalleVenta.IdProducto + ", " + "\"id_venta_nuevo:\"" + detalleVenta.IdVenta + ", " + "\"cantidad_nuevo:\"" + detalleVenta.Cantidad + ", " + "\"valor_total_nuevo:\"" + detalleVenta.ValorTotal + ", " + "\"session_nuevo:\"" + detalleVenta.Session + "\"last_modified_nuevo:\"" + detalleVenta.Last + "}";
            auditoria.Pk = String.Concat(detalleVenta.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarPedido(EPedido pedido)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = pedido.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "pedido";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = pedido.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + pedido.IdPedido + ", " + "\"tipo_entrega_nuevo:\"" + pedido.TipoEntrega + ", " + "\"direccion_nuevo:\"" + pedido.Direccion + ", " + "\"valor_total_nuevo:\"" + pedido.ValorTotal + ", " + "\"id_subsede_nuevo:\"" + pedido.IdSubsede + ", " + "\"id_usuario_nuevo:\"" + pedido.IdUsuario + ", " + "\"session_nuevo:\"" + pedido.Session + "\"last_modified_nuevo:\"" + pedido.Last +"\"estado_modified_nuevo:\"" +pedido.Estado1 + "}";
            auditoria.Pk = String.Concat(pedido.IdPedido);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarDetallePedido(EDetallePedido detallePedido)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = detallePedido.Last;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "detalle_pedido";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = detallePedido.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + detallePedido.Id + ", " + "\"cantidad_nuevo:\"" + detallePedido.Cantidad + ", " + "\"valor_unitario_nuevo:\"" + detallePedido.ValorUnitario + ", " + "\"id_producto_nuevo:\"" + detallePedido.IdProducto + ", " + "\"id_pedido_nuevo:\"" + detallePedido.IdPedido + ", " + "\"session_nuevo:\"" + detallePedido.Session+ ", " + "\"last_modified_nuevo:\"" + detallePedido.Last + "\"valor_total_nuevo:\"" + detallePedido.ValorTotal + "}";
            auditoria.Pk = String.Concat(detallePedido.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarAutenticacion(EAutenticacion autenticacion)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = autenticacion.FechaInicio;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "security";
            auditoria.Tabla = "autenticacion";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = autenticacion.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + autenticacion.Id + ", " + "\"user_id_nuevo:\"" + autenticacion.IdUsuario + ", " + "\"ip_nuevo:\"" + autenticacion.Ip + ", " + "\"mac_nuevo:\"" +autenticacion.Mac + ", " + "\"fecha_inicio_nuevo:\"" + autenticacion.FechaInicio + ", " + "\"session_nuevo:\"" + autenticacion.Session + ", " + "\"fecha_fin_nuevo:\"" + autenticacion.FechaFin +"}";
            auditoria.Pk = String.Concat(autenticacion.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarIdioma(EIdioma idioma)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            auditoria.Accion = "INSERT";
            auditoria.Schema = "idioma";
            auditoria.Tabla = "idioma";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session =idioma.Session ;
            auditoria.Data = "{" + "\"id_nuevo:\"" + idioma.Id + ", " + "\"nombre_nuevo:\"" + idioma.Nombre + ", " + "\"terminacion_nuevo:\"" + idioma.Terminacion + "}";
            auditoria.Pk = String.Concat(idioma.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarTokenRecuperacionContrasena(EtokenRecuperacionUsuario recuperacion)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = recuperacion.FechaCreado;
            auditoria.Accion = "INSERT";
            auditoria.Schema = "usuario";
            auditoria.Tabla = "token_recuperacion_usuario";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session = " ";
            auditoria.Data = "{" + "\"id_nuevo:\"" + recuperacion.Id + ", " + "\"user_id_nuevo:\"" + recuperacion.UserId + ", " + "\"token_nuevo:\"" + recuperacion.Token + "\"fecha_creado_nuevo:\"" + recuperacion.FechaCreado + "\"fecha_vigente_nuevo:\"" + recuperacion.FechaVigencia + "}";
            auditoria.Pk = String.Concat(recuperacion.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaInsertarControles(EControles controles)
        {
            EAuditoria auditoria = new EAuditoria();
            auditoria.Fecha = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            auditoria.Accion = "INSERT";
            auditoria.Schema = "idioma";
            auditoria.Tabla = "controles";
            auditoria.UserBaseDatos = "ferronetlogin";
            auditoria.Session =controles.Session;
            auditoria.Data = "{" + "\"id_nuevo:\"" + controles.Id + ", " + "\"control_nuevo:\"" + controles.Control + ", " + "\"id_idioma_nuevo:\"" + controles.IdIdioma + "\"id_formulario_nuevo:\"" + controles.IdIdioma + "\"texto_nuevo:\"" + controles.Texto + "\"session_nuevo:\"" + controles.Session+ "}";
            auditoria.Pk = String.Concat(controles.Id);


            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        public void AuditoriaModificar(EAuditoria auditoria)
        {
            using (var db = new Mapeo())
            {
                db.auditoria.Add(auditoria);
                db.SaveChanges();
            }
        }

        
    }
}
