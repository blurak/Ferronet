using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_UniempleOfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ServicioUniempleo.ServidorUniempleoSoapClient obwsClientesSoap = new ServicioUniempleo.ServidorUniempleoSoapClient();
            obwsClientesSoap.ClientCredentials.UserName.UserName = "ferronet";
            obwsClientesSoap.ClientCredentials.UserName.Password = "9p8mSXrM5v";

            ServicioUniempleo.SeguridadToken objclsSeguridad = new ServicioUniempleo.SeguridadToken()
            {
                username = "ferronet",
                Pass = "9p8mSXrM5v"
            };

            String token = obwsClientesSoap.AutenticacionUsuario(objclsSeguridad);

            if (token.Equals("-1"))
                throw new Exception("Requiere validacion");

            objclsSeguridad.Token_Autenticacion = token;
            DataSet a = obwsClientesSoap.Top_5_Empresas(objclsSeguridad);
            GV_miPost.DataSource = a;
            GV_miPost.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<Script Language='JavaScript'>parent.alert('" + ex.Message + "');</Script>");
        }
    }


}