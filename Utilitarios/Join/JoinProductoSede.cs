using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class JoinProductoSede
    {
        private int Codigo_producto;
        private String descripcion;
        private int Cantidadd;
        private int CantidadMin;
        private String imagen;
        private int codigo;
        private String categoria;
        private double precio;

        public int Codigo_producto1 { get => Codigo_producto; set => Codigo_producto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidadd1 { get => Cantidadd; set => Cantidadd = value; }
        public int CantidadMin1 { get => CantidadMin; set => CantidadMin = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public int Codigo { get => codigo; set => codigo = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public double Precio { get => precio; set => precio = value; }
    }
}
