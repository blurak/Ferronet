using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_HacerPedidoCliente : System.Web.UI.Page
{

    DataTable dtb;
    DataRow fila;
    DataTable carrito = new DataTable();
    DataTable lista = new DataTable();

    
    protected void Page_Load(object sender, EventArgs e)
    {
        //CargarDetalle();
        LCliente inicio = new LCliente();
        try{
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()));
        }
        catch (Exception)
        {
            Response.Redirect("IniciarSesion.aspx");
        }

        try
        {
            //EPedido resultado = new EPedido();
            //resultado.Pedido = (DataTable)Session["pedido"];

            //resultado = inicio.validarHacerPedido(resultado);

            if (Session["pedido"] == null)
            {
                Session["subsede"] = null;
                CargarDetalle();
            }
            else
            {
                var items = (DataTable)Session["pedido"];
                if (items.Rows.Count == 0)
                {
                    Session["subsede"] = null;
                }
            }
        }
        catch (Exception)
        {

        }

        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("HacerPedidoCliente.aspx", selectedLanguaje);
           // Session["idioma"] = null;
            Session["idioma"] = hashMap;
            IBCarrito.ImageUrl = hashMap["IBCarrito"];
            LBuscarProducto.Text = hashMap["LBuscarProducto"];
            LSeleccionarSede.Text = hashMap["LSeleccionarSede"];
            BBuscar.Text = hashMap["BBuscar"];
            GVProductos.Columns[0].HeaderText = hashMap["GVProductosColumna0"];
            GVProductos.Columns[1].HeaderText = hashMap["GVProductosColumna1"];
            GVProductos.Columns[2].HeaderText = hashMap["GVProductosColumna2"];
            GVProductos.Columns[3].HeaderText = hashMap["GVProductosColumna3"];
            GVProductos.Columns[4].HeaderText = hashMap["GVProductosColumna4"];
            GVProductos.Columns[5].HeaderText = hashMap["GVProductosColumna5"];
            GVProductos.EmptyDataText = hashMap["EmptyGVProductos"];
        }
        catch (Exception)
        {

        }



    }

    public void AgregarItem(string cod, string des, double precio)
    {
        double total;
        int cantidad = 1;
        String dis = "✓";
        total = precio * cantidad;
        carrito = (DataTable)Session["pedido"];
        fila= carrito.NewRow();
        fila[0] = cod;
        fila[1] = des;
        fila[2] = precio;
        fila[3] = cantidad;
        fila[4] = dis;
        fila[5] = total;
        carrito.Rows.Add(fila);
        
        Session["pedido"] = carrito;
    }


    public void CargarDetalle()
    {
        dtb = new DataTable();
       
        dtb.Columns.Add("codigo");
        dtb.Columns.Add("descripcion");
        dtb.Columns.Add("precio");
        dtb.Columns.Add("cantidad");
        dtb.Columns.Add("disponibilidad");
        dtb.Columns.Add("total");
       
        Session["pedido"] = dtb;
    }


    protected void Agregar_Click(object sender, EventArgs e)
    {
        
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
        try
        {
            EPedido entrada = new EPedido();
            LCliente resultado = new LCliente();
            entrada.Codigo = int.Parse(this.GVProductos.Rows[e.NewSelectedIndex].Cells[1].Text);
            entrada.Descripcion = this.GVProductos.Rows[e.NewSelectedIndex].Cells[2].Text;
            entrada.Precio = double.Parse(this.GVProductos.Rows[e.NewSelectedIndex].Cells[4].Text);
            entrada.IdSubsede = int.Parse(DL_subsede.SelectedValue.ToString());
            entrada.Pedido = (DataTable)Session["pedido"];
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            hashMap = (Dictionary<String, String>)Session["idioma"];
            entrada.MensajeProductoAgregado = hashMap["MensajeProductoAgregado"];
            entrada.MensajeProductosDeDiferentesSedes = hashMap["MensajeProductosDeDiferentesSedes"];
            entrada.MensajeProductoYaAgregado = hashMap["MensajeProductoYaAgregado"];
            entrada = resultado.agregarProducto(entrada, int.Parse(DL_subsede.SelectedValue.ToString()), Session["subsede"]);
            Session["subsede"] = entrada.IdSubsede;
            Session["pedido"] = entrada.Pedido;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "invocarfuncion", entrada.Mensaje, false);
        }
        catch (Exception)
        {

        }
       
    }

    protected void DL_subsede_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["subsede"] = null;
    }

    protected void GVProductos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("L_Header3")).Text = ((Dictionary<String, String>)Session["mensajes"])["GV_Idioma_Column0"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Row.FindControl("BAgregarCarrito")).Text = ((Dictionary<String, String>)Session["idioma"])["BAgregarCarrito"].ToString();
            }
        }
        catch (Exception exx)
        {
        }
    }



}