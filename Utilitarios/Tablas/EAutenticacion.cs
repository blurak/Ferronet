using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("autenticacion", Schema = "security")]
    public class EAutenticacion
    {

        private Int64 id;
        private int idUsuario;
        private String ip;
        private String mac;
        private DateTime fechaInicio;
        private String session;
        private DateTime fechaFin;

        [Key]
        [Column("id")]
        public Int64 Id { get => id; set => id = value; }
        [Column("user_id")]
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        [Column("ip")]
        public string Ip { get => ip; set => ip = value; }
        [Column("mac")]
        public string Mac { get => mac; set => mac = value; }
        [Column("fecha_inicio")]
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("fecha_fin")]
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
    }
}