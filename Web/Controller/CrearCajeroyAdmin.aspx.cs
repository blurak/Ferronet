using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Newtonsoft.Json;
using Utilitarios;
using Utilitarios.Servicios;

public partial class View_CrearCajero : System.Web.UI.Page
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
            hashMap = datos.devolver("CrearCajeroyAdmin.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LBRegistreAdminYCajero.Text = hashMap["LBRegistreAdminYCajero"];
            LBNombre.Text = hashMap["LBNombre"];
            LBCorreo.Text = hashMap["LBCorreo"];
            LBContrasena.Text = hashMap["LBContrasena"];
            LBRol.Text = hashMap["LBRol"];
            BT_registrar.Text = hashMap["BT_registrar"];
            IBSalir.ImageUrl = hashMap["IBSalir"];
            RENombre.ErrorMessage = hashMap["RENombre"];
            REUsuario.ErrorMessage = hashMap["REUsuario"];
            REContra.ErrorMessage = hashMap["REContra"];
            LBAspirantes.Text = hashMap["LBAspirantes"];
            Buscar.Text = hashMap["Buscar"];
            if (DL_rol.Items.Count == 0)
            {
                DL_rol.Items.Clear();
                ListItem Seleccione = new ListItem(hashMap["DDSeleccionee"], "0");
                DL_rol.Items.Add(Seleccione);
                ListItem Domicilio = new ListItem(hashMap["DDCajero"], "4");
                DL_rol.Items.Add(Domicilio);
                ListItem Contra = new ListItem(hashMap["DDAdministrador"], "3");
                DL_rol.Items.Add(Contra);
            }




        }
        catch (Exception)
        {

        }

    }

    protected void BT_registrar_Click(object sender, EventArgs e)
    {
        String mensaje = "", mensajeErroneo = "";
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
        EUsuario usuario = new EUsuario();
        usuario.Nombre = TB_nombre.Text.ToString();
        usuario.UserName = TB_usuario.Text.ToString();
        usuario.Clave = TB_clave.Text.ToString();
        usuario.Correo = TB_correo.Text.ToString(); ;
        usuario.IdRol = int.Parse(DL_rol.SelectedValue.ToString());
        usuario.Session = Session.SessionID;
       
        LSede registro = new LSede();
        EUsuario resultado = registro.RegistrarAdministradorYCajero(usuario,mensaje,mensajeErroneo);

        TB_nombre.Text = resultado.Nombre;
        TB_usuario.Text = resultado.UserName;
        TB_clave.Text = resultado.Clave;
        TB_correo.Text = resultado.Correo;

        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", resultado.Mensaje, false);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", resultado.Mensaje);

    }

    protected void Button5_Click(object sender, EventArgs e)
    {

    }


    protected void GwProductosSede_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int idProducto = Convert.ToInt32(GwProductosSede.DataKeys[e.NewSelectedIndex].Value);
        String nombre = this.GwProductosSede.Rows[e.NewSelectedIndex].Cells[2].Text;
        String apellido = this.GwProductosSede.Rows[e.NewSelectedIndex].Cells[3].Text;
        String titulo = this.GwProductosSede.Rows[e.NewSelectedIndex].Cells[4].Text;
        //Session["idProducto"] = idProducto;
        TB_nombre.Text = "";
        TB_usuario.Text = "";
        TB_nombre.Text = nombre;
        TB_usuario.Text = nombre + apellido;
    }

    protected void BTNBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            ServicioUniempleo.ServidorUniempleoSoapClient obwsClientesSoap = new ServicioUniempleo.ServidorUniempleoSoapClient();
            obwsClientesSoap.ClientCredentials.UserName.UserName = "ferronet";
            obwsClientesSoap.ClientCredentials.UserName.Password = "9p8mSXrM5v";

            ServicioUniempleo.SeguridadToken objclsSeguridad = new ServicioUniempleo.SeguridadToken()
            {
                username = "ferronet",
                Pass = "9p8mSXrM5v"
            };

            String token = obwsClientesSoap.AutenticacionUsuario(objclsSeguridad);

            if (token.Equals("-1"))
                throw new Exception("Requiere validacion");

            objclsSeguridad.Token_Autenticacion = token;

            List<JoinUsuarioUni> a = JsonConvert.DeserializeObject<List<JoinUsuarioUni>>(obwsClientesSoap.Busqueda_Aspirantes(objclsSeguridad, textbox.Text));


            GwProductosSede.DataSource = a;
            GwProductosSede.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<Script Language='JavaScript'>parent.alert('" + ex.Message + "');</Script>");
        }
    }
}