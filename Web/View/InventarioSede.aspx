<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/InventarioSede.aspx.cs" Inherits="View_InventarioSede" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style14 {
            text-align: center;
            width: 34%;
        }
        .auto-style15 {
            text-align: center;
            width: 33%;
        }
        .auto-style16 {
            text-align: center;
            width: 33%;
        }
        .auto-style17 {
            width: 100%;
            height: 494px;
        }
        .auto-style18 {
            width: 23%;
            height: 28px;
            text-align: center;
        }
        .auto-style19 {
            font-size: x-large;
        }
        </style>
     <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="1200px">
        <table class="auto-style17">
            <tr>
                <td class="auto-style18">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1141px" Width="793px">
                        <br />
                        <br />
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style9" colspan="3">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="LBInventarioActu" runat="server" CssClass="auto-style19" Text="Inventario actual de la sede"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:GridView ID="GW_productos_sede" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="DOSproductosede" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GW_productos_sede_SelectedIndexChanged" Width="722px">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" ValidationGroup="actualizar"></asp:LinkButton>
                                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" OnClick="LinkButton1_Click" Text="añadir cantidades"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Codigo del producto">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Codigo_producto1") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Codigo_producto1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Descripcion">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad minima">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("CantidadMin1") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("CantidadMin1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad">
                                                        <EditItemTemplate>
                                                            <table class="auto-style1">
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="TextBox4" runat="server" MaxLength="9" Text='<%# Bind("Cantidadd1") %>' TextMode="Number" Width="70px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="actualizar"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox4" CssClass="auto-style20" ErrorMessage="RangeValidator" ForeColor="Red" MaximumValue="429496729" MinimumValue="1" SetFocusOnError="True" Type="Integer" ValidationGroup="actualizar">cantidad demasiada grande solo se permite hasta 429496729</asp:RangeValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Cantidadd1") %>'></asp:Label>
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
                                            <asp:ObjectDataSource ID="DOSproductosede" runat="server" SelectMethod="obtenerInventarioSede" TypeName="Logica.LSede" UpdateMethod="PmodificarInventarioSede">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="idUsuario" SessionField="user_id" Type="Int32" />
                                                </SelectParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="cantidad" Type="Int32" />
                                                    <asp:Parameter Name="cantidadmin" Type="Int32" />
                                                    <asp:Parameter Name="idProducto" Type="Int32" />
                                                    <asp:Parameter Name="id_usuario" Type="Int32" />
                                                    <asp:Parameter Name="id_producto" Type="Int32" />
                                                    <asp:Parameter Name="descripcio" Type="String" />
                                                    <asp:Parameter Name="cantidad_minima" Type="Int32" />
                                                    <asp:Parameter Name="Codigo_producto1" Type="Int32" />
                                                    <asp:Parameter Name="Descripcion" Type="String" />
                                                    <asp:Parameter Name="CantidadMin1" Type="Int32" />
                                                    <asp:Parameter Name="Cantidadd1" Type="Int32" />
                                                </UpdateParameters>
                                            </asp:ObjectDataSource>
                                            <br />
                                            <asp:Label ID="LBProductosBajas" runat="server" CssClass="auto-style19" Text="Productos con bajas cantidades en inventario"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:GridView ID="GWProductosBajas" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="DOSProductosBajosSede" EmptyDataText="Aun no hay productos con cantidades bajas" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GWProductosBajas_SelectedIndexChanged" Width="722px">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar"></asp:LinkButton>
                                                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Añadir cantidades" ValidationGroup="anadir"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Codigo del producto">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Label10" runat="server" Text='<%# Bind("Codigo_producto1") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Codigo_producto1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Descripcion">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Label11" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad minima">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Label12" runat="server" Text='<%# Bind("CantidadMin1") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("CantidadMin1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad">
                                                        <EditItemTemplate>
                                                            <table class="auto-style1">
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Cantidadd1") %>' TextMode="Number"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="*" ForeColor="Red" ValidationGroup="anadir"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TextBox4" CssClass="auto-style21" ErrorMessage="Cantidad demasiado grande valor maximo permitido 429496729" ForeColor="Red" MaximumValue="429496729" MinimumValue="1" style="font-size: small" ValidationGroup="anadir"></asp:RangeValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Cantidadd1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                                <SortedDescendingHeaderStyle BackColor="#820000" />
                                            </asp:GridView>
                                            <asp:ObjectDataSource ID="DOSProductosBajosSede" runat="server" OnSelecting="DOSProductosBajosSede_Selecting" SelectMethod="obtenerInventarioSedeCantidadesBajas" TypeName="Logica.LSede" UpdateMethod="PmodificarInventarioSede">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="idUsuario" SessionField="user_id" Type="Int32" />
                                                </SelectParameters>
                                                <UpdateParameters>
                                                    <asp:Parameter Name="cantidad" Type="Int32" />
                                                    <asp:Parameter Name="cantidadmin" Type="Int32" />
                                                    <asp:Parameter Name="idProducto" Type="Int32" />
                                                    <asp:Parameter Name="id_usuario" Type="Int32" />
                                                    <asp:Parameter Name="id_producto" Type="Int32" />
                                                    <asp:Parameter Name="descripcio" Type="String" />
                                                    <asp:Parameter Name="cantidad_minima" Type="Int32" />
                                                    <asp:Parameter Name="Codigo_producto1" Type="Int32" />
                                                    <asp:Parameter Name="Descripcion" Type="String" />
                                                    <asp:Parameter Name="CantidadMin1" Type="Int32" />
                                                    <asp:Parameter Name="Cantidadd1" Type="Int32" />
                                                </UpdateParameters>
                                            </asp:ObjectDataSource>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GW_productos_sede" EventName="RowEditing" />
                                            <asp:AsyncPostBackTrigger ControlID="GW_productos_sede" EventName="RowCancelingEdit" />
                                            <asp:AsyncPostBackTrigger ControlID="GW_productos_sede" EventName="RowUpdating" />
                                            <asp:AsyncPostBackTrigger ControlID="GWProductosBajas" EventName="RowEditing" />
                                            <asp:AsyncPostBackTrigger ControlID="GWProductosBajas" EventName="RowCancelingEdit" />
                                            <asp:AsyncPostBackTrigger ControlID="GWProductosBajas" EventName="RowUpdating" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style15">
                                    <asp:ImageButton ID="IBRegistrarProductos" runat="server" Height="165px" ImageUrl="~/Images/botones/registrar producto.jpg" PostBackUrl="~/View/CrearProducto.aspx" />
                                </td>
                                <td class="auto-style14">
                                    <asp:ImageButton ID="IBAgregarProdu" runat="server" Height="165px" ImageUrl="~/Images/botones/agregarProducto.jpg" PostBackUrl="~/View/AgregarProducto.aspx" />
                                </td>
                                <td class="auto-style16">
                                    <asp:ImageButton ID="IBEliminarProdu" runat="server" Height="165px" ImageUrl="~/Images/botones/eliminar producto.jpg" PostBackUrl="~/View/BorrarProducto.aspx" />
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

