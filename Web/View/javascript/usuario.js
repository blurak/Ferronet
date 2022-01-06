
// <script type="text/javascript" src="javascript/prueba.js"></script>
//function RedireccionarSuper() {
//    window.location.href = "AdministracionDeSubsedes.aspx";
//}

//function RedireccionarAdmin() {
//    window.location.href = "InventarioActualSubsede.aspx";
//}

//function RedireccionarCliente() {
//    window.location.href = "HacerPedidoCliente.aspx";
//}
function RedireccionarIniciarSesion() {
    window.location.href = "IniciarSesion.aspx";
}

function TokenInvalido() {
    alert('El token es invalido por favor verifique e intentelo de nuevo');
    window.location.href = "IniciarSesion.aspx";
}

function TokenVencido() {
    alert('El token esta vencido genere uno nuevo');
    window.location.href = "GenerarToken.aspx";
}

function ContrasenaCambiada() {
    alert('La contraseña ha sido cambiada satisfactoriamente');
    window.location.href = "IniciarSesion.aspx";
}

function ContrasenasNoIguales() {
    alert('Las contraseñas no coinciden intentelo de nuevo');
}

function ErrorDeInicio() {
    alert('El usuario o contraseña son incorrectos');
    windows.location.href = "IniciarSesion.aspx";
}

function UsuarioRegistrado() {
    alert('El username ya esta en uso');
}

function UserAlreadyRegistrer() {
    alert('The username is already in use');
}

function RegistradoCorrectamente() {
    alert('Registrado correctamente');
}

function RegisteredSuccessfully() {
    alert('Registered Successfully');
}

// <script type="text/javascript" src="javascript/prueba.js"></script>
var pop;






function CerrarVentana() {
    pop.close();
    pop.window.close();
}


function VentanaCantidades() {
    pop = window.open('Cantidades.aspx', 'cantidade', 'width=310, height=530,menubar=si');
    pop.focus();

}



