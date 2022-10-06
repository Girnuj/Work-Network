function loginEmpresa(){	
	event.preventDefault();
	let correoEmpresa =	$('#correoEmpresa').val();
	let passEmpresa = $('#passwordEmpresa').val();
	let url = '../../GestionDeUsuarios/Ingresar';
	let data = { email: correoEmpresa, password:passEmpresa };
	$.post(url, data).done(resultado => {
		resultado ? window.location.href='/' : alert('usuario o contraseña incorrecta')
	}).fail(e => console.log(e))
}

function register() {
	event.preventDefault();
	let rol = $('#Rol').val();
	let correo = $('#Email').val();
	let pass = $('#Password').val();
	let passConfirm = $('#ConfirmPassword').val();
	let url = '../../GestionDeUsuarios/Registrar';
	let data = { email: correo, password: pass, Rol: rol }
	pass === passConfirm
		? $.post(url, data).done(resultado => resultado ? window.location.href = '/' : alert('usuario o contraseña incorrecta')).fail(e => console.log(e))
		: alert('las contraseñas no coinciden');
}
function registerPerson(){
	event.preventDefault();
	let rol = $('#Persona').val();
	let correoPersona = $('#EmailPersona').val()
	let passPersona = $('#PasswordPersona').val();
	let passConfirmPersona = $('#ConfirmPasswordPersona').val();
	let loader = document.getElementById('loaderRegisterPersona') 
	$("#registrarPersona").addClass('visually-hidden')
	$('#errorRegisterPersona').text('holaaas')
	$('#loaderRegisterPersona').removeClass('visually-hidden')
	let url = '../../GestionDeUsuarios/Registrar';
	let data = { email: correoPersona, password: passPersona, Rol: rol }
	if(passPersona === passConfirmPersona){
		$.post(url,data).done(
			(resultado)=>{
				if (resultado) {
					window.location.href = '/'
				}else{
					$('#errorRegisterPersona').text('El usuario ya existe')
				}
			}
		)
	}else{
		$('#errorRegisterPersona').text('Las contraseñas no coinciden')
	}

}
function loginPersona(){	
	event.preventDefault();
	let correoPersona=	$('#correoPersona').val();
	let passPersona= $('#passwordPersona').val();
	let url = '../../GestionDeUsuarios/Ingresar';
	let loader = document.getElementById('loaderLoginPersona') 
	$('#iniciarSesionPersona').addClass('visually-hidden');
	$('#loaderLoginPersona').removeClass('visually-hidden');
	let data = { email: correoPersona, password:passPersona};
	$.post(url, data).done(resultado => {
		if(resultado){
			window.location.href='/'
		}else{
			loader.classList.add('visually-hidden');
			$('#errorInicioSesion').removeClass('visually-hidden');
			$('#iniciarSesionPersona').removeClass('visually-hidden')
		}
	}).fail(e => {
		$('#iniciarSesionPersona').removeClass('visually-hidden')
		$('#errorInicioSesion').removeClass('visually-hidden')
		loader.classList.add('visually-hidden')	
	})
}