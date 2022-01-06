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
    [Table("token_recuperacion_usuario", Schema = "usuario")]
    public class EtokenRecuperacionUsuario
    {
        private Int32 id;
        private String nombre;
        private String correo;
        private String user_name;
        private Int32 estado;
        private long fecha;
        private Int32 userId;
        private String token;
        private DateTime fechaCreado;
        private DateTime fechaVigencia;
       
        [NotMapped]
        public string Nombre { get => nombre; set => nombre = value; }
        [NotMapped]
        public string Correo { get => correo; set => correo = value; }
        [NotMapped]
        public string User_name { get => user_name; set => user_name = value; }
        [NotMapped]
        public int Estado { get => estado; set => estado = value; }
        [NotMapped]
        public long Fecha { get => fecha; set => fecha = value; }

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("user_id")]
        public int UserId { get => userId; set => userId = value; }
        [Column("token")]
        public string Token { get => token; set => token = value; }
        [Column("fecha_creado")]
        public DateTime FechaCreado { get => fechaCreado; set => fechaCreado = value; }
        [Column("fecha_vigencia")]
        public DateTime FechaVigencia { get => fechaVigencia; set => fechaVigencia = value; }

       
       
    }
}
