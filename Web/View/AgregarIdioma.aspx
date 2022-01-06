<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/AgregarIdioma.aspx.cs" Inherits="View_AgregarIdioma" %>

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
            width:13%;
        }
        .auto-style30 {
            font-size: medium;
        }
        .auto-style31 {
            margin-top: 0;
        }
        .auto-style32 {
            font-size: large;
        }
        .auto-style1{
            width:84%;
        }
        .auto-style34 {
            width: 100%;
        }
        .auto-style35 {
            font-size: xx-large;
        }
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1600px" Width="100%">
        <br />
        <table class="auto-style29">
            <tr>
                <td class="auto-style27">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1500px" Width="84%">
                        <br />
                        <table class="auto-style34">
                            <tr>
                                <td colspan="2" class="auto-style9">
                                    <br />
                                    <asp:Label ID="LBAgregarProducto" runat="server" CssClass="auto-style35" Text="AGREGAR PRODUCTO"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:Label ID="LBInfoIdiomas" runat="server" CssClass="auto-style32" Text="Aca se encuentra una lista de los idiomas que puede añadir"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="DDIdiomas" runat="server" CssClass="auto-style30">
                                        <asp:ListItem Value="af">Afrikaans</asp:ListItem>
                                        <asp:ListItem Value="ar-EG">Arabic (Egypt)</asp:ListItem>
                                        <asp:ListItem Value="bg-BG">Bulgarian (Bulgaria)</asp:ListItem>
                                        <asp:ListItem Value="bg-BG">Welsh (United Kingdom)</asp:ListItem>
                                        <asp:ListItem Value="cy-GB">Danish (Denmark)</asp:ListItem>
                                        <asp:ListItem Value="de-AT">German (Austria)</asp:ListItem>
                                        <asp:ListItem Value="et-EE">Estonian (Estonia)</asp:ListItem>
                                        <asp:ListItem Value="fi-FI">Finnish (Finland)</asp:ListItem>
                                        <asp:ListItem Value="fr-FR">French (France)</asp:ListItem>
                                        <asp:ListItem Value="hr-HR">Croatian (Croatia)</asp:ListItem>
                                        <asp:ListItem Value="hu-HU">Hungarian (Hungary)</asp:ListItem>
                                        <asp:ListItem Value="is-IS">Icelandic (Iceland)</asp:ListItem>
                                        <asp:ListItem Value="ka-GE">Georgian (Georgia)</asp:ListItem>
                                        <asp:ListItem Value="mr-IN">Marathi (India)</asp:ListItem>
                                        <asp:ListItem Value="ns-ZA">Northern Sotho (South Africa)</asp:ListItem>
                                        <asp:ListItem Value="pt-PT">Portuguese (Portugal)</asp:ListItem>
                                        <asp:ListItem Value="qu-PE">Quechua (Peru)</asp:ListItem>
                                        <asp:ListItem Value="tr-TR">Turkish (Turkey)</asp:ListItem>
                                        <asp:ListItem Value="zh-HK">Chinese (Hong Kong)</asp:ListItem>
                                        <asp:ListItem Value="zu-ZA">Zulu (South Africa)</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="BAnadir" runat="server" CssClass="auto-style30" Height="37px" OnClick="BAnadir_Click" OnCommand="Page_Load" Text="Añadir idioma" Width="184px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                    <asp:Label ID="LInstruccionUno" runat="server" CssClass="auto-style32" Text="1.  Seleccione uno de los idiomas registrados: "></asp:Label>
                                    <br />
                                </td>
                                <td>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="DDIdiomasRegistrados" runat="server" CssClass="auto-style30" DataSourceID="ODSIdiomasRegistrados" DataTextField="Cliente" DataValueField="Direccion">
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ODSIdiomasRegistrados" runat="server" SelectMethod="obtenerIdiomasRegitrados" TypeName="Logica.LVisitante"></asp:ObjectDataSource>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="auto-style34">
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="LInstruccionDos" runat="server" CssClass="auto-style32" Text="2. Seleccione con doble click el formulario:"></asp:Label>
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style9">
                                                        <asp:GridView ID="GVFormularios" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Total" DataSourceID="ODSFormularios" EmptyDataText="Aun no hay formularios registrados" ForeColor="#333333" GridLines="None" OnSelectedIndexChanging="GVFormularios_SelectedIndexChanging" Width="80%">
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                            <Columns>
                                                                <asp:CommandField ShowSelectButton="True" />
                                                                <asp:BoundField DataField="Total" HeaderText="Codigo" />
                                                                <asp:BoundField DataField="Cliente" HeaderText="Formulario" />
                                                            </Columns>
                                                            <EditRowStyle BackColor="#999999" />
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                        </asp:GridView>
                                                        <asp:ObjectDataSource ID="ODSFormularios" runat="server" SelectMethod="obtenerFormularios" TypeName="Logica.LVisitante"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="LInstruccionTres" runat="server" CssClass="auto-style32" Text="Edite el controlador el cual quiere cambiar o añadir texto en su idioma:"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style9">
                                                        <asp:GridView ID="GVControles" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style31" EmptyDataText="Aun no hay seleccionado ningun control" ForeColor="#333333" GridLines="None" Height="87px" OnRowCancelingEdit="GVControles_RowCancelingEdit" OnRowEditing="GVControles_RowEditing" OnRowUpdating="GVControles_RowUpdating" OnSelectedIndexChanging="GVControles_SelectedIndexChanging" OnPageIndexChanging="GVControles_PageIndexChanging" Width="100%">
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Control">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="LControl" runat="server" Text='<%# Bind("Control") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Control") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ControlStyle Width="150px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Texto">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TBTexto" runat="server" Text='<%# Bind("Texto") %>' Width="100%"></asp:TextBox>
                                                                        <br />
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TBTexto" ErrorMessage="Solo se admiten numeros o letras" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[A-Za-z0-9\s\0,.]+$" ValidationGroup="BotonActualizar"></asp:RegularExpressionValidator>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Texto") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" ValidationGroup="BotonActualizar"></asp:LinkButton>
                                                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
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
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="LControladores" runat="server" CssClass="auto-style32" Text="Aqui estas los controladores que estan cargados con el idioma:"></asp:Label>
                                                        <asp:Label ID="LIDioma" runat="server" CssClass="auto-style32" ForeColor="Red"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style9">
                                                        <asp:GridView ID="GVControlesTraducidos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ODSControlesTraducidos" EmptyDataText="Aun no hay nada que mostrar" ForeColor="Black" GridLines="Horizontal" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="Control" HeaderText="Control" />
                                                                <asp:BoundField DataField="Texto" HeaderText="Texto" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                                        </asp:GridView>
                                                        <asp:ObjectDataSource ID="ODSControlesTraducidos" runat="server" SelectMethod="obtenerControlesTraducidos" TypeName="Logica.LVisitante">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="GVFormularios" Name="idFormulario" PropertyName="SelectedValue" Type="Int32" />
                                                                <asp:ControlParameter ControlID="DDIdiomasRegistrados" Name="terminacion" PropertyName="SelectedValue" Type="String" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="LBControlesImagen" runat="server" CssClass="auto-style32" Text="Aca aparecen los controladores que tienen imagenes del formulario seleccionado:"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table class="auto-style34">
                                                            <tr>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <table class="auto-style34">
                                                                                <tr>
                                                                                    <td class="auto-style9">
                                                                                        <asp:GridView ID="GVControlesImagen" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnRowCancelingEdit="GVControlesImagen_RowCancelingEdit" OnRowEditing="GVControlesImagen_RowEditing" OnRowUpdating="GVControlesImagen_RowUpdating" PageSize="5" Width="100%" EmptyDataText="Aun no hay nada que mostrar">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Control">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Control") %>'></asp:Label>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Control") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Imagen">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:Image ID="Image3" runat="server" ImageUrl='<%# Eval("Texto") %>' />
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("Texto") %>' />
                                                                                                    </ItemTemplate>
                                                                                                    <ControlStyle Width="100px" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:FileUpload ID="imagen" runat="server" />
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="imagen" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonActualizar"></asp:RequiredFieldValidator>
                                                                                                    </EditItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField ShowHeader="False">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" ValidationGroup="BotonActualizar"></asp:LinkButton>
                                                                                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <FooterStyle BackColor="White" ForeColor="#333333" />
                                                                                            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                                                                            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                                                                            <RowStyle BackColor="White" ForeColor="#333333" />
                                                                                            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                                                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                                                            <SortedAscendingHeaderStyle BackColor="#487575" />
                                                                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                                                            <SortedDescendingHeaderStyle BackColor="#275353" />
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <br />
                                                                                        <asp:Label ID="LBControlesTraducido" runat="server" CssClass="auto-style32" Text="Aca aparecen los controladores que tienen imagenes del formulario seleccionado, cargado con el idioma:"></asp:Label>
                                                                                        <asp:Label ID="LIdiomaDos" runat="server" CssClass="auto-style32" ForeColor="Red"></asp:Label>
                                                                                        <br />
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="auto-style9">
                                                                                        <asp:GridView ID="GVControladoresConImagen" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" EmptyDataText="Aun no hay nada que mostrar" ForeColor="#333333" GridLines="None">
                                                                                            <AlternatingRowStyle BackColor="White" />
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Control">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Control") %>'></asp:TextBox>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Control") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Imagen">
                                                                                                    <EditItemTemplate>
                                                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Texto") %>'></asp:TextBox>
                                                                                                    </EditItemTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Texto") %>' />
                                                                                                    </ItemTemplate>
                                                                                                    <ControlStyle Width="100px" />
                                                                                                </asp:TemplateField>
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
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="GVControladoresConImagen" />
                                                                            <asp:PostBackTrigger ControlID="GVControlesImagen" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                    &nbsp;<br /> </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GVFormularios" EventName="SelectedIndexChanging" />
                                            <asp:AsyncPostBackTrigger ControlID="GVControles" EventName="RowEditing" />
                                            <asp:AsyncPostBackTrigger ControlID="GVControles" EventName="RowCancelingEdit" />
                                            <asp:AsyncPostBackTrigger ControlID="GVControles" EventName="RowUpdating" />
                                            <asp:AsyncPostBackTrigger ControlID="GVControlesTraducidos" EventName="DataBinding" />
                                            <asp:AsyncPostBackTrigger ControlID="GVControles" EventName="SelectedIndexChanging" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </asp:Panel>
                    <ajaxToolkit:DropShadowExtender ID="Panel2_DropShadowExtender" runat="server" BehaviorID="Panel2_DropShadowExtender" TargetControlID="Panel2" Rounded="true" Opacity="0.8"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

