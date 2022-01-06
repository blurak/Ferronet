using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_ConsultasSubsede : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();

        LSede inicio = new LSede();
        try
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()), false);
        }
        catch (Exception we)
        {
            Response.Redirect("IniciarSesion.aspx");
        }
        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("ConsultasSubsede.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;


            IBAdminCaje.ImageUrl = hashMap["IBAdminCaje"];
            IBInventarioSubsede.ImageUrl = hashMap["IBInventarioSubsede"];
            IBVentasHoy.ImageUrl = hashMap["IBVentasHoy"];
            IBVentasPasadas.ImageUrl = hashMap["IBVentasPasadas"];
            IBSalir.ImageUrl = hashMap["IBSalir"];






        }
        catch (Exception)
        {

        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteAdminyCajeros.aspx");
    }

    protected void Button5_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Productos_subsede.aspx");
    }

    protected void BT_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Consultas.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("ReporteAdminyCajeros.aspx");
    }
}