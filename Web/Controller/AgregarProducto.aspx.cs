using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            hashMap = datos.devolver("AgregarProducto.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LBCantidad.Text = hashMap["LBCantidad"];
            LBCantidadMinima.Text = hashMap["LBCantidadMinima"];
            LBAsigneProductos.Text = hashMap["LBAsigneProductos"];
            LBProducto.Text = hashMap["LBProducto"];
            BTAgregarProducto.Text = hashMap["BTAgregarProducto"];

            IBSalir.ImageUrl = hashMap["IBSalir"];
            RGCantidad.ErrorMessage = hashMap["RGCantidad"];
            RGCantimin.ErrorMessage = hashMap["RGCantimin"];



        }
        catch (Exception)
        {

        }
        }




    protected void BT_agregar_producto_Click(object sender, EventArgs e)
    {
        EProducto producto = new EProducto();
        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            producto.MensajeCantidadNegativa = hashMap["mensajeCantidadNoNegativa"];
            producto.MensajeAsignadoCorrectamente = hashMap["mensajeProductoAsignado"];      
            producto.MensajeProductoYaAsignado = hashMap["mensajeProductoYaAsignado"];
            producto.MensajeCantidadMinimaMenorACantidadMaxima = hashMap["mensajeCantidadMinima"];
        }
        catch (Exception)
        {

        }
        EProductoSede encapsulado = new EProductoSede();

        encapsulado.Cantidad = int.Parse(TB_cantidad.Text.ToString());
        encapsulado.CantidadMinima = int.Parse(TB_cantidad_minima.Text.ToString());
        encapsulado.Id_producto = int.Parse(DL_producto.SelectedValue.ToString());
        encapsulado.Session = Session.SessionID;
        

        LSede resultado = new LSede();
        producto = resultado.AsignarProductoAInventario(producto, int.Parse(Session["user_id"].ToString()),encapsulado);

        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", producto.Mensaje, false);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", producto.Mensaje);
        TB_cantidad.Text = string.Empty;
        TB_cantidad_minima.Text = string.Empty;
        DL_producto.DataBind();
    }
}