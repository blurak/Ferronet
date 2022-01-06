using Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Utilitarios.Join;
using Utilitarios.Tablas;


namespace Datos.Persistencia
{
    public class DAOIdioma
    {
        private DAOAuditoria auditoria = new DAOAuditoria();
        public List<JoinPedidoCliente> obtenerIdiomasRegistrados()
        {
            using (var db = new Mapeo())
            {
                var query = from a in db.idioma
                            select new JoinPedidoCliente
                            {
                                  Direccion=a.Terminacion,
                                 Cliente=a.Nombre

                            };

                return query.ToList();

            }
        }

        public List<JoinIdiomaControles> obtenerControles(String formulario,String terminacion)
        {
          

            int idForm = 11;
            int idIdio = 10;
            idForm = idFormulario(formulario);
            idIdio = idIdioma(terminacion);
            using (var db = new Mapeo())
            {
                var consulta = (from c in db.controles
                                where c.IdFormulario == idForm & c.IdIdioma == idIdio
                                select new JoinIdiomaControles
                                {
                                    Control = c.Control,
                                    Texto = c.Texto
                                   });
                return consulta.ToList();
            }


        }

      

        public int idIdioma(String terminacion)
        {
            int id =0;
                var db = new Mapeo();
                id = db.idioma.FirstOrDefault(x => x.Terminacion.Contains(terminacion)).Id;
            
            return id;
        }

        public int idFormulario(String nombre)
        {
            int id = 0;
            var db = new Mapeo();
            id = db.formulario.FirstOrDefault(x => x.Nombre.Contains(nombre)).Id;
            return id;
        }

        public void agregarIdioma(EIdioma idioma)
        {
            using (var db = new Mapeo())
            {
                db.idioma.Add(idioma);
                db.SaveChanges();
            }
            auditoria.AuditoriaInsertarIdioma(idioma);
        }

        public List<JoinPedidoCliente> obtenerFormularios()
        {
            using (var db = new Mapeo())
            {
                var query = from a in db.formulario
                            select new JoinPedidoCliente
                            {
                                 Total = a.Id,
                                Cliente = a.Nombre

                            };

                return query.ToList();

            }
        }

        public List<JoinIdiomaControles> obtenerControles(int idFormulario)
        {
            using (var db = new Mapeo())
            {
                var query = from a in db.controles
                            where a.IdIdioma == 9 & a.IdFormulario == idFormulario & !a.Texto.Contains("/Images")
                            select new JoinIdiomaControles
                            {
                                Control = a.Control,
                                Texto = a.Texto,
                                Id = a.IdIdioma,
                                IdFormulario = a.IdFormulario

                            };

                return query.ToList();

            }
        }

        public List<JoinIdiomaControles> obtenerControlesTraducidosDeImagenes(int idFormulario,String terminacion)
        {
            int idIdio = 0;
            idIdio = idIdioma(terminacion);
            using (var db = new Mapeo())
            {
                var query = from a in db.controles
                            where a.IdIdioma == idIdio & a.IdFormulario == idFormulario & (a.Texto.Contains("/Images") | a.Texto.Contains("\\Images"))
                            select new JoinIdiomaControles
                            {
                                 Control=a.Control,
                                 Texto=a.Texto
                            };

                return query.ToList();

            }
        }


        public List<JoinIdiomaControles> obtenerControles(int idFormulario,String terminacion)
        {
            int idIdio = 0;
            idIdio = idIdioma(terminacion);
            using (var db = new Mapeo())
            {
                var query = from a in db.controles
                            where a.IdIdioma == idIdio & a.IdFormulario == idFormulario & !(a.Texto.Contains("/Images") | a.Texto.Contains("\\Images"))
                            select new JoinIdiomaControles
                            {
                                Control = a.Control,
                                Texto = a.Texto,
                                Id = a.IdIdioma,
                                IdFormulario = a.IdFormulario

                            };

                return query.ToList();

            }
        }

        public List<JoinIdiomaControles> obtenerControlesImagenes(int idFormulario)
        {

            using (var db = new Mapeo())
            {
                var query = from a in db.controles
                            where a.IdIdioma == 9 & a.IdFormulario == idFormulario & (a.Texto.Contains("/Images") | a.Texto.Contains("\\Images"))
                            select new JoinIdiomaControles
                            {
                                Control = a.Control,
                                Texto = a.Texto
                            };

                return query.ToList();

            }
        }
    }
}
