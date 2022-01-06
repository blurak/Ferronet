using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.Tablas
{
    [Serializable]
    [Table("controles", Schema = "idioma")]
    public class EControles
    {
        private int id;
        private String control;
        private int idIdioma;
        private int idFormulario;
        private String texto;
        private String session;
       
    
        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("control")]
        public string Control { get => control; set => control = value; }
        [Column("id_idioma")]
        public int IdIdioma { get => idIdioma; set => idIdioma = value; }
        [Column("id_formulario")]
        public int IdFormulario { get => idFormulario; set => idFormulario = value; }
        [Column("texto")]
        public string Texto { get => texto; set => texto = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
       
    }
}
