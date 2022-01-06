using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_CrearSede : System.Web.UI.Page
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

        LVisitante datos = new LVisitante();
        Dictionary<String, String> hashMap = new Dictionary<string, string>();
        String selectedLanguaje = Session["terminacion"].ToString();
        hashMap = datos.devolver("CrearSede.aspx", selectedLanguaje);
        Session["idioma"] = hashMap;

        LBNombreSede.Text = hashMap["LBNombreSede"];
        LBUbicacion.Text = hashMap["LBUbicacion"];
        LBAdministradoresDisponibles.Text = hashMap["LBAdministradoresDisponibles"];
        LBCajerosDisponibles.Text = hashMap["LBCajerosDisponibles"];
        IBSalir.ImageUrl = hashMap["IBSalir"];
        BTCrearSede.Text = hashMap["BTCrearSede"];
        RENombre.ErrorMessage = hashMap["RENombre"];



    }

 
    protected void BtnCrearSede_Click(object sender, EventArgs e)
    {
        ESubsede resultado = new ESubsede();
        String mensajeDeCajeroYadministrador = "", mensajeCorrecto = "";
        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            mensajeDeCajeroYadministrador = hashMap["mensajeDeCajeroYadministrador"];
            mensajeCorrecto = hashMap["mensajeCorrecto"];
        }
        catch (Exception)
        {

        }
        resultado.Nombre = TB_nombre.Text.ToString();
        resultado.Ubicacion = TB_coor.Text.ToString();
        try
        {
            resultado.IdAdmin = int.Parse(DL_administradores.SelectedValue.ToString());
            resultado.IdCajero = int.Parse(DL_cajeros.SelectedValue.ToString());
        }
        catch (FormatException ew)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", @"<script type='text/javascript'>alert('" + mensajeDeCajeroYadministrador +"');</script>", false);
        }

        resultado.Session = Session.SessionID;
        LSede registrar = new LSede();
        
        resultado = registrar.insertarSubsede(resultado, mensajeDeCajeroYadministrador, mensajeCorrecto,int.Parse(Session["user_id"].ToString()));
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", resultado.Mensaje, false);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", resultado.Mensaje);

        DL_administradores.DataBind();
        DL_cajeros.DataBind();
        TB_nombre.Text = resultado.Nombre;
        TB_coor.Text = resultado.Ubicacion;
    }
}