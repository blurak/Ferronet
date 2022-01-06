using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
    public class JoinDetallepedidoProducto
    {
        private String descripcion;
        private double precio;
        private int cantidad;
        private int valorTotal;

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int ValorTotal { get => valorTotal; set => valorTotal = value; }
    }
}
