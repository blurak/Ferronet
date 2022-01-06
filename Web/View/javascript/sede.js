var pop;
var pop2;

function SesionNula() {
    alert('Error por favor inicie sesion');
    window.location.href = "IniciarSesion.aspx";
}

function RolIncorrecto() {
    alert('Acceso denegado');
    window.location.href = "IniciarSesion.aspx";
}

function ProductoRegistrado() {
    alert('Producto registrado correctamente');
}
function FormatoImagen() {
    alert('Solo se admiten imagenes en formato Jpeg o png');
}

function CerrarVentanaCorrecto() {
  
    window.close();
}

function CerrarVentanaProductoAsignado() {
    //alert('Este producto ya esta asignado en el inventario de la subsede seleccionada');
    window.close();
}

function VentanaCantidades() {
    pop = window.open('Cantidades.aspx', 'cantidade', 'width=310, height=530,menubar=si');
    pop.focus();

}


//VentanaPlato

function VentanaPlato() {
    alert('hola');
    pop2 = window.open('PromocionesPlatos.aspx', 'platos', 'width=900, height=530,menubar=si');
    pop2.focus();
    
}



function RedireccionarSuper() {
    alert('Bienvenido');
    window.location.href = 'AdministracionDeSubsedes.aspx';
}

function RedireccionarAdmin() {
    windows.location.href = "InventarioActualSubsede.aspx";
}

function RedireccionarCliente() {
    windows.location.href = 'HacerPedidoCliente.aspx';
}


function RedireccionarCajero() {
    windows.location.href = "RegistrarVentaConGridview.aspx";
}