using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Tablas
{
   public class EProductosSede
    {
        [Serializable]
        [Table("producto_sede", Schema = "usuario")]
        public class EProductoSedeEnti
        {
            int id;
            int cantidad;
            int cantidadmin;
            int id_producto;
            int id_sede;
            bool activo;
            String mensaje;
            private DateTime last;
            private String mensajeCantidadNegativa;
            private String mensajeCantidadInsuficiente;
            private String mensajeAsignadoCorrectamente;
            private String mensajeProductoYaAsignado;
            private String mensajeCantidadMinimaMenorACantidadMaxima;
            [Key]
            [Column("id")]
            public int Id
            {
                get
                {
                    return id;
                }

                set
                {
                    id = value;
                }
            }
            [Column("cantidad")]
            public int Cantidad
            {
                get
                {
                    return cantidad;
                }

                set
                {
                    cantidad = value;
                }
            }
            [Column("cantidadmin")]
            public int Cantidadmin
            {
                get
                {
                    return cantidadmin;
                }

                set
                {
                    cantidadmin = value;
                }
            }
            [Column("id_producto")]
            public int Id_producto
            {
                get
                {
                    return id_producto;
                }

                set
                {
                    id_producto = value;
                }
            }
            [Column("id_sede")]
            public int Id_sede
            {
                get
                {
                    return id_sede;
                }

                set
                {
                    id_sede = value;
                }
            }
            [Column("activo")]
            public bool Activo
            {
                get
                {
                    return activo;
                }

                set
                {
                    activo = value;
                }
            }
            [NotMapped]
            public string Mensaje
            {
                get
                {
                    return mensaje;
                }

                set
                {
                    mensaje = value;
                }
            }
            [NotMapped]
            public String MensajeCantidadMinimaMenorACantidadMaxima
            {
                get
                {
                    return mensajeCantidadMinimaMenorACantidadMaxima;
                }

                set
                {
                    mensajeCantidadMinimaMenorACantidadMaxima = value;
                }
            }

            [NotMapped]
            public String MensajeCantidadNegativa
            {
                get
                {
                    return mensajeCantidadNegativa;
                }

                set
                {
                    mensajeCantidadNegativa = value;
                }
            }
            [NotMapped]
            public String MensajeCantidadInsuficiente
            {
                get
                {
                    return mensajeCantidadInsuficiente;
                }

                set
                {
                    mensajeCantidadInsuficiente = value;
                }
            }
            [NotMapped]
            public String MensajeAsignadoCorrectamente
            {
                get
                {
                    return mensajeAsignadoCorrectamente;
                }

                set
                {
                    mensajeAsignadoCorrectamente = value;
                }
            }
            [NotMapped]
            public String MensajeProductoYaAsignado
            {
                get
                {
                    return mensajeProductoYaAsignado;
                }

                set
                {
                    mensajeProductoYaAsignado = value;
                }
            }

            [Column("last_modified")]
            public DateTime Last { get => last; set => last = value; }
        }
    }
}
