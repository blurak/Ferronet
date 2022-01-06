using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Utilitarios;
using Utilitarios.Join;

namespace Datos.Persistencia
{
    public class DAOSubsede
    {
        public ESubsede verificarSiTieneSubsede(int idUsuario)
        {
            using (var db = new Mapeo())
            {
                return db.subsede.FirstOrDefault(x => x.IdAdmin == idUsuario | x.IdCajero == idUsuario);

            }
        }

        public EPedido devolverPedido(int idPedido)
        {
            using (var db = new Mapeo())
            {
                return db.Pedido.FirstOrDefault(x =>x.IdPedido==idPedido);

            }
        }


        public List<EEstadoPedido> ObtenerEstado(int idUsuario)
        {
            ESubsede subsede = new ESubsede();
            subsede = obtenerIdSubsede(idUsuario);

            using (var db = new Mapeo())
            {
                var query = from a in db.Pedido
                            join s in db.usuario on a.IdUsuario equals s.Id
                            where a.IdSubsede == subsede.Id && a.Estado1.Contains( "pendiente")

                            select new EEstadoPedido
                            {
                                Id_pedido = a.IdPedido,
                                TipoDeEntrega = a.TipoEntrega,
                                Direccion1 = a.Direccion,
                                Total = a.ValorTotal,
                                Nombre1 = s.Nombre,
                                Estado1 = a.Estado1

                            };

                return query.ToList();

            }

        }

        public List<JoinDetalleDeVenta> obtenerDetalleVentaAdministrador(int idVenta)
        {
            using (var db = new Mapeo())
            {
                var query = from a in db.DetalleVenta
                            join s in db.producto on a.IdProducto equals s.IdProducto
                            where a.IdVenta == idVenta

                            select new JoinDetalleDeVenta
                            {
                                Descripcion = s.Descripcion,
                                Cantidad = a.Cantidad,
                                Precio = a.ValorUnitario,
                                ValorTotal = a.ValorTotal
                            };

                return query.ToList();

            }

        }
        public ESubsede obtenerIdSubsede(int idUsuario)
        {
            using (var db = new Mapeo())
            {
                return db.subsede.FirstOrDefault(x => x.IdCajero == idUsuario | x.IdAdmin == idUsuario);


            }
        }

        public EPedido obtenerPedidocajero(EPedido usuario)
        {
            using (var db = new Mapeo())
            {
                return db.Pedido.FirstOrDefault(x => x.IdPedido == usuario.IdPedido);


            }
        }


        public void ActualizarEstadosPedido(EPedido usuario)
        {
            using (var db = new Mapeo())
            {
                db.Pedido.Attach(usuario);
                var entry = db.Entry(usuario);
                entry.State = EntityState.Modified;
                db.SaveChanges();


            }
        }

        public List<JoinProductoSubsede> ObtenerInventariSubsedeCajero(int idUsuario)
        {
            ESubsede subsede = new ESubsede();
            subsede = obtenerIdSubsede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.productoSubsede
                            join s in db.producto on a.IdProducto equals s.IdProducto
                            where a.Id_subsede == subsede.Id
                            select new JoinProductoSubsede
                            {
                                Codigo_producto1 = a.IdProducto,
                                Descripcion1 = s.Descripcion,
                                Cantidad1 = a.Cantidad,
                                Cantidadminima1 = a.CantidadMinima
                            };
                return query.ToList();

            }
        }

        public List<JoinProductoSubsede> ObtenerProductosSubsedeCajero(int idUsuario)
        {
            ESubsede subsede = new ESubsede();
            subsede = obtenerIdSubsede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.productoSubsede
                            join s in db.producto on a.IdProducto equals s.IdProducto
                            where a.Id_subsede == subsede.Id & !(a.Cantidad==a.CantidadMinima)
                            select new JoinProductoSubsede
                            {
                                Id_producto = a.IdProducto,
                                Descripcion1 = s.Descripcion,
                                Cantidad1 = a.Cantidad - a.CantidadMinima,
                                Precio = s.Precio
                            };
                return query.ToList();

            }
        }

        public List<JoinPedidoCliente> obtenerPedidosCajeros(int idUsuario)
        {
            ESubsede subsede = new ESubsede();
            subsede = obtenerIdSubsede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.Pedido
                            join s in db.usuario on a.IdUsuario equals s.Id
                            where a.IdSubsede == subsede.Id
                            select new JoinPedidoCliente
                            {
                                NumeroPedido = a.IdPedido,
                                TipoDeEntrega = a.TipoEntrega,
                                Direccion = a.Direccion,
                                Total = a.ValorTotal,
                                Cliente = s.Nombre,
                                Estado = a.Estado1
                            };
                return query.ToList();

            }
        }
        public List<JoinDetallepedidoProducto> obtenerDetallePedido(int idPedido)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.DetallePedido
                            join s in db.producto on a.IdProducto equals s.IdProducto
                            where a.IdPedido == idPedido

                            select new JoinDetallepedidoProducto
                            {
                                Descripcion = s.Descripcion,
                                Precio = s.Precio,
                                Cantidad = a.Cantidad,
                                ValorTotal = a.ValorTotal
                            };
                return query.ToList();

            }
        }


        public List<EVenta> ObtenerVentaasDiaAdmin(int id_usuario, string fecha)
        {
            int id_subsede;
            ESubsede l = new ESubsede();
            l = obtenerIdSubsede(id_usuario);
            id_subsede = l.Id;

            using (var db = new Mapeo())
            {
                var query = from a in db.Ventas
                            where a.IdSubsede == id_subsede & a.Dia.Contains(fecha)
                            select new EVenta
                            {
                                IdVenta = a.Id,
                                Total = a.ValorTotal,
                                Dia = a.Dia,
                                Hora = a.Hora,
                            };

                return query.ToList();

            }
        }

        public List<JoinProductosSubsede> ObtenerProductosSubsede(int idUsuario)
        {
            ESubsede l = new ESubsede();
            l = obtenerIdSubsede(idUsuario);
            int idSubsede;
            idSubsede = l.Id;
            using (var db = new Mapeo())
            {
                var query = from a in db.productoSubsede
                            join s in db.producto on a.IdProducto equals s.IdProducto
                            where a.Id_subsede == idSubsede
                            select new JoinProductosSubsede
                            {
                                IdProducto = a.IdProducto,
                                Descripcion = s.Descripcion,
                                Precio = s.Precio,
                                Cantidad = a.Cantidad,
                                CantidadMin = a.CantidadMinima,

                            };

                return query.ToList();

            }
        }
        public List<EEstadoPedido> ObtenerPedidosSubsedeAdmin(int id_usuario)
        {
            ESubsede l = new ESubsede();
            l = obtenerIdSubsede(id_usuario);
            int idSubsede;
            idSubsede = l.Id;
            using (var db = new Mapeo())
            {
                var query = from a in db.Pedido
                            where a.IdSubsede == idSubsede
                            select new EEstadoPedido
                            {
                                Id_pedido = a.IdPedido,
                                TipoDeEntrega = a.TipoEntrega,
                                Total = a.ValorTotal,
                                Estado1 = a.Estado1,
                            };

                return query.ToList();

            }
        }
        public List<JoinProductosSubsede> ObtenerDetallePedido(int id_pedido)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.DetallePedido
                            join s in db.producto on a.IdProducto equals s.IdProducto
                            where a.IdPedido == id_pedido
                            select new JoinProductosSubsede
                            {
                                IdProducto = a.IdProducto,
                                Descripcion = s.Descripcion,
                                Precio = a.ValorUnitario,
                                Cantidad = a.Cantidad,
                                CantidadMin = a.ValorTotal,

                            };

                return query.ToList();

            }
        }
        public List<EEstadoPedido> ObtenerCajeroAsignadoAdmin(int id_usuario)
        {
            ESubsede l = new ESubsede();
            l = obtenerIdSubsede(id_usuario);
            int idSubsede;
            idSubsede = l.Id;

            using (var db = new Mapeo())
            {
                var query = from a in db.subsede
                            join s in db.usuario on a.IdCajero equals s.Id
                            where a.Id == idSubsede
                            select new EEstadoPedido
                            {
                                Id_pedido = a.IdCajero,
                                Nombre1 = s.Nombre,
                                Direccion1 = s.Correo,
                                TipoDeEntrega = s.Usuario,

                            };

                return query.ToList();

            }
        }
    }

}
