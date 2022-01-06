using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("producto", Schema = "usuario")]

    public class EProducto
    {
        private int cantidad;
        private int cantidadMinima;
        private double precio;
        private String descripcion;
        private String imagen;
        private int categoria;
        private String session;
        private String mensaje;
        private String saveLocation;
        private int sede;
        private int idProducto;
        private String milisegundo;
        private String mensajeCantidadNegativa;
        private String mensajeCantidadInsuficiente;
        private String mensajeAsignadoCorrectamente;
        private String mensajeProductoYaAsignado;
        private String mensajeCantidadMinimaMenorACantidadMaxima;
        private DateTime last;

        [Column("last_modified")]
        public DateTime Last
        {
            get
            {
                return last;
            }

            set
            {
                last = value;
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





        [NotMapped]
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
        [NotMapped]
        public String Milisegundo
        {
            get
            {
                return milisegundo;
            }

            set
            {
                milisegundo = value;
            }
        }
        [NotMapped]
        public int CantidadMinima
        {
            get
            {
                return cantidadMinima;
            }

            set
            {
                cantidadMinima = value;
            }
        }
        [Column("precio")]
        public double Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        [Column("descripcion")]
        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        [Column("imagen")]
        public string Imagen
        {
            get
            {
                return imagen;
            }

            set
            {
                imagen = value;
            }
        }

        [Column("id_categoria")]
        public int Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        [Column("session")]
        public string Session
        {
            get
            {
                return session;
            }

            set
            {
                session = value;
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
        public string SaveLocation
        {
            get
            {
                return saveLocation;
            }

            set
            {
                saveLocation = value;
            }
        }
        [NotMapped]
        public int Sede
        {
            get
            {
                return sede;
            }

            set
            {
                sede = value;
            }
        }

        [Key]
        [Column("id")]
        public int IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
            }
        }
    }
}
