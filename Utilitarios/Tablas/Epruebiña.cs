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
    [Table("pruebaa", Schema = "usuario")]
    public class Epruebiña
    {
        private int id;
        private String nombre;
        private int correo;
        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("numero")]
        public int Correo { get => correo; set => correo = value; }
    }
}
