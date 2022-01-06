using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Utilitarios.Tablas
{
    [Serializable]
    [Table("detalle_pedido", Schema = "usuario")]

    public class EDetallePedido
    {
        private int id;
        private int valorUnitario;
        private int idProducto;
        private int idPedido;
        private int cantidad;
        private int valorTotal;
        private String session;
        private DateTime last;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("valor_unitario")]
        public int ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        [Column("id_producto")]
        public int IdProducto { get => idProducto; set => idProducto = value; }
        [Column("id_pedido")]
        public int IdPedido { get => idPedido; set => idPedido = value; }
        [Column("cantidad")]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        [Column("valor_total")]
        public int ValorTotal { get => valorTotal; set => valorTotal = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modified")]
        public DateTime Last { get => last; set => last = value; }
    }
}
