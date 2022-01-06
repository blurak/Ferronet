<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/AgregarProducto.aspx.cs" Inherits="View_AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style12 {
            width: 20%;
        }
        .auto-style17 {
            width: 100%;
            height: 330px;
        }
        .auto-style21 {
            text-align: center;
            height: 100px;
        }
        .auto-style23 {
            text-align: center;
            height: 99px;
            width: 29%;
        }
        .auto-style24 {
            text-align: left;
            height: 99px;
        }
        .auto-style25 {
            font-size: xx-large;
        }
        .auto-style26 {
            width: 29%;
            text-align: center;
        }
        .auto-style27 {
            width: 130px;
        }
        .auto-style28 {
            font-size: medium;
        }
        .auto-style29 {
            font-size: large;
        }
        .auto-style30 {
            width: 130px;
            height: 86px;
        }
        .auto-style31 {
            height: 86px;
        }
        .auto-style32 {
            width: 100%;
            height: 497px;
        }
        .auto-style33 {
            font-size: small;
            color: #FF0000;
        }
    </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="800px">
        <table class="auto-style32">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="730px" Width="763px">
                        <br />
                        <br />
                        <br />
                        <table class="auto-style17">
                            <tr>
                                <td class="auto-style21" colspan="2">
                                    <asp:Label ID="LBAsigneProductos" runat="server" CssClass="auto-style25" Text="Asigne los productos a su inventario"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style23"></td>
                                <td class="auto-style24">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style27">
                                                <br />
                                                <asp:Label ID="LBCantidad" runat="server" CssClass="auto-style29" Text="Cantidad"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <table class="auto-style1">
                                                    <tr>
                                                        <td>
                                                            <br />
                                                            <br />
                                                            <asp:TextBox ID="TB_cantidad" runat="server" BackColor="#CCCCCC" CssClass="auto-style28" TextMode="Number" MaxLength="10"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_cantidad" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonAgregar"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RangeValidator ID="RGCantidad" runat="server" ControlToValidate="TB_cantidad" CssClass="auto-style33" ErrorMessage="La cantidad excede el limite permitido maximo que es 429496729" MaximumValue="429496729" MinimumValue="1" Type="Integer" ValidationGroup="BotonAgregar"></asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style27">
                                                <asp:Label ID="LBCantidadMinima" runat="server" CssClass="auto-style29" Text="Cantidad minima"></asp:Label>
                                            </td>
                                            <td>
                                                <table class="auto-style1">
                                                    <tr>
                                                        <td>
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <asp:TextBox ID="TB_cantidad_minima" runat="server" BackColor="#CCCCCC" CssClass="auto-style28" TextMode="Number" MaxLength="10"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_cantidad_minima" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonAgregar"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RangeValidator ID="RGCantimin" runat="server" ControlToValidate="TB_cantidad_minima" CssClass="auto-style33" ErrorMessage="La cantidad excede el limite permitido maximo que es 429496729" MaximumValue="429496729" MinimumValue="1" Type="Integer" ValidationGroup="BotonAgregar"></asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style30">
                                                <br />
                                                <asp:Label ID="LBProducto" runat="server" CssClass="auto-style29" Text="Producto"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style31">
                                                <asp:DropDownList ID="DL_producto" runat="server" CssClass="auto-style28" Height="40px" Width="165px" BackColor="#CCCCCC" DataSourceID="DAOSProductos" DataTextField="Cliente" DataValueField="NumeroPedido">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DL_producto" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonAgregar"></asp:RequiredFieldValidator>
                                                <asp:ObjectDataSource ID="DAOSProductos" runat="server" SelectMethod="recuperarProductos" TypeName="Logica.LSede">
                                                    <SelectParameters>
                                                        <asp:SessionParameter Name="idusuario" SessionField="user_id" Type="Int32" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style26">
                                    <br />
                                    <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/InventarioSede.aspx" />
                                    <br />
                                </td>
                                <td class="auto-style9">
                                    <asp:Button ID="BTAgregarProducto" runat="server" BackColor="#FFB56A" Height="40px"  Text="Agregar producto a inventario" ValidationGroup="BotonAgregar" OnClick="BT_agregar_producto_Click" />
                                </td>
                            </tr>
                        </table>
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

