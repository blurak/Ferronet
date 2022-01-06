using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Datos;
using System.Data;
using Utilitarios.Tablas;

namespace Logica
{
    public class LProducto
    {
        public void borrarproducto(Int32 id_producto, Int32 sede)
        {

            DProducto modifica = new DProducto();
            modifica.BorrarProductos(id_producto, sede);
        }
        public EProducto EliminarProducto(EProducto entrada, int idUsuario,String mensajeBorradoCorrectamente)
        {
            DProducto consultar = new DProducto();
            DProducto consultar2 = new DProducto();
            DAOSede datos = new DAOSede();
            ESede encapsulado=datos.DevolverSede(idUsuario);
            //DataTable y = consultar.obtenerSede(idUsuario);
            //int sede = int.Parse(y.Rows[0]["id_sede"].ToString());
            int sede = encapsulado.Id;
            consultar2.BorrarProductos(entrada.IdProducto, sede);


            entrada.Mensaje = @"<script type='text/javascript'>alert('"+mensajeBorradoCorrectamente+"');</script>";
            return entrada;
        }

        //public Dictionary<String,String> devolver(String formulario,String terminacion)
        //{
        //    Dictionary<String, String> resultado = new Dictionary<String, String>();
        //    DRutas datos = new DRutas();
        //     var items= datos.obtenerControles(formulario, terminacion);
        //    foreach (DataRow dr in items.Rows)
        //    {
        //        for (int rr = 0; rr < 1; rr++)
        //        {

                    
        //            String key = (String)dr[rr].ToString();
        //            String valor = (String)dr[rr + 1].ToString();
        //            resultado.Add(key, valor);

        //        }
        //    }
        //    return resultado;
        //}
    }
}
