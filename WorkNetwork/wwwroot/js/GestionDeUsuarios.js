﻿function loginEmpresa(){	
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
	let url = '../../GestionDeUsuarios/Registrar';
	let data = { email: correoPersona, password: passPersona, Rol: rol }
	passPersona === passConfirmPersona
		? $.post(url, data).done(resultado => resultado ? window.location.href = '/' : alert('usuario o contraseña incorrecta')).fail(e => console.log(e))
		: alert('las contraseñas no coinciden');
}
