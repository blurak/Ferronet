using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;

public partial class View_RegistrarVentaConGridview : System.Web.UI.Page
{
    private string[] cant;
    private string[] id;
    private int valortotal;
    LCajero Datos = new LCajero();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Page.IsPostBack == false)
        {
            CargarVentas();
           
        }

        Response.Cache.SetNoStore();

        LCajero inicio = new LCajero();
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
            hashMap = datos.devolver("RegistrarVentaConGridview.aspx", selectedLanguaje);
            Session["idioma_venta"] = hashMap;
            GwRegistrando.Columns[0].HeaderText = hashMap["GwRegistrando0"];
            GwRegistrando.Columns[1].HeaderText = hashMap["GwRegistrando1"];
            GwRegistrando.Columns[2].HeaderText = hashMap["GwRegistrando2"];
            GwRegistrando.Columns[3].HeaderText = hashMap["GwRegistrando3"];
            GwRegistrando.Columns[4].HeaderText = hashMap["GwRegistrando4"];
            LBInventario.Text = hashMap["LBInventario"];
            LBProductos.Text = hashMap["LBProductos"];
            BTTerminar.Text = hashMap["BTTerminar"];
            BTReiniciar.Text = hashMap["BTReiniciar"];
            LBSeleccione.Text = hashMap["LBSeleccione"];
            GwRegistrando.EmptyDataText = hashMap["EPGwRegistrando"];
            GWInventario.Columns[0].HeaderText = hashMap["GWInventario0"];
            GWInventario.Columns[1].HeaderText = hashMap["GWInventario1"];
            GWInventario.Columns[2].HeaderText = hashMap["GWInventario2"];
            GWInventario.Columns[3].HeaderText = hashMap["GWInventario3"];
            GWInventario.Columns[4].HeaderText = hashMap["GWInventario4"];
            GWInventario.Columns[5].HeaderText = hashMap["GWInventario5"];    





        }
        catch (Exception)
        {

        }

    }

    public void CargarVentas(){
       
        GWInventario.DataSource = Datos.obtenerProductosSubsede(int.Parse(Session["user_id"].ToString()));
        GWInventario.DataBind();

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        
    }

    protected void Button5_Click1(object sender, EventArgs e)
    {
        Session["venta"] = null;
        CargarVentas();
        CargarVentaRegistrada();
    }


    protected void Button6_Click(object sender, EventArgs e)
    {
        String mensajeVentaHecha = "";
        try
        {
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma_venta"];
            mensajeVentaHecha = hashMap["mensajeVentaHecha"];
        }
        catch (Exception)
        {

        }
        EVenta resultado = new EVenta();
        LCajero logica = new LCajero();
        DateTime fecha12;
        fecha12 = DateTime.Now;
        string formato123 = "hh:mm:ss";
        string formato1 = "MM dd yyyy";
        resultado.Dia = fecha12.ToString(formato1);
        resultado.Hora = fecha12.ToString(formato123);
        resultado.IdCajero = int.Parse(Session["user_id"].ToString());
        resultado.VentaSesion = (DataTable)Session["venta"];
        resultado.Session = Session.SessionID;
        resultado.Diacompa = fecha12;
        
        resultado=logica.registrarVenta(resultado,mensajeVentaHecha);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", resultado.Mensaje);

        ScriptManager.RegisterStartupScript(this, this.GetType(), "invocarfuncion", resultado.Mensaje, false);
        Session["venta"] = null;
        CargarVentaRegistrada();
        CargarVentas();

    }

    public void CargarVentaRegistrada()
    {
        GwRegistrando.DataSource = Session["venta"];
        GwRegistrando.DataBind();
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        string columna;
        int mirarcolumna;
        TextBox btn2 = (TextBox)sender;
        string cantidad;
        cantidad = btn2.Text;
        columna = btn2.ClientID;
        string string2 = Convert.ToString(columna[columna.Length - 1]);
        mirarcolumna = Convert.ToInt32(string2);
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e) {
        bool  mirar;
        
        
        string columna;
        int mirarcolumna;
        CheckBox btn = (CheckBox)sender;
        
        mirar = btn.Checked;
        columna = btn.ClientID;
        string string2 = Convert.ToString(columna[columna.Length - 1]);
       mirarcolumna = Convert.ToInt32(string2) ;
        id = new string[GWInventario.Rows.Count];


        GridViewRow row = GWInventario.Rows[mirarcolumna];
        id[mirarcolumna] = GWInventario.Rows[mirarcolumna].Cells[3].Text;
        int id_producto = int.Parse(id[mirarcolumna]);

    }
   
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow Row = GWInventario.Rows[index];
            TextBox txtsn = ((TextBox)Row.FindControl("IdCantidad"));
            Label nombre = ((Label)Row.FindControl("LbDescripcion"));
            Label cantidadDisponible = ((Label)Row.FindControl("LbcantidadDispo"));
            Label precio = ((Label)Row.FindControl("LbPrecio"));

            EVenta c = new EVenta();

            c.IdProducto = Convert.ToInt32(GWInventario.DataKeys[index].Value);
            c.Cantidad = int.Parse(txtsn.Text);
            c.IdCajero = Int32.Parse(Session["user_id"].ToString());
            c.Descripcion = nombre.Text;
            c.Precio =double.Parse( precio.Text);
            c.CantidadDisponible = int.Parse(cantidadDisponible.Text);
            c.VentaSesion =(DataTable) Session["venta"];
            LCajero resultado = new LCajero();
            c = resultado.validarCantidades(e.CommandName, c);
            Session["venta"] = c.VentaSesion;
            CargarVentaRegistrada();
        }
        catch(Exception)
        {

        }
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GWInventario.EditIndex = e.NewEditIndex;
        CargarVentas();

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GWInventario.EditIndex = -1;
        CargarVentas();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GWInventario.EditIndex = -1;
        CargarVentas();
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GWInventario.PageIndex = e.NewPageIndex;
        CargarVentas();
    }
}
