using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.Tablas
{
    [Serializable]
    [Table("idioma", Schema = "idioma")]
    public class EIdioma
    {
        private int id;
        private String nombre;
        private String terminacion;
        private String session;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("terminacion")]
        public string Terminacion { get => terminacion; set => terminacion = value; }
        [NotMapped]
        public string Session { get => session; set => session = value; }
    }
}
