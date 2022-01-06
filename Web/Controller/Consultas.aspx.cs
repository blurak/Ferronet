using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios.Tablas;

public partial class View_Consultas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LSede inicio = new LSede();
        
        try
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()));

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
            hashMap = datos.devolver("Consultas.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;


            IBInventario.ImageUrl = hashMap["IBInventario"];
            IBProveedores.ImageUrl = hashMap["IBProveedores"];
            IBSubsedes.ImageUrl = hashMap["IBSubsedes"];





        }
        catch (Exception)
        {

        }
        string a = "hola";
        int b = 3;
        LSede hh = new LSede();
        Epruebiña x = new Epruebiña();
        x.Nombre = a;
        x.Correo = b;
        hh.registrarprueba(x);
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteProsede.aspx");

    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteProvee.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {

    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ReporteProvee.aspx");
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ReporteProsede.aspx");
    }
}