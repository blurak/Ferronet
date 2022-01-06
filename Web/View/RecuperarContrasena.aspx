<%@ Page Title="" Language="C#" MasterPageFile="~/View/principal.master" AutoEventWireup="true" CodeFile="~/Controller/RecuperarContrasena.aspx.cs" Inherits="View_RecuperarContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style13 {
            width: 25%
            ;
        }
        .auto-style14 {
            width: 213px;
        }
        .auto-style15 {
            width: 25%;
        }
    .auto-style16 {
        text-align: center;
    }
    .auto-style17 {
        width: 100%;
        height: 473px;
    }
    .auto-style18 {
        width: 100%;
        height: 430px;
    }
    .auto-style19 {
        width: 100%;
        height: 257px;
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
    <table class="auto-style17">
    <tr>
        <td>
            <br />
            <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="435px" Width="100%">
                <table class="auto-style18">
                    <tr>
                        <td class="auto-style13">&nbsp;</td>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="438px" Width="589px">
                                <table class="auto-style19">
                                    <tr>
                                        <td class="auto-style15">&nbsp;</td>
                                        <td>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LDigiteSuNueva" runat="server" Font-Size="Large" Text="Digite su nueva contraseña"></asp:Label>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <br />
                                                        <br />
                                                        <asp:TextBox ID="TB_1" runat="server" BackColor="Silver" Font-Size="Medium" OnTextChanged="TB_1_TextChanged" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_1" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonCambiar"></asp:RequiredFieldValidator>
                                                        <br />
                                                        <br />
                                                        <asp:RegularExpressionValidator ID="REContrasenaExpresion" runat="server" ControlToValidate="TB_1" CssClass="auto-style20" ErrorMessage="contraseña en formato incorrecto solo pueden ser letras, numeros, sin espacios y de 4 a 16 caracteres" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9]{4,16})$" ValidationGroup="BotonCambiar"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <asp:Label ID="LRepitaContrasena" runat="server" Font-Size="Large" Text="Repita su nueva contraseña"></asp:Label>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <asp:TextBox ID="TB_2" runat="server" BackColor="Silver" Font-Size="Medium" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_2" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonCambiar"></asp:RequiredFieldValidator>
                                                        <br />
                                                        <asp:RegularExpressionValidator ID="RERepitaExpresion" runat="server" ControlToValidate="TB_2" CssClass="auto-style20" ErrorMessage="contraseña en formato incorrecto solo pueden ser letras, numeros, sin espacios y de 4 a 16 caracteres" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9]{4,16})$" ValidationGroup="BotonCambiar"></asp:RegularExpressionValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="LInformacion" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style16" colspan="2">
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="BCambiar" runat="server" BackColor="#FF952B" Font-Size="Medium" Height="38px" OnClick="Button1_Click" Text="Cambiar" Width="104px" ValidationGroup="BotonCambiar" />
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
        </td>
    </tr>
</table>
</asp:Content>

