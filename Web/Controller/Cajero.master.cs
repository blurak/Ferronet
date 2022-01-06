using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_Cajero : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
  
        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("Cajero.master", selectedLanguaje);
            Session["idioma"] = hashMap;
            ICajero.ImageUrl = hashMap["ICajero"];
            IBInventario.ImageUrl = hashMap["IBInventario"];
            IBRegistrarVentas.ImageUrl = hashMap["IBRegistrarVentas"];
            IBPedidos.ImageUrl = hashMap["IBPedidos"];
            BTNPlato.Text = hashMap["BTNPlato"];

        }
        catch (Exception)
        {

        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["user_id"] = null;
        Session["user_name"] = null;

        EUsuario datos = new EUsuario();
        datos.Session = Session.SessionID;
        LUsuario user = new LUsuario();
        user.CerrarSesion(datos);

        Response.Redirect("IniciarSesion.aspx");
    }



    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        LUsuario o = new LUsuario();
        if (Session["user_id"] != null)
        {
            o.restarsessiones(int.Parse(Session["user_id"].ToString()));
            Session["user_id"] = null;
            Session["user_name"] = null;

            EUsuario datos = new EUsuario();
            datos.Session = Session.SessionID;
            LUsuario user = new LUsuario();
            user.CerrarSesion(datos);

            Response.Redirect("IniciarSesion.aspx");
        }
        else
        {
            Response.Redirect("IniciarSesion.aspx");
        }
    }

    protected void BTNPlato_Click(object sender, EventArgs e)
    {
        String script = @"<script type='text/javascript'> var pop2; pop2 = window.open('PromocionesPlatos.aspx', 'platos', 'width=900, height=700,menubar=si');
    pop2.focus();</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
    }
}

