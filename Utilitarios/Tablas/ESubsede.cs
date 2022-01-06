using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{

    [Serializable]
    [Table("sub_sede", Schema = "usuario")]
    public class ESubsede
    { 

        string nombre;
        string ubicacion;
        int idAdmin;
        int idCajero;
        int idSede;
        int id;
        private String session;
        private String mensaje;
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

        [Column("ubicacion")]
        public string Ubicacion
        {
            get
            {
                return ubicacion;
            }

            set
            {
                ubicacion = value;
            }
        }

        [Column("id_admin")]
        public int IdAdmin
        {
            get
            {
                return idAdmin;
            }

            set
            {
                idAdmin = value;
            }
        }

        [Column("id_cajero")]
        public int IdCajero
        {
            get
            {
                return idCajero;
            }

            set
            {
                idCajero = value;
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

        [Column("last_modified")]
        public DateTime Last { get => last; set => last = value; }

        [NotMapped]
        public string Mensaje
        {
            get
            {
                return mensaje;
            }

            set
            {
                mensaje = value;
            }
        }

       
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Utilitarios
//{
//    public class ESubsede
//    {







//        private String nombre;
//        private String ubicacion;
//        private Int32 idAdmin;
//        private Int32 idCajero;
//        private Int32 idSede;
//        private String session;
//        private String mensaje;

//        public string Nombre
//        {
//            get
//            {
//                return nombre;
//            }

//            set
//            {
//                nombre = value;
//            }
//        }

//        public string Ubicacion
//        {
//            get
//            {
//                return ubicacion;
//            }

//            set
//            {
//                ubicacion = value;
//            }
//        }

//        public int IdAdmin
//        {
//            get
//            {
//                return idAdmin;
//            }

//            set
//            {
//                idAdmin = value;
//            }
//        }

//        public int IdCajero
//        {
//            get
//            {
//                return idCajero;
//            }

//            set
//            {
//                idCajero = value;
//            }
//        }

//        public int IdSede
//        {
//            get
//            {
//                return idSede;
//            }

//            set
//            {
//                idSede = value;
//            }
//        }

//        public string Session
//        {
//            get
//            {
//                return session;
//            }

//            set
//            {
//                session = value;
//            }
//        }

//        public string Mensaje
//        {
//            get
//            {
//                return mensaje;
//            }

//            set
//            {
//                mensaje = value;
//            }
//        }
//    }
//}
