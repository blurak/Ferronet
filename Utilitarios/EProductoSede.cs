using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utilitarios.Tablas;

namespace Utilitarios
{
    [Serializable]
    [Table("producto_sede", Schema = "usuario")]

    public class EProductoSede
    {
        private int id;
        private int cantidad;
        private int cantidadMinima;
        private int id_producto;
        private int idSede;
        private String session;
        private DateTime last;
        private Boolean activo;
        private String mensaje;
        private String mensajeCantidadNegativa;
        private String mensajeCantidadInsuficiente;
        private String mensajeAsignadoCorrectamente;
        private String mensajeProductoYaAsignado;
        private String mensajeCantidadMinimaMenorACantidadMaxima;


        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("cantidad")]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        [Column("cantidadmin")]
        public int CantidadMinima { get => cantidadMinima; set => cantidadMinima = value; }
        [Column("id_producto")]
        public int Id_producto { get => id_producto; set => id_producto = value; }
        [Column("id_sede")]
        public int IdSede { get => idSede; set => idSede = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Last { get => last; set => last = value; }
        [Column("activo")]
        public bool Activo { get => activo; set => activo = value; }
        [NotMapped]
        public string Mensaje { get => mensaje; set => mensaje = value; }
        [NotMapped]
        public string MensajeCantidadNegativa { get => mensajeCantidadNegativa; set => mensajeCantidadNegativa = value; }
        [NotMapped]
        public string MensajeCantidadInsuficiente { get => mensajeCantidadInsuficiente; set => mensajeCantidadInsuficiente = value; }
        [NotMapped]
        public string MensajeAsignadoCorrectamente { get => mensajeAsignadoCorrectamente; set => mensajeAsignadoCorrectamente = value; }
        [NotMapped]
        public string MensajeProductoYaAsignado { get => mensajeProductoYaAsignado; set => mensajeProductoYaAsignado = value; }
        [NotMapped]
        public string MensajeCantidadMinimaMenorACantidadMaxima { get => mensajeCantidadMinimaMenorACantidadMaxima; set => mensajeCantidadMinimaMenorACantidadMaxima = value; }
    }
}
