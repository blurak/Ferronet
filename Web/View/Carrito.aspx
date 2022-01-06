<%@ Page Title="" Language="C#" MasterPageFile="~/View/Cliente.master" AutoEventWireup="true" CodeFile="~/Controller/Carrito.aspx.cs" Inherits="View_Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">



        .auto-style32 {
            width: 100%;
            height: 429px;
        }
                
        .auto-style12 {
            width: 20%;
            height: 28px;
            text-align: center;
        }
        
        .auto-style12 {
            width: 20%;
        }
        .auto-style34 {
            margin-right: 2px;
            margin-top: 0px;
        }
        .auto-style42 {
            width: 1px;
        }
        .auto-style43 {
            width: 400px;
            height: 400px;
        }
        .auto-style44 {
            text-align: center;
        }
        .auto-style46 {
            font-size: medium;
        }
        .auto-style48 {
            height: 26px;
        }
        .auto-style51 {
            width: 275px;
        }
        .auto-style52 {
            width: 275px;
            height: 26px;
        }
        .auto-style53 {
            font-size: large;
        }
        .auto-style55 {
            height: 30px;
            text-align: center;
        }
        .auto-style56 {
            text-align: justify;
        }
        .auto-style57 {
            font-size: x-large;
        }
        .auto-style58 {
            font-size: xx-small;
        }
        </style>
    <script type="text/javascript" src="javascript/sede.js"></script>
    <script type="text/javascript" src="javascript/subsede.js"></script>
    <script type="text/javascript" src="javascript/usuario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    -<asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="1750px">
        <table class="auto-style32">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Height="1650px" Width="963px">
                        <table class="auto-style1">
                            <tr>
                                <td colspan="2" class="auto-style56">
                                    <br />
                                    <table class="auto-style1">
                                        <tr>
                                            <td>
                                                &nbsp;
                                                <asp:Label ID="Label22" runat="server" CssClass="auto-style57" Text="✓"></asp:Label>
                                                &nbsp;
                                                <asp:Label ID="LProductoDisponible" runat="server" Text="Producto disponible"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label21" runat="server" CssClass="auto-style57" Text="X"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="LProductoNoDisponible" runat="server" Text="Producto no disponible"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:ScriptManager ID="ScriptManager2" runat="server">
                                    </asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="auto-style44">
                                                <br />
                                                <asp:Label ID="LInstruccion" runat="server" Text="Seleccione la opcion de añadir e ingrese la cantidad de productos que desea comprar y verifique su disponibilidad:"></asp:Label>
                                                <br />
                                                <br />
                                                <asp:GridView ID="GW_carrito" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style34" DataKeyNames="codigo" EmptyDataText="Aun no hay productos en el carrito" ForeColor="Black" GridLines="Horizontal" Height="157px" OnPageIndexChanging="GW_carrito_PageIndexChanging" OnRowCancelingEdit="GW_carrito_RowCancelingEdit" OnRowCommand="GW_carrito_RowCommand" OnRowDataBound="GW_carrito_RowDataBound" OnRowDeleting="GW_carrito_RowDeleting" OnRowEditing="GW_carrito_RowEditing" OnRowUpdating="GW_carrito_RowUpdating" OnSelectedIndexChanged="GW_carrito_SelectedIndexChanged" Width="937px">
                                                    <Columns>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <ItemTemplate>
                                                                <asp:Button ID="BEliminar" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Codigo">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="Label15" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Descripcion">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="Label16" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Precio">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="Label17" runat="server" Text='<%# Bind("precio") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("precio") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cantidad">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="cantidadTB" runat="server" Text='<%# Bind("cantidad") %>' TextMode="Number"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="cantidadTB" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="cantidadTB" CssClass="auto-style58" ErrorMessage="La cantidad no es valida solo se permiten numeros de 3 digitos mayores a cero" ForeColor="Red" ValidationExpression="^[1-9][0-9]{0,2}$" ValidationGroup="botonActu"></asp:RegularExpressionValidator>
                                                                <br />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label20" runat="server" Text='<%# Bind("cantidad") %>'></asp:Label>
                                                                <br />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Disponibilidad">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="Label18" runat="server" Text='<%# Bind("disponibilidad") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("disponibilidad") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total">
                                                            <EditItemTemplate>
                                                                <asp:Label ID="Label19" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField ShowHeader="False">
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="LinBActualizar" runat="server" CausesValidation="True" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Update" Text="Actualizar" ValidationGroup="botonActu"></asp:LinkButton>
                                                                &nbsp;<asp:LinkButton ID="LinBCancelar" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinBEditar" runat="server" CausesValidation="False" CommandName="Edit" Text="Añadir "></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
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
                                            </div>
                                            <br />
                                            <br />
                                            <asp:Label ID="LTotalPedido" runat="server" CssClass="auto-style53" Text="Total pedido"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="LB_total" runat="server" CssClass="auto-style53"></asp:Label>
                                            <br />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="GW_carrito" EventName="DataBinding"/>

                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style51">
                                    <br />
                                    <br />
                                    <br />
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style55" colspan="2">
                                    <br />
                                    <asp:Button ID="BContinuarComprando" runat="server" BackColor="#FF952B" CssClass="auto-style46" OnClick="BT_continuar_Click" PostBackUrl="~/View/HacerPedidoCliente.aspx" Text="Continuar comprando" Height="40px" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style52"></td>
                                <td class="auto-style48">
                                    <asp:TextBox ID="lat" runat="server" Width="0px" BackColor="White" ForeColor="White"></asp:TextBox>
                                    <asp:TextBox ID="lon" runat="server" Width="0px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style48" colspan="2">
                                    <br />
                                    <asp:Label ID="LUbicacion" runat="server" CssClass="auto-style53" Text="Ubicacion del punto de venta"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style48" colspan="2">
                                    <div id="map" class="auto-style43">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style52">
                                    &nbsp;</td>
                                <td class="auto-style48">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style48" colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                                        <br />
                                                        <asp:Label ID="LBObtencion" runat="server" CssClass="auto-style53" Text="¿Como quiere obtenerlos?"></asp:Label>
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DL_tipo_envio" runat="server" AutoPostBack="True" CssClass="auto-style46" Height="48px" OnSelectedIndexChanged="DL_tipo_envio_SelectedIndexChanged" Width="117px" BackColor="#999999">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DL_tipo_envio" ErrorMessage="*" ForeColor="Red"  InitialValue="0" ValidationGroup="confirmar" ></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LDireccion" runat="server" CssClass="auto-style53" Text="Direccion de envio"></asp:Label>
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <br />
                                                        <asp:TextBox ID="TB_direccion" runat="server"  Width="208px" BackColor="#999999"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" BackColor="White" ErrorMessage="*" ForeColor="Red" ValidationGroup="confirmar" ControlToValidate="TB_direccion"></asp:RequiredFieldValidator>
                                                        <br />
                                                        <asp:RegularExpressionValidator ID="REDireccionExpresion" runat="server" ControlToValidate="TB_direccion" CssClass="auto-style46" ErrorMessage="La direccion no puede contener caracteres especiales" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9\s-]+$" ValidationGroup="confirmar"></asp:RegularExpressionValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <script type="text/javascript">
                                       
                
               function Mensaje()
               {
                   alert('Aun no hay productos para mostrar :( ');
                   
               }
               function alerta() {
                   alert('Se ha presionado el boton: ');
               }


        
        var marker;        
        var coords = {};   
       
       
        initMap = function () {
            
            coords = {
                lng: longi(),
                lat: latitu()
            };
            setMapa(coords); 
        }

        function setMapa(coords) {
           
            var map = new google.maps.Map(document.getElementById('map'),
            {
                zoom: 13,
                center: new google.maps.LatLng(coords.lat, coords.lng),

            });

          
            marker = new google.maps.Marker({
                map: map,
                draggable: true,
                animation: google.maps.Animation.DROP,
                position: new google.maps.LatLng(coords.lat, coords.lng),

            });
        
            marker.addListener('click', toggleBounce);

            marker.addListener('dragend', function (event) {
               
               var direccion= document.getElementById("coordenadas").value = this.getPosition().lat() + "," + this.getPosition().lng();
               cargar(direccion);
            });
            
        }

        function toggleBounce() {
            if (marker.getAnimation() !== null) {
                marker.setAnimation(null);
            } else {
                marker.setAnimation(google.maps.Animation.BOUNCE);
            }
        }

        
                                        function latitu(){
                                            var nick = document.getElementById('<%= lat.ClientID %>').value;
                                            return nick;
                                        }

                                         function longi(){
                                            var nick = document.getElementById('<%= lon.ClientID %>').value;
                                            return nick;
                                         }

    </script>
                                    <script async="" defer src="http://maps.google.com/maps/api/js?key=AIzaSyDIo9h40sVSPeIddQ7lTJbnYbrTYrcNRMg&callback=initMap">

</script>
                                    <br />
                                    <caption>
                                        <br />
                                    </caption>
                                    </div>
                                    <asp:TextBox ID="TB_coor" runat="server" Width="1px"></asp:TextBox>
                                    <caption>
                                        <input id="coordenadas" type="text" class="auto-style42" disabled="disabled" />
                                    </caption>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style44" colspan="2">
                                    <asp:Button ID="BT_confirmar" runat="server" BackColor="#FF952B" CssClass="auto-style46" Height="40px" Text="Confirmar pedido" OnClick="BT_confirmar_Click" ValidationGroup="confirmar" />
                                </td>
                            </tr>
                        </table>
                        <br />
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

