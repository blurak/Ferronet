using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.Tablas
{
    [Serializable]
    [Table("sede", Schema = "usuario")]
    public class ESede
    {
        private int id;
        private String nombre;
        private String ubicacion;
        private int idSuper;
        private String session;
        private DateTime last;
        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("ubicacion")]
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        [Column("id_super")]
        public int IdSuper { get => idSuper; set => idSuper = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Last { get => last; set => last = value; }
    }
}
