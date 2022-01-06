using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_Carrito : System.Web.UI.Page
{
    
    DataTable carrito = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            CargarCarrito();
        }



        LCliente inicio = new LCliente();
        //GW_carrito.DataSource = inicio.validarPost(Page.IsPostBack,(DataTable)Session["pedido"]);
        //GW_carrito.DataBind();

        try
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", inicio.ValidarSesion(Session["user_id"].ToString(), Session["id_rol"].ToString()));
        }
        catch (Exception)
        {
            Response.Redirect("IniciarSesion.aspx"); ;
        }

        try
        {

            EPedido pedido = new EPedido();
            pedido.Pedido = (DataTable)Session["pedido"];
            pedido.IdSubsede = (Int32)Session["subsede"];
            pedido = inicio.cargaIncio(pedido,(Int32)Session["subsede"], (DataTable)Session["pedido"]);
            LDireccion.Visible = false;
            TB_direccion.Visible = false;
            string[] separadas;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", pedido.Mensaje);
            separadas = pedido.TipoEntrega.Split(',');
            String latitud = separadas[0];
            String longitud = separadas[1];
            lat.Text = latitud;
            lon.Text = longitud;
            LDireccion.Visible = false;
            LB_total.Text = pedido.ValorTotal.ToString();
            TB_direccion.Visible = false;
            
        }
        catch (Exception)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", @"<script type='text/javascript'>alert('No hay pedidos aun en su carrito');windows.href.location('HacerPedidoCliente.aspx');</script>");
        }
        //if (Session["user_id"] == null)
        //{
        //    Response.Redirect("IniciarSesion.aspx");
        //}
        //else
        //{

        //    int rol = int.Parse(Session["id_rol"].ToString());
        //    if (rol != 1)
        //    {
        //        Response.Redirect("IniciarSesion.aspx");
        //        Session["user_id"] = null;

        //    }
        //    else
        //    {
        //        if (Session["subsede"] == null | Session["pedido"] == null)
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "Mensaje();", true);
        //            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "<script>javascript:Mensaje();</script>");
        //            Response.Redirect("HacerPedidoCliente.aspx");
        //        }
        //        else
        //        {
        //            var items = (DataTable)Session["pedido"];
        //            if (items.Rows.Count == 0)
        //            {
        //                Session["subsede"] = null;
        //                Response.Redirect("HacerPedidoCliente.aspx");
        //            }
        //           
        //            if (Page.IsPostBack == false)
        //            {
        //                //GW_carrito = null;
        //                CargarCarrito();

        //            }

        //            //DAOSubsede z = new DAOSubsede();
        //            //DataTable ubi = z.ObtenerUbicacion(int.Parse((String)Session["subsede"].ToString()));

        //            //String ubiacion = ubi.Rows[0]["ubicacion"].ToString();

        //            //string[] separadas;

        //            //separadas = ubiacion.Split(',');

        //            //String latitud = separadas[0];
        //            //String longitud = separadas[1];

        //            //lat.Text = latitud;
        //            //lon.Text = longitud;

        //        }

        //    }
        //}

        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("Carrito.aspx", selectedLanguaje);
      
            Session["idioma"] = hashMap;

            LProductoDisponible.Text = hashMap["LProductoDisponible"];
            LProductoNoDisponible.Text = hashMap["LProductoNoDisponible"];
            LInstruccion.Text = hashMap["LInstruccion"];
            BContinuarComprando.Text = hashMap["BContinuarComprando"];
            LTotalPedido.Text = hashMap["LTotalPedido"];
            LUbicacion.Text = hashMap["LUbicacion"];
            LBObtencion.Text = hashMap["LBObtencion"];
            LDireccion.Text = hashMap["LDireccion"];
            REDireccionExpresion.ErrorMessage = hashMap["REDireccionExpresion"];
            BT_confirmar.Text = hashMap["BT_confirmar"];

            GW_carrito.Columns[1].HeaderText = hashMap["GW_carrito_columnas0"];
            GW_carrito.Columns[2].HeaderText = hashMap["GW_carrito_columnas1"];
            GW_carrito.Columns[3].HeaderText = hashMap["GW_carrito_columnas2"];
            GW_carrito.Columns[4].HeaderText = hashMap["GW_carrito_columnas3"];
            GW_carrito.Columns[5].HeaderText = hashMap["GW_carrito_columnas4"];
            GW_carrito.Columns[6].HeaderText = hashMap["GW_carrito_columnas5"];

            if (DL_tipo_envio.Items.Count == 0)
            {
                DL_tipo_envio.Items.Clear();
                ListItem Seleccione = new ListItem(hashMap["DDSeleccione"], "0");
                DL_tipo_envio.Items.Add(Seleccione);
                ListItem Domicilio = new ListItem(hashMap["DDDomicilio"], "1");
                DL_tipo_envio.Items.Add(Domicilio);
                ListItem Contra = new ListItem(hashMap["DDContraEntrega"], "2");
                DL_tipo_envio.Items.Add(Contra);
            }




        }
        catch (Exception)
        {

        }


    }

    public void CargarCarrito()
    {
        GW_carrito.DataSource = Session["pedido"];
        GW_carrito.DataBind();
    }

    protected void GW_carrito_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            int index = Convert.ToInt32(e.CommandArgument);
            EPedido pedido = new EPedido();
            LCliente entrada = new LCliente();
            GridViewRow row = GW_carrito.Rows[index];
            pedido.Codigo = Convert.ToInt32(GW_carrito.DataKeys[index].Value);
            pedido.IdSubsede = int.Parse(Session["subsede"].ToString());
            TextBox txtsn = ((TextBox)row.FindControl("cantidadTB"));
            pedido.Cantidad = int.Parse(txtsn.Text);
            pedido.Pedido = (DataTable)Session["pedido"];
            pedido=entrada.validarCantidades(e.CommandName, pedido);
            Session["pedido"] = pedido.Pedido;
            LB_total.Text = pedido.Total.ToString();
            
            //((Label)row.FindControl("Label1")).Text = "X";
            //((Label)row.FindControl("Label1")).ForeColor = Color.Red;
        }
        catch(Exception)
        {

        }
           
        
    }

    protected void GW_carrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = Session["pedido"] as DataTable;
        dt.Rows[index].Delete();
        Session["pedido"] = dt;
        CargarCarrito();
    }

    protected void GW_carrito_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BT_continuar_Click(object sender, EventArgs e)
    {
       
    }

    protected void GW_carrito_RowDataBound(object sender, GridViewRowEventArgs e) {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("L_Header3")).Text = ((Dictionary<String, String>)Session["mensajes"])["GV_Idioma_Column0"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Row.FindControl("BEliminar")).Text = ((Dictionary<String, String>)Session["idioma"])["BEliminar"].ToString();
                ((LinkButton)e.Row.FindControl("LinBEditar")).Text = ((Dictionary<String, String>)Session["idioma"])["LinBEditar"].ToString();
                ((LinkButton)e.Row.FindControl("LinBCancelar")).Text = ((Dictionary<String, String>)Session["idioma"])["LinBCancelar"].ToString();
                ((LinkButton)e.Row.FindControl("LinBActualizar")).Text = ((Dictionary<String, String>)Session["idioma"])["LinBActualizar"].ToString();

            }
        }
        catch (Exception exx)
        {
        }

    }

    protected void DL_tipo_envio_SelectedIndexChanged(object sender, EventArgs e)
    {
        EPedido pedido = new EPedido();
        LCliente logica = new LCliente();
        String valslsala = DL_tipo_envio.SelectedValue.ToString();
        LDireccion.Visible= logica.validarDrop(DL_tipo_envio.SelectedItem.ToString());
        TB_direccion.Visible= logica.validarDrop(DL_tipo_envio.SelectedItem.ToString());
    }

    protected void BT_confirmar_Click(object sender, EventArgs e)
    {
        EPedido p = new EPedido();
        try
        {

            String mensaje = "", mensajeErroneo = "";
            try
            {
                Dictionary<String, String> hashMap = new Dictionary<string, string>();
                hashMap = (Dictionary<String, String>)Session["idioma"];
                p.MensajePedidoActivo = hashMap["MensajePedidoActivo"];
                p.MensajePedidoHecho = hashMap["MensajePedidoHecho"];
                p.MensajeSinProductosEnELCarrito = hashMap["MensajeSinProductosEnELCarrito"];
                p.MensajeProductosNoDisponibles = hashMap["MensajeProductosNoDisponibles"];
            }
            catch (Exception)
            {

            }
            LCliente logica = new LCliente();
            
            String selectedLanguaje = Session["terminacion"].ToString();

            p.TipoEntrega = DL_tipo_envio.SelectedItem.ToString();
            p.Direccion = TB_direccion.Text.ToString();
            p.ValorTotal = int.Parse(LB_total.Text);
            p.IdSubsede = int.Parse((String)Session["subsede"].ToString());
            p.IdUsuario = int.Parse((String)Session["user_id"].ToString());
            p.Session = Session.SessionID;
            p.Pedido = (DataTable)Session["pedido"];
            p = logica.validarPedidoYDespachar(p,selectedLanguaje);
            Session["pedido"] = p.Pedido;
            CargarCarrito();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "invocarfuncion", p.Mensaje, false);
        }
        catch (Exception bn)
        {
            string sss = bn.ToString();
            String lenguaje = Session["terminacion"].ToString();

            if (lenguaje.Equals("es-CO"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "invocarfuncion", @"<script type='text/javascript'>alert('Aun no tiene productos en su carrito ');window.location.href='HacerPedidoCliente.aspx';</script>", false);
            }
            if (lenguaje.Equals("en-US"))
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "invocarfuncion", @"<script type='text/javascript'>alert('You do not have any products in your cart yet');window.location.href='HacerPedidoCliente.aspx';</script>", false);
            }
           
        }
        
    }

    protected void GW_carrito_RowEditing(object sender, GridViewEditEventArgs e){
        GW_carrito.EditIndex = e.NewEditIndex;
        CargarCarrito();
    }

    protected void GW_carrito_RowUpdating(object sender, GridViewUpdateEventArgs e){
        //DataTable dt = (DataTable)Session["pedido"];
        GW_carrito.EditIndex = -1;
        CargarCarrito();
    }

    protected void GW_carrito_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e){
        GW_carrito.EditIndex = -1;
        CargarCarrito();
    }

    protected void GW_carrito_PageIndexChanging(object sender, GridViewPageEventArgs e){
        GW_carrito.PageIndex = e.NewPageIndex;
        CargarCarrito();
    }
}
