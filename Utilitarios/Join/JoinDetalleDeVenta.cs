using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
    public class JoinDetalleDeVenta
    {
        string producto;
        int cantidad;
        int precio;
        int valorTotal;
        private String descripcion;

        public string Producto { get => producto; set => producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Precio { get => precio; set => precio = value; }
        public int ValorTotal { get => valorTotal; set => valorTotal = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
