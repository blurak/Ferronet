<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/CantidadesProximasATerminar.aspx.cs" Inherits="View_CantidadesProximasATerminar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style23 {
            width: 100%;
            height: 404px;
        }
               
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style29 {
        width: 100%;
        height: 351px;
    }
        .auto-style27 {
            width: 14%;
        }
        .auto-style36 {
            width: 501px;
            text-align: center;
        }
        .auto-style37 {
            font-size: x-large;
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
                <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="800px" Width="100%">
                    <br />
                    <table class="auto-style29">
                        <tr>
                            <td class="auto-style27">&nbsp;</td>
                            <td>
                                <br />
                                <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="750px" Width="921px">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td class="auto-style9">
                                                        <br />
                                                        <br />
                                                        <asp:Label ID="LBSubsedesCanti" runat="server" CssClass="auto-style37" Text="Subsedes con cantidades bajas de productos"></asp:Label>
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style9">
                                                        <br />
                                                        <asp:GridView ID="GWCantiadesBajas" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="DAOSProductosProximos" EmptyDataText="Ninguna subsede tiene productos bajos en inventario" ForeColor="#333333" GridLines="None" Width="100%">
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField SortExpression="CodigoRegistro">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" Enabled="False" ReadOnly="True" Text='<%# Bind("CodigoRegistro") %>' Visible="False" Width="50px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CodigoRegistro") %>' Visible="False"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Codigo del producto" SortExpression="CodigoProducto">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox7" runat="server" Enabled="False" ReadOnly="True" Text='<%# Bind("CodigoProducto") %>' Width="50px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CodigoProducto") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Subsede" SortExpression="Subsede">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox10" runat="server" Enabled="False" Text='<%# Bind("Subsede") %>' Width="50px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Subsede") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Producto" SortExpression="Producto">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox8" runat="server" Enabled="False" Text='<%# Bind("Producto") %>' Width="50px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Producto") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Categoria" SortExpression="Categoria">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox9" runat="server" Enabled="False" Text='<%# Bind("Categoria") %>' Width="50px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cantidad minima" SortExpression="CantidadMinima">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox11" runat="server" Enabled="False" Text='<%# Bind("CantidadMinima") %>' Width="50px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("CantidadMinima") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cantidad" SortExpression="Cantidad">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Cantidad") %>' TextMode="Number" Width="50px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox6" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cantidad disponible en inventario" SortExpression="CantidadDisponible">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox12" runat="server" Enabled="False" Text='<%# Bind("CantidadDisponible") %>' Width="50px"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("CantidadDisponible") %>'></asp:Label>
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
                                                        <asp:ObjectDataSource ID="DAOSProductosProximos" runat="server" SelectMethod="ProductosProximosATerminars" TypeName="Logica.LSede" UpdateMethod="ModificarProductosProximosAterminarsubP">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="idUsuario" SessionField="user_id" Type="Int32" />
                                                            </SelectParameters>
                                                            <UpdateParameters>
                                                                <asp:Parameter Name="CodigoRegistro" Type="Int32" />
                                                                <asp:Parameter Name="CodigoProducto" Type="Int32" />
                                                                <asp:Parameter Name="producto" Type="String" />
                                                                <asp:Parameter Name="Categoria" Type="String" />
                                                                <asp:Parameter Name="subsede" Type="String" />
                                                                <asp:Parameter Name="Cantidad" Type="Int32" />
                                                                <asp:Parameter Name="cantidadMinima" Type="Int32" />
                                                                <asp:Parameter Name="cantidadDisponible" Type="Int32" />
                                                                <asp:Parameter Name="codigo" Type="Int32" />
                                                            </UpdateParameters>
                                                        </asp:ObjectDataSource>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                    <br />
                                    <br />
                                    <table class="auto-style1">
                                        <tr>
                                            <td class="auto-style36">
                                                <asp:ImageButton ID="IBSalir" runat="server" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/AdministracionDeSubsedes.aspx" Width="80px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style36">&nbsp;</td>
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

