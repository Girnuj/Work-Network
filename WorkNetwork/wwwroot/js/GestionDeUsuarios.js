function loginEmpresa(){	
			event.preventDefault();
			let correoEmpresa =	$('#correoEmpresa').val();
			let passEmpresa = $('#passwordEmpresa').val();
			let url = '../../GestionDeUsuarios/Ingresar';
			let data = { email: correoEmpresa, password:passEmpresa };
	$.post(url, data).done(resultado => {
		resultado ? console.log('logeado') : alert('usuario o contraseña incorrecta')
			}).fail(e => console.log(e))
		}
function register() {
	event.preventDefault();
	let correo = $('#Email').val();
	let pass = $('#Password').val();
	let passConfirm = $('#ConfirmPassword').val();
	let url = '../../GestionDeUsuarios/Registrar';
	let data = { email: correo, password: pass }
	$.post(url, data).done(resultado => resultado ? console.log('logeado') : alert('usuario o contraseña incorrecta')).fail(e=>console.log(e))
	
}