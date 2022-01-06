using Datos.Persistencia;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilitarios;
using Utilitarios.Join;
using Utilitarios.Tablas;

namespace Datos
{
    public class DAOUsuario
    {
        private DAOAuditoria auditoria = new DAOAuditoria();

        public void actualizarContrasena(PUsuario animal)
        {

            using (var context = new Mapeo())
            {
                var cliente = context.usuario.Find(animal.Id);
                cliente.Clave = animal.Clave;
                cliente.Estado = 1;
                context.SaveChanges();
            }
        }

        public void cerrarSesion(String session)
        {

            EAutenticacion autentica = new EAutenticacion();
            autentica = devolverAutenticacion(session);
            DateTime fechahoy = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            using (var context = new Mapeo())
            {
                var cliente = context.autenticacion.Find(autentica.Id);
                cliente.FechaFin = fechahoy;
                context.SaveChanges();
            }
        }

        public EAutenticacion devolverAutenticacion(String sesion)
        {

            using (var db = new Mapeo())
            {
                return db.autenticacion.FirstOrDefault(x => x.Session.Contains(sesion));

            }
        }
        public EAutenticacion devolverAutenticacion(Int64 id)
        {

            using (var db = new Mapeo())
            {
                return db.autenticacion.FirstOrDefault(x => x.Id==id);

            }
        }


        public PUsuario devolverUsuario(int id)
        {

            using (var db = new Mapeo())
            {
                return db.usuario.FirstOrDefault(x => x.Id == id);

            }
        }


        public void restarSesiones(int idUsuario)
        {

            using (var context = new Mapeo())
            {
                var cliente = context.usuario.Find(idUsuario);
                cliente.SesionesActivas =cliente.SesionesActivas-1;
                context.SaveChanges();
            }
        }

        public void actualizarEstado(int userId)
        {

            using (var context = new Mapeo())
            {
                var cliente = context.usuario.Find(userId);
                cliente.Estado = 2;
                context.SaveChanges();
            }
        }
        public void almacenarToken(EtokenRecuperacionUsuario token)
        {
            DateTime fechahoy = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            DateTime fechaDoshoras = fechahoy.AddMinutes(120);
            token.FechaCreado = fechahoy;
            token.FechaVigencia = fechaDoshoras;
            actualizarEstado(token.UserId);
            using (var db = new Mapeo())
            {
                db.tokenRecuperacion.Add(token);
                db.SaveChanges();
            }

            auditoria.AuditoriaInsertarTokenRecuperacionContrasena(token);
        }
        public void guardarSesion(EAutenticacion usuario)
        {
            using (var db = new Mapeo())
            {
                db.autenticacion.Add(usuario);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarAutenticacion(usuario);
        }

        public void registrarUsuario(PUsuario usuario)
        {
           
            using (var db = new Mapeo())
            {
                db.usuario.Add(usuario);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarUsuario(usuario);
           
        }

        public PUsuario verificarExistenciaDelUsuario(String username)
        {
           
                using (var db = new Mapeo())
                {
                    var a = db.usuario.FirstOrDefault(x => x.Usuario.Contains(username));
                    return a;
                }
           
                  

        }

        public List<PUsuario> verificarBaneo(String username)
        {
            using (var db = new Mapeo())
            { 
                var a = db.usuario.ToList<PUsuario>().Where(x => x.Usuario.Contains(username));
                return a.ToList<PUsuario>();
            }
        }

        public void actualizarIntentosErroneos(PUsuario animal)
        {
            
            using (var context = new Mapeo())
            {
                var cliente = context.usuario.Find(animal.Id);
                cliente.IntentosIncorrectos = animal.IntentosIncorrectos+cliente.IntentosIncorrectos;
                context.SaveChanges();
            }
        }

        public void actualizarIntentosErroneosACero(PUsuario animal)
        {

            using (var context = new Mapeo())
            {
                var cliente = context.usuario.Find(animal.Id);
                cliente.IntentosIncorrectos = animal.IntentosIncorrectos;
                context.SaveChanges();
            }
        }
        public void ColocarBaneos(PUsuario animal)
        {

            using (var context = new Mapeo())
            {
                var cliente = context.usuario.Find(animal.Id);
                cliente.Baneado = animal.Baneado;
                cliente.Baneo = animal.Baneo;
                context.SaveChanges();
            }
        }

        public PUsuario Loggin(PUsuario usuario)
        {
            String nombre = usuario.Usuario;

           
            using (var db = new Mapeo())
            {
                return db.usuario.FirstOrDefault(x => x.Usuario.Contains(nombre));
                
            }
        }

        public void SumarSesiones(PUsuario animal)
        {

            using (var context = new Mapeo())
            {
                var cliente = context.usuario.Find(animal.Id);
                cliente.SesionesActivas = animal.SesionesActivas+cliente.SesionesActivas;
                context.SaveChanges();
            }
        }

        public List<JoinProductoSubsede> obtenerProductosSubsede(String criterio)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.producto
                            join s in db.productoSubsede on a.IdProducto equals s.IdProducto
                            join su in db.subsede on s.Id_subsede equals su.Id
                            join c in db.categoria on a.Categoria equals c.Id
                            where a.Descripcion.Contains(criterio) & !(s.CantidadMinima==s.Cantidad)
                            select new JoinProductoSubsede
                            {
                                 Imagen=a.Imagen,
                                  Codigo_producto1=a.IdProducto,
                                  Descripcion1=a.Descripcion,
                                  Categoria=c.Nombre,
                                  Precio=a.Precio,
                                  Subsede=su.Nombre
                            };
                return query.ToList();
            }
        }

