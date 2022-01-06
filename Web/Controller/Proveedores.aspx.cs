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
using Datos;
using Logica;
using Utilitarios;
using Utilitarios.Tablas;

public partial class View_Proveedores : System.Web.UI.Page
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
            hashMap = datos.devolver("Proveedores.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
            RENombre.Text = hashMap["RENombre"];
            LBRegistrar.Text = hashMap["LBRegistrar"];
            LBNombre.Text = hashMap["LBNombre"];
            LBCorreo.Text = hashMap["LBCorreo"];
            LBTelefono.Text = hashMap["LBTelefono"];
            RETelefono.ErrorMessage = hashMap["RETelefono"];
            LBCategoria.Text = hashMap["LBCategoria"];
            BtnRegistrar.Text = hashMap["BtnRegistrar"];
            RENombre.ErrorMessage = hashMap["RENombre"];


        }
        catch (Exception)
        {
        }

    }

    
    
    protected void BtnRegistrar_Click(object sender, EventArgs e)
    {
        String mensajeProveedorRegistrado = "";
        LSede registrar = new LSede();
        EProveedor resultado = new EProveedor();
        DAOSede datosSede = new DAOSede();
        ESede sede = new ESede();
        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            mensajeProveedorRegistrado = hashMap["mensajeProveedorRegistrado"];
        }
        catch (Exception)
        {

        }
       
        resultado.Nombre = TB_nombre.Text;
        resultado.Correo = TB_correo.Text;
        resultado.Telefono = telefono.Text;
        resultado.IdCategoria = int.Parse(DRL_categoria.SelectedValue.ToString());
        resultado.Session = Session.SessionID;
        sede=datosSede.DevolverSede(int.Parse(Session["user_id"].ToString()));
        resultado.IdSede = sede.Id;
        resultado.Last= Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
        registrar.insertarProveedor(resultado,mensajeProveedorRegistrado);
        TB_nombre.Text = resultado.Nombre;
        TB_correo.Text = resultado.Correo;
        telefono.Text = resultado.Telefono;
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", resultado.Script, false);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", resultado.Script);



    }
}