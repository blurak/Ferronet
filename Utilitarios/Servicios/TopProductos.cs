using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Servicios
{
    public class TopProductos
    {
        private String imagen;
        private int codigo;
        private String descripcion;
        private String categoria;
        private double precio;
        private String subsede;

        public string Imagen { get => imagen; set => imagen = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public double Precio { get => precio; set => precio = value; }
        public string Subsede { get => subsede; set => subsede = value; }
    }
}
