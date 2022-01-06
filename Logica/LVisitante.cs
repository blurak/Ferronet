using Datos;
using Datos.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Utilitarios.Join;
using Utilitarios.Tablas;

namespace Logica
{
    public class LVisitante
    {
        private DIdioma datos = new DIdioma();

        public List<JoinIdiomaControles> ObtenerControlesImagen(int formulario)
        {
            DAOIdioma idioma = new DAOIdioma();

            //DataTable y = datos.obtenerControlesImagen(formulario);
            return idioma.obtenerControlesImagenes(formulario);
        }

        public List<JoinPedidoCliente> obtenerIdiomasRegitrados()
        {
            DAOIdioma idioma = new DAOIdioma();

            //DataTable y = datos.ObtenerIdiomasRegistrados();
            return idioma.obtenerIdiomasRegistrados();

        }

        public void registrarIdioma(EIdioma idioma)
        {
            DAOIdioma idio = new DAOIdioma();
            idio.agregarIdioma(idioma);
            //datos.RegistrarIdioma(idioma, terminacion);
        }


        public List<JoinPedidoCliente> obtenerFormularios()
        {
            DAOIdioma idio = new DAOIdioma();
            
            //DataTable y = datos.obtenerFormularios();
            return idio.obtenerFormularios();
        }

        public List<JoinIdiomaControles> obtenerControles(int idFormulario)
        {
            DAOIdioma idio = new DAOIdioma();
            
            return  idio.obtenerControles(idFormulario);
        }

        public List<JoinIdiomaControles> obtenerControlesTraducidosImagenes(int idFormulario, String terminacion)
        {
            DAOIdioma idio = new DAOIdioma();
            //DataTable y = datos.obtenerControlesTraducidosImagenes(idFormulario, terminacion);
            return idio.obtenerControlesTraducidosDeImagenes(idFormulario, terminacion); ;

        }

       public List<JoinIdiomaControles> obtenerControlesTraducidos(int idFormulario, String terminacion)  {
            DAOIdioma idio = new DAOIdioma();

            //DataTable y = datos.obtenerControlesTraducidos(idFormulario, terminacion);
            return idio.obtenerControles(idFormulario,terminacion);
        }

        public DataTable ModificarOInsertarIdiomaDeControles(String control, String terminacion, int id_formulario, String texto)
        {
            DataTable y = datos.ModificarOInsertarIdiomaDeControles(control, terminacion, id_formulario, texto);
            return y;
        }

        public Dictionary<String, String> devolver(String formulario, String terminacion)
        {
            Dictionary<String, String> resultado = new Dictionary<String, String>();

            DAOIdioma datos = new DAOIdioma();
            List<JoinIdiomaControles> lista = datos.obtenerControles(formulario, terminacion);
            foreach (JoinIdiomaControles idioma in lista)
            {
                String key = idioma.Control;
                String valor = idioma.Texto;
                resultado.Add(key, valor);
            }
            return resultado;
        }

        public EProducto CrearProducto(EProducto entrada, String extension, String nombreArchivo)
        {
            DateTime thisDay = DateTime.Now;

            if (!(string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".jpe", true) == 0 || string.Compare(extension, ".png", true) == 0))
            {
                entrada.SaveLocation = @"<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o png');</script>";
            }
            else
            {
                entrada.SaveLocation = "~\\Images\\productos";
                entrada.Milisegundo = thisDay.Minute.ToString() + thisDay.Millisecond.ToString();
                entrada.Imagen = "~\\Images\\productos" + "\\" + entrada.Milisegundo + nombreArchivo;
                if (entrada.Imagen != null)
                {
                    DProducto registrar = new DProducto();
                    entrada.Mensaje = @"<script type='text/javascript'>alert('imagen guardada correctamente');</script>";
                    entrada.Precio = 0;
                    entrada.Descripcion = String.Empty;
                    entrada.Categoria = 0;
                }
            }
            return entrada;
        }
    }
}