        public List<JoinProductoSubsede> obtenerSesionesMaximas(int idRol)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.usuario
                            where a.IdRol == idRol
                            select new JoinProductoSubsede
                            {

                                Codigo_producto1 = a.SesionesMaximas,
                                
                            };
                return query.ToList();
            }
        }

        public  PUsuario generarToken(String username)
        {

            using (var db = new Mapeo())
            {
                return db.usuario.FirstOrDefault(x => x.Usuario.Contains(username));

            }
        }

        public List<JoinUsuario> ValidarToken(String username)
        {
            DateTime fechainicios=Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
           
            using (var db = new Mapeo())
            {
                var query = from a in db.usuario
                            join s in db.tokenRecuperacion on a.Id equals s.UserId
                            where a.Usuario.Contains(username) & ((s.FechaCreado <= fechainicios) & ( s.FechaVigencia>=fechainicios) )
                            select new JoinUsuario
                            {
                                Id = a.Id,
                                Nombre = a.Nombre,
                                Estado = a.Estado,
                                Usuario = a.Usuario,
                                Correo = a.Correo

                            };
                return query.ToList();
            }
        }


        public List<JoinUsuario> DevolverUsuario(String username)
        {
            using (var db = new Mapeo())
            {
                var query = from a in db.usuario
                            where a.Usuario.Contains(username) 
                            select new JoinUsuario
                            {
                                Id = a.Id,
                                Nombre = a.Nombre,
                                Estado = a.Estado,
                                Usuario = a.Usuario,
                                Correo = a.Correo

                            };
                return query.ToList();
            }
        }

        public List<JoinUsuario> verificarTokenSiEsValido(String token)
        {
            using (var db = new Mapeo())
            {
                var query = from a in db.tokenRecuperacion
                            where a.Token == token
                            select new JoinUsuario
                            {
                                Id = a.Id
                            };
                return query.ToList();
            }
        }

        public List<JoinUsuario> verificarTokenSiEstaVencido(String token)
        {
            DateTime fechainicios = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

            using (var db = new Mapeo())
            {
                var query = from a in db.tokenRecuperacion
                            where a.Token == token & ((a.FechaCreado <= fechainicios) & (a.FechaVigencia >= fechainicios))
                            select new JoinUsuario
                            {
                                Id = a.UserId
                            };
                return query.ToList();
            }
        }

        public void borrarTokenVencido(String token)
        {
            try
            {
                var db = new Mapeo();

                var employer = new EtokenRecuperacionUsuario {  Token=token};
                db.tokenRecuperacion.Attach(employer);
                db.tokenRecuperacion.Remove(employer);
                db.SaveChanges();

            }
            catch (Exception)
            {

            }   
        }



    }
}
