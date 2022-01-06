using Logica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Utilitarios.Tablas;

public partial class View_AgregarIdioma : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Cache.SetNoStore();
        LVisitante logica = new LVisitante();
        try
        {
            LIDioma.Text = DDIdiomasRegistrados.SelectedItem.ToString();
            LIdiomaDos.Text = DDIdiomasRegistrados.SelectedItem.ToString();

        }
        catch (Exception)
        {

        }
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
            hashMap = datos.devolver("AgregarIdioma.aspx", selectedLanguaje);
            Session["idioma_venta"] = hashMap;

            LBInfoIdiomas.Text = hashMap["LBInfoIdiomas"];
            LInstruccionUno.Text = hashMap["LInstruccionUno"];
            BAnadir.Text = hashMap["BAnadir"];
            LInstruccionDos.Text = hashMap["LInstruccionDos"];
            LInstruccionTres.Text = hashMap["LInstruccionTres"];
            LControladores.Text = hashMap["LControladores"];
            LBControlesImagen.Text = hashMap["LBControlesImagen"];
            LBControlesTraducido.Text = hashMap["LBControlesTraducido"];
            LBAgregarProducto.Text = hashMap["LBAgregarProducto"];

            GVFormularios.Columns[1].HeaderText = hashMap["GVFormulariosColumna1"];
            GVFormularios.Columns[2].HeaderText = hashMap["GVFormulariosColumna2"];

            GVControles.Columns[0].HeaderText = hashMap["GVControlesColumna0"];
            GVControles.Columns[1].HeaderText = hashMap["GVControlesColumna1"];

            GVControlesTraducidos.Columns[0].HeaderText = hashMap["GVControlesTraducidosColumna0"];
            GVControlesTraducidos.Columns[1].HeaderText = hashMap["GVControlesTraducidosColumna1"];

            GVControlesImagen.Columns[0].HeaderText = hashMap["GVControlesImagenColumna0"];
            GVControlesImagen.Columns[1].HeaderText = hashMap["GVControlesImagenColumna1"];

            GVControladoresConImagen.Columns[0].HeaderText = hashMap["GVControladoresConImagenColumna0"];
            GVControladoresConImagen.Columns[1].HeaderText = hashMap["GVControladoresConImagenColumna1"];

            GVFormularios.EmptyDataText = hashMap["EmptyGVFormularios"];
            GVControles.EmptyDataText = hashMap["EmptyGVControles"];
            GVControlesTraducidos.EmptyDataText = hashMap["EmptyGVControlesTraducidos"];
            GVControlesImagen.EmptyDataText = hashMap["EmptyGVControlesImagen"];
            GVControladoresConImagen.EmptyDataText = hashMap["EmptyGVControladoresConImagen"];
        }
        catch (Exception)
        {

        }

    }

    protected void BAnadir_Click(object sender, EventArgs e)
    {
        EIdioma idioma = new EIdioma();
        idioma.Nombre = DDIdiomas.SelectedItem.ToString();
        idioma.Terminacion = DDIdiomas.SelectedValue.ToString();
        LVisitante registrar = new LVisitante();
        idioma.Session = Session.SessionID;
       registrar.registrarIdioma(idioma);
        DDIdiomasRegistrados.DataBind();
        
    }



    protected void GVControles_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Set the edit index.
        GVControles.EditIndex = e.NewEditIndex;
        //Bind data to 8989the GridView control.
        cargarControles();
    }

    protected void GVControles_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        LSede resultado = new LSede();
        GridViewRow row = GVControles.Rows[e.RowIndex];
        String control = ((Label)row.FindControl("LControl")).Text;
        String texto =((TextBox)row.FindControl("TBTexto")).Text;
        String idFormulario= GVFormularios.SelectedValue.ToString();
        String terminacion = DDIdiomasRegistrados.SelectedValue.ToString();
        resultado.FuncionMultiidoma(control, terminacion, int.Parse(idFormulario), texto,Session.SessionID);
        GVControles.EditIndex = -1;

        //Bind data to the GridView control.
        cargarControles();
        cargarControlesImagen();
     
        GVControles.DataBind();
        GVControlesTraducidos.DataBind();
    }

    public void cargarControles()
    {
        try
        {
            LVisitante logica = new LVisitante();
            GVControles.DataSource = logica.obtenerControles(int.Parse(GVFormularios.SelectedValue.ToString()));
            GVControles.DataBind();
        }
        catch (Exception)
        {
            
        }
        
    }

    public void cargarControlesConImagen()
    {
        try
        {
            LVisitante logica = new LVisitante();
            GVControladoresConImagen.DataSource = logica.obtenerControlesTraducidosImagenes(int.Parse(GVFormularios.SelectedValue.ToString()),DDIdiomasRegistrados.SelectedValue.ToString());
            GVControladoresConImagen.DataBind();
        }
        catch (Exception)
        {

        }

    }
    public void cargarControlesImagen()
    {
        try
        {
            LVisitante logica = new LVisitante();
            GVControlesImagen.DataSource = logica.ObtenerControlesImagen(int.Parse(GVFormularios.SelectedValue.ToString()));
            GVControlesImagen.DataBind();
        }
        catch (Exception)
        {

        }

    }



    protected void GVFormularios_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        cargarControles();
        cargarControlesImagen();
        cargarControlesConImagen();
    }

    protected void GVControles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

            //Reset the edit index.
            GVControles.EditIndex = -1;
        //Bind data to the GridView control.
        cargarControles();
        
    }

    protected void GVControlesImagen_RowEditing(object sender, GridViewEditEventArgs e)
    {

        //Set the edit index.
        GVControlesImagen.EditIndex = e.NewEditIndex;
        //Bind data to 8989the GridView control.
        cargarControlesImagen();
    }

    protected void GVControlesImagen_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
             GridViewRow row = GVControlesImagen.Rows[e.RowIndex];
       
             LVisitante resultado = new LVisitante();
             EProducto encapsulado = new EProducto();
             String nombreArchivo = "";
             String extension = "";
             String saveLocation = "";
             String control = ((Label)row.FindControl("Label5")).Text;
             FileUpload fu = (FileUpload)row.FindControl("imagen");
       
            if (fu != null && fu.HasFile)
            {
                 nombreArchivo = System.IO.Path.GetFileName(fu.PostedFile.FileName);
                 extension = System.IO.Path.GetExtension(fu.PostedFile.FileName);
            }

            encapsulado=resultado.CrearProducto(encapsulado, extension, nombreArchivo);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", encapsulado.Mensaje);
            try
            {
                saveLocation = Server.MapPath(encapsulado.SaveLocation) + "\\" + encapsulado.Milisegundo + nombreArchivo;
                fu.PostedFile.SaveAs(saveLocation);
            }
            catch (ArgumentException)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", @"<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o png');</script>", false);

            }

            String terminacion = DDIdiomasRegistrados.SelectedValue.ToString();
            resultado.ModificarOInsertarIdiomaDeControles(control, terminacion, int.Parse(GVFormularios.SelectedValue.ToString()),encapsulado.Imagen);
            GVControlesImagen.EditIndex = -1;
            cargarControlesImagen();
    }

    protected void GVControlesImagen_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //Reset the edit index.
        GVControlesImagen.EditIndex = -1;
        //Bind data to the GridView control.
        cargarControlesImagen();
    }

    protected void GVControles_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void GVControles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        cargarControles();
        GVControles.PageIndex = e.NewPageIndex;
        GVControles.DataBind();
    }
}