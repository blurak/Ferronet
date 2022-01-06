using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;


public partial class View_InventarioSubsedeCajero : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LCajero inicio = new LCajero();
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
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["terminacion"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["terminacion"].ToString());
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("InventarioSubsedeCajero.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            GWInventario.EmptyDataText = hashMap["EmptyGWDetalle"];
            GWInventario.Columns[0].HeaderText = hashMap["GWInventario0"];
            GWInventario.Columns[1].HeaderText = hashMap["GWInventario1"];
            GWInventario.Columns[2].HeaderText = hashMap["GWInventario2"];
            GWInventario.Columns[3].HeaderText = hashMap["GWInventario3"];

            LBInventario.Text = hashMap["LBInventario"];
        
            

        }
        catch (Exception)
        {


        }


    }
}