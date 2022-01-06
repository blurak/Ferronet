using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
    public class JoinProductosSubsede
    {
        int idProducto;
        String descripcion;
        Double precio;
        int cantidad;
        int cantidadMin;
        int valorunitario;
        string categoria;
        string imagen;

    

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int CantidadMin { get => cantidadMin; set => cantidadMin = value; }
        public int Valorunitario { get => valorunitario; set => valorunitario = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Imagen { get => imagen; set => imagen = value; }
    }
}
