using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios.Tablas
{
    [Serializable]
    [Table("auditoria", Schema = "security")]
    public class EAuditoria
    {
        private int id;
        private DateTime fecha;
        private String accion;
        private String schema;
        private String tabla;
        private String session;
        private String userBaseDatos;
        private String data;
        private String pk;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("fecha")]
        public DateTime Fecha { get => fecha; set => fecha = value; }
        [Column("accion")]
        public string Accion { get => accion; set => accion = value; }
        [Column("schema")]
        public string Schema { get => schema; set => schema = value; }
        [Column("tabla")]
        public string Tabla { get => tabla; set => tabla = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("user_bd")]
        public string UserBaseDatos { get => userBaseDatos; set => userBaseDatos = value; }
        [Column("data")]
        public String Data { get => data; set => data = value; }
        [Column("pk")]
        public string Pk { get => pk; set => pk = value; }

    }
}
