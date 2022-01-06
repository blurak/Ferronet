using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
    public class JoinUsuario
    {
        private int id;
        private String nombre;
        private String usuario;
        private String correo;
        private int estado;
        private String clave;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Estado { get => estado; set => estado = value; }
        public string Clave { get => clave; set => clave = value; }
    }
}
