using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
    public class JoinProductosProximosATerminar
    {
        private int codigoRegistro;
        private int codigoProducto;
        private String subsede;
        private String producto;
        private String categoria;
        private int cantidad;
        private int cantidadMinima;
        private int cantidadDisponible;

        public int CodigoProducto { get => codigoProducto; set => codigoProducto = value; }
        public string Subsede { get => subsede; set => subsede = value; }
        public string Producto { get => producto; set => producto = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int CantidadMinima { get => cantidadMinima; set => cantidadMinima = value; }
        public int CantidadDisponible { get => cantidadDisponible; set => cantidadDisponible = value; }
        public int CodigoRegistro { get => codigoRegistro; set => codigoRegistro = value; }
    }
}
