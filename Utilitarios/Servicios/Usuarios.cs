using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Servicios
{
   public  class Usuarios
    {
        private String nombre;
        private String correo;
        private String clave;
        private String usuario;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Usuario { get => usuario; set => usuario = value; }
    }
}
