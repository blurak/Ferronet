<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/Productos_subsede.aspx.cs" Inherits="View_Productos_subsede" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style29 {
        width: 100%;
        height: 572px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style30 {
            width: 20%;
        }
        .auto-style34 {
            width: 443px;
        }
        .auto-style36 {
            font-size: large;
        }
    </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="100%" Width="100%">
                    <br />
                    <table class="auto-style29">
                        <tr>
                            <td class="auto-style30">&nbsp;</td>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="466px" Width="938px">
                                    <br />
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td class="auto-style34">
                                                        <asp:Label ID="LBSeleccionSub" runat="server" CssClass="auto-style36" Text="Seleccione una subsede"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <br />
                                                        <asp:Label ID="LBInventario" runat="server" CssClass="auto-style36" Text="Inventario"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style34">
                                                        <asp:GridView ID="GW_Subsedes" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="IdProducto" DataSourceID="ODS_obtenerSubsedesSuper" ForeColor="Black" GridLines="None" Height="177px" Width="309px" AllowPaging="True" EmptyDataText="Aun no hay subsedes registradas">
                                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                            <Columns>
                                                                <asp:BoundField DataField="IdProducto" HeaderText="Codigo subsede" />
                                                                <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
                                                            </Columns>
                                                            <FooterStyle BackColor="Tan" />
                                                            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                                            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                                                        </asp:GridView>
                                                        <asp:ObjectDataSource ID="ODS_obtenerSubsedesSuper" runat="server" SelectMethod="ObtenerSubsedees" TypeName="Logica.LSede">
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                    <td>
                                                        <div class="auto-style9">
                                                            <asp:GridView ID="GW_Productos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ODS_ProductosSubsde" EmptyDataText="No Tiene Subsede Seleccionada o la subsede no tiene inventario" ForeColor="Black" GridLines="Horizontal" Height="177px" style="margin-left: 0px" Width="448px" AllowPaging="True">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Precio" HeaderText="Codigo producto" />
                                                                    <asp:BoundField DataField="Producto" HeaderText="Descripcion" />
                                                                    <asp:BoundField DataField="ValorTotal" HeaderText="Cantidad minima" />
                                                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                                            </asp:GridView>
                                                            <asp:ObjectDataSource ID="ODS_ProductosSubsde" runat="server" SelectMethod="ObtenerProductosPorsubsede" TypeName="Logica.LSede">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="GW_Subsedes" Name="id_subsede" PropertyName="SelectedValue" Type="Int32" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GW_Subsedes" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <br />
                                    <br />
                                    <br />
                                    <asp:ImageButton ID="IBSalir" runat="server" Height="90px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/ConsultasSubsede.aspx" />
                                    <br />
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </asp:Content>

