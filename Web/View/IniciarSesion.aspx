<%@ Page Title="" Language="C#" MasterPageFile="~/View/principal.master" AutoEventWireup="true" CodeFile="~/Controller/IniciarSesion.aspx.cs" Inherits="View_IniciarSesion" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style14 {
            width: 52%;
        }
        .auto-style15 {
            text-align: center;
        }
        .auto-style19 {
            height: 48px;
            text-align: center;
        }
        .auto-style20 {
            height: 44px;
            text-align: center;
        }
        .auto-style21 {
            height: 42px;
            text-align: center;
            width: 215px;
        }
        .auto-style22 {
            height: 43px;
            text-align: center;
            width: 215px;
        }
        .auto-style23 {
            width: 100%;
            height: 404px;
        }
        .auto-style24 {
            width: 79%;
            height: 287px;
            position:center;
        }
        .auto-style25 {
            height: 43px;
            text-align: center;
            width: 401px;
        }
        .auto-style26 {
            height: 42px;
            text-align: center;
            width: 401px;
        }
        .auto-style27 {
            width: 30%;
        }
        .auto-style28 {
            width: 9%;
        }
    .auto-style29 {
        width: 100%;
        height: 558px;
    }
        .auto-style30 {
            font-size: medium;
        }
        .auto-style31 {
            font-size: small;
        }
        .auto-style32 {
            height: 42px;
            text-align: center;
        }
    </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="auto-style23">
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="100%" Width="100%">
  
                    <table class="auto-style29">
                        <tr>
                            <td class="auto-style27">&nbsp;</td>
                            <td>
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="313px" Width="507px">
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style28">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                            </td>
                                            <td>
                                                <table align="center" class="auto-style24">
                                                    <tr>
                                                        <td class="auto-style15" colspan="2">
                                                            <br />
                                                            <asp:Label ID="LIniciarSesion" runat="server" Font-Size="X-Large" Text="Iniciar sesion"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style22">
                                                            <br />
                                                            <asp:Label ID="LUsername" runat="server" Font-Size="Large" Text="Username"></asp:Label>
                                                            <br />
                                                            <br />
                                                        </td>
                                                        <td class="auto-style25">
                                                            <br />
                                                            <asp:TextBox ID="TB_username" runat="server" BackColor="#CCCCCC" Font-Size="Medium"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_username" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="iniciarSesion"></asp:RequiredFieldValidator>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="REUsernameExpresion" runat="server" ControlToValidate="TB_username" CssClass="auto-style30" ErrorMessage="Username mal escrito" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9]{4,16})$" ValidationGroup="iniciarSesion">Username mal escrito</asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style21">
                                                            <asp:Label ID="LContrasena" runat="server" Font-Size="Large" Text="Contraseña"></asp:Label>
                                                        </td>
                                                        <td class="auto-style26">
                                                            <br />
                                                            <asp:TextBox ID="TB_contrasena" runat="server" BackColor="Silver" Font-Size="Medium" TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_contrasena" ErrorMessage="*" ForeColor="#CC3300" ValidationGroup="iniciarSesion"></asp:RequiredFieldValidator>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="REContrasenaExpresion" runat="server" ControlToValidate="TB_contrasena" CssClass="auto-style31" ErrorMessage="Contraseña en formato incorrecto" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9]{4,16})$" ValidationGroup="iniciarSesion"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>                           
                                                    <tr>
                                                        <td class="auto-style20" colspan="2">
                                                            <br />
                                                            <asp:Button ID="BIniciarSesion" runat="server" OnClick="BTN_iniciar_Click" Text="Iniciar sesion" BackColor="#FF952B" Font-Size="Medium" Height="40px" ValidationGroup="iniciarSesion" Width="163px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style19" colspan="2">
                                                            <br />
                                                            <br />
                                                            <asp:HyperLink ID="HPOlvidoSuContrasena" runat="server" ForeColor="#FF9933" NavigateUrl="~/View/GenerarToken.aspx">¿Olvido su contraseña?</asp:HyperLink>
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
                                <ajaxToolkit:DropShadowExtender ID="Panel2_DropShadowExtender" runat="server" BehaviorID="Panel2_DropShadowExtender" TargetControlID="Panel2" Rounded="true" Opacity="0.8"/>
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
    <br />
    <br />
</asp:Content>

