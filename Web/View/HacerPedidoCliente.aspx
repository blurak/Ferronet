<%@ Page Title="" Language="C#" MasterPageFile="~/View/Cliente.master" AutoEventWireup="true" CodeFile="~/Controller/HacerPedidoCliente.aspx.cs" Inherits="View_HacerPedidoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .auto-style32 {
            width: 100%;
            height: 1491px;
        }
                
        .auto-style12 {
            width: 20%;
        }
        .auto-style12 {
            width: 20%;
            height: 28px;
            text-align: center;
        }
        
        .auto-style17 {
            width: 100%;
            height: 712px;
        }
        .auto-style21 {
            text-align: center;
            height: 50px;
        }
        .auto-style35 {
            text-align: center;
            height: 48px;
        }
        .auto-style37 {
            font-size: large;
        }
        .auto-style38 {
            text-align: center;
            height: 48px;
            width: 202px;
        }
        .auto-style39 {
            font-size: medium;
        }
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="1906px">
        <table class="auto-style32">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1703px" Width="803px">
                        <asp:ImageButton ID="IBCarrito" runat="server" Height="331px" ImageUrl="~/Images/botones/carrito.jpg" PostBackUrl="~/View/Carrito.aspx" Width="472px" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table class="auto-style17">
                                    <tr>
                                        <td class="auto-style38">
                                            <asp:Label ID="LSeleccionarSede" runat="server" CssClass="auto-style37" Text="Seleccione la sede en que desea comprar:" Width="300px"></asp:Label>
                                        </td>
                                        <td class="auto-style35">
                                            <asp:Label ID="LBuscarProducto" runat="server" Text="Buscar producto"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style38">
                                            <asp:DropDownList ID="DL_subsede" runat="server" AutoPostBack="True" BackColor="#999999" DataSourceID="ODS_obtenerSubsedes0" DataTextField="Subsede" DataValueField="Id" Height="40px" Width="135px" CssClass="auto-style39" OnSelectedIndexChanged="DL_subsede_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:ObjectDataSource ID="ODS_obtenerSubsedes0" runat="server" SelectMethod="obtenerSubsedesDrop" TypeName="Logica.LCliente"></asp:ObjectDataSource>
                                        </td>
                                        <td class="auto-style35">&nbsp;&nbsp;<asp:TextBox ID="TbBusqueda" runat="server"></asp:TextBox>
                                            <asp:Button ID="BBuscar" runat="server" Text="buscar" />
                                            
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style21" colspan="2">
                                            <asp:GridView ID="GVProductos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="DAOProductospedido" ForeColor="#333333" GridLines="None" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" Width="790px"  OnRowDataBound="GVProductos_RowDataBound"  EmptyDataText="La subsede aun no tiene productos asignados">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen">
                                                        <ControlStyle Height="100px" />
                                                    </asp:ImageField>
                                                    <asp:BoundField DataField="Codigo_producto1" HeaderText="Codigo del producto" />
                                                    <asp:BoundField DataField="Descripcion1" HeaderText="Descripcion" />
                                                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                                                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                                    <asp:BoundField DataField="Subsede" HeaderText="Subsede" />
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:Button ID="BAgregarCarrito" runat="server" CausesValidation="False" CommandName="Select" Text="Agregar al carrito" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                            <asp:ObjectDataSource ID="DAOProductospedido" runat="server" SelectMethod="obtenerProductosCatalogo" TypeName="Logica.LCliente">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="DL_subsede" Name="idSubsede" PropertyName="SelectedValue" Type="Int32" />
                                                    <asp:ControlParameter ControlID="TbBusqueda" DefaultValue= " " PropertyName="Text" Type="String" Name="criterio" />
                                                </SelectParameters>
                                            </asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            <Triggers>
                                
                            </Triggers>
                        </asp:UpdatePanel>
                        <br />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
</asp:Content>

