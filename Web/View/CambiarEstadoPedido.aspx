<%@ Page Title="" Language="C#" MasterPageFile="~/View/Cajero.master" AutoEventWireup="true" CodeFile="~/Controller/CambiarEstadoPedido.aspx.cs" Inherits="View_CambiarEstadoPedido" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

              
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style33 {
            font-size: xx-large;
        }
        .auto-style36 {
            width: 23%;
        }
        .auto-style37 {
            text-align: left;
        }
        .auto-style41 {
            text-align: center;
            width: 47px;
        }
        .auto-style42 {
            font-size: x-large;
        }
    </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="750px" Width="100%">
                    <br />
                    <table class="auto-style29">
                        <tr>
                            <td class="auto-style36">&nbsp;</td>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="674px" Width="770px">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style6" colspan="2">
                                                <br />
                                                <asp:Label ID="LBCambiarE" runat="server" CssClass="auto-style33" Text="CAMBIAR ESTADO DE PEDIDO"></asp:Label>
                                                <br />
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style37" colspan="2">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table class="auto-style1">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="LBSeleccione" runat="server" CssClass="auto-style42" Text="Seleccione los pedidos que ya han sido entregados o despachados"></asp:Label>
                                                                    <br />
                                                                    <div class="auto-style6">
                                                                        <asp:GridView ID="GW_CambiaE" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="ODS_PedidoCajero" ForeColor="Black" GridLines="None" Height="188px" Width="744px" EmptyDataText="No hay pedidos que despachar">
                                                                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                                                            <Columns>
                                                                                <asp:TemplateField AccessibleHeaderText="Cantidad" HeaderText="Seleccion">
                                                                                    <EditItemTemplate>
                                                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                                                    </EditItemTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Id_pedido" HeaderText="N° pedido" />
                                                                                <asp:BoundField DataField="TipoDeEntrega" HeaderText="Tipo de entrega" />
                                                                                <asp:BoundField DataField="Direccion1" HeaderText="Direccion" />
                                                                                <asp:BoundField DataField="Total" HeaderText="Total" />
                                                                                <asp:BoundField DataField="Nombre1" HeaderText="Nombre del cliente" />
                                                                                <asp:BoundField DataField="Estado1" HeaderText="Estado" />
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
                                                                    </div>
                                                                    <asp:ObjectDataSource ID="ODS_PedidoCajero" runat="server" SelectMethod="ObtenerEstadoPedido" TypeName="Logica.LSubsede">
                                                                        <SelectParameters>
                                                                            <asp:SessionParameter Name="idUsuario" SessionField="user_id" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="auto-style6">
                                                                    <br />
                                                                    <asp:ImageButton ID="IBSalir" runat="server" Height="90px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/PedidosCajero.aspx" />
                                                                </td>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style41">
                                                &nbsp;</td>
                                            <td class="auto-style37">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
    </asp:Content>

