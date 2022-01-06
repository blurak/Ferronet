using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ConsultaPedidosCajero : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LCajero inicio = new LCajero();
        try
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()));
        }
        catch (Exception we)
        {
            Response.Redirect("IniciarSesion.aspx");
        }
        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("ConsultaPedidosCajero.aspx", selectedLanguaje);
            GWDetalle.Columns[0].HeaderText = hashMap["GWDetalle0"];
            GWDetalle.Columns[1].HeaderText = hashMap["GWDetalle1"];
            GWDetalle.Columns[2].HeaderText = hashMap["GWDetalle2"];
            GWDetalle.Columns[3].HeaderText = hashMap["GWDetalle3"];
            GWPedido.Columns[1].HeaderText = hashMap["GWPedido0"];
            GWPedido.Columns[2].HeaderText = hashMap["GWPedido1"];
            GWPedido.Columns[3].HeaderText = hashMap["GWPedido2"];
            GWPedido.Columns[4].HeaderText = hashMap["GWPedido3"];
            GWPedido.Columns[5].HeaderText = hashMap["GWPedido4"];
            GWPedido.Columns[6].HeaderText = hashMap["GWPedido5"];
            LBPedidos.Text = hashMap["LBPedidos"];            
            LBSeleccione.Text = hashMap["LBSeleccione"];            
            IBSalir.ImageUrl = hashMap["IBSalir"];
            GWPedido.EmptyDataText = hashMap["EmptyGWPedido"];
            GWDetalle.EmptyDataText = hashMap["EmptyGWDetalle"];




        }
        catch (Exception)
        {

        }
    }
}