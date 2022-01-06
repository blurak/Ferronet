using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
    public class JoinDetallePedidoCliente
    {
        private int codigoDelProducto;
        private String descripcion;
        private int cantidad;
        private int precio;
        private int valorTotal;

        public int CodigoDelProducto { get => codigoDelProducto; set => codigoDelProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Precio { get => precio; set => precio = value; }
        public int ValorTotal { get => valorTotal; set => valorTotal = value; }
    }
}
