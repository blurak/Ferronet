using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Utilitarios.Join;
using Utilitarios.Tablas;
using Utilitarios.Servicios;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Datos.Persistencia
{
    public class DAOServicio
    {
        public EServicio devolverToken(String usuario,String contrasena)
        {

            using (var db = new Mapeo())
            {
                return db.servicio.FirstOrDefault(x => x.Usuario.Contains(usuario) & x.Contrasena.Contains(contrasena));

            }
        }

        public void modificarToken(EServicio servicio)
        {
            DateTime fechahoy = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            servicio.Validez= fechahoy.AddDays(2);
            using (var context = new Mapeo())
            {
                var cliente = context.servicio.Find(servicio.Id);
                cliente.Token = servicio.Token;
                cliente.Validez = servicio.Validez;
                context.SaveChanges();
            }
        }

        public List<Productos> obtenerProductosVisitante(String criterio)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.producto
                            join s in db.productoSubsede on a.IdProducto equals s.IdProducto
                            join su in db.subsede on s.Id_subsede equals su.Id
                            join c in db.categoria on a.Categoria equals c.Id
                            where a.Descripcion.Contains(criterio) & !(s.CantidadMinima == s.Cantidad)
                            select new Productos
                            {
                                Imagen = a.Imagen,
                                CodigoProducto = a.IdProducto,
                                Descripcion = a.Descripcion,
                                Categoria = c.Nombre,
                                Precio = a.Precio,
                                NombreSubsede = su.Nombre
                            };
                return query.ToList();
            }
        }

        public EServicio devolverToken(String token)
        {

            using (var db = new Mapeo())
            {
                return db.servicio.FirstOrDefault(x => x.Token.Contains(token));

            }
        }

        public List<Proveedores> obtenerProveedores(int categoria)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.proveedores
                            join s in db.categoria on a.IdCategoria equals s.Id
                            where a.IdCategoria == categoria
                            select new Proveedores
                            {
                                Codigo = a.Id,
                                Nombre = a.Nombre,
                                Correo = a.Correo,
                                Telefono = a.Telefono,
                                Categoria = s.Nombre
                            };
                return query.ToList();
            }
        }

        public List<JoinProveedoresCategoria> ObtenerUbicacionesDeSubsede()
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.subsede
                            select new JoinProveedoresCategoria
                            {
                                Nombre = a.Ubicacion
                            };
                return query.ToList();
            }
        }

        public List<Usuarios> ObtenerUsuarios()
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.usuario
                            where a.IdRol == 1
                            select new Usuarios
                            {
                                Nombre = a.Nombre,
                                Correo = a.Correo,
                                Usuario = a.Usuario,
                                Clave = a.Clave
                            };
                return query.ToList();
            }
        }

        public List<JoinUsuario> ValidarToken(EServicio servicio)
        {
            DateTime fechainicios = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

            using (var db = new Mapeo())
            {
                var query = from a in db.servicio
                            where (fechainicios >= a.Validez & a.Usuario.Contains(servicio.Usuario)& a.Contrasena.Contains(servicio.Contrasena))
                            select new JoinUsuario
                            {
                                 Nombre=a.Usuario

                            };
                return query.ToList();
            }
        }

        public List<JoinModificaSessiones> ObteneridsSubsedes()
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.subsede
                            select new JoinModificaSessiones
                            {
                                Id = a.Id,
                            };

                return query.ToList();
            }
        }

        public List<JoinModificaSessiones> ObtenerventasPorSubsede(int id_subsede)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.Ventas
                            where a.IdSubsede == id_subsede
                            select new JoinModificaSessiones
                            {
                                Id = a.Id,
                            };

                return query.ToList();
            }
        }

        public List<TopSubsedes> obtenerSubsedesevice(int id1, int id2, int id3)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.subsede
                            join s in db.sede on a.IdSede equals s.Id
                            join u in db.usuario on a.IdAdmin equals u.Id
                            join w in db.usuario on a.IdCajero equals w.Id
                            where a.Id == id1 || a.Id == id2 || a.Id == id3
                            select new TopSubsedes
                            {
                                Codigo = a.Id,
                                Subsede = a.Nombre,
                                SedeCentral = s.Nombre,
                                Administrador = u.Nombre,
                                Cajero =w.Nombre
                            };

                return query.ToList();

            }
        }

        public int ObtenerTotalVendido(int idSubsede)
        {
            int total = 0;
            try
            {
                var db = new Mapeo();
                total = db.Ventas.Where(x => x.IdSubsede == idSubsede).Sum(x => x.ValorTotal);

            }
            catch (Exception)
            {

            }
            return total;
        }

        public DataTable ObteneridsVentasdelmes(string id_subsede)
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ferronetContext"].ConnectionString))
            {

                string cadena = "SELECT id FROM usuario.ventas WHERE MONTH(diacompa) = '" + id_subsede + "'";
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

        public List<JoinModificaSessiones> obtenerdetalleventaservice(int id_venta)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.DetalleVenta
                            where a.IdVenta == id_venta
                            select new JoinModificaSessiones
                            {
                                Id = a.IdProducto,
                            };

                return query.ToList();
            }
        }

        public List<JoinModificaSessiones> obtenerdetalleventaservicenumero(int id_producto)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.DetalleVenta
                            where a.IdProducto == id_producto
                            select new JoinModificaSessiones
                            {
                                Id = a.Id
                            };

                return query.ToList();
            }
        }

        public List<TopProductos> obtenerProductosSubsede(int id1, int id2, int id3)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.producto
                            join s in db.productoSubsede on a.IdProducto equals s.IdProducto
                            join su in db.subsede on s.Id_subsede equals su.Id
                            join c in db.categoria on a.Categoria equals c.Id
                            where a.IdProducto == id1 || a.IdProducto == id2 || a.IdProducto == id3
                            select new TopProductos
                            {

                                Imagen = a.Imagen,
                                Codigo = a.IdProducto,
                                Descripcion = a.Descripcion,
                                Categoria = c.Nombre,
                                Precio = a.Precio,
                                Subsede = su.Nombre
                            };
                return query.ToList();
            }
        }

    }
}
