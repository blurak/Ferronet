using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios.Tablas
{

    [Serializable]
    [Table("detalle_venta", Schema = "usuario")]
    public class EDetalleVenta
    {
        private int id;
        private int valorUnitario;
        private int idProducto;
        private int idVenta;
        private int cantidad;
        private int valorTotal;
        private string session;
        private DateTime last;
        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("valor_unitario")]
        public int ValorUnitario { get => valorUnitario; set => valorUnitario = value; }
        [Column("id_producto")]
        public int IdProducto { get => idProducto; set => idProducto = value; }
        [Column("id_venta")]
        public int IdVenta { get => idVenta; set => idVenta = value; }
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
