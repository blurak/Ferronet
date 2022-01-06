<%@ Page Title="" Language="C#" MasterPageFile="~/View/principal.master" AutoEventWireup="true" CodeFile="~/Controller/GenerarToken.aspx.cs" Inherits="View_GenerarToken" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style13 {
            width: 25%;
            height: 140px;
        }
        .auto-style14 {
            height: 20px;
        }
        .auto-style15 {
            height: 140px;
        }
        .auto-style16 {
            width: 100%;
            height: 306px;
        }
        .auto-style17 {
            width: 25%;
        }
    .auto-style18 {
        width: 100%;
        height: 135px;
    }
    .auto-style19 {
        width: 97%;
        height: 108px;
    }
    .auto-style20 {
        text-align: center;
    }
    .auto-style21 {
        text-align: right;
    }
    .auto-style22 {
        text-align: left;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="337px">
        <table class="auto-style16">
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style15">
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="248px" Width="732px">
                        <table class="auto-style18">
                            <tr>
                                <td class="auto-style20" colspan="2">
                                    <br />
                                    <br />
                                    <asp:Label ID="LInstruccion" runat="server" Font-Size="Large" ForeColor="#4A4A4A" Text="     Por favor, introduzca su username que utilizó para registrarse. Recibirá un enlace temporal para restablecer su contraseña."></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">&nbsp;</td>
                                <td>
                                    <table class="auto-style19">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label runat="server" Font-Size="Large" Text="Username" ID="LUsername"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TB_username" runat="server" BackColor="#CCCCCC" Font-Size="Medium"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_username" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRecuperar"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REUsernameExpresion" runat="server" ControlToValidate="TB_username" ErrorMessage="Username mal escrito" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9]{4,16})$" ValidationGroup="BotonRecuperar"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style21">
                                                <asp:Button ID="BRecuperar" runat="server" BackColor="#FF952B" Font-Size="Medium" OnClick="BT_recuperar_Click" Text="Recuperar" Width="100px" ValidationGroup="BotonRecuperar" />
                                            </td>
                                            <td class="auto-style20" colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style22" colspan="3">
                                                <asp:Label ID="LMensaje" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

