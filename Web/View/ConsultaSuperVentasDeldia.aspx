<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/ConsultaSuperVentasDeldia.aspx.cs" Inherits="View_ConsultaSuperVentasDeldia" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style29 {
        width: 100%;
        height: 477px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style27 {
            width: 11%;
        }
        .auto-style24 {
            width: 99%;
            height: 287px;
            position:center;
        }
        .auto-style15 {
            text-align: center;
        }
        .auto-style31 {
            font-size: large;
        }
        .auto-style32 {
            font-size: xx-large;
        }
        .auto-style33 {
            margin-right: 4;
        }
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1100px" Width="100%" CssClass="auto-style33">
                    <br />
                    <table class="auto-style29">
                        <tr>
                            <td class="auto-style27">&nbsp;</td>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1050px" Width="858px">
                                    <table class="auto-style1">
                                        <tr>
                                            <td>
                                                <table align="center" class="auto-style24">
                                                    <tr>
                                                        <td class="auto-style15">
                                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                            </asp:ScriptManager>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style15">
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <table class="auto-style1">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:Label ID="LBVentas" runat="server" CssClass="auto-style32" Text="VENTAS DEL DIA"></asp:Label>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <br />
                                                                                <asp:Label ID="LBSeleccionSub" runat="server" CssClass="auto-style31" Text="Seleccione la sede:"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <br />
                                                                                <asp:Label ID="LBSeleccioneVenta" runat="server" CssClass="auto-style31" Text="Seleccione la venta para ver el detalle"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <br />
                                                                                <br />
                                                                                <asp:GridView ID="GWSede" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="IdProducto" DataSourceID="ODSubsedes" AllowPaging="True" AutoGenerateColumns="False" Height="173px" Width="386px" EmptyDataText="Aun no tiene subsedes registradas">
                                                                                    <Columns>
                                                                                        <asp:CommandField ShowSelectButton="True" />
                                                                                        <asp:BoundField DataField="IdProducto" HeaderText="Codigo de subsede" />
                                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Nombre" />
                                                                                    </Columns>
                                                                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                                                                </asp:GridView>
                                                                                <asp:ObjectDataSource ID="ODSubsedes" runat="server" SelectMethod="ObtenerSubsedees" TypeName="Logica.LSede">
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                            <td>
                                                                                <br />
                                                                                <asp:GridView ID="GWVenta" runat="server" DataKeyNames="IdVenta" DataSourceID="ODSVentasSubsede" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" EmptyDataText="No tenemos ventas que mostrar" GridLines="Horizontal" Width="440px">
                                                                                    <Columns>
                                                                                        <asp:CommandField ShowSelectButton="True" />
                                                                                        <asp:BoundField DataField="IdVenta" HeaderText="Codigo de venta" />
                                                                                        <asp:BoundField DataField="Total" HeaderText="Valor total" />
                                                                                        <asp:BoundField DataField="Dia" HeaderText="Fecha" />
                                                                                        <asp:BoundField DataField="Hora" HeaderText="Hora" />
                                                                                    </Columns>
                                                                                    <FooterStyle BackColor="White" ForeColor="#333333" />
                                                                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <RowStyle BackColor="White" ForeColor="#333333" />
                                                                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                                                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                                                    <SortedDescendingHeaderStyle BackColor="#275353" />
                                                                                </asp:GridView>
                                                                                <asp:ObjectDataSource ID="ODSVentasSubsede" runat="server" SelectMethod="ObtenerVentasPorSubsede" TypeName="Logica.LSede">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="GWSede" Name="id_subsede" PropertyName="SelectedValue" Type="Int32" />
                                                                                        <asp:SessionParameter Name="fecha" SessionField="Fechahoy" Type="String" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <br />
                                                                                <br />
                                                                                <br />
                                                                                <br />
                                                                                <asp:Label ID="LBDetalle" runat="server" CssClass="auto-style31" Text="Detalle de la venta"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:GridView ID="GWDetalle" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="ODSObtenerDetalleVenta" ForeColor="#333333" GridLines="None" Width="360px" EmptyDataText="Aun no hay ventas seleccionada">
                                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="Producto" HeaderText="Producto" />
                                                                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                                                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                                                                        <asp:BoundField DataField="ValorTotal" HeaderText="Valor total" />
                                                                                    </Columns>
                                                                                    <EditRowStyle BackColor="#999999" />
                                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                                                </asp:GridView>
                                                                                <asp:ObjectDataSource ID="ODSObtenerDetalleVenta" runat="server" SelectMethod="ObtenerDetalleVentasPorSubsede" TypeName="Logica.LSede">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="GWVenta" Name="id_venta" PropertyName="SelectedValue" Type="Int32" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                            </td>
                                                                            <td>
                                                                                <br />
                                                                                <br />
                                                                                <br />
                                                                                <asp:GridView ID="GWTotalVendido" runat="server" CellPadding="4" DataSourceID="ODSObtenerto" ForeColor="#333333" GridLines="None" Width="205px">
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                    <EditRowStyle BackColor="#7C6F57" />
                                                                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <RowStyle BackColor="#E3EAEB" />
                                                                                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                                                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                                                                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                                                                                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                                                                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                                                </asp:GridView>
                                                                                <asp:ObjectDataSource ID="ODSObtenerto" runat="server" SelectMethod="ObtenerTotalVendidoHoy" TypeName="Logica.LSede">
                                                                                    <SelectParameters>
                                                                                        <asp:ControlParameter ControlID="GWSede" Name="idSubsede" PropertyName="SelectedValue" Type="Int32" />
                                                                                        <asp:SessionParameter Name="fechaHoy" SessionField="Fechahoy" Type="String" />
                                                                                    </SelectParameters>
                                                                                </asp:ObjectDataSource>
                                                                                <br />
                                                                                <br />
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="GWSede" EventName="SelectedIndexChanged" />
                                                                    <asp:AsyncPostBackTrigger ControlID="GWDetalle" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style15">
                                                            <br />
                                                            <br />
                                                            <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/ConsultasSubsede.aspx" />
                                                            <br />
                                                            <br />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
        <br />
    </asp:Content>

