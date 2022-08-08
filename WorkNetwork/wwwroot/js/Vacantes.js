const CompletarTablaVacantes = () => {
    VaciarFormulario();

    let url = '../../Vacante/TablaVacantes'

    $.get(url).done(empresas => {
        $('#tbody-empresa').empty();
        $.each(empresas, function (index, empresas) {
            $("#tbody-empresa").append(
                `<tr class= 'tabla-hover '>
                        <td class='texto'>${empresas.razonSocial}</td>
                        <td class='texto'>${empresas.cuit}</td>
                        <td class = 'text-center'>botonsitos 
                        </td>
                    </tr>`
            )
        })
    }).fail(e => console.error('Error al cargar tabla localidades ' + e));
}

const GuardarVacante= () => {
    let idVacante= $('#idVacante').val();
    let idEmpresa= $('#idEmpresa').val();
    let tituloVacante =$('#tituloVacante')
    let descripcionVacante=$('#descripcionVacante').val();
    let expRequeridaVacante= $('#expRequeridaVacante').val();
    let paisID = $('#PaisID').val();
    let provinciaID = $('#ProvinciaID').val();
    let localidadID = $('#LocalidadID').val();
    let fechaFinalizacionVacante =$('#fechaFinalizacionVacante').val();
    let idiomaVacante = $('#idiomaVacante').val();
    let disponibilidadHoraria = $('#disponibilidadHoraria').val();
    let modalidadVacante = $('#modalidadVacante').val();
    let imagenVacante = $('#imagenVacante').val();
    let rubroID = $('#RubroID').val();
    let tipoEmpresa = $('#tipoEmpresa').val();
    const url = '../../Empresas/GuardarEmpresa'
    const data = {
        VacanteID:idVacante, EmpresaID: idEmpresa, Nombre: tituloVacante, Descripcion: descripcionVacante, ExperienciaRequerida: expRequeridaVacante, LocalidadID: localidadID, FechaDeFinalizacion: fechaFinalizacionVacante,  Idiomas: idiomaVacante, DisponibilidadHoraria:disponibilidadHoraria, tipoModalidad:modalidadVacante, Imagen:imagenVacante
    }
    $.post(url, data).done(resultado => {
        $('#modalCrearEmpresa').modal('hide');
        CompletarTablaEmpresas()
    }).fail(e => console.log('error en guardar empresa' + e))
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
    }).fail(e => console.log('error en combo provincias ' + e));
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
    $('#modalCrearVacante').modal('show');
    $('#ProvinciaID').val(0);
    $('#LocalidadID').val(0);
}

const VaciarFormulario = () => {
    $('#idEmpresa').val(0);
    $('#nombreEmpresa').val('')
}