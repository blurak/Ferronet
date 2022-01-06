using System;

namespace Utilitarios
{
    public class UUsuario
    {
        private String url;
        private Int32 userId;
        private Int32 rolId;
        private String mensaje;

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public int UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }

        public int RolId
        {
            get
            {
                return rolId;
            }

            set
            {
                rolId = value;
            }
        }

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
