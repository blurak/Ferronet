using System;
using System.Collections.Generic;
using System.Linq;
using Utilitarios;
using Utilitarios.Join;
using Utilitarios.Tablas;

namespace Datos.Persistencia
{
    public class DAOCliente
    {
        private DAOAuditoria auditoria = new DAOAuditoria();
        public String obtenerUbicacion(int idSubsede)
        {
            String ubicacion = "";
            var db = new Mapeo();
            ubicacion = db.subsede.FirstOrDefault(x => x.Id == idSubsede).Ubicacion.ToString();
            return ubicacion;

        }

        public void registrarPedido(EPedido pedido)
        {
            using (var db = new Mapeo())
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarPedido(pedido);
        }

        public EProductoSubsede devolverProductoSubsede(int idSubsede, int idProducto)
        {
            using (var db = new Mapeo())
            {
                return db.productoSubsede.FirstOrDefault(x => x.Id_subsede == idSubsede & x.IdProducto == idProducto);
            }
        }

        public void modificarCantidadesPedido(EPedido detallePedido)
        {
            EProductoSubsede subsedeproductos = new EProductoSubsede();
            subsedeproductos = devolverProductoSubsede(detallePedido.IdSubsede, detallePedido.IdProducto);
            int cantidadTotal = devolverCantidadTotal(detallePedido.IdSubsede, detallePedido.IdProducto, detallePedido.Cantidad);
            using (var context = new Mapeo())
            {
                var cliente = context.productoSubsede.Find(subsedeproductos.Id);
                cliente.Cantidad = cantidadTotal;
                context.SaveChanges();
            }
        }

        public void modificarValorTotalPedido(int IdPedido,int valor)
        {

            using (var context = new Mapeo())
            {
                var cliente = context.Pedido.Find(IdPedido);
                cliente.ValorTotal = valor;
                context.SaveChanges();
            }
        }


        public int devolverCantidadTotal(int idSub, int idProducto, int cantidadPedida)
        {
            int cantidadtot = 0;
            var db = new Mapeo();
            cantidadtot = db.productoSubsede.FirstOrDefault(x => x.Id_subsede == idSub & x.IdProducto == idProducto).Cantidad - cantidadPedida;
            return cantidadtot;
        }

        public void registrarDetallePedido(EDetallePedido detallePedido)
        {
            using (var db = new Mapeo())
            {
                db.DetallePedido.Add(detallePedido);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarDetallePedido(detallePedido);
        }

        public int obtenerIdPedido(int idUsuario)
        {
            int idPedido;
            var db = new Mapeo();
            idPedido = db.Pedido.FirstOrDefault(x => x.IdUsuario == idUsuario & x.Estado1.Contains("pendiente")).IdPedido;
            return idPedido;

        }
        public String VerificarExistenciaDePedido(int idUsuario)
        {
            String pedido = "";
            try
            {
                var db = new Mapeo();
                pedido = db.Pedido.FirstOrDefault(x => x.IdUsuario == idUsuario & x.Estado1.Contains("pendiente")).TipoEntrega.ToString();
            }
            catch (Exception)
            {
                pedido = null;
            }

            return pedido;

        }


        public String cantidadDisponible(int codigoProducto, int idSubsede)
        {
            int cantidad = 0;
            var db = new Mapeo();
            cantidad = db.productoSubsede.FirstOrDefault(x => x.Id_subsede == idSubsede & x.IdProducto == codigoProducto).Cantidad - db.productoSubsede.FirstOrDefault(x => x.Id_subsede == idSubsede & x.IdProducto == codigoProducto).CantidadMinima;
            return String.Concat(cantidad);

        }

        public List<JoinProductoSubsede> obtenerProductosSubsede(int idSubsede, String criterio)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.producto
                            join s in db.productoSubsede on a.IdProducto equals s.IdProducto
                            join su in db.subsede on s.Id_subsede equals su.Id
                            join c in db.categoria on a.Categoria equals c.Id
                            where a.Descripcion.Contains(criterio) & s.Id_subsede == idSubsede & !(s.Cantidad==s.CantidadMinima)
                            select new JoinProductoSubsede
                            {
                                Imagen = a.Imagen,
                                Codigo_producto1 = a.IdProducto,
                                Descripcion1 = a.Descripcion,
                                Categoria = c.Nombre,
                                Precio = a.Precio,
                                Subsede = su.Nombre
                            };
                return query.ToList();
            }
        }

        public List<JoinSubsedes> obtenerSubsedes() {

            using (var db = new Mapeo())
            {
                var query = from a in db.subsede

                            select new JoinSubsedes
                            {
                                Id = a.Id,
                                Subsede = a.Nombre

                            };

                return query.ToList();

            }


        }

        public int devolverIdPedido(int idUsuario)
        {
            int idPedido = 0;
            try
            {
                var db = new Mapeo();
                idPedido = int.Parse(db.Pedido.FirstOrDefault(x => x.IdUsuario == idUsuario & x.Estado1.Contains("pendiente")).IdPedido.ToString());
            }
            catch (Exception)
            {
                idPedido = 0;
            }

            return idPedido;

        }

        public List<JoinDetallePedidoCliente> obtenerInformacioPedido(int idUsuario)
        {
            int idPedido = devolverIdPedido(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.DetallePedido
                            join s in db.producto on a.IdProducto equals s.IdProducto
                            where a.IdPedido == idPedido
                            select new JoinDetallePedidoCliente
                            {
                                CodigoDelProducto = s.IdProducto,
                                Descripcion = s.Descripcion,
                                Cantidad = a.Cantidad,
                                Precio = a.ValorUnitario,
                                ValorTotal = a.ValorTotal
                            };

                return query.ToList();

            }
        }


        public List<JoinPedidoCliente> obtenerTotalPedidoYTipoDeEntrega(int idUsuario)
        {
            int idPedido = devolverIdPedido(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.Pedido

                            where a.IdUsuario == idUsuario & a.Estado1.Contains("pendiente")
                            select new JoinPedidoCliente
                            {
                                Total = a.ValorTotal,
                                TipoDeEntrega = a.TipoEntrega
                            };

                return query.ToList();

            }
        }

    }
}
