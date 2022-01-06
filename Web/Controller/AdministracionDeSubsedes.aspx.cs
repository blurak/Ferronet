using System;
using System.Web.UI;
using Logica;
using System.Collections.Generic;

public partial class View_AdministracionDeSubsedes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();

        LSede inicio = new LSede();
        try
        {
            
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()), false);
        }
        catch(Exception we)
        {
            Response.Redirect("IniciarSesion.aspx");
        }


        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("AdministracionDeSubsedes.aspx", selectedLanguaje);
            IBRegistrarAdminYCajero.ImageUrl = hashMap["IBRegistrarAdminYCajero"];
            IBCrearSubsede.ImageUrl = hashMap["IBCrearSubsede"];
            IBAsignarInventario.ImageUrl = hashMap["IBAsignarInventario"];
            IBCantidadesBajas.ImageUrl = hashMap["IBCantidadesBajas"];
            




        }
        catch (Exception)
        {

        }


    }

    protected void BT_crear_subsede_Click(object sender, EventArgs e)
    {

    }
}