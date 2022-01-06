using Logica;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_PromocionesPlatos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            PlatoWeb.ServiciosSoapClient obwsClientesSoap = new PlatoWeb.ServiciosSoapClient();
            obwsClientesSoap.ClientCredentials.UserName.UserName = "";

            PlatoWeb.Seguridad objclsSeguridad = new PlatoWeb.Seguridad()
            {
                stToken = DateTime.Now.ToString("yyyyMMdd")
            };

            String stToken = obwsClientesSoap.AutenticationUsuario(objclsSeguridad);

            if (stToken.Equals("-1"))
                throw new Exception("Requiere validacion");


            objclsSeguridad.AutenticationToken = stToken;
            Productos fr = new Productos();
            String ofertas = obwsClientesSoap.TopPlatos(objclsSeguridad);
            DataTable ofer = JsonConvert.DeserializeObject<DataTable>(ofertas);
            GWPlatos.DataSource = ofer;
            GWPlatos.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<Script Language='JavaScript'>parent.alert('" + ex.Message + "');</Script>");
        }


        try
        {

            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("PromocionesPlatos.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LBNombre.Text = hashMap["LBNombre"];
            LBEmail.Text = hashMap["LBEmail"];
            LTelefono.Text = hashMap["LTelefono"];
            LMensaje.Text = hashMap["LMensaje"];
            BtnEnviar.Text = hashMap["BtnEnviar"];
            BtnSalir.Text = hashMap["BtnSalir"];

        }
        catch (Exception)
        {

        }

    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void GWPlatos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Response.Redirect("http://platoweb.ddns.net/View/Loggin.aspx");
    }

    protected void BtnSalir_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", @"<script type='text/javascript'>window.close();</script>", false);
        String ejecutar = @"<script type='text/javascript'>window.close();</script>";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", ejecutar);
    }

    protected void BtnEnviar_Click(object sender, EventArgs e)
    {
        try
        {

            PlatoWeb.ServiciosSoapClient obwsClientesSoap = new PlatoWeb.ServiciosSoapClient();
            obwsClientesSoap.ClientCredentials.UserName.UserName = "";

            PlatoWeb.Seguridad objclsSeguridad = new PlatoWeb.Seguridad()
            {
                stToken = DateTime.Now.ToString("yyyyMMdd")
            };

            String stToken = obwsClientesSoap.AutenticationUsuario(objclsSeguridad);

            if (stToken.Equals("-1"))
                throw new Exception("Requiere validacion");

            PlatoWeb.UUser user = new PlatoWeb.UUser();
            objclsSeguridad.AutenticationToken = stToken;
            user = obwsClientesSoap.Contactenos(objclsSeguridad,TBNombre.Text,TBEmail.Text,TBTelefono.Text,TBMensaje.Text);
            String ejecutar = @"<script type='text/javascript'>alert('Procesado correctamente');</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", ejecutar);
            TBEmail.Text = String.Empty;
            TBMensaje.Text = String.Empty;
            TBNombre.Text = String.Empty;
            TBTelefono.Text = String.Empty;
        }
        catch (Exception ex)
        {
            Response.Write("<Script Language='JavaScript'>parent.alert('" + ex.Message + "');</Script>");
        }
    }
}