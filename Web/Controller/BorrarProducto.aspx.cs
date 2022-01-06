using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_BorrarProducto : System.Web.UI.Page
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
            hashMap = datos.devolver("BorrarProducto.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LBBorreProduc.Text = hashMap["LBBorreProduc"];
            LBCodigo.Text = hashMap["LBCodigo"];
            BTBorrar.Text = hashMap["BTBorrar"];
            
            IBSalir.ImageUrl = hashMap["IBSalir"];
            



        }
        catch (Exception)
        {

        }
        int hola = 27;
        Session["subsede"] = hola;
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        String mensajeBorradoCorrectamente = "", mensajeNingunProductoSeleccionado = "";
        try
        {
        
            try
            {
                Dictionary<String, String> hashMap = new Dictionary<string, string>();
                hashMap = (Dictionary<String, String>)Session["idioma"];
                mensajeBorradoCorrectamente = hashMap["mensajeBorradoCorrectamente"];
                mensajeNingunProductoSeleccionado = hashMap["mensajeNingunProductoSeleccionado"];
            }
            catch (Exception)
            {

            }
            EProducto producto = new EProducto();

            producto.IdProducto = int.Parse(DL_productos.SelectedValue.ToString());
            producto.Session = Session.SessionID;
            LProducto resultado = new LProducto();
            EProductoSede b = new EProductoSede();
            LSede a = new LSede();
            b.Id_producto = int.Parse(DL_productos.SelectedValue.ToString());
            b = a.ObteneridProductosede(b);
            b.Activo = false;
            b.Last = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
            b =a.ActualizarEstadoproducto(b, mensajeBorradoCorrectamente);
            //producto = resultado.EliminarProducto(producto, int.Parse(Session["user_id"].ToString()),mensajeBorradoCorrectamente);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", b.Mensaje, false);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", b.Mensaje);
            DL_productos.DataBind();
           
        }
        catch (Exception)
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", @"<script type='text/javascript'>alert('"+ mensajeNingunProductoSeleccionado + "');</script>", false);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", @"<script type='text/javascript'>alert('"+ mensajeNingunProductoSeleccionado + "');</script>");
        }


    }




    protected void DL_productos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

}