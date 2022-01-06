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

public partial class View_AgregarProducto : System.Web.UI.Page
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
            hashMap = datos.devolver("CrearProducto.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Session["terminacion"].ToString());
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["terminacion"].ToString());

            LBRegisPro.Text = hashMap["LBRegisPro"];
            LBPrecio.Text = hashMap["LBPrecio"];
            LBDescripcion.Text = hashMap["LBDescripcion"];
            LBImagen.Text = hashMap["LBImagen"];
            LBCategoria.Text = hashMap["LBCategoria"];
            RECaracteresEspecia.ErrorMessage = hashMap["RECaracteresEspecia"];
            BTAgregar.Text = hashMap["BTAgregar"];


            IBSalir.ImageUrl = hashMap["IBSalir"];

            //GWCantiadesBajas.Columns[2].HeaderText = hashMap["GWCantiadesBajas0"];
            //GWCantiadesBajas.Columns[3].HeaderText = hashMap["GWCantiadesBajas1"];
            //GWCantiadesBajas.Columns[4].HeaderText = hashMap["GWCantiadesBajas2"];
            //GWCantiadesBajas.Columns[5].HeaderText = hashMap["GWCantiadesBajas3"];
            //GWCantiadesBajas.Columns[6].HeaderText = hashMap["GWCantiadesBajas4"];
            //GWCantiadesBajas.Columns[7].HeaderText = hashMap["GWCantiadesBajas5"];
            //GWCantiadesBajas.Columns[8].HeaderText = hashMap["GWCantiadesBajas6"];








        }
        catch (Exception)
        {

        }
    }

    protected void BT_cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministracionDeSubsedes.aspx");
    }


    protected void BT_agregar_Click(object sender, EventArgs e)
    {
        String mensajeProductoRegistrado = "", mensajeFormatoDeImagenNoValido = "";
        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            mensajeProductoRegistrado = hashMap["mensajeProductoRegistrado"];
            mensajeFormatoDeImagenNoValido = hashMap["mensajeFormatoDeImagenNoValido"];
        }
        catch (Exception)
        {

        }

        EProducto pro = new EProducto();
        LSede salida = new LSede();

        pro.Precio = double.Parse(TB_precio.Text.ToString());
        pro.Descripcion = TA_descripcion.Text.ToString();
        pro.Categoria = int.Parse(DL_categoria.SelectedValue.ToString());
        pro.Session = Session.SessionID;
        pro.MensajeAsignadoCorrectamente = mensajeProductoRegistrado;
        pro.MensajeProductoYaAsignado = mensajeFormatoDeImagenNoValido;
        String nombreArchivo = System.IO.Path.GetFileName(imagen.PostedFile.FileName);
        String extension = System.IO.Path.GetExtension(imagen.PostedFile.FileName);

        EProducto resultado = salida.CrearProducto(pro, extension, nombreArchivo);

        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", resultado.Mensaje, false);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", resultado.Mensaje);

        DateTime thisDay = DateTime.Now;
        String saveLocation = "";
        try
        {
            saveLocation = Server.MapPath(resultado.SaveLocation) + "\\" +resultado.Milisegundo + nombreArchivo;
            imagen.PostedFile.SaveAs(saveLocation);

        }
        catch (ArgumentException we)
        {

            LImagenIncorrecta.Text = mensajeFormatoDeImagenNoValido;
           ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", @"<script type='text/javascript'>alert('"+mensajeFormatoDeImagenNoValido+"');</script>", false);
           
        }

        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", resultado.Mensaje, false);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", resultado.Mensaje);

        TB_precio.Text = String.Concat(resultado.Precio);
        TA_descripcion.Text = resultado.Descripcion;
    }
}