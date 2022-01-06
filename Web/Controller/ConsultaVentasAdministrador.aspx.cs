using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_ConsultaVentasAdministrador : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        LSubsede inicio = new LSubsede();
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
            hashMap = datos.devolver("ConsultaVentasAdministrador.aspx", selectedLanguaje);

            IBVentasPasadas.ImageUrl = hashMap["IBVentasPasadas"];
            IBVentasDeHoy.ImageUrl = hashMap["IBVentasDeHoy"];

           

        }
        catch (Exception)
        {

        }

    }
}