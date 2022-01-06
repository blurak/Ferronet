using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Administrador : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("Administrador.master", selectedLanguaje);

            IAdministrador.ImageUrl = hashMap["IAdministrador"];
            IBCajeroAsignado.ImageUrl = hashMap["IBCajeroAsignado"];
            IBConsultarPedidos.ImageUrl = hashMap["IBConsultarPedidos"];
            IBConsultarVentas.ImageUrl = hashMap["IBConsultarVentas"];
            IBInventarioActual.ImageUrl = hashMap["IBInventarioActual"];
        }
        catch (Exception)
        {

        }
        
    }

    protected void BtnCerrarSesion_Click(object sender, ImageClickEventArgs e)
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
}
