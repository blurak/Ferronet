using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Servicios
{
    public class Proveedores
    {
        private int codigo;
        private String nombre;
        private String correo;
        private String telefono;
        private String categoria;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Categoria { get => categoria; set => categoria = value; }
    }
}
