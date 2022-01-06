using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios.Join
{
    public class JoinProductoSubsede
    {
        int Codigo_producto;
        string Descripcion;
        int Cantidadminima;
        int Cantidad;
        double precio;
        int id_producto;
        private String imagen;
        private String categoria;
        private String subsede;

        public int Codigo_producto1
        {
            get
            {
                return Codigo_producto;
            }

            set
            {
                Codigo_producto = value;
            }
        }

        public string Descripcion1
        {
            get
            {
                return Descripcion;
            }

            set
            {
                Descripcion = value;
            }
        }

        public int Cantidadminima1
        {
            get
            {
                return Cantidadminima;
            }

            set
            {
                Cantidadminima = value;
            }
        }

        public int Cantidad1
        {
            get
            {
                return Cantidad;
            }

            set
            {
                Cantidad = value;
            }
        }

        public double Precio { get => precio; set => precio = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Subsede { get => subsede; set => subsede = value; }
    }
}
