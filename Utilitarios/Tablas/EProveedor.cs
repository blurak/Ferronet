using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("proveedores", Schema = "usuario")]

    public class EProveedor
    {
        private int id;
        private String nombre;
        private String correo;
        private String telefono;
        private int idCategoria;
        private int idSede;
        private String session;
        private String script;
        private DateTime last;
        [Key]
        [Column("id")]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        [Column("nombre")]
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
        [Column("correo")]
        public string Correo
        {
            get
            {
                return correo;
            }

            set
            {
                correo = value;
            }
        }
        [Column("telefono")]
        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }
        [Column("id_categoria")]
        public int IdCategoria
        {
            get
            {
                return idCategoria;
            }

            set
            {
                idCategoria = value;
            }
        }

        [Column("id_sede")]
        public int IdSede
        {
            get
            {
                return idSede;
            }

            set
            {
                idSede = value;
            }
        }

        [Column("session")]
        public string Session
        {
            get
            {
                return session;
            }

            set
            {
                session = value;
            }
        }
        [NotMapped]
        public string Script
        {
            get
            {
                return script;
            }

            set
            {
                script = value;
            }
        }

        [Column("last_modified")]
        public DateTime Last { get => last; set => last = value; }
    }
}
