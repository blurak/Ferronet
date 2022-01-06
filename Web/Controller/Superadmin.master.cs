using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;

public partial class View_Superadmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("Superadmin.master", selectedLanguaje);
            IBAdministracionSubsede.ImageUrl = hashMap["IBAdministracionSubsede"];
            IBInventarioPrincipal.ImageUrl = hashMap["IBInventarioPrincipal"];
            IBConsultas.ImageUrl = hashMap["IBConsultas"];
            IBProveedores.ImageUrl = hashMap["IBProveedores"];
            ISuperAdmin.ImageUrl = hashMap["ISuperAdmin"];
            IBConfiguracion.ImageUrl = hashMap["IBConfiguracion"];
            


        }
        catch (Exception)
        {

        }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsultasSubsede.aspx");
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
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

