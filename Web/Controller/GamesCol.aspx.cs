using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_GamesCol : System.Web.UI.Page
{

    int etique = 1;
    GamesCol.ServiceToken token = new GamesCol.ServiceToken();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            GamesCol.Facebook_servideSoapClient etiqueta = new GamesCol.Facebook_servideSoapClient();

            {
                token.sToken = "ferronetGLjkORNZK12UUf2Qmqsh";
            };

            string sToken = etiqueta.AutenticacionCliente(token);

            if (sToken.Equals("-1"))
            {
                Response.Write("<Script Language='JavaScript'>parent.alert('Token invalido');</Script>");
                throw new Exception("token invalido");
            }
            token.AutenticacionToken = sToken;
            etiqueta.postpc(token);

            string m = "probando mensajes";
            ;

            Response.Write("<Script Language='JavaScript'>parent.alert('" + m + "');</Script>");
            GV_miPost.DataSource = obtenerPost(token);
            GV_miPost.DataBind();
        }
        catch (Exception ex)
        {

            Response.Write("<Script Language='JavaScript'>parent.alert('" + ex.Message + "');</Script>");
        }

    }
    public DataTable obtenerPost(GamesCol.ServiceToken p)
    {
        GamesCol.Facebook_servideSoapClient eti = new GamesCol.Facebook_servideSoapClient();
        DataTable dato = new DataTable();
        dato = eti.noticias(p);
        return dato;
    }
   

    }
