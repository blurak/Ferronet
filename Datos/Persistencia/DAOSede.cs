using Datos.Persistencia;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Utilitarios;
using Utilitarios.Join;
using Utilitarios.Tablas;

namespace Datos
{
    public class DAOSede
    {
        private DAOAuditoria auditoria = new DAOAuditoria();

        public List<JoinPedidoCliente> obtenerSubsede(int idUsuario)
        {
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.subsede
                            where a.IdSede == sede.Id
                            select new JoinPedidoCliente
                            {
                                NumeroPedido = a.Id,
                                Cliente = a.Nombre

                            };

                return query.ToList();

            }
        }

        public void registrarProducto(EProducto producto)
        {
            using (var db = new Mapeo())
            {
                db.producto.Add(producto);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarProducto(producto);

        }

        public List<JoinPedidoCliente> obtenerProductosAsignar(int idUsuario)
        {
            ESede sede = new ESede();
            sede=DevolverSede(idUsuario);
            using (var db = new Mapeo())
            {

                var subselect = (from u in db.productoSede                       
                                 where u.IdSede == sede.Id
                                 select u.Id_producto).ToList();

                var custContact = (from cc in db.producto
                                   where !subselect.Contains(cc.IdProducto)
                                   select new JoinPedidoCliente
                                   {
                                       NumeroPedido = cc.IdProducto,
                                       Cliente = cc.Descripcion
                                   });
                return custContact.ToList();
            }
        }

        public List<JoinPedidoCliente> obtenerAdministradores()
        {
            using (var db = new Mapeo())
            {

                var subselect = (from u in db.usuario
                                 join s in db.subsede
                                 on  u.Id equals s.IdAdmin
                                 where u.IdRol==3
                                 select s.IdAdmin).ToList();

                var custContact = (from cc in db.usuario
                                   where !subselect.Contains(cc.Id) & cc.IdRol==3
                                   select new JoinPedidoCliente
                                   {
                                       NumeroPedido = cc.Id,
                                       Cliente = cc.Nombre
                                   });
                return custContact.ToList();
            }
        }

        public List<JoinPedidoCliente> obtenerCajeros()
        {
            using (var db = new Mapeo())
            {

                var subselect = (from u in db.usuario
                                 join s in db.subsede
                                 on u.Id equals s.IdCajero
                                 where u.IdRol == 4
                                 select s.IdCajero).ToList();

                var custContact = (from cc in db.usuario
                                   where !subselect.Contains(cc.Id) & cc.IdRol == 4
                                   select new JoinPedidoCliente
                                   {
                                       NumeroPedido = cc.Id,
                                       Cliente = cc.Nombre
                                   });
                return custContact.ToList();
            }
        }

        public List<JoinProductoSede> ReporteProsede(int idUsuario)
        {
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.productoSede
                            join s in db.producto on a.Id_producto equals s.IdProducto
                            where a.IdSede == sede.Id
                            select new JoinProductoSede
                            {
                                Codigo_producto1 = a.Id_producto,
                                Descripcion = s.Descripcion,
                                CantidadMin1 = a.CantidadMinima,
                                Cantidadd1 = a.Cantidad,

                            };

                return query.ToList();

            }
        }

        public void insertarSede(ESubsede subsede, int idUsuario)
        {
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);
            subsede.IdSede = sede.Id;
            using (var db = new Mapeo())
            {
                db.subsede.Add(subsede);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarSubsede(subsede);

        }

