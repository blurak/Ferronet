<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/CrearProducto.aspx.cs" Inherits="View_AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style12 {
            width: 20%;
        }
        .auto-style16 {
            width: 100%;
            height: 455px;
        }
        .auto-style17 {
            width: 100%;
            height: 331px;
        }
        .auto-style18 {
            text-align: left;
        }
        .auto-style19 {
            font-size: xx-large;
        }
        .auto-style20 {
            font-size: large;
        }
        .auto-style21 {
            font-size: medium;
        }
        .auto-style22 {
            width: 340px;
        }
        .auto-style23 {
            font-size: small;
        }
                           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        </style>
    
  <script type="text/javascript" src="javascript/sede.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="1405px">
        <table class="auto-style16">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="806px" Width="803px">
                        <br />
                        <br />
                        <br />
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style9">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:Label ID="LBRegisPro" runat="server" CssClass="auto-style19" Text="Registre sus productos"></asp:Label>
                                    <br />
                                    <br />
                                    <table class="auto-style17">
                                        <tr>
                                            <td class="auto-style22">
                                                <asp:Label ID="LBPrecio" runat="server" Text="Precio" CssClass="auto-style20"></asp:Label>
                                            </td>
                                            <td class="auto-style18">
                                                <br />
                                                <br />
                                                <asp:TextBox ID="TB_precio" runat="server" BackColor="Silver" CssClass="auto-style21" MaxLength="9"></asp:TextBox>
                                                <ajaxToolkit:MaskedEditExtender ID="TB_precio_MaskedEditExtender" runat="server" BehaviorID="TB_precio_MaskedEditExtender" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" TargetControlID="TB_precio" Mask="999999" MaskType="Number"  DisplayMoney="Right" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TB_precio" ValidationGroup="BotonRegistrar"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TB_precio" CssClass="auto-style23" ErrorMessage="Formato incorrecto de precio" ForeColor="Red" ValidationExpression="^[0-9]+([\,|\.]{0,1}[0-9]{2}){0,1}$" ValidationGroup="BotonRegistrar"></asp:RegularExpressionValidator>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style22">
                                                <asp:Label ID="LBDescripcion" runat="server" Text="Descripcion" CssClass="auto-style20"></asp:Label>
                                            </td>
                                            <td class="auto-style18">
                                                <asp:TextBox ID="TA_descripcion" runat="server" Height="136px" TextMode="MultiLine" Width="212px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="TA_descripcion" ValidationGroup="BotonRegistrar"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="RECaracteresEspecia" runat="server" ControlToValidate="TA_descripcion" CssClass="auto-style23" ErrorMessage="No se pueden incluir caracteres especiales" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9\s-]+$" ValidationGroup="BotonRegistrar"></asp:RegularExpressionValidator>
                                                <ajaxToolkit:ValidatorCalloutExtender ID="RECaracteresEspecia_ValidatorCalloutExtender" runat="server" BehaviorID="RECaracteresEspecia_ValidatorCalloutExtender" TargetControlID="RECaracteresEspecia">
                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                <br /> </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style22">
                                                <br />
                                                <asp:Label ID="LBImagen" runat="server" Text="Imagen" CssClass="auto-style20"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style18">
                                                <br />
                                                <asp:FileUpload ID="imagen" runat="server" Height="22px" Width="276px" BackColor="Silver" ValidateRequestMode="Enabled" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="imagen" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrar"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:Label ID="LImagenIncorrecta" runat="server" CssClass="auto-style23" ForeColor="Red"></asp:Label>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style22">
                                                <asp:Label ID="LBCategoria" runat="server" Text="Categoria" CssClass="auto-style20"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style18">
                                                <br />
                                                <br />
                                                <br />
                                                <asp:DropDownList ID="DL_categoria" runat="server" DataSourceID="DAOCategorias" DataTextField="Cliente" DataValueField="NumeroPedido" Height="42px" Width="169px" BackColor="Silver">
                                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="DAOCategorias" runat="server" SelectMethod="obtenerCategorias" TypeName="Logica.LSede"></asp:ObjectDataSource>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="DL_categoria" ValidationGroup="BotonRegistrar"></asp:RequiredFieldValidator>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style22">
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/InventarioSede.aspx" />
                                            </td>
                                            <td>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <asp:Button ID="BTAgregar" runat="server"  Text="Agregar producto" BackColor="#FF952B" CssClass="auto-style21" Height="40px" ValidationGroup="BotonRegistrar" OnClick="BT_agregar_Click" />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

