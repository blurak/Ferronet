using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
   public class EEstadoPedido
    {
        int id_pedido;
        string tipoDeEntrega;
        string Direccion;
        int total;
        String Nombre;
        string Estado;

        public int Id_pedido
        {
            get
            {
                return id_pedido;
            }

            set
            {
                id_pedido = value;
            }
        }

        public string TipoDeEntrega
        {
            get
            {
                return tipoDeEntrega;
            }

            set
            {
                tipoDeEntrega = value;
            }
        }

        public string Direccion1
        {
            get
            {
                return Direccion;
            }

            set
            {
                Direccion = value;
            }
        }

        public int Total
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

        public string Nombre1
        {
            get
            {
                return Nombre;
            }

            set
            {
                Nombre = value;
            }
        }

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