        public List<JoinProductoSede> obtenerInventarioSede(int idUsuario)
        {
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.producto
                            join s in db.productoSede on a.IdProducto equals s.Id_producto

                            where s.IdSede == sede.Id & s.Activo == true & !(s.Cantidad==s.CantidadMinima)
                            select new JoinProductoSede
                            {
                                Codigo_producto1 = a.IdProducto,
                                Descripcion = a.Descripcion,
                                Cantidadd1 = s.Cantidad,
                                CantidadMin1 = s.CantidadMinima
                            };
                return query.ToList();
            }
        }

        public void ModificarCantidades(EProductoSede animal)
        {
            using (var context = new Mapeo())
            {
                var cliente = context.productoSede.Find(animal.Id);
                cliente.Cantidad = animal.Cantidad;
                context.SaveChanges();
            }
        }

        public EProductoSede DevolverIdProductoSede(EProductoSede usuario)
        {

            using (var db = new Mapeo())
            {
                return db.productoSede.FirstOrDefault(x => x.Id_producto == usuario.Id_producto);

            }
        }

        public List<JoinProductoSede> obtenerInventarioSedeCantidadesBajas(int idUsuario)
        {
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.producto
                            join s in db.productoSede on a.IdProducto equals s.Id_producto

                            where s.IdSede == sede.Id & s.Cantidad == s.CantidadMinima & s.Activo == true
                            select new JoinProductoSede
                            {
                                Codigo_producto1 = a.IdProducto,
                                Descripcion = a.Descripcion,
                                Cantidadd1 = s.Cantidad,
                                CantidadMin1 = s.CantidadMinima
                            };
                return query.ToList();
            }
        }

        public void AsignarProducto(EProductoSede producto)
        {
            using (var db = new Mapeo())
            {
                db.productoSede.Add(producto);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarProductoSede(producto);
        }

        public List<JoinProveedoresCategoria> obtenerProveedores(int idUsuario)
        {
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.proveedores
                            join s in db.categoria on a.IdCategoria equals s.Id

                            where a.IdSede == sede.Id
                            select new JoinProveedoresCategoria
                            {
                                IdProveedor = a.Id,
                                Nombre = a.Nombre,
                                Correo = a.Correo,
                                Telefono = a.Telefono,
                                Categoria = s.Nombre
                            };
                return query.ToList();
            }
        }

        public void insertarProveedorEmpy(EProveedor proveedor)
        {
            using (var db = new Mapeo())
            {
                db.proveedores.Add(proveedor);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarProveedor(proveedor);


        }

        public ESede DevolverSede(int idUsuario)
        {

            using (var db = new Mapeo())
            {
                return db.sede.FirstOrDefault(x => x.IdSuper == idUsuario);

            }
        }

        public EProductoSubsede DevolverProductoSubsede(int idSubsede,int idPro)
        {

            using (var db = new Mapeo())
            {
                return db.productoSubsede.FirstOrDefault(x => x.Id_subsede == idSubsede & x.IdProducto==idPro);

            }
        }

        public EProductoSede ObtenerIdProducto(EProductoSede producto)
        {
            using (var db = new Mapeo())
            {
                return db.productoSede.FirstOrDefault(x => x.Id_producto == producto.Id_producto);
            }
        }

        public void ActualizarEstadosProducto(EProductoSede producto)
        {
            using (var db = new Mapeo())
            {
                db.productoSede.Attach(producto);
                var entry = db.Entry(producto);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<EProductosDrop> ObtenerProductosDrop(int idUsuario)
        {
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.productoSede
                            join s in db.producto on a.Id_producto equals s.IdProducto
                            where a.Activo == true & a.IdSede == sede.Id
                            select new EProductosDrop
                            {
                                IdProducto = a.Id_producto,
                                Descripcion = s.Descripcion,
                            };

                return query.ToList();

            }
        }

        public List<EProductosDrop> ObtenerSubsedees()
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.subsede
                            select new EProductosDrop
                            {
                                IdProducto = a.Id,
                                Descripcion = a.Nombre,
                            };

                return query.ToList();

            }
        }

        public List<EVenta> ObtenerVentaas(int id_subsede, string fecha)
        {

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

        public List<EVentasPasadas> ObtenerVentaasPasadas(int id_subsede, DateTime fechainicios, DateTime fechafin)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.Ventas
                            where a.IdSubsede == id_subsede & Convert.ToDateTime(a.Dia) <= fechainicios & Convert.ToDateTime(a.Dia) >= fechafin
                            select new EVentasPasadas
                            {
                                IdVenta = a.Id,
                                Total = a.ValorTotal,
                                //Dia = a.Dia,
                                Hora = a.Hora,
                            };

                return query.ToList();

            }
        }

        public List<JoinDetalleDeVenta> ObtenerProductosPorSubsede(int id_subsede)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.productoSubsede
                            join s in db.producto on a.IdProducto equals s.IdProducto
                            where a.Id_subsede == id_subsede
                            select new JoinDetalleDeVenta
                            {
                                Precio = a.IdProducto,
                                Producto = s.Descripcion,
                                Cantidad = a.Cantidad,
                                ValorTotal = a.CantidadMinima,

                            };

                return query.ToList();

            }
        }

        public List<JoinDetalleDeVenta> ObtenerDetalleVentaas(int id_venta)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.DetalleVenta
                            join s in db.producto on a.IdProducto equals s.IdProducto
                            where a.IdVenta == id_venta
                            select new JoinDetalleDeVenta
                            {
                                Producto = s.Descripcion,
                                Cantidad = a.Cantidad,
                                Precio = a.ValorUnitario,
                                ValorTotal = a.ValorTotal,
                            };

                return query.ToList();

            }
        }

        public List<JoinProductosProximosATerminar> obtenerProductosProximosATerminar(int idUsuario)
        {
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);

            using (var db = new Mapeo())
            {
                var query = from ps in db.productoSede
                            join p in db.producto on ps.Id_producto equals p.IdProducto
                            join c in db.categoria on p.Categoria equals c.Id
                            join s in db.subsede on ps.IdSede equals s.IdSede
                            join psu in db.productoSubsede on p.IdProducto equals psu.IdProducto

                            where psu.IdProducto == p.IdProducto & psu.Id_subsede == s.Id & p.Categoria == c.Id
                            & psu.Cantidad == psu.CantidadMinima & s.IdSede == sede.Id & ps.Id_producto == p.IdProducto & ps.Activo == true

                            select new JoinProductosProximosATerminar
                            {
                                CodigoRegistro = psu.Id,
                                CodigoProducto = psu.IdProducto,
                                Subsede = s.Nombre,
                                Producto = p.Descripcion,
                                Categoria = c.Nombre,
                                CantidadMinima = psu.CantidadMinima,
                                Cantidad = psu.Cantidad,
                                CantidadDisponible = ps.Cantidad - ps.CantidadMinima
                            };


                return query.ToList();

            }
        }


        public void ModificarCantidadesProductosBajosSubsede(EProductoSubsede subsede)
        {
            using (var context = new Mapeo())
            {
                var cliente = context.productoSubsede.Find(subsede.Id);
                cliente.Cantidad = subsede.Cantidad;
                context.SaveChanges();
            }
        }


        public void ModificarCantidadesProductosBajosSede(EProductoSede sede)
        {
            EProductoSede pSede = new EProductoSede();
            pSede = DevolverRegistroProducto(sede.Id_producto);
            using (var context = new Mapeo())
            {
                var cliente = context.productoSede.Find(pSede.Id);
                cliente.Cantidad = sede.Cantidad;
                context.SaveChanges();
            }
        }

        public EProductoSede DevolverRegistroProducto(int idProducto)
        {

            using (var db = new Mapeo())
            {
                return db.productoSede.FirstOrDefault(x => x.Id_producto == idProducto);

            }
        }

        public EPedido obtenerPedidocajero(EPedido usuario)
        {
            using (var db = new Mapeo())
            {
                return db.Pedido.FirstOrDefault(x => x.IdPedido == usuario.IdPedido);


            }
        }

        public int ObtenerTotalVendidoHoy(int idSubsede, String fechaHoy)
        {
            int total = 0;
            try
            {
                var db = new Mapeo();
                total = db.Ventas.Where(x => x.IdSubsede == idSubsede & x.Dia.Contains(fechaHoy)).Sum(x => x.ValorTotal);

            }
            catch (Exception)
            {

            }
            return total;
        }

        public List<JoinReporteAdminyCajero> ReporteAdminyCajero()
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.subsede
                            join s in db.usuario on a.IdAdmin equals s.Id
                            join w in db.usuario on a.IdCajero equals w.Id
                            select new JoinReporteAdminyCajero
                            {
                                Nombre = a.Nombre,
                                IdCajero = a.IdCajero,
                                IdAdmin = a.IdAdmin,
                                Cajero = w.Nombre,
                                Admins = s.Nombre,
                            };

                return query.ToList();

            }



        }

        public List<JoinModificaSessiones> ObtenerUsuariosModificarSessiones(int id_role)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.usuario
                            where a.IdRol == id_role
                            select new JoinModificaSessiones
                            {
                                Id = a.Id,                                
                            };

                return query.ToList();
            }
        }

        
        public PUsuario obtenerUsuarioSessionesMaximas(PUsuario usuario)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.FirstOrDefault(x => x.Id == usuario.Id);


            }
        }

        
        public void ActualizarSessionesMaximas(PUsuario Ususario)
        {
           
            using (var db = new Mapeo())
            {
                db.usuario.Attach(Ususario);
                var entry = db.Entry(Ususario);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
           
        }

        public List<JoinPedidoCliente> obtenerCategorias()
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.categoria
                            select new JoinPedidoCliente
                            {
                                NumeroPedido = a.Id,
                                Cliente = a.Nombre
                                 
                            };

                return query.ToList();

            }
        }

        public List<JoinProductoSede> obtenerProductosSede(String criterio,int idUsuario)
        {
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);
            using (var db = new Mapeo())
            {
                var query = from a in db.producto
                            join s in db.productoSede on a.IdProducto equals s.Id_producto
                            join c in db.categoria on a.Categoria equals c.Id
                            where a.Descripcion.Contains(criterio) & s.IdSede == sede.Id & !(s.Cantidad==s.CantidadMinima)
                            select new JoinProductoSede
                            {
                                Imagen = a.Imagen,
                                Codigo = a.IdProducto,
                                Descripcion = a.Descripcion,
                                Categoria = c.Nombre,
                                Precio = a.Precio
                            };
                return query.ToList();
            }
        }

        public int cantidadDisponible(int idProducto,int idUsuario)
        {
            int cantidad = 0;
            ESede sede = new ESede();
            sede = DevolverSede(idUsuario);
            var db = new Mapeo();
            cantidad = db.productoSede.FirstOrDefault(x => x.Id_producto == idProducto & x.IdSede==sede.Id).Cantidad - db.productoSede.FirstOrDefault(x => x.Id_producto == idProducto & x.IdSede == sede.Id).CantidadMinima;
            return cantidad;

        }

        public String nombreProducto(int idProducto)
        {
            String cantidad = "";
            var db = new Mapeo();
            cantidad = db.producto.FirstOrDefault(x => x.IdProducto == idProducto).Descripcion;
            return cantidad;

        }

        public DataTable ObtenerVentaasPasadasSql(int id_subsede, string fechainicio, string fechafin)
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ferronetContext"].ConnectionString))
            {
                string cadena = "select * from usuario.ventas where id_subsede='"+id_subsede+ "'and diacompa between '"+fechainicio+ "' and '" + fechafin + "'";
                SqlCommand cmd = new SqlCommand(cadena, cn);
                cmd.Parameters.AddWithValue("@idsubsede", id_subsede);              
                cn.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                //En caso a función retorne un tipo bit
                return dt;
            }
        }
        
        public List<JoinProductosSubsede> obtenerproductosService(int id_categoria)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.producto
                            join s in db.categoria on a.Categoria equals s.Id
                            where s.Id == id_categoria
                            select new JoinProductosSubsede
                            {
                                 IdProducto = a.IdProducto,
                                 Descripcion = a.Descripcion,
                                  Precio=a.Precio,
                                  Imagen=a.Imagen,
                                  Categoria=s.Nombre,
                                  
                                 

                            };

                return query.ToList();

            }
        }
        public void registrarProductoSubsede(EProductoSubsede producto)
        {
            using (var db = new Mapeo())
            {
                db.productoSubsede.Add(producto);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarProductoSubsede(producto);
        }
        public EProductoSede obtenerProductoSedeiva(EProductoSede producto)
        {
            using (var db = new Mapeo())
            {
                return db.productoSede.FirstOrDefault(x => x.Id_producto == producto.Id_producto);


            }
        }
        public List<JoinProductosSubsede> obtenerProductosubsdedeCantidad(int id_producto, int id_subsede)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.productoSubsede
                            where a.IdProducto==id_producto & a.Id_subsede==id_subsede
                            select new JoinProductosSubsede
                            {
                                IdProducto = a.Id,
                            };

                return query.ToList();

            }
        }
        public void ModificarProductosedeiva(EProductoSede animal,int _cantidad)
        {
            using (var context = new Mapeo())
            {
                var cliente = context.productoSede.Find(animal.Id);
                cliente.Cantidad = animal.Cantidad-_cantidad;
                context.SaveChanges();
            }
        }
        public EControles devolverControl(int id)
        {

            using (var db = new Mapeo())
            {
                return db.controles.FirstOrDefault(x => x.Id==id);

            }
        }

        public PUsuario devolverUsuario(int id)
        {

            using (var db = new Mapeo())
            {
                return db.usuario.FirstOrDefault(x => x.Id == id);

            }
        }

        public void ModificarIdioma(EControles control)
        {
            using (var context = new Mapeo())
            {
                var cliente = context.controles.Find(control.Id);
                cliente.Texto = control.Texto;
                cliente.Session = control.Session;
                context.SaveChanges();
            }   
        }

        public EControles ObtenerResultadoIdioma(EControles producto)
        {
            using (var db = new Mapeo())
            {
                return db.controles.FirstOrDefault(x => x.Control.Contains(producto.Control) && x.IdFormulario== producto.IdFormulario && x.IdIdioma==producto.IdIdioma
              );


            }
        }
        public EIdioma ObtenerIdidioma(EIdioma producto)
        {
            using (var db = new Mapeo())
            {
                return db.idioma.FirstOrDefault(x => x.Terminacion.Contains(producto.Terminacion));


            }
        }
        public List<JoinProductosSubsede> ObtenerControlParaContar(int id_control)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.controles
                            where a.Id == id_control
                            select new JoinProductosSubsede
                            {
                                IdProducto = a.Id,
                            };

                return query.ToList();

            }
        }
        public void registrarcontrol(EControles control)
        {
            using (var db = new Mapeo())
            {
                db.controles.Add(control);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarControles(control);
        }

        public EProductoSede devolverProductoSede(int id)
        {
            using (var db = new Mapeo())
            {
                return db.productoSede.FirstOrDefault(x => x.Id == id);

            }
        }

        public EProductoSubsede devolverProductoSubsede(int id)
        {
            using (var db = new Mapeo())
            {
                return db.productoSubsede.FirstOrDefault(x => x.Id == id);

            }
        }
        public void insertarPrueba(Epruebiña proveedor)
        {
            using (var db = new Mapeo())
            {
                db.prueba.Add(proveedor);
                db.SaveChanges();
            }

        }
    }

}
