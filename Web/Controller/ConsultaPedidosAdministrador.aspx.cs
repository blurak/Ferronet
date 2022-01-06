using System;
using System.Collections.Generic;
using System.Web.UI;
using Logica;
public partial class View_ConsultaPedidosAdministrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        LSubsede inicio = new LSubsede();
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
            hashMap = datos.devolver("ConsultaPedidosAdministrador.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LPedidosActivos.Text = hashMap["LPedidosActivos"];
            lSeleccionePedido.Text = hashMap["LSeleccionePedido"];

            GW_pedidos.Columns[1].HeaderText = hashMap["GW_pedidosColumna1"];
            GW_pedidos.Columns[2].HeaderText = hashMap["GW_pedidosColumna2"];
            GW_pedidos.Columns[3].HeaderText = hashMap["GW_pedidosColumna3"];
            GW_pedidos.Columns[4].HeaderText = hashMap["GW_pedidosColumna4"];
            GW_pedidos.EmptyDataText = hashMap["EmptyGW_pedidos"];

            GW_detalle.Columns[0].HeaderText = hashMap["GW_detalleColumna0"];
            GW_detalle.Columns[1].HeaderText = hashMap["GW_detalleColumna1"];
            GW_detalle.Columns[2].HeaderText = hashMap["GW_detalleColumna2"];
            GW_detalle.Columns[3].HeaderText = hashMap["GW_detalleColumna3"];
            GW_detalle.Columns[4].HeaderText = hashMap["GW_detalleColumna4"];
            GW_detalle.EmptyDataText = hashMap["EmptyGW_detalle"];

        }
        catch (Exception)
        {

        }


    }
}