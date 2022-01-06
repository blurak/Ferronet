using Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controller_InventarioSubsede : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

     
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
            LSede buscar = new LSede();
        
            GwProductosSede.DataSource = buscar.buscarProductosEnInventarioSede(TbBuscar.Text.ToString(), int.Parse(Session["user_id"].ToString()));
            GwProductosSede.DataBind();
        }
        catch(Exception)
        {
            //String script = @"<script type='text/javascript'>SesionNula();</script>";
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "myKey", script);
        }
        try
        {
            LVisitante datos = new LVisitante();
            Dictionary<String, String> hashMap = new Dictionary<string, string>();
            String selectedLanguaje = Session["terminacion"].ToString();
            hashMap = datos.devolver("InventarioSubsede.aspx", selectedLanguaje);
            Session["idioma"] = hashMap;

            LBSubsede.Text = hashMap["LBSubsede"];
            LBInventarioActualSede.Text = hashMap["LBInventarioActualSede"];
            BTBuscar.Text = hashMap["BTBuscar"];
            IBSalir.ImageUrl = hashMap["IBSalir"];

            GwProductosSede.Columns[1].HeaderText = hashMap["GwProductosSede0"];
            GwProductosSede.Columns[2].HeaderText = hashMap["GwProductosSede1"];
            GwProductosSede.Columns[3].HeaderText = hashMap["GwProductosSede2"];
            GwProductosSede.Columns[4].HeaderText = hashMap["GwProductosSede3"];
            GwProductosSede.Columns[5].HeaderText = hashMap["GwProductosSede4"];
            





        }
        catch (Exception)
        {

        }


    }

    

    protected void BtBuscar_Click(object sender, EventArgs e)
    {
        LSede buscar = new LSede();
        GwProductosSede.DataSource = buscar.buscarProductosEnInventarioSede(TbBuscar.Text.ToString(), int.Parse(Session["user_id"].ToString()));
        
        GwProductosSede.DataBind();
    }

    protected void GwProductosSede_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)

    {

        int idProducto = Convert.ToInt32(GwProductosSede.DataKeys[e.NewSelectedIndex].Value);
        Session["idProducto"] = idProducto;
        Session["subsede"] = DL_subsede.SelectedValue.ToString();

        String script = @"<script type='text/javascript'>VentanaCantidades();</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion",script, false);

       
        
        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", script);

    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        String script = @"<script type='text/javascript'>var pop;pop = window.open('Cantidades.aspx', 'cantidade', 'width=310, height=530,menubar=si');pop.focus();alert('jsahasa');</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", script, false);
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", script);
    }

    protected void GwProductosSede_PageIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void GwProductosSede_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        LSede traer = new LSede();
        GwProductosSede.PageIndex = e.NewPageIndex;
        GwProductosSede.DataSource = traer.buscarProductosConId(int.Parse(Session["user_id"].ToString()));
        GwProductosSede.DataBind();
    }

    protected void GwProductosSede_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            try
            {
                ((Label)e.Row.FindControl("L_Header3")).Text = ((Dictionary<String, String>)Session["mensajes"])["GV_Idioma_Column0"].ToString();
            }
            catch (Exception exe)
            {

                ((Button)e.Row.FindControl("BEliminar")).Text = ((Dictionary<String, String>)Session["idioma"])["BEliminar"].ToString();
                

            }
        }
        catch (Exception exx)
        {
        }
    }
}