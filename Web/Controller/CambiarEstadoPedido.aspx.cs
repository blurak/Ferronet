using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using Utilitarios;



public partial class View_CambiarEstadoPedido : System.Web.UI.Page
{
    private int[] cant;
    private string[] id;
    public int contador;




    //DataTable dt = new DataTable();
    //List<int> list = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
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
            hashMap = datos.devolver("CambiarEstadoPedido.aspx", selectedLanguaje);
            GW_CambiaE.Columns[0].HeaderText = hashMap["GW_CambiaE0"];
            GW_CambiaE.Columns[1].HeaderText = hashMap["GW_CambiaE1"];
            GW_CambiaE.Columns[2].HeaderText = hashMap["GW_CambiaE2"];
            GW_CambiaE.Columns[3].HeaderText = hashMap["GW_CambiaE3"];
            GW_CambiaE.Columns[4].HeaderText = hashMap["GW_CambiaE4"];
            GW_CambiaE.Columns[5].HeaderText = hashMap["GW_CambiaE5"];
            GW_CambiaE.Columns[6].HeaderText = hashMap["GW_CambiaE6"];
            GW_CambiaE.EmptyDataText = hashMap["EmptyCambiar"];
            LBSeleccione.Text = hashMap["LBSeleccione"];
            LBCambiarE.Text = hashMap["LBCambiarE"];
            IBSalir.ImageUrl = hashMap["IBSalir"];
        }
        catch (Exception)
        {

        }

    }

    protected void Button5_Click1(object sender, EventArgs e)
    {
        
       

    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        

        bool mirar;
        string columna;
        int mirarcolumna;
        CheckBox btn = (CheckBox)sender;

        mirar = btn.Checked;
        columna = btn.ClientID;
        string string2 = Convert.ToString(columna[columna.Length - 1]);
        mirarcolumna = Convert.ToInt32(string2);
        id = new string[GW_CambiaE.Rows.Count];
        int NumeroRows = GW_CambiaE.Rows.Count;
        LCajero c = new LCajero();
        EPedido resultado = new EPedido();
        LSubsede a = new LSubsede();

        GridViewRow row = GW_CambiaE.Rows[mirarcolumna];
        id[mirarcolumna] = GW_CambiaE.Rows[mirarcolumna].Cells[1].Text;
        int id_producto = int.Parse(id[mirarcolumna]);

        
        resultado.IdPedido = id_producto;
        
        resultado=a.obtenerpedidoCajeo(resultado);
        resultado.Estado1 = "Entregado";
        //c.CambiarEstado(id_producto, int.Parse(Session["user_id"].ToString()));
        resultado.Hora =Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
        resultado.Last= Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));
        a.ActualizarEstadoPedido(resultado);
        Response.Redirect("CambiarEstadoPedido.aspx"); 
    }
}