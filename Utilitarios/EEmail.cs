using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class EEmail
    {
        private String nombre;
        private String email;
        private String asunto;
        private String mensaje;
        private String script;
        private String mensajeCorreoEnviado;
        private String mensajeCorreoNoEnviado;

        public string MensajeCorreoEnviado
        {
            get
            {
                return mensajeCorreoEnviado;
            }

            set
            {
                mensajeCorreoEnviado = value;
            }
        }

        public string MensajeCorreoNoEnviado
        {
            get
            {
                return mensajeCorreoNoEnviado;
            }

            set
            {
                mensajeCorreoNoEnviado = value;
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

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Asunto
        {
            get
            {
                return asunto;
            }

            set
            {
                asunto = value;
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
    }
}
