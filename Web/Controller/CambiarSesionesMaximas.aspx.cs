using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
public partial class View_CambiarSesionesMaximas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();

        LSede inicio = new LSede();
        try
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()), false);
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
            hashMap = datos.devolver("CambiarSesionesMaximas.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
            LCantidadDeSesionesMaximas.Text = hashMap["LCantidadDeSesionesMaximas"];
            LSeleccioneRol.Text = hashMap["LSeleccioneRol"];
            LCambiar.Text = hashMap["LCambiar"];
            RECantidadDeSesiones.ErrorMessage = hashMap["RECantidadDeSesiones"];
            BCambiar.Text = hashMap["BCambiar"];
        }
        catch (Exception)
        {

        }
    }

    protected void BCambiar_Click(object sender, EventArgs e)
    {
        String mensaje = "", Script="";
        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            mensaje = hashMap["MensajeCorrecto"];
        }
        catch (Exception)
        {

        }

        
        LSede logica = new LSede();
        logica.ObtenerUsuarioParaSessionesMax(int.Parse(DDLRoles.SelectedValue.ToString()),int.Parse(TBCantidadSesiones.Text.ToString()));
        DDLRoles.SelectedValue = "0";
        TBCantidadSesiones.Text = "";
        Script = @"<script type='text/javascript'>alert('" + mensaje + "');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", Script);
    }

 
}