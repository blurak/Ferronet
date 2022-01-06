using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_InventarioActualSubsede : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        LSubsede inicio = new LSubsede();
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
            hashMap = datos.devolver("InventarioActualSubsede.aspx", selectedLanguaje);

            GVInventarioActual.Columns[0].HeaderText = hashMap["GVInventarioActualColumna0"];
            GVInventarioActual.Columns[1].HeaderText = hashMap["GVInventarioActualColumna1"];
            GVInventarioActual.Columns[2].HeaderText = hashMap["GVInventarioActualColumna2"];
            GVInventarioActual.Columns[3].HeaderText = hashMap["GVInventarioActualColumna3"];
            GVInventarioActual.Columns[4].HeaderText = hashMap["GVInventarioActualColumna4"];
            GVInventarioActual.EmptyDataText = hashMap["EmptyGVInventarioActual"];
        }
        catch (Exception)
        {

        }


    }
}