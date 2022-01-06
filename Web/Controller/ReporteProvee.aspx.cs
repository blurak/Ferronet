using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ReporteProvee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LSede inicio = new LSede();
        LSede resultado = new LSede();

        try
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()), false);
            CRS_ReporteProveedores.ReportDocument.SetDataSource(resultado.obtenerReporteProvedorP(int.Parse(Session["user_id"].ToString())));
            CRV_ReporteProveedores.ReportSource = CRS_ReporteProveedores;

        }
        catch (Exception we)
        {
            Response.Redirect("IniciarSesion.aspx");
        }

    
      

    }
    
}