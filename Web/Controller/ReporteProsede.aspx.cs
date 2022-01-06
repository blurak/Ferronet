using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ReporteProsede : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LSede resultado = new LSede();
        LSede inicio = new LSede();
        Response.Cache.SetNoStore();

        
        try
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()), false);
            CRS_ReporteProsede.ReportDocument.SetDataSource(resultado.ObtenerInformeProductosSede(int.Parse(Session["user_id"].ToString())));
            CRV_ReporteProsede.ReportSource = CRS_ReporteProsede;
        }
        catch (Exception we)
        {
            Response.Redirect("IniciarSesion.aspx");
        }


    }
    

}

