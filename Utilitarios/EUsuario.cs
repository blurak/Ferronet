using System;

namespace Utilitarios
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
        private String mensaje;
        private String url;
        private String mensajeContrasenaIncorrecta;
        private String mensajeSinSubsedeAsignada;
        private String mensajeBaneado;
        private String mensajeSesionesMaximas;
        private String mensajeUsuarioInexistente;
        private String mensajeUsernameNoDisponible;

        public string MensajeUsernameNoDisponible
        {
            get
            {
                return mensajeUsernameNoDisponible;
            }

            set
            {
                mensajeUsernameNoDisponible = value;
            }
        }

        public string MensajeSinSubsedeAsignada
        {
            get
            {
                return mensajeSinSubsedeAsignada;
            }

            set
            {
                mensajeSinSubsedeAsignada = value;
            }
        }
        public string MensajeBaneado
        {
            get
            {
                return mensajeBaneado;
            }

            set
            {
                mensajeBaneado = value;
            }
        }
        public string MensajeSesionesMaximas
        {
            get
            {
                return mensajeSesionesMaximas;
            }

            set
            {
                mensajeSesionesMaximas = value;
            }
        }
        public string MensajeUsuarioInexistente
        {
            get
            {
                return mensajeUsuarioInexistente;
            }

            set
            {
                mensajeUsuarioInexistente = value;
            }
        }
        public string MensajeContrasenaIncorrecta
        {
            get
            {
                return mensajeContrasenaIncorrecta;
            }

            set
            {
                mensajeContrasenaIncorrecta = value;
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

        public string Clave
        {
            get
            {
                return clave;
            }

            set
            {
                clave = value;
            }
        }

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

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public int IdRol
        {
            get
            {
                return idRol;
            }

            set
            {
                idRol = value;
            }
        }

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

        public string Ip
        {
            get
            {
                return ip;
            }

            set
            {
                ip = value;
            }
        }

        public string Mac
        {
            get
            {
                return mac;
            }

            set
            {
                mac = value;
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
    }
}
