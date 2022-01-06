using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_PedidosCajero : System.Web.UI.Page
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
            hashMap = datos.devolver("PedidosCajero.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
            IBConsulta.ImageUrl = hashMap["IBConsulta"];
            IBDespachar.ImageUrl = hashMap["IBDespachar"];
            LBPedidos.Text = hashMap["LBPedidos"];



        }
        catch (Exception)
        {

        }
    }
}