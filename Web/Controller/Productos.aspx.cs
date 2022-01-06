using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Productos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
        try
        {
            LUsuario de = new LUsuario();

            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("productos.aspx", selectedLanguaje);

            LBusqueAquiSuProducto.Text = hashMap["LBusqueAquiSuProducto"];
            BBuscar.Text = hashMap["BBuscar"];
            GVProductos.Columns[0].HeaderText = hashMap["GVProductosColumna0"];
            GVProductos.Columns[1].HeaderText = hashMap["GVProductosColumna1"];
            GVProductos.Columns[2].HeaderText = hashMap["GVProductosColumna2"];
            GVProductos.Columns[3].HeaderText = hashMap["GVProductosColumna3"];
            GVProductos.Columns[4].HeaderText = hashMap["GVProductosColumna4"];
            GVProductos.Columns[5].HeaderText = hashMap["GVProductosColumna5"];
            GVProductos.EmptyDataText = hashMap["GVEmptyProducto"];

        }
        catch (Exception)
        {
            
        }
    }

}