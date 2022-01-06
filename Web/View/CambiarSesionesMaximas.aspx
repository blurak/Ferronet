<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/CambiarSesionesMaximas.aspx.cs" Inherits="View_CambiarSesionesMaximas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .auto-style29 {
        width: 100%;
        height: 351px;
    }
               
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style27 {
            width: 25%;
        }
        .auto-style32 {
            font-size: medium;
        }
        .auto-style34 {
            font-size: small;
        }
        .auto-style35 {
            width: 42%;
            height: 21px;
        }
        .auto-style36 {
            height: 21px;
        }
        .auto-style37 {
            font-size: x-large;
        }
        .auto-style39 {
            font-size: large;
        }
        .auto-style40 {
            width: 42%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="500px" Width="100%">
        <br />
        <table class="auto-style29">
            <tr>
                <td class="auto-style27">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="349px" Width="621px">
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style35">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </td>
                                <td class="auto-style36"></td>
                            </tr>
                            <tr>
                                <td class="auto-style9" colspan="2">
                                    <br />
                                    <asp:Label ID="LCambiar" runat="server" CssClass="auto-style37" Text="CAMBIAR SESIONES MAXIMAS DE USUARIOS"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style40">
                                    <br />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="LSeleccioneRol" runat="server" Text="Seleccione un rol" CssClass="auto-style39"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                                <td>
                                    <br />
                                    <asp:DropDownList ID="DDLRoles" runat="server" CssClass="auto-style39">
                                        <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                        <asp:ListItem Value="1">Cliente</asp:ListItem>
                                        <asp:ListItem Value="3">Administrador</asp:ListItem>
                                        <asp:ListItem Value="4">Cajero</asp:ListItem>
                                        <asp:ListItem Value="2">Superadministrador</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFRol" runat="server" ControlToValidate="DDLRoles" ErrorMessage="*"  InitialValue="0" ForeColor="Red" ValidationGroup="botonCambiar"></asp:RequiredFieldValidator>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style40">
                                    <br />
                                    <br />
                                    &nbsp;
                                    <asp:Label ID="LCantidadDeSesionesMaximas" runat="server" Text="Cantidad de sesiones maximas" CssClass="auto-style39" Width="85%"></asp:Label>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                    <br />
                                    <br />
                                    <asp:TextBox ID="TBCantidadSesiones" runat="server" CssClass="auto-style32" Height="17px"></asp:TextBox>
                                    <br />
                                    <asp:RegularExpressionValidator ID="RECantidadDeSesiones" runat="server" ControlToValidate="TBCantidadSesiones" CssClass="auto-style34" ErrorMessage="tiene que ser un numero mayor a 1 menor de 999" ForeColor="Red" ValidationGroup="botonCambiar" ValidationExpression="^[1-9]{1,3}$"></asp:RegularExpressionValidator>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9" colspan="2">
                                    <br />
                                    <asp:Button ID="BCambiar" runat="server" Text="Cambiar" BackColor="#FF952B" CssClass="auto-style32" Height="55px" ValidationGroup="botonCambiar" OnClick="BCambiar_Click" Width="109px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <ajaxToolkit:DropShadowExtender ID="Panel2_DropShadowExtender" runat="server" BehaviorID="Panel2_DropShadowExtender" TargetControlID="Panel2" Rounded="true" Opacity="0.8"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

