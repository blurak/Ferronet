<%@ Page Title="" Language="C#" MasterPageFile="~/View/principal.master" AutoEventWireup="true" CodeFile="~/Controller/Registrarse.aspx.cs" Inherits="View_Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style13 {
            width: 25%;
            
        }
        .auto-style14 {
            width: 359px;
        }
        .auto-style20 {
            width: 100%;
            height: 766px;
        }
        .auto-style21 {
            text-align: center;
        }
        .auto-style36 {
            font-size: small;
        }
        .auto-style38 {
            font-size: xx-large;
        }
        .auto-style42 {
            margin-bottom: 0;
        }
        .auto-style43 {
            width: 311px;
        }
        .auto-style44 {
            text-align: justify;
        }
        .auto-style46 {
            width: 311px;
            text-align: left;
        }
        .auto-style47 {
            text-align: left;
        }
        .auto-style48 {
            width: 22px;
            text-align: left;
        }
        .auto-style49 {
            width: 22px;
        }
        .auto-style50 {
            width: 40px;
        }
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Height="802px">
        <asp:Panel ID="Panel2" runat="server" BackColor="#999999" Height="809px">
            <table class="auto-style20">
                <tr>
                    <td class="auto-style13">&nbsp;</td>
                    <td>
                        <asp:Panel ID="Panel3" runat="server" BackColor="White" Height="700px" Width="682px">
                            <br />
                            <table class="auto-style1">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td class="auto-style21">
                                        <asp:Label ID="LIngreseSusDatos" runat="server" CssClass="auto-style38" Font-Size="X-Large" Text="Ingrese sus datos"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <br />
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style48">&nbsp;</td>
                                    <td class="auto-style46">
                                        <asp:Label ID="LCorreoElectronico" runat="server" Font-Size="Large" Text="Correo electronico"></asp:Label>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                    <td class="auto-style47">
                                        <asp:TextBox ID="TB_correo" runat="server" BackColor="#CCCCCC" Font-Size="Medium" TextMode="Email" ViewStateMode="Enabled"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_correo" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrarse"></asp:RequiredFieldValidator>
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style48">&nbsp;</td>
                                    <td class="auto-style46">
                                        <asp:Label ID="LNombre" runat="server" Font-Size="Large" Text="Nombre"></asp:Label>
                                        <br />
                                    </td>
                                    <td class="auto-style47">
                                        <asp:TextBox ID="TB_nombre" runat="server" BackColor="#CCCCCC" Font-Size="Medium"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrarse"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style49">&nbsp;</td>
                                    <td class="auto-style43">&nbsp;</td>
                                    <td class="auto-style44">
                                        <asp:RegularExpressionValidator ID="RENombreExpresion" runat="server" ControlToValidate="TB_nombre" CssClass="auto-style36" ErrorMessage="Nombre en formato incorrecto no debe contener caracteres especiales, numeros,  ni espacios y debe ser de 3 a 50 caracteres" ForeColor="Red" ValidationExpression="[a-zA-ZñÑ\s]{3,50}" ValidationGroup="BotonRegistrarse"></asp:RegularExpressionValidator>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style48">&nbsp;</td>
                                    <td class="auto-style46">
                                        <asp:Label ID="LUsername" runat="server" Font-Size="Large" Text="Username"></asp:Label>
                                        <br />
                                    </td>
                                    <td class="auto-style47">
                                        <asp:TextBox ID="TB_user" runat="server" BackColor="#CCCCCC" CssClass="auto-style42" Font-Size="Medium"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_user" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrarse"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style49">&nbsp;</td>
                                    <td class="auto-style43">&nbsp;</td>
                                    <td class="auto-style47">
                                        <asp:Label ID="usuario_registrado" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style49">&nbsp;</td>
                                    <td class="auto-style43">&nbsp;</td>
                                    <td class="auto-style44">
                                        <asp:RegularExpressionValidator ID="REUsernameExpresion" runat="server" ControlToValidate="TB_user" CssClass="auto-style36" ErrorMessage="El username no debe contener caracteres especiales, ni espacios y debe ser de 6 a 15 caracteres con letras y numeros" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9]{4,16})$" ValidationGroup="BotonRegistrarse"></asp:RegularExpressionValidator>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style48">&nbsp;</td>
                                    <td class="auto-style46">
                                        <asp:Label ID="LContrasena" runat="server" Font-Size="Large" Text="Contraseña"></asp:Label>
                                        <br />
                                    </td>
                                    <td class="auto-style47">
                                        <asp:TextBox ID="TB_contrasena" runat="server" BackColor="#CCCCCC" Font-Size="Medium" Height="20px" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TB_contrasena" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrarse"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style49">&nbsp;</td>
                                    <td class="auto-style43">&nbsp;</td>
                                    <td class="auto-style44">
                                        <asp:RegularExpressionValidator ID="REContrasenaExpresion" runat="server" ControlToValidate="TB_contrasena" CssClass="auto-style36" ErrorMessage="contraseña en formato incorrecto solo pueden ser letras, numeros, sin espacios y de 4 a 16 caracteres" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9]{4,16})$" ValidationGroup="BotonRegistrarse"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style49">&nbsp;</td>
                                    <td class="auto-style43">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <script type="text/javascript">
                
                function OcultarDiv()
                {
                    var div = document.getElementById("map");
                        div.style.display = "none";
                }
                function MostrarDiv() {
                    
                    var div = document.getElementById("map");   
                    div.style.display = "block";
                    iniciar();
                   
                }
            </script>
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style50">&nbsp;</td>
                                    <td class="auto-style21">
                                        <asp:Button ID="BRegistrar" runat="server" BackColor="#FF952B" Font-Size="Medium" Height="41px" OnClick="Button1_Click" Text="Registrar" ValidationGroup="BotonRegistrarse" Width="109px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

