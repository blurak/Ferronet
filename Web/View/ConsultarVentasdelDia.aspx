<%@ Page Title="" Language="C#" MasterPageFile="~/View/Administrador.master" AutoEventWireup="true" CodeFile="~/Controller/ConsultarVentasdelDia.aspx.cs" Inherits="View_ConsultarVentasdelDia" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style9 {
            height: 70px;
        }
    .auto-style29 {
        width: 100%;
        height: 351px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style27 {
            width: 30%;
        }
        .auto-style30 {
            font-size: large;
        }
        </style>
      <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script> 
    <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style9">
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1100px" Width="100%">
                    <br />
                    <table class="auto-style29">
                        <tr>
                            <td class="auto-style27">&nbsp;</td>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1002px" Width="600px">
                                    <table class="auto-style1">
                                        <tr>
                                            <td>
                                                <br />
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="LInstruccionUno" runat="server" CssClass="auto-style30" Text="Seleccione la venta para ver el detalle:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <div class="auto-style8">
                                                            <asp:GridView ID="GVVenta" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdVenta" DataSourceID="ODS_VentasDia" ForeColor="#333333" GridLines="None" Height="146px" Width="580px" EmptyDataText="Aun no hay ventas que mostrar">
                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                <Columns>
                                                                    <asp:CommandField ShowSelectButton="True" />
                                                                    <asp:BoundField DataField="IdVenta" HeaderText="Codigo de venta" />
                                                                    <asp:BoundField DataField="Total" HeaderText="Valor total" />
                                                                    <asp:BoundField DataField="Dia" HeaderText="Fecha" />
                                                                    <asp:BoundField DataField="Hora" HeaderText="Hora" />
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
                                                        </div>
                                                        <asp:ObjectDataSource ID="ODS_VentasDia" runat="server" SelectMethod="ObtenerVentasSubsedeAdmin" TypeName="Logica.LSubsede">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="administrador" SessionField="user_id" Type="Int32" DefaultValue="" />
                                                                <asp:SessionParameter DefaultValue="" Name="fecha" SessionField="Fechahoy" Type="String" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                        <br />
                                                        <br />
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="LDetalleVenta" runat="server" CssClass="auto-style30" Text="Detalle de venta:"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <asp:GridView ID="GVDetalleVenta" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="DAOSDetalleVenta" ForeColor="#333333" GridLines="None" Width="580px" EmptyDataText="Aun no hay ninguna venta seleccionada">
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Producto" HeaderText="Producto" />
                                                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                                                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                                                <asp:BoundField DataField="ValorTotal" HeaderText="Valor total" />
                                                            </Columns>
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
                                                        <asp:ObjectDataSource ID="DAOSDetalleVenta" runat="server" SelectMethod="ObtenerDetalleVentasPorSubsede" TypeName="Logica.LSede">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="GVVenta" Name="id_venta" PropertyName="SelectedValue" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                        <asp:Label ID="LDetalleVenta0" runat="server" CssClass="auto-style30" Text="Total Vendido:"></asp:Label>
                                                        <br />
                                                        <asp:GridView ID="GVTotalVendido" runat="server" AutoGenerateColumns="true" DataSourceID="DAOSTotaVendido" EmptyDataText="Aun no hay ninguna venta seleccionada">
                                                        </asp:GridView>
                                                        <asp:ObjectDataSource ID="DAOSTotaVendido" runat="server" SelectMethod="ObtenerTotalVendidoHoyAdmin" TypeName="Logica.LSubsede">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="id_usuario" SessionField="user_id" Type="Int32" />
                                                                <asp:SessionParameter Name="fechaHoy" SessionField="Fechahoy" Type="String" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td class="auto-style8">
                                                                    <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/ConsultaVentasAdministrador.aspx" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="GVVenta" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <br />
                                                &nbsp;<br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </td>
        </tr>
        </table>
</asp:Content>

