using System;

namespace Encapsular
{
    public class EUsuario
    {
        private Int32 userId;
        private String clave;
        private String nombre;
        private String correo;
        private String userName;
        private Int32 idRol;
        private String session;
        private String ip;
        private String mac;

        public int UserId { get => userId; set => userId = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public string UserName { get => userName; set => userName = value; }
        public int IdRol { get => idRol; set => idRol = value; }
        public string Session { get => session; set => session = value; }
        public string Ip { get => ip; set => ip = value; }
        public string Mac { get => mac; set => mac = value; }
    }
}
