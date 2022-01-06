using System;

namespace Utilitarios.Join
{
    public class JoinPedidoCliente
    {
        private  int numeroPedido;
        private String tipoDeEntrega;
        private String direccion;
        private int total;
        private String cliente;
        private String estado;
        

        public int NumeroPedido { get => numeroPedido; set => numeroPedido = value; }
        public string TipoDeEntrega { get => tipoDeEntrega; set => tipoDeEntrega = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Total { get => total; set => total = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
