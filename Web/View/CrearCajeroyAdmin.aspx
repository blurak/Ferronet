<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/CrearCajeroyAdmin.aspx.cs" Inherits="View_CrearCajero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style12 {
            width: 20%;
        }
        .auto-style15 {
            text-align: center;
            width: 16%;
        }
        .auto-style16 {
            font-size: large;
        }
        .auto-style17 {
            width: 100%;
            height: 589px;
        }
        .auto-style18 {
            text-align: center;
            width: 16%;
            height: 374px;
        }
        .auto-style19 {
            text-align: center;
            height: 374px;
        }
        .auto-style20 {
            width: 100%;
            height: 395px;
        }
        .auto-style21 {
            font-size: medium;
        }
        .auto-style22 {
            text-align: left;
        }
        .auto-style25 {
            text-align: left;
            width: 209px;
        }
        .headerCssClass{
            background-color:#C5EFF7;
            color:black;
            border:1px solid black;
            padding:24px;
            height:20px;
            text-align:center;
            width:200px;
        }
        .contentCssClass{
            background-color:#4183d7;
            color:black;
            border:1px dotted black;
            padding:4px;
        }
        .headerSelectedCss{
            background-color:#C5EFF7;
            color:black;
            text-align:center;
            border:1px solid black;
            padding:24px;
            height:20px;
        }
        .nuevoEstilo1 {
            font-family: "malgun Gothic";
        }
        .auto-style26 {
            font-family: "malgun Gothic";
            font-size: medium;
            color: #000066;
        }
        .auto-style27 {
            font-weight: bold;
            font-style: italic;
        }

    </style>
       <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="1150px">
        <table class="auto-style17">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1100px" Width="793px">
                        <table class="auto-style20">
                            <tr>
                                <td class="auto-style18"></td>
                                <td class="auto-style19">
                                    <br />
                                    <table class="auto-style1">
                                        <tr>
                                            <td colspan="2" class="auto-style22">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                                
                                                  <strong><em>
                                                <ajaxToolkit:Accordion ID="Accordion1" runat="server"   AutoSize="None" ContentCssClass="contentCssClass" CssClass="auto-style26" FadeTransitions="true" HeaderCssClass="headerCssClass" HeaderSelectedCssClass="headerSelectedCss" RequireOpenedPane="false" SelectedIndex="0" SuppressHeaderPostbacks="true" TransitionDuration="500">
                                                    <Panes>
                                                        <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                                                            <Header>
                                                                <asp:label runat="server" ID="LBAspirantes" Text="Aspirante uniempleo"></asp:label>
                                                                <asp:Image runat="server" Height="50px" ImageAlign="Right"  ImageUrl="~/Images/maletin.png" Width="50px" />
                                                            </Header>
                                                            <Content>
                                                                <asp:TextBox ID="textbox" runat="server"></asp:TextBox>
                                                                <asp:Button ID="Buscar"  Text="Buscar" runat="server" OnClick="BTNBuscar_Click" ContentCssClass="contentCssClass" CssClass="auto-style26" />
                                                                <asp:GridView ID="GwProductosSede" runat="server" Width="500px" AutoGenerateColumns="false" DataKeyNames="Id_aspirante" OnSelectedIndexChanging="GwProductosSede_SelectedIndexChanging">
                                                                    <Columns>
                                                                        <asp:CommandField ButtonType="Button" SelectText="Asignar" ShowSelectButton="True" />
                                                                        <asp:BoundField DataField="Id_aspirante" HeaderText="Codigo aspirante" />
                                                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                                                        <asp:BoundField DataField="Habilidad1" HeaderText="Habilidad uno" />
                                                                        <asp:BoundField DataField="Habilidad1" HeaderText="Habilidad uno" />
                                                                    </Columns>
                                                                    <EditRowStyle BackColor="#7C6F57" />
                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#E3EAEB" />
                                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                                                                </asp:GridView>
                                                            </Content>
                                                        </ajaxToolkit:AccordionPane>
                                                    </Panes>
                                                </ajaxToolkit:Accordion>
                                                </em></strong>
                                               
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <asp:Label ID="LBRegistreAdminYCajero" runat="server" CssClass="auto-style16" Text="REGISTRE ADMINISTRADORES Y CAJEROS"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style25">
                                                <asp:Label ID="LBNombre" runat="server" CssClass="auto-style16" Text="Nombre"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style22">
                                                <table class="auto-style1">
                                                    <tr>
                                                        <td>
                                                            <br />
                                                            <br />
                                                            <asp:TextBox ID="TB_nombre" runat="server" BackColor="Silver" CssClass="auto-style21"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrar"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="RENombre" runat="server" ControlToValidate="TB_nombre" ErrorMessage="Nombre en formato incorrecto no debe contener caracteres especiales,numeros  ni espacios" Font-Size="Small" ForeColor="Red" ValidationExpression="[a-zA-ZñÑ\s]{3,50}" ValidationGroup="BotonRegistrar"></asp:RegularExpressionValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="RENombre_ValidatorCalloutExtender" runat="server" BehaviorID="RENombre_ValidatorCalloutExtender" TargetControlID="RENombre">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style25">
                                                <asp:Label ID="LbUserName" runat="server" CssClass="auto-style16" Text="Username"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style22">
                                                <table class="auto-style1">
                                                    <tr>
                                                        <td>
                                                            <br />
                                                            <br />
                                                            <asp:TextBox ID="TB_usuario" runat="server" BackColor="Silver" CssClass="auto-style21"></asp:TextBox>
                                                            <asp:Label ID="usuario_registrado" runat="server" CssClass="auto-style21" ForeColor="Red"></asp:Label>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_usuario" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrar"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="REUsuario" runat="server" ControlToValidate="TB_usuario" ErrorMessage="El username no debe contener caracteres especiales ni espacios y debe ser de 6 a 15 caracteres" Font-Size="Small" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9]{4,16})$" ValidationGroup="BotonRegistrar"></asp:RegularExpressionValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="REUsuario_ValidatorCalloutExtender" runat="server" BehaviorID="REUsuario_ValidatorCalloutExtender" TargetControlID="REUsuario">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style25">
                                                <asp:Label ID="LBCorreo" runat="server" CssClass="auto-style16" Text="Correo"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style22">
                                                <br />
                                                <asp:TextBox ID="TB_correo" runat="server" CssClass="auto-style21" BackColor="Silver" TextMode="Email"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_correo" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrar"></asp:RequiredFieldValidator>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style25">
                                                <asp:Label ID="LBContrasena" runat="server" CssClass="auto-style16" Text="Contraseña"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style22">
                                                <table class="auto-style1">
                                                    <tr>
                                                        <td>
                                                            <br />
                                                            <br />
                                                            <asp:TextBox ID="TB_clave" runat="server" BackColor="Silver" CssClass="auto-style21" TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TB_clave" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrar"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="REContra" runat="server" ControlToValidate="TB_clave" ErrorMessage="contraseña en formato incorrecto solo pueden ser letras, numeros, sin espacios y de 4 a 16 caracteres" Font-Size="Small" ForeColor="Red" ValidationExpression="^([a-zA-Z0-9]{4,16})$" ValidationGroup="BotonRegistrar"></asp:RegularExpressionValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="REContra_ValidatorCalloutExtender" runat="server" BehaviorID="REContra_ValidatorCalloutExtender" TargetControlID="REContra">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style25">
                                                <asp:Label ID="LBRol" runat="server" CssClass="auto-style16" Text="rol"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style22">
                                                <br />
                                                <asp:DropDownList ID="DL_rol" runat="server" CssClass="auto-style21" Height="24px" Width="126px" BackColor="Silver">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" runat="server" ControlToValidate="DL_rol" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonRegistrar"></asp:RequiredFieldValidator>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">
                                    <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/AdministracionDeSubsedes.aspx" />
                                </td>
                                <td class="auto-style9">
                                    <asp:Button ID="BT_registrar" runat="server" BackColor="#FFB56A" Height="49px" OnClick="BT_registrar_Click" Text="Registrar" CssClass="auto-style21" ValidationGroup="BotonRegistrar" Width="113px" />
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

