using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("categoria", Schema = "usuario")]

    public class ECategoria
    {
       
        private int id;
        private String nombre;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
