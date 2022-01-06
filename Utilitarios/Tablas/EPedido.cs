using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("pedido", Schema = "usuario")]
    public class EPedido
    {
        private int cantidad;
        private int idSubsede;
        private int codigo;
        private String descripcion;
        private double precio;
        private String mensaje;
        private DataTable pedido;
        private double total;
        private String tipoEntrega;
        private String direccion;
        private int valorTotal;
        private int idUsuario;
        private String session;
        private int idPedido;
        private int idProducto;
        private int valorTotalProducto;
        private DataTable sesionsub;
        private String mensajeProductoAgregado;
        private String mensajeProductoYaAgregado;
        private String mensajeProductosDeDiferentesSedes;
        private String mensajePedidoActivo;
        private String mensajePedidoHecho;
        private String mensajeProductosNoDisponibles;
        private String mensajeSinProductosEnELCarrito;
        private string Estado;
        private DateTime hora;
        private DateTime last;

        [Column("last_modified")]
        public DateTime Last
        {
            get
            {
                return last;
            }

            set
            {
                last = value;
            }
        }


        [Column("hora")]
        public DateTime Hora
        {
            get
            {
                return hora;
            }

            set
            {
                hora = value;
            }
        }

        [NotMapped]
        public string MensajePedidoActivo
        {
            get
            {
                return mensajePedidoActivo;
            }

            set
            {
                mensajePedidoActivo = value;
            }
        }
        [NotMapped]
        public string MensajePedidoHecho
        {
            get
            {
                return mensajePedidoHecho;
            }

            set
            {
                mensajePedidoHecho = value;
            }
        }
        [NotMapped]
        public string MensajeProductosNoDisponibles
        {
            get
            {
                return mensajeProductosNoDisponibles;
            }

            set
            {
                mensajeProductosNoDisponibles = value;
            }
        }
        [NotMapped]
        public string MensajeSinProductosEnELCarrito
        {
            get
            {
                return mensajeSinProductosEnELCarrito;
            }

            set
            {
                mensajeSinProductosEnELCarrito = value;
            }
        }
        [NotMapped]
        public string MensajeProductoAgregado
        {
            get
            {
                return mensajeProductoAgregado;
            }

            set
            {
                mensajeProductoAgregado = value;
            }
        }
        [NotMapped]
        public string MensajeProductoYaAgregado
        {
            get
            {
                return mensajeProductoYaAgregado;
            }

            set
            {
                mensajeProductoYaAgregado = value;
            }
        }
        [NotMapped]
        public string MensajeProductosDeDiferentesSedes
        {
            get
            {
                return mensajeProductosDeDiferentesSedes;
            }

            set
            {
                mensajeProductosDeDiferentesSedes = value;
            }
        }

        [NotMapped]
        public DataTable Sesionsub
        {
            get
            {
                return sesionsub;
            }

            set
            {
                sesionsub = value;
            }
        }
        [Column("id_usuario")]
        public int IdUsuario
        {
            get
            {
                return idUsuario;
            }

            set
            {
                idUsuario = value;
            }
        }
        [Key]
        [Column("id")]
        public int IdPedido
        {
            get
            {
                return idPedido;
            }

            set
            {
                idPedido = value;
            }
        }
        [NotMapped]
        public int IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
            }
        }
        [NotMapped]
        public int ValorTotalProducto
        {
            get
            {
                return valorTotalProducto;
            }

            set
            {
                valorTotalProducto = value;
            }
        }
        [Column("valor_total")]
        public int ValorTotal
        {
            get
            {
                return valorTotal;
            }

            set
            {
                valorTotal = value;
            }
        }
        [Column("session")]
        public string Session
        {
            get
            {
                return session;
            }

            set
            {
                session = value;
            }
        }
        [Column("direccion")]
        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }
        [Column("tipo_entrega")]
        public string TipoEntrega
        {
            get
            {
                return tipoEntrega;
            }

            set
            {
                tipoEntrega = value;
            }
        }

        [NotMapped]
        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
        [NotMapped]
        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }
        [Column("id_subsede")]
        public int IdSubsede
        {
            get
            {
                return idSubsede;
            }

            set
            {
                idSubsede = value;
            }
        }
        [NotMapped]
        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }
        [NotMapped]
        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }
        [NotMapped]
        public double Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }
        [NotMapped]
        public string Mensaje
        {
            get
            {
                return mensaje;
            }

            set
            {
                mensaje = value;
            }
        }
        [NotMapped]
        public DataTable Pedido
        {
            get
            {
                return pedido;
            }

            set
            {
                pedido = value;
            }
        }
        [Column("estado")]
        public string Estado1
        {
            get
            {
                return Estado;
            }

            set
            {
                Estado = value;
            }
        }
    }
}
