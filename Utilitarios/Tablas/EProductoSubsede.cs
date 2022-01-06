using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Tablas
{
    [Serializable]
    [Table("producto_subsede", Schema = "usuario")]

    public class EProductoSubsede
    {
        private int cantidad;
        private int cantidadMinima;
        private int id_subsede;
        private int idProducto;
        private int id;
        private string session;
        private DateTime last;
        private String mensajeCantidadNegativa;
        private String mensajeCantidadInsuficiente;
        private String mensajeAsignadoCorrectamente;
        private String mensajeProductoYaAsignado;
        private String mensajeCantidadMinimaMenorACantidadMaxima;
        private bool activo;

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
        [Column("id_subsede")]
        public int Id_subsede
        {
            get
            {
                return id_subsede;
            }

            set
            {
                id_subsede = value;
            }
        }
        
        [Column("id_producto")]
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
        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Last { get => last; set => last = value; }
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

        [Column("activo")]
        public bool Activo { get => activo; set => activo = value; }
    }
}
