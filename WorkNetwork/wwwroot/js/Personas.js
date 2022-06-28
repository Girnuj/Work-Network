const CompletarTablaPersonas = async () => {

    await VaciarFormulario();

    $.ajax({
        type: "POST",
        url: '../../Personas/TablaPersonas',
        data: {},
        success: async (personas) => {
            $('#tbody-personas').empty();
            $.each(personas, await function (index, persona) {
                console.log(persona)
                let claseEliminado = '';
                //let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarRubro(${persona.idPersona})"><i class="bi bi-pencil-square"></i> Editar</btn>
                //                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarRubro(${rubro.rubroID},1)"><i class="bi bi-trash3"></i> Eliminar</btn>`

                //if (rubro.eliminado) {
                //    claseEliminado = 'table-danger';
                //    botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarRubro(${rubro.rubroID},0)"><i class="bi bi-recycle"></i> Activar</btn>`
                //}
                $("#tbody-personas").append(
                    `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${persona.nombrePersona}</td>
                        <td class='texto'>${persona.apellidoPersona}</td>

                        <td class='texto'>${persona.tipoDoc}</td>
                        <td class='texto'>${persona.nroDNI}</td>
                        <td class='texto'>${persona.mailUser}</td>
                        <td class='texto'>${persona.userDom}</td>
                        <td class='texto'>${persona.idPais}</td>
                        <td class='texto'>${persona.idProvincia}</td>
                        <td class='texto'>${persona.idLocalidad}</td>
                        <td class='texto'>${persona.genre}</td>
                        <td class='texto'>${persona.tel1}</td>
                        <td class='texto'>${persona.tel2}</td>
                        <td class='texto'>${persona.estCivil}</td>
                        <td class='texto'>${persona.tituloAcadem}</td>
                        <td class='texto'>${persona.imagenUp}</td>
                        <td class = 'text-center'>
                           
                        </td>
                    </tr>`



                )
                $('#cards').append(
                    `<div class="card">
						<div class="content">
							<div class="img">
								<!--- <img src="images/img1.jpg" alt="">-->
							</div>
							<div class="details">
								<div class="name">${persona.nombrePersona}</div>
								<div class="job">${persona.apellidoPersona}</div>
							</div>
							<div class="media-icons">
								<a href="#"><i class="fab fa-facebook-f"></i></a>
								<a href="#"><i class="fab fa-twitter"></i></a>
								<a href="#"><i class="fab fa-instagram"></i></a>
								<a href="#"><i class="fab fa-youtube"></i></a>
							</div>
						</div>
					</div>`
                )
            });
        },
        error: (err) => console.log("error en CompletarTablaPersonas",err)
    });
}

const GuardarPersona = async () => {
    let idPersona = $('#idPersona').val();
    let nombrePersona = $('#nombrePersona').val();
    let apellidoPersona = $('#apellidoPersona').val();
    let tipoDoc = $('#tipoDoc').val();
    let nroDNI = $('#nroDNI').val();
    let fecNac = $('#fecNac').val();
    let mailUser = $('#mailUser').val();
    let userDom = $('#userDom').val();
    let idPais = $('#idPais').val();
    let idProvincia = $('#idProvincia').val();
    let idLocalidad = $('#idLocalidad').val();
    let genre = $('#Genre').val();
    let tel1 = $('#tel1').val();
    let tel2 = $('#tel2').val();
    let estCivil = $('#estCivil').val();
    let tituloAcadem = $('#tituloAcadem').val();
    let imagenUp = $('#imagenUp').val();

    let url = '../../Personas/CrearPersona';
    let data = {
        IdPersona: idPersona, NombrePersona: nombrePersona, ApellidoPersona: apellidoPersona, TipoDoc: tipoDoc,
        NroDNI: nroDNI, FecNac: fecNac, MailUser: mailUser, UserDom: userDom, IdPais: idPais, IdProvincia: idProvincia,
        IdLocalidad: idLocalidad, Genre: genre, Tel1: tel1, Tel2: tel2, EstCivil: estCivil, TituloAcadem: tituloAcadem,
        ImagenUp: imagenUp
    };

    //j.query
    $.post(url, data).done(await function (resultado) {
        if (resultado == false) {
            $('#modalCrearPersona').modal('hide')
            CompletarTablaPersonas()
        }
    }).fail((err) => console.log("error en GuardarPersona", err))


    //$.ajax({
    //    type: "POST",
    //    url: '../../Personas/CrearPersona',
    //    data: { IdPersona: idPersona, NombrePersona: nombrePersona, ApellidoPersona: apellidoPersona },
    //    success: await function (resultado) {
    //        if (resultado == false) {
    //            $('#modalCrearPersona').modal('hide')
    //            CompletarTablaPersonas()
    //        }
    //    },
    //    error: (err) => console.log("error en GuardarPersona",err)
    //})

}
const AbrirModal = () => {
    $('#idPersona').val(0);
    $('#modalCrearPersona').modal('show');
}

const VaciarFormulario = () => {

    $("#idPersona").val(0);
    $("#nombrePersona").val('');
    $("#apellidoPersona").val('');
    $("#tipoDoc").val('');
    $("#nroDNI").val('');
    $("#fecNac").val('');
    $("#mailUser").val('');
    $("#userDom").val('');
    $("#idPais").val('');
    $("#idProvincia").val('');
    $("#idLocalidad").val('');
    $("#genre").val('');
    $("#tel1").val('');
    $("#tel2").val('');
    $("#estCivil").val('');
    $("#tituloAcadem").val('');
    $("#imagenUp").val('');
}