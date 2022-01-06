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
    [Table("ventas", Schema = "usuario")]
    public class Eventas
    {
        int id;
        int idSubsede;
        string session;
        int valorTotal;
        int idUsusario;
        string dia;
        string hora;
        DateTime diacompa;
        private DateTime last;
        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("id_subsede")]
        public int IdSubsede { get => idSubsede; set => idSubsede = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("valor_total")]
        public int ValorTotal { get => valorTotal; set => valorTotal = value; }
        [Column("id_usuario")]
        public int IdUsusario { get => idUsusario; set => idUsusario = value; }
        [Column("dia")]
        public string Dia { get => dia; set => dia = value; }
        [Column("hora")]
        public string Hora { get => hora; set => hora = value; }
        [Column("diacompa")]
        public DateTime Diacompa { get => diacompa; set => diacompa = value; }
        [Column("last_modified")]
        public DateTime Last { get => last; set => last = value; }
    }
}
