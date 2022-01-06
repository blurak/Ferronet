<%@ Page Title="" Language="C#" MasterPageFile="~/View/Superadmin.master" AutoEventWireup="true" CodeFile="~/Controller/CrearSede.aspx.cs" Inherits="View_CrearSede" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style12 {
            width: 16%;
        }
        .auto-style25 {
            margin-right: 0px;
        }
        .auto-style27 {
            width: 100%;
            height: 554px;
        }
        .auto-style28 {
            width: 14%;
        }
        .auto-style31 {
            width: 179px;
        }
        .auto-style33 {
            font-size: medium;
        }
        .auto-style34 {
            font-size: large;
        }
        .auto-style35 {
            width: 100%;
            height: 360px;
        }
        .auto-style36 {
            width: 99%;
        }
        .auto-style42 {
            width: 1px;
        }
        .auto-style43 {
            width: 350px;
        }
    </style>
    <script src="http://maps.google.com/maps/api/js?key=AIzaSyDIo9h40sVSPeIddQ7lTJbnYbrTYrcNRMg" type="text/javascript">
    </script>

    <script type="text/javascript">

        function load() {
            if (GBrowserIsCompatible()) {
                var map = new GMap2(document.getElementById("map"));
                map.addControl (new GSmallMapControl());
                map.addControl(new GMapTypeControl());
                var center = new GLatLng(4.7064752877673435, -74.07232940081076);
                map.setCenter(center, 11);
                map.setMapType(G_SATELLITE_MAP);
                geocoder = new   GClientGeocoder();
                var marker = new GMarker(center, {draggable: true}); 
                map.addOverlay(marker);
                document.getElementById("lat").value = center.lat();
                document.getElementById("lng").value = center.lng ();
                geocoder = new GClientGeocoder();

                GEvent.addListener(marker, "dragend", function() {
                    var point =marker.getPoint();
                    map.panTo(point);
                    document.getElementById("lat").value = point.lat();
                    document.getElementById("lng").value = point.lng();
                });

                GEvent.addListener(map, "moveend", function() {
                    map.clearOverlays();
                    var center = map.getCenter();
                    var marker = new GMarker(center, {draggable: true});
                    map.addOverlay(marker);
                    document.getElementById ("lat").value = center.lat();
                    document.getElementById("lng").value = center.lng();

                GEvent.addListener(marker, "dragend", function() {
                        var point =marker.getPoint();
                        map.panTo(point);
                        document.getElementById("lat").value = point.lat();
                        document.getElementById("lng").value = point.lng();
                    });
                });
            }   
    }

            function showAddress(address) {
                    var map = new GMap2(document.getElementById("map"));
                    map.addControl(new GSmallMapControl());
                    map.addControl(new GMapTypeControl());
                if (geocoder) {
                        geocoder.getLatLng (
                        address,
                    function(point) {
                        if (!point) {
                            alert(address + " ciudad no encontrada");
                    }
                    else {
                        document.getElementById("lat").value = point.lat();
                        document.getElementById("lng").value = point.lng();
                        map.clearOverlays()
                        map.setCenter(point, 14);
                        var marker = new GMarker(point, {draggable: true}); 
                        map.addOverlay(marker);

                        GEvent.addListener(marker, "dragend", function() {
                            var pt =marker.getPoint();
                            map.panTo(pt);
                            document.getElementById("lat").value = pt.lat();
                            document.getElementById("lng").value = pt.lng();
                        });

                        GEvent.addListener(map, "moveend", function() {
                            map.clearOverlays();
                            var center = map.getCenter();
                            var marker = new GMarker(center, {draggable: true});
                            map.addOverlay(marker);
                            document.getElementById ("lat").textContent = center.lat();
                            document.getElementById("lng").textContent = center.lng();

                          GEvent.addListener(marker, "dragend", function() {
                                var pt =marker.getPoint();
                                map.panTo(pt);
                                document.getElementById("lat").value = pt.lat();
                                document.getElementById("lng").value = pt.lng();
                            });
                      });
                        }
                    }
                );
                }
            }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <div>

            
    <asp:Panel ID="Panel1" runat="server" BackColor="#999999" Height="947px">
        
        <table class="auto-style27">
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>
                    <asp:Panel ID="Panel2" runat="server" BackColor="White" Width="811px" Height="883px" CssClass="auto-style25">
                        <table class="auto-style35">
                            <tr>
                                <td class="auto-style28">&nbsp;</td>
                                <td>
                                    <table class="auto-style36">
                                        <tr>
                                            <td class="auto-style43" colspan="2">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                                <br />
                                                <asp:Label ID="LBNombreSede" runat="server" CssClass="auto-style34" Text="Nombre de la sede"></asp:Label>
                                                <br />
                                            </td>
                                            <td colspan="3">
                                                <br />
                                                <table class="auto-style1">
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="TB_nombre" runat="server" BackColor="Silver" CssClass="auto-style33"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_nombre" ErrorMessage="*" ForeColor="Red" ValidationGroup="BotonCrear"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="RENombre" runat="server" ControlToValidate="TB_nombre" ErrorMessage="El nombre debe contener de 3 a 20 caracteres sin caracteres especiales ni numeros" Font-Size="Small" ForeColor="Red" ValidationExpression="^[a-zA-Z]+(\s*[a-zA-Z]*)*[a-zA-Z]+$" ValidationGroup="BotonCrear"></asp:RegularExpressionValidator>
                                                            <ajaxToolkit:ValidatorCalloutExtender ID="RENombre_ValidatorCalloutExtender" runat="server" BehaviorID="RENombre_ValidatorCalloutExtender" TargetControlID="RENombre">
                                                            </ajaxToolkit:ValidatorCalloutExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style43" colspan="2">
                                                <asp:Label ID="LBUbicacion" runat="server" CssClass="auto-style34" Text="Ubicacion"></asp:Label>
                                            </td>
                                            <td colspan="3"> <div id="map" class="auto-style1" style="width: 400px; height: 400px" ></div>
          <asp:TextBox ID="TB_coor" runat="server" Width="1px"></asp:TextBox>
          
    
    

        <input id="coordenadas" type="text" class="auto-style42" disabled="disabled" /><script type="text/javascript">
        
        var marker;        
        var coords = {};   
       
       
        initMap = function () {

            coords = {
                lng: -74.07749933337402,
                lat: 4.716719804788972
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

        function cargar(direccion) {
            var nick = document.getElementById('<%= TB_coor.ClientID %>').value=direccion;
          return true;
        }



       
  
    </script><script src="http://maps.google.com/maps/api/js?key=AIzaSyDIo9h40sVSPeIddQ7lTJbnYbrTYrcNRMg&callback=initMap"></script><br /></td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style43" colspan="2">
                                                <br />
                                                <asp:Label ID="LBAdministradoresDisponibles" runat="server" CssClass="auto-style34" Text="Administradores disponibles"></asp:Label>
                                                <br />
                                            </td>
                                            <td class="auto-style31">
                                                <br />
                                                <br />
                                                <asp:DropDownList ID="DL_administradores" runat="server" BackColor="#999999" CssClass="auto-style33" DataSourceID="DAOSAdministradores"  DataTextField="Cliente" DataValueField="NumeroPedido" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="DAOSAdministradores" SelectMethod="obtenerAdministradoresP"  runat="server" TypeName="Logica.LSede"></asp:ObjectDataSource>
                                                <br />
                                                <br />
                                            </td>
                                            <td class="auto-style31">
                                                <asp:Label ID="LBCajerosDisponibles" runat="server" CssClass="auto-style34" Text="Cajeros disponibles"></asp:Label>
                                            </td>
                                            <td>
                                                <br />
                                                <asp:DropDownList ID="DL_cajeros" runat="server" BackColor="Silver" CssClass="auto-style33" DataSourceID="DOSCajeros" DataTextField="Cliente" DataValueField="NumeroPedido" Height="45px" Width="145px">
                                                </asp:DropDownList>
                                                <asp:ObjectDataSource ID="DOSCajeros" runat="server" SelectMethod="obtenerCajerosP" TypeName="Logica.LSede"></asp:ObjectDataSource>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style9">
                                                <br />
                                                <asp:ImageButton ID="IBSalir" runat="server" Height="110px" ImageUrl="~/Images/botones/salir.jpg" PostBackUrl="~/View/AdministracionDeSubsedes.aspx" />
                                            </td>
                                            <td class="auto-style9" colspan="4">
                                                <br />
                                                <br />
                                                <asp:Button ID="BTCrearSede" runat="server" BackColor="#FF952B" CssClass="auto-style33" Height="40px"  Text="Crear sede" ValidationGroup="BotonCrear" Width="128px" OnClick="BtnCrearSede_Click" />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
        <br />
   
    </asp:Panel>
        </div>
          
   
</asp:Content>

