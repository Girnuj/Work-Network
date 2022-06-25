const CompletarTablaLocalidades = async () => {
    await VaciarFormulario()

    let url = '../../Localidades/TablaLocalidades'

    $.get(url).done(async localidades => {
        $('#tbody-localidad').empty();
        $.each(localidades,await function (index, localidad) {
            $("#tbody-localidad").append(
                `<tr class= 'tabla-hover '>
                        <td class='texto'>${localidad.nombreLocalidad}</td>
                        <td class='texto'>${localidad.cp}</td>
                        <td class = 'text-center'>botonsitos 
                        </td>
                    </tr>`
            )
        })
    }).fail(e => console.error('Error al cargar tabla localidades ' + e))
}

const GuardarLocalidad = () => {
    let idLocalidad = $('#idLocalidad').val();
    let nombreLocalidad = $('#nombreLocalidad').val();
    let cpLocalidad = $('#cpLocalidad').val();
    let idProvincia = $('#ProvinciaID').val();
    let url = '../../Localidades/GuardarLocalidad';
    let data = { IdLocalidad: idLocalidad, NombreLocalidad: nombreLocalidad, ProvinciaID: idProvincia, CP: parseInt(cpLocalidad) };

    $.post(url, data).done(resultado => {
        $('#modalCrearLocalidad').modal('hide');
        CompletarTablaLocalidades();
    }).fail(e => console.log('Error en guardar localidad ' + e))
}


const AbrirModal = () => {
    $('#idLocalidad').val(0);
    $('#modalCrearLocalidad').modal('show');
    $("#ProvinciaID").val(0);
}

const VaciarFormulario = () => {
    $('#idLocalidad').val(0);
    $('#nombreLocalidad').val('')
}