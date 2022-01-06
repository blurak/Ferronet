<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/Proveedores.aspx.cs" Inherits="View_Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style12 {
            width: 20%;
        }
        .auto-style13 {
            width: 16%;
        }
        .auto-style14 {
            height: 23px;
            text-align: center;
        }
        .auto-style19 {
            width: 234px;
        }
        .auto-style20 {
            font-size: small;
        }
    </style>
 <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="719px">
        <table class="auto-style1">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="600px" Width="666px">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style13">&nbsp;</td>
                                <td>
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style9" colspan="2">
                                                <br />
                                                <asp:Label ID="LBRegistrar" runat="server" Text="Registrar proveedor" Font-Size="X-Large"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                                <br />
                                                <asp:Label ID="LBNombre" runat="server" Font-Size="Large" Text="Nombre"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                                <br />
                                                <br />
                                                <asp:TextBox ID="TB_nombre" runat="server" BackColor="Silver" Font-Size="Medium" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red" ValidationGroup="botonRegistrar"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="RENombre" runat="server" ControlToValidate="TB_nombre" CssClass="auto-style20" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="[a-zA-ZñÑ\s]{3,50}" ValidationGroup="botonRegistrar">Nombre en formato incorrecto no debe contener caracteres especiales,numeros  ni espacios</asp:RegularExpressionValidator>
                                                <ajaxToolkit:ValidatorCalloutExtender ID="RENombre_ValidatorCalloutExtender" runat="server" BehaviorID="RENombre_ValidatorCalloutExtender" TargetControlID="RENombre">
                                                </ajaxToolkit:ValidatorCalloutExtender>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">
                                                <br />
                                                <asp:Label ID="LBCorreo" runat="server" Text="correo electronico" Font-Size="Large"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TB_correo" runat="server" BackColor="Silver" Font-Size="Medium"  TextMode="Email"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_correo" ErrorMessage="*" ForeColor="Red" ValidationGroup="botonRegistrar"></asp:RequiredFieldValidator>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">
                                                <br />
                                                <asp:Label ID="LBTelefono" runat="server" Text="telefono" Font-Size="Large"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                                <br />
                                                <asp:TextBox ID="telefono" runat="server" BackColor="Silver" Font-Size="Medium" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="telefono" ErrorMessage="*" ForeColor="Red" ValidationGroup="botonRegistrar"></asp:RequiredFieldValidator>
                                                <br />
                                                <br />
                                                <asp:RegularExpressionValidator ID="RETelefono" runat="server" ControlToValidate="telefono" CssClass="auto-style20" ErrorMessage="Solo se pueden ingresar numeros" ForeColor="Red" ValidationExpression="^[0-9\s]+$" ValidationGroup="botonRegistrar"></asp:RegularExpressionValidator>
                                                <ajaxToolkit:ValidatorCalloutExtender ID="RETelefono_ValidatorCalloutExtender" runat="server" BehaviorID="RETelefono_ValidatorCalloutExtender" TargetControlID="RETelefono">
                                                </ajaxToolkit:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">
                                                <br />
                                                <br />
                                                <br />
                                                <asp:Label ID="LBCategoria" runat="server" Text="Categoria que provee" Font-Size="Large"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DRL_categoria" runat="server" Font-Size="Medium" DataSourceID="DAOSCategorias" DataTextField="Cliente" DataValueField="NumeroPedido">
                                                    <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                                    <asp:ListItem Value="1">Plomeria</asp:ListItem>
                                                    <asp:ListItem Value="2">Electricidad</asp:ListItem>
                                                    <asp:ListItem Value="3">Elementos de epp</asp:ListItem>
                                                    <asp:ListItem Value="4">Fijaciones y adhesivos</asp:ListItem>
                                                    <asp:ListItem Value="5">Tornilleria</asp:ListItem>
                                                    <asp:ListItem Value="6">Herramientas</asp:ListItem>
                                                    <asp:ListItem Value="7">Elementos de pinturas</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="DAOSCategorias" runat="server" SelectMethod="obtenerCategorias" TypeName="Logica.LSede"></asp:ObjectDataSource>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style14" colspan="2">
                                                <br />
                                                <br />
                                                <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" Font-Size="Medium" Height="40px" BackColor="#FF952B" ValidationGroup="botonRegistrar" OnClick="BtnRegistrar_Click" />
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
</asp:Content>

