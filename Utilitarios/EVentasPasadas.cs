using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    public class EVentasPasadas
    {
        private int idCajero;
        private int idSubsede;
        private int idVenta;
        private DataTable ventaSesion;
        private int cantidad;
        private double precio;
        private double total;
        private int idProducto;
        private String descripcion;
        private String mensaje;
        private int cantidadDisponible;
        private DateTime dia;
        private String hora;

        public int CantidadDisponible
        {
            get
            {
                return cantidadDisponible;
            }

            set
            {
                cantidadDisponible = value;
            }
        }

        public int IdVenta
        {
            get
            {
                return idVenta;
            }

            set
            {
                idVenta = value;
            }
        }
        public DateTime Dia
        {
            get
            {
                return dia;
            }

            set
            {
                dia = value;
            }
        }
        public String Hora
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
        public String Mensaje
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
        public String Descripcion
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

        public int IdCajero
        {
            get
            {
                return idCajero;
            }

            set
            {
                idCajero = value;
            }
        }

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

        public DataTable VentaSesion
        {
            get
            {
                return ventaSesion;
            }

            set
            {
                ventaSesion = value;
            }
        }

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
    }
}

