const CompletarTablaVacantes = () => {
    VaciarFormulario();

    let url = '../../Vacante/TablaVacantes'

    $.get(url).done(vacantes => {
        $('#tbody-vacante').empty();
        $.each(vacantes, function (index, vacantes) {
            let claseEliminado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarVacantes(${vacantes.idVacante})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarVacante(${vacantes.idVacante},1)"><i class="bi bi-trash3"></i> Eliminar</btn>`

            if (vacantes.eliminado) {
                claseEliminado = 'table-danger';
                botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarVacante(${vacantes.idVacante},0)"><i class="bi bi-recycle"></i> Activar</btn>`
            }
            $("#tbody-vacante").append(
                `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${vacante.tituloVacante}</td>
                        <td class='texto'>${vacante.descripcionVacante}</td>
                        <td class='texto'>${vacante.expRequeridaVacante}</td>
                        <td class='texto'>${vacante.localidadID}</td>
                        <td class='texto'>${vacante.fechaFinalizacionVacante}</td>
                        <td class='texto'>${vacante.idiomaVacante}</td>
                        <td class='texto'>${vacante.disponibilidadHoraria}</td>
                        <td class='texto'>${vacante.modalidadVacante}</td>
                        <td class = 'text-center'>
                        ${botones}
                        </td>
                 </tr>`

            )
        })
    }).fail(e => console.error('Error al cargar tabla localidades ', e));
}

const GuardarVacante= () => {
    let idVacante= $('#idVacante').val();
    let idEmpresa= $('#idEmpresa').val();
    let tituloVacante =$('#tituloVacante')
    let descripcionVacante=$('#descripcionVacante').val();
    let expRequeridaVacante= $('#expRequeridaVacante').val();
    //let paisID = $('#PaisID').val();
    //let provinciaID = $('#ProvinciaID').val();
    let localidadID = $('#LocalidadID').val();
    let fechaFinalizacionVacante =$('#fechaFinalizacionVacante').val();
    let idiomaVacante = $('#idiomaVacante').val();
    let disponibilidadHoraria = $('#disponibilidadHoraria').val();
    let modalidadVacante = $('#modalidadVacante').val();
    let imagenVacante = $('#imagenVacante').val();
    const url = '../../Vacantes/GuardarVacante';
    const data = {
        VacanteID: idVacante, EmpresaID: idEmpresa, Nombre: tituloVacante,
        Descripcion: descripcionVacante, ExperienciaRequerida: expRequeridaVacante,
        LocalidadID: localidadID, FechaDeFinalizacion: fechaFinalizacionVacante,
        Idiomas: idiomaVacante, DisponibilidadHorariaid: disponibilidadHoraria,
        tipoModalidadid: modalidadVacante, Imagen: imagenVacante
    }
    $.post(url, data).done(resultado => {
        $('#modalCrearVacante').modal('hide');
        CompletarTablaVacantes()
    }).fail(e => console.log('error en guardar vacante' + e))
}

$('#PaisID').change(() => BuscarProvincia());

const BuscarProvincia = () => {
    $('#ProvinciaID').empty();
    let url = '../../Provincias/ComboProvincia';
    let data = { id: $('#PaisID').val() };
    $.post(url, data).done(provincias => {
        provincias.length === 0
            ? $('#ProvinciaID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`)
            : $.each(provincias, (i, provincia) => {
                $('#ProvinciaID').append(`<option value=${provincia.value}>${provincia.text}</option>`)
              });
    }).fail(e => console.log('error en combo provincias ' + e));
    return false
}

$('#ProvinciaID').change(() => BuscarLocalidad());

const BuscarLocalidad = () => {
    $('#LocalidadID').empty();
    let url = '../../Localidades/ComboLocalidades';
    let data = { id: $('#ProvinciaID').val() };
    $.post(url, data).done(localidades => {
        localidades.length === 0
            ? $('#LocalidadID').append(`<option value=${0}>[NO EXISTEN LOCALIDADES]</option>`)
            : $.each(localidades, (i, localidad) => {
                $('#LocalidadID').append(`<option value=${localidad.value}>${localidad.text}</option>`)
            });
    }).fail(e => console.log('error en combo localidades' + e))
    return false
}
const AbrirModal = () => {
    $('#idVacante').val(0);
    $('#modalCrearVacante').modal('show');
}

const VaciarFormulario = () => {
    $('#idVacante').val(0);
    $('#idEmpresa').val(0);
    $('#tituloVacante').val('')
    $('#descripcionVacante').val('');
    $('#expRequeridaVacante').val('');
    $('#idPais').val('');
    $('#idProvincia').val('');
    $('#idLocalidad').val('');
    $('#fechaFinalizacionVacante').val('');
    $('#idiomaVacante').val('');
    $('#disponibilidadHoraria').val('');
    $('#modalidadVacante').val('');
    $('#imagenVacante').val('');
}