const CompletarTablaPaises = async () => {
    await VaciarFormulario()
    const url = '../../Paises/TablaPaises'


    $.get(url).done(
        paises => {
            $('#tbody-pais').empty();
            $.each(paises, async (index, pais) => {
                console.log('hola')
                let claseEliminado = '';
                $('#tbody-pais').append(`<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>pais${pais.nombrePais}</td>
                        <td class = 'text-center'>
                        </td>
                    </tr>`)
            })
        }
    ).fail(e=>console.log(e))
}

const AbrirModal = () => {
    $('#idPais').val(0)
    $('#nombrePais').val('')
    $('#modalCrearPais').modal('show')
}

const VaciarFormulario = () => {

    $("#idPais").val(0);
    $("#nombrePais").val('');
}

const GuardarPais = async () => {
    let idPais = $('#idPais').val();
    let nombrePais = $('#nombrePais').val();
    let url = '../../Paises/CrearPais';
    let data = { NombrePais: nombrePais }

    $.post(url, data).done(await function (resultado){
        if (resultado == false) {
            $('#modalCrearPais').modal('hide')
            CompletarTablaPaises()
        }
    }).fail(err => console.log('error en crear Pais: ', err ))
}
