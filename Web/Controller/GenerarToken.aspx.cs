using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Data;

public partial class View_GenerarToken : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LMensaje.Text = "";
        try
        {

            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("GenerarToken.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
            LInstruccion.Text = hashMap["LInstruccion"];
            LUsername.Text = hashMap["LUsername"];
            BRecuperar.Text = hashMap["BRecuperar"];
            REUsernameExpresion.ErrorMessage = hashMap["REUsernameExpresion"];


        }
        catch (Exception)
        {

        }
    }

    protected void BT_recuperar_Click(object sender, EventArgs e)
    {

        String mensajeEnviado = "";
        String mensajeTokenExistente = "";
        String mensajeUsuarioInexistente = "";
        String mensajeCorreo = "";
        try     
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
             mensajeEnviado = hashMap["mensajeEnviado"];
             mensajeTokenExistente = hashMap["mensajeTokenExistente"];
             mensajeUsuarioInexistente = hashMap["mensajeUsuarioInexistente"];
            mensajeCorreo = hashMap["mensajeCorreo"];
        }
        catch (Exception)
        {

        }
       

        LUsuario u = new LUsuario();
        String selectedLanguaje = Session["terminacion"].ToString();
        LMensaje.Text = u.recuperarContrasena(TB_username.Text.ToString(),selectedLanguaje,mensajeEnviado,mensajeTokenExistente,mensajeUsuarioInexistente,mensajeCorreo);
    }

    
}