using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ReporteAdminyCajeros : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LSede inicio = new LSede();


        LSede resultado = new LSede();
        try
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()), false);
            CRS_ReporteCajeroyAdmin.ReportDocument.SetDataSource(resultado.ObtenerInformeAdminYcajero(int.Parse(Session["user_id"].ToString())));
            CRV_ReporteCajeroyAdmin.ReportSource = CRS_ReporteCajeroyAdmin;
        }
        catch (Exception we)
        {
            Response.Redirect("IniciarSesion.aspx");
        }

        Response.Cache.SetNoStore();

        


    }
    
}