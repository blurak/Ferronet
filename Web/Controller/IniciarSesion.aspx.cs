using System;
using System.Data;
using Utilitarios;
using Logica;
using System.Web.UI;
using System.Collections.Generic;
using Utilitarios.Servicios;
using Datos.Persistencia;

public partial class View_IniciarSesion : System.Web.UI.Page
{
    public DAOServicio serviciodatos = new DAOServicio();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("IniciarSesion.aspx", selectedLanguaje);
            LIniciarSesion.Text = hashMap["LIniciarSesion"];
            Session["idioma"] = hashMap;
            LUsername.Text = hashMap["LUsername"];
            LContrasena.Text = hashMap["LContrasena"];
            HPOlvidoSuContrasena.Text = hashMap["HPOlvidoSuContrasena"];
            BIniciarSesion.Text = hashMap["BIniciarSesion"];
            REContrasenaExpresion.ErrorMessage = hashMap["REContrasenaExpresion"];
            REUsernameExpresion.ErrorMessage = hashMap["REUsernameExpresion"];
        }
        catch (Exception)
        {

        }
    }


   

    protected void LB_Recuperar_Click(object sender, EventArgs e)
    {
       Response.Redirect("GenerarToken.aspx");
    }



    protected void BTN_iniciar_Click(object sender, EventArgs e)
    {
        PUsuario datos = new PUsuario();
        LUsuario logica = new LUsuario();
        String selectedLanguaje = Session["terminacion"].ToString();

        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            datos.MensajeSinSubsedeAsignada = hashMap["MensajeUsuarioSinSubsede"];
            datos.MensajeContrasenaIncorrecta = hashMap["MensajeContrasenaIncorrecta"];
            datos.MensajeBaneado = hashMap["MensajeBaneado"];
            datos.MensajeSesionesMaximas = hashMap["MensajeSesionesMaximas"];
            datos.MensajeUsuarioInexistente = hashMap["MensajeUsuarioInexistente"];
        }
        catch (Exception)
        {

        }

        datos.Usuario = TB_username.Text.ToString();
        datos.Clave = TB_contrasena.Text.ToString();
        datos.Session = Session.SessionID;
        datos = logica.logear(datos);

        Session["user_id"] = datos.Id;
        Session["id_rol"] = datos.IdRol;
        Session["pedido"] = null;
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", datos.Mensaje, false);
        TB_username.Text = datos.Usuario;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String ejecutar = @"<script type='text/javascript'>ErrorDeInicio();</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", ejecutar, false);
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        String ejecutar = @"<script type='text/javascript'>ErrorDeInicio();</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", ejecutar, false);
    }

    protected void Button1_Click2(object sender, EventArgs e)
    {
        String ejecutar = @"<script type='text/javascript'>RedireccionarSuper();</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", ejecutar, false);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        String script = @"<script type='text/javascript'> var pop2; pop2 = window.open('PromocionesPlatos.aspx', 'platos', 'width=900, height=530,menubar=si');
    pop2.focus();</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
    }
}