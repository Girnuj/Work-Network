const CompletarTablaPersonas = async () => {

    await VaciarFormulario();

    $.ajax({
        type: "POST",
        url: '../../Personas/TablaPersonas',
        data: {},
        success: async (personas) => {
            $('#tbody-personas').empty();
            $.each(personas, function (index, personas) {
                let claseEliminado = '';
                let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarPersona(${personas.idPersona})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarPersona(${personas.idPersona},1)"><i class="bi bi-trash3"></i> Eliminar</btn>`

                if (personas.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarPersona(${personas.idPersona},0)"><i class="bi bi-recycle"></i> Activar</btn>`
                }
                $("#tbody-personas").append(
                    `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${personas.nombrePersona}</td>
                        <td class='texto'>${personas.apellidoPersona}</td>

                        <td class='texto'>${personas.tipoDocumento}</td>
                        <td class='texto'>${personas.numeroDocumento}</td>
                        <td class='texto'>${personas.correoElectronico}</td>
                        <td class='texto'>${personas.domicilioPersona}</td>
                        <td class='texto'>${personas.localidadID}</td>
                        <td class='texto'>${personas.genero}</td>
                        <td class='texto'>${personas.telefono1}</td>
                        <td class='texto'>${personas.telefono2}</td>
                        <td class='texto'>${personas.estadoCivil}</td>
                        <td class='texto'>${personas.tituloAcademico}</td>
                        <td class = 'text-center'>
                           ${botones}
                        </td>
                    </tr>`
                )
            });
        },
        error: (err) => console.log("error en CompletarTablaPersonas", err)
    });
}

const GuardarPersona = async () => {
    let idPersona = $('#idPersona').val();
    let nombrePersona = $('#nombrePersona').val().trim();
    let apellidoPersona = $('#apellidoPersona').val().trim();
    let tipoDoc = $('#tipoDoc').val();
    let nroDNI = $('#nroDNI').val();
    let fecNac = $('#fecNac').val();
    let mailUser = $('#mailUser').val();
    let idPais = $('#PaisID').val();
    let idProvincia = $('#ProvinciaID').val();
    let idLocalidad = $('#LocalidadID').val();
    let genre = $('#genre').val();
    let tel1 = $('#tel1').val();
    let tel2 = $('#tel2').val();
    let estCivil = $('#estCivil').val();
    let tituloAcadem = $('#tituloAcadem').val();
    let imagenUp = $('#imagenUp').val();
    let domicilio = $('#Domicilio').val()
    let numero = $('#numeroDomicilio').val()
    let domicilioCompleto = `${domicilio} ${numero}`
    let cantidadHijos = $('#cantidadHijos').val()

    let url = '../../Personas/GuardarPersona';
    let data = {
        IdPersona: idPersona, NombrePersona: nombrePersona, ApellidoPersona: apellidoPersona, TipoDocumentoid: tipoDoc,
        NumeroDocumento: nroDNI, FechaNacimiento: fecNac, MailUser: mailUser, DomicilioPersona: domicilioCompleto,
        IdLocalidad: idLocalidad, Generoid: genre, Telefono1: tel1, Telefono2: tel2, EstadoCivil: estCivil, TituloAcademico: tituloAcadem,
        ImagenUp: imagenUp, CantidadHijos: cantidadHijos
    };

    //j.query
    $.post(url, data).done(await function (resultado) {
        if (resultado == false) {
            $('#modalCrearPersona').modal('hide')
            CompletarTablaPersonas()
        }
    }).fail((err) => console.log("error en GuardarPersona", err))
}

$('#PaisID').change(() => BuscarProvincia());

const BuscarProvincia = () => {
    $('#ProvinciaID').empty();
    let url = '../../Provincias/ComboProvincia';
    let data = { id: $('#PaisID').val() };
    $.post(url, data).done(provincias => {
        if (provincias.length === 0) {
            $('#ProvinciaID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`);
        }
        else {
            $.each(provincias, (i, provincia) => {
                $('#ProvinciaID').append(`<option value=${provincia.value}>${provincia.text}</option>`)
            });
        }
    }).fail(e => console.log('error en combo provincias ' + e))
    return false
}

$('#ProvinciaID').change(() => BuscarLocalidad());
const BuscarLocalidad = () => {
    $('#LocalidadID').empty();
    let url = '../../Localidades/ComboLocalidades';
    let data = { id: $('#ProvinciaID').val() };
    $.post(url, data).done(localidades => {
        if (localidades.length === 0) {
            $('#LocalidadID').append(`<option value=${0}>[NO EXISTEN LOCALIDADES]</option>`);
        }
        else {
            $.each(localidades, (i, localidad) => {
                $('#LocalidadID').append(`<option value=${localidad.value}>${localidad.text}</option>`)
            });
        }
    }).fail(e => console.log('error en combo localidades' + e))
    return false
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