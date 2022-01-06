<%@ Page Title="" Language="C#" MasterPageFile="~/View/principal.master" AutoEventWireup="true" CodeFile="~/Controller/Contactenos.aspx.cs" Inherits="View_Contactenos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style13 {
            width: 22%;
        }
        .auto-style14 {
            width: 357px;
        }
        .auto-style15 {
            width: 15%;
        }
        .auto-style17 {
            width: 97%;
            height: 507px;
        }
        .auto-style18 {
            width: 100%;
            height: 576px;
        }
        .auto-style19 {
            width: 277px;
            text-align: right;
        }
        .auto-style20 {
            width: 100%;
        }
        .auto-style21 {
            margin-right: 19;
        }
        .auto-style22 {
            font-size: medium;
        }
        .auto-style25 {
            width: 50%;
        }
        .auto-style26 {
            font-size: small;
        }
    </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="714px" CssClass="auto-style21">
        <table class="auto-style18">
            <tr>
                <td class="auto-style13">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="546px" Width="745px">
                        <table class="auto-style17">
                            <tr>
                                <td class="auto-style15">&nbsp;</td>
                                <td>
                                    <table class="auto-style20">
                                        <tr>
                                            <td colspan="2">
                                                <br />
                                                <asp:Label ID="LCuentanos" runat="server" Font-Size="Large" Text="Cuentanos lo que piensas"></asp:Label>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="LInquietudes" runat="server" Text="Tus inquietudes y comentarios serán atendidos oportunamente."></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style25">
                                                <br />
                                                <br />
                                                <asp:Label ID="LNombre" runat="server" Font-Size="Medium" Text="Nombre"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                                <asp:TextBox ID="TB_nombre" runat="server" Font-Size="Medium" MaxLength="15"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red" ValidationGroup="botonEnviar"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="RENombreExpresion" runat="server" ControlToValidate="TB_nombre" CssClass="auto-style26" ErrorMessage="Formato incorrecto solo debe contener letras" ForeColor="Red" ValidationExpression="^[A-z\.\-\s]+$" ValidationGroup="botonEnviar">Formato incorrecto solo debe contener letras</asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style25">
                                                <br />
                                                <asp:Label ID="LCorreoElectronico" runat="server" Font-Size="Medium" Text="Correo electronico"></asp:Label>
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                                <asp:TextBox ID="TB_email" runat="server" Font-Size="Medium" TextMode="Email"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_email" ErrorMessage="*" ForeColor="Red" ValidationGroup="botonEnviar"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style25">
                                                <br />
                                                <br />
                                                <asp:Label ID="LAsunto" runat="server" Font-Size="Medium" Text="Asunto"></asp:Label>
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <br />
                                                <asp:TextBox ID="TB_asunto" runat="server" Font-Size="Medium" MaxLength="20"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_asunto" ErrorMessage="*" ForeColor="Red" ValidationGroup="botonEnviar"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REAsuntoExpresion" runat="server" ControlToValidate="TB_asunto" CssClass="auto-style26" ErrorMessage="Formato incorrecto solo debe contener letras" ForeColor="Red" ValidationExpression="^[A-z\.\-\s]+$" ValidationGroup="botonEnviar"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style25">
                                                <br />
                                                <asp:Label ID="LMensaje" runat="server" Font-Size="Medium" Text="Mensaje"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style22">
                                                <asp:TextBox ID="TBMensaje" runat="server" Height="122px" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TBMensaje" ErrorMessage="*" ForeColor="Red" ValidationGroup="botonEnviar"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:RegularExpressionValidator ID="REMensajeExpresion" runat="server" ControlToValidate="TBMensaje" CssClass="auto-style26" ErrorMessage="Formato incorrecto solo debe contener letras" ForeColor="Red" ValidationExpression="^[A-z\.\-\s]+$" ValidationGroup="botonEnviar"></asp:RegularExpressionValidator>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style19">
                                                <br />
                                                <asp:Button ID="BEnviar" runat="server" Font-Size="Medium" Text="Enviar" Height="34px" Width="81px" OnClick="BT_enviar_Click" BackColor="#FF952B" ValidationGroup="botonEnviar" />
                                            </td>
                                            <td>&nbsp;</td>
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

