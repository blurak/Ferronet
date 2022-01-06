using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.Tablas
{
    [Serializable]
    [Table("servicio", Schema = "usuario")]
    public class EServicio
    {
        private int id;
        private String usuario;
        private String contrasena;
        private String token;
        private DateTime validez;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("usuario")]
        public string Usuario { get => usuario; set => usuario = value; }
        [Column("contrasena")]
        public string Contrasena { get => contrasena; set => contrasena = value; }
        [Column("token")]
        public string Token { get => token; set => token = value; }
        [Column("validez")]
        public DateTime Validez { get => validez; set => validez = value; }
    }
}
