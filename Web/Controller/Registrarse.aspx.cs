using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Registrarse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TB_ubicacion.Visible = false;
        LUsername.Text = "";

        try
        {

            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("registrarse.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;
            LNombre.Text = hashMap["LNombre"];
            LIngreseSusDatos.Text = hashMap["LIngreseSusDatos"];
            LCorreoElectronico.Text = hashMap["LCorreoElectronico"];
            LUsername.Text = hashMap["LUsername"];
            LContrasena.Text = hashMap["LContrasena"];
            BRegistrar.Text = hashMap["BRegistrar"];
            REContrasenaExpresion.ErrorMessage = hashMap["REContrasenaExpresion"];
            REUsernameExpresion.ErrorMessage = hashMap["REUsernameExpresion"];
            RENombreExpresion.ErrorMessage = hashMap["RENombreExpresion"];
            

        }
        catch (Exception)
        {

        }

    }



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String mensaje="", mensajeErroneo="";
        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            mensaje = hashMap["MensajeCorrecto"];
           mensajeErroneo = hashMap["MensajeErroneo"];
        }
        catch (Exception)
        {

        }
        
        String correo = TB_correo.Text;
        String nombre = TB_nombre.Text;
        String user = TB_user.Text;
        String contra = TB_contrasena.Text;
        LUsuario registrar = new LUsuario();
        EUsuario resultado = new EUsuario();
        EUsuario usuario = new EUsuario();
        usuario.Nombre = nombre;
        usuario.UserName = user;
        usuario.Clave = contra;
        usuario.Correo = correo;
        usuario.IdRol = 1;
        usuario.Session = Session.SessionID;
        usuario.Mensaje = mensaje;
        usuario.MensajeUsernameNoDisponible = mensajeErroneo;


        resultado=registrar.insertarUsuario(usuario);

        
        TB_correo.Text = resultado.Correo;
        TB_nombre.Text = resultado.Nombre;
        TB_user.Text = resultado.UserName;
        TB_contrasena.Text = resultado.Clave;

        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", resultado.Mensaje, false);
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", resultado.Mensaje);
    }

}