using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
public partial class View_RecuperarContrasena : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LUsuario validar = new LUsuario();

        String selectedLanguaje = Session["terminacion"].ToString();
        String script=validar.verificarToken(Request.QueryString.Count, Request.QueryString[0],selectedLanguaje);

        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);

        Session["user_id"] = script;

        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("RecuperarContrasena.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
            LDigiteSuNueva.Text = hashMap["LDigiteSuNueva"];
            LRepitaContrasena.Text = hashMap["LRepitaContrasena"];
            BCambiar.Text = hashMap["BCambiar"];
            REContrasenaExpresion.ErrorMessage = hashMap["REContrasenaExpresion"];
            RERepitaExpresion.ErrorMessage = hashMap["RERepitaExpresion"];
        }

        catch (Exception)
        {

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        String MensajeContrasenasNoIguales = "";
        String MensajeContrasenaCambiada = "";
        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
             MensajeContrasenasNoIguales = hashMap["MensajeContrasenasNoIguales"];
            MensajeContrasenaCambiada = hashMap["MensajeContrasenaCambiada"];
        }
        catch (Exception)
        {

        }
        LUsuario logica = new LUsuario();
        String ejecutar=logica.cambioContrasena(TB_1.Text.ToString(), TB_2.Text.ToString(), Session["user_id"].ToString(),MensajeContrasenasNoIguales,MensajeContrasenaCambiada);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", ejecutar);

    }

    protected void TB_1_TextChanged(object sender, EventArgs e)
    {

    }
}