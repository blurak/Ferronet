using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;

public partial class View_ConsultarPedidoCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LCliente inicio = new LCliente();

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
            EPedido resultado = new EPedido();
            resultado= inicio.devolverIdPedido(int.Parse((String)Session["user_id"].ToString()));
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", resultado.Mensaje);
            nPedido.Text = resultado.Cantidad.ToString();
        }
        catch (Exception)
        {

        }

        try
        {

            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("ConsultarPedidoCliente.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LInformacion.Text = hashMap["LInformacion"];
            LNumeroPedido.Text = hashMap["LNumeroPedido"];

            GVDetallePedido.Columns[0].HeaderText = hashMap["GVDetallePedidoColumna0"];
            GVDetallePedido.Columns[1].HeaderText = hashMap["GVDetallePedidoColumna1"];
            GVDetallePedido.Columns[2].HeaderText = hashMap["GVDetallePedidoColumna2"];
            GVDetallePedido.Columns[3].HeaderText = hashMap["GVDetallePedidoColumna3"];
            GVDetallePedido.Columns[4].HeaderText = hashMap["GVDetallePedidoColumna4"];
        }
        catch (Exception)
        {

        }
        
        
       
    }

    protected void DLTotalYTipo_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Item.FindControl("L_Header3")).Text = ((Dictionary<String, String>)Session["mensajes"])["GV_Idioma_Column0"].ToString();
            }
            catch (Exception exe)
            {

                ((Label)e.Item.FindControl("LTotal")).Text = ((Dictionary<String, String>)Session["idioma"])["LTotal"].ToString();
                ((Label)e.Item.FindControl("LTipo")).Text = ((Dictionary<String, String>)Session["idioma"])["LTipo"].ToString();
            }
        }
        catch (Exception exx)
        {
        }
    }
}


