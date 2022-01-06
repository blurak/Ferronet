<%@ Page Title="" Language="C#" MasterPageFile="~/View/Cajero.master" AutoEventWireup="true" CodeFile="~/Controller/RegistrarVentaConGridview.aspx.cs" Inherits="View_RegistrarVentaConGridview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


    .auto-style29 {
        width: 100%;
        height: 659px;
    }
           
      
        * {
             padding: 0;
            margin: 0;
        }

      

        .auto-style30 {
            width: 99%;
            height: 299px;
        }
        .auto-style31 {
            width: 17%;
        }
        .auto-style33 {
            font-size: xx-large;
        }
        .auto-style34 {
            font-size: medium;
        }
        .auto-style36 {
            width: 15%;
        }
        .auto-style37 {
            font-size: x-large;
        }
        .auto-style38 {
            font-size: large;
        }
        .auto-style39 {
            font-size: xx-small;
        }
    </style>
      <script type="text/javascript" src="javascript/subsede.js"></script>
     <script type="text/javascript" src="javascript/sede.js"></script>
     <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" BackColor="Silver" Height="1050px" Width="100%">
        <br />
        <table class="auto-style29">
            <tr>
                <td class="auto-style31">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1300px" Width="790px">
                        <table class="auto-style30">
                            <tr>
                                <td class="auto-style36">&nbsp;</td>
                                <td class="auto-style6">
                                    <asp:Label ID="LBInventario" runat="server" CssClass="auto-style33" Text="INVENTARIO ACTUAL"></asp:Label>
                                    <br />
                                    <br />
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <br />
                                            <asp:Label ID="LBSeleccione" runat="server" CssClass="auto-style38" Text="Seleccione la opcion de añadir e ingrese la cantidad de productos que desea vender:"></asp:Label>
                                            <br />
                                            <br />
                                            <br />
                                            <asp:GridView ID="GWInventario" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_producto" ForeColor="#333333" GridLines="None" Height="188px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="762px" EmptyDataText="Aun no hay productos asignados a la subsede">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Codigo del producto">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("Id_producto") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Id_producto") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Descripcion">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="LbDescripcion" runat="server" Text='<%# Bind("Descripcion1") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Descripcion1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad disponible">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="LbcantidadDispo" runat="server" Text='<%# Bind("Cantidad1") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cantidad1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Precio">
                                                        <EditItemTemplate>
                                                            <asp:Label ID="LbPrecio" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Precio") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cantidad">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="IdCantidad" runat="server" TextMode="Number" Width="70px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdCantidad" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="botonActu">*</asp:RequiredFieldValidator>
                                                            <br />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="IdCantidad" CssClass="auto-style39" ErrorMessage="Cantidad no valida solo se aceptan numeros de 5 digitos mayores a cero" ForeColor="Red" ValidationExpression="^[1-9][0-9]{0,4}$"></asp:RegularExpressionValidator>
                                                            <br />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <table class="auto-style1">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td>&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="LbActualizar" runat="server" CausesValidation="True" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Update" Text="Guardar" ValidationGroup="botonActu"></asp:LinkButton>
                                                            &nbsp;<asp:LinkButton ID="LbCancelar" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LbEditar" runat="server" CausesValidation="False" CommandName="Edit" Text="Añadir"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GWInventario" EventName="DataBound" />
                                            <asp:AsyncPostBackTrigger ControlID="GwRegistrando" EventName="DataBound" />
                                            <asp:AsyncPostBackTrigger ControlID="GWInventario" EventName="RowEditing" />
                                            <asp:AsyncPostBackTrigger ControlID="GWInventario" EventName="RowCancelingEdit" />
                                            <asp:AsyncPostBackTrigger ControlID="GWInventario" EventName="PageIndexChanging" />
                                            <asp:AsyncPostBackTrigger ControlID="GWInventario" EventName="RowUpdating" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanel1_UpdatePanelAnimationExtender" runat="server" BehaviorID="UpdatePanel1_UpdatePanelAnimationExtender" TargetControlID="UpdatePanel1">
                                    <Animations>
            <OnUpdating>
                    <Sequence>
                        <%-- Store the original height of the panel --%>
                        <ScriptAction Script="var b = $find('animation'); b._originalHeight = b._element.offsetHeight;" />
                         <%-- Disable all the controls --%>
                        <Parallel duration=".25">
                            <EnableAction AnimationTarget="btnUpdate" Enabled="true" />
                            <EnableAction AnimationTarget="effect_color" Enabled="true" />
                            <EnableAction AnimationTarget="effect_collapse" Enabled="true" />
                            <EnableAction AnimationTarget="effect_fade" Enabled="true" />
                        </Parallel>
                        <StyleAction Attribute="overflow" Value="hidden" />
                        <%-- Do each of the selected effects --%>
                        
                    </Sequence>
                </OnUpdating>
                <OnUpdated>
                    <Sequence>
                        <%-- Do each of the selected effects --%>
                        <Parallel duration=".50" Fps="30">
                            
                                <FadeIn AnimationTarget="up_container" minimumOpacity=".2" />
                           
                            <Condition ConditionScript="$get('effect_collapse').checked">
                                <%-- Get the stored height --%>
                                <Resize HeightScript="$find('animation')._originalHeight" />
                            </Condition>
                            
                              
                            
                        </Parallel>
                         <%-- Enable all the controls --%>
                        <Parallel duration="0">
                            <EnableAction AnimationTarget="effect_collapse" Enabled="true" />
                            <EnableAction AnimationTarget="effect_color" Enabled="true" />
                            <EnableAction AnimationTarget="btnUpdate" Enabled="true" />
                        </Parallel>                           
                    </Sequence>
                </OnUpdated>
            </Animations>
                                    </ajaxToolkit:UpdatePanelAnimationExtender>
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <br />
                                            <br />
                                            <asp:Label ID="LBProductos" runat="server" CssClass="auto-style37" Text="PRODUCTOS SELECCIONADOS"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:GridView ID="GwRegistrando" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="749px" EmptyDataText="Aun no hay productos seleccionados">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Codigo">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("codigo") %>'></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                                                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                                                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                                    <asp:BoundField DataField="total" HeaderText="Total" />
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GwRegistrando" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <br />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <br />
                                    <asp:Button ID="BTTerminar" runat="server" BackColor="#FF952B" CssClass="auto-style34" Height="40px" OnClick="Button6_Click" Text="Terminar venta" ValidationGroup="verificarExistencias" Width="205px" />
                                    <br />
                                    <br />
                                    <br />
                                    <asp:Button ID="BTReiniciar" runat="server" BackColor="#FF952B" CssClass="auto-style34" Height="40px" OnClick="Button5_Click1" Text="Reiniciar venta" Width="187px" />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
</asp:Content>

