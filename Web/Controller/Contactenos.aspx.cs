using System;
using System.Net.Mail;
using Utilitarios;
using Logica;
using System.Collections.Generic;

public partial class View_Contactenos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("Contactenos.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
            LCuentanos.Text = hashMap["LCuentanos"];
            LInquietudes.Text = hashMap["LInquietudes"];
            LNombre.Text = hashMap["LNombre"];
            LCorreoElectronico.Text = hashMap["LCorreoElectronico"];
            LAsunto.Text = hashMap["LAsunto"];
            LMensaje.Text = hashMap["LMensaje"];
            BEnviar.Text = hashMap["BEnviar"];
            REAsuntoExpresion.ErrorMessage = hashMap["REAsuntoExpresion"];
            REMensajeExpresion.ErrorMessage = hashMap["REMensajeExpresion"];
            RENombreExpresion.ErrorMessage = hashMap["RENombreExpresion"];

        }
        catch (Exception)
        {

        }

    }

    protected void BT_enviar_Click(object sender, EventArgs e)
    {
        EEmail pqr = new EEmail();

        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            pqr.MensajeCorreoEnviado= hashMap["MensajeCorreoEnviado"];
            pqr.MensajeCorreoNoEnviado = hashMap["MensajeCorreoNoEnviado"];
        }
        catch (Exception)
        {

        }

        

        pqr.Nombre = TB_nombre.Text;
        pqr.Email = TB_email.Text;
        pqr.Asunto = TB_asunto.Text;
        pqr.Mensaje = TBMensaje.ToString();

        LUsuario contactenos = new LUsuario();
        String selectedLanguaje = Session["terminacion"].ToString();
        pqr = contactenos.enviarCorreoContactenos(pqr,selectedLanguaje);

        TB_nombre.Text=pqr.Nombre;
        TB_email.Text=pqr.Email;
        TB_asunto.Text=pqr.Asunto;
        TBMensaje.Text=pqr.Mensaje;

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message",pqr.Script);
    }

}