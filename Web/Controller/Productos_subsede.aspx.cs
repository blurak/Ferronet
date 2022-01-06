using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Productos_subsede : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

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
            hashMap = datos.devolver("Productos_subsede.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LBSeleccionSub.Text = hashMap["LBSeleccionSub"];
            LBInventario.Text = hashMap["LBInventario"];
            IBSalir.ImageUrl = hashMap["IBSalir"];

            GW_Subsedes.Columns[0].HeaderText = hashMap["GW_Subsedes0"];
            GW_Subsedes.Columns[1].HeaderText = hashMap["GW_Subsedes1"];
            


            GW_Productos.Columns[0].HeaderText = hashMap["GW_Productos0"];
            GW_Productos.Columns[1].HeaderText = hashMap["GW_Productos1"];
            GW_Productos.Columns[2].HeaderText = hashMap["GW_Productos2"];
            GW_Productos.Columns[3].HeaderText = hashMap["GW_Productos3"];
        





        }
        catch (Exception)
        {

        }


    }

    protected void BT_salir_Click(object sender, EventArgs e)
    {
        Response.Redirect("Consultas.aspx");
    }
}