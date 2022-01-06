using Logica;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_principal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["terminacion"] == null)
        {
            Session["terminacion"] = "es-CO";
        }

        try
        {
            String selectedLanguaje = Session["terminacion"].ToString();
            Dictionary<String, String> resultado = new Dictionary<String, String>();
            LVisitante datos = new LVisitante();
            resultado = datos.devolver("principal.master", selectedLanguaje);

            inicio.InnerText = resultado["inicio"];
            productos.InnerText = resultado["productos"];
            registrarse.InnerText = resultado["registrarse"];
            iniciarsesion.InnerText = resultado["iniciarsesion"];
            contactenos.InnerText = resultado["contactenos"];
            HPManual.Text = resultado["HPManual"];
            BTGames.Text = resultado["BTGames"];
            BTUniempleo.Text = resultado["BTUniempleo"];

        }
        catch (Exception ex)
        {
           String js= ex.ToString();
        }

    }

    protected void DDIdioma_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Session["terminacion"] = DDIdioma.SelectedValue.ToString();
            //Dictionary<String, String> resultado = new Dictionary<String, String>();
            //LVisitante datos = new LVisitante();
            //resultado = datos.devolver("principal.master", DDIdioma.SelectedValue.ToString());
            //inicio.InnerText = resultado["inicio"];
            //productos.InnerText = resultado["productos"];
            //registrarse.InnerText = resultado["registrarse"];
            //iniciarsesion.InnerText = resultado["iniciarsesion"];
            //contactenos.InnerText = resultado["contactenos"];
            //HPManual.Text = resultado["HPManual"];
            
            //DDIdioma.Enabled = false;
        }
        catch (Exception)
        {

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //Session["terminacion"] = DDIdioma.SelectedValue.ToString();
            ////Dictionary<String, String> resultado = new Dictionary<String, String>();
            ////LVisitante datos = new LVisitante();
            ////resultado = datos.devolver("principal.master", DDIdioma.SelectedValue.ToString());
            ////inicio.InnerText = resultado["inicio"];
            ////productos.InnerText = resultado["productos"];
            ////registrarse.InnerText = resultado["registrarse"];
            ////iniciarsesion.InnerText = resultado["iniciarsesion"];
            ////contactenos.InnerText = resultado["contactenos"];
            ////HPManual.Text = resultado["HPManual"];
            //DDIdioma.SelectedValue = Session["terminacion"].ToString();
            //DDIdioma.Enabled = true;
        }
        catch (Exception)
        {

        }
    }

    protected void BT_registrar_Click(object sender, EventArgs e)
    {

    }
}

