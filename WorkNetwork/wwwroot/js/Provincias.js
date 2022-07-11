const CompletarTablaProvincias = async () => {

    await VaciarFormulario();
    let url = '../../Provincias/TablaProvincias'

    $.get(url).done(async provincias => {
        $('#tbody-provincias').empty();
        $.each(provincias, await function (index, value) {
            let claseEliminado = '';
            $("#tbody-provincias").append(
                `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${value.nombreProvincia}</td>
                        <td class = 'text-center'>botonsitos 
                        </td>
                    </tr>`
            )
        })
    }).fail(e => console.error(`Error cargar provincias '${e}'`))

}



const GuardarProvincia = () => {
    let idProvincia = $('#idProvincia').val();
    let nombreProvincia = $('#nombreProvincia').val();
    let idPais = $('#PaisID').val();
    let url = '../../Provincias/CrearProvincia';
    let data = { IdProvincia: idProvincia, NombreProvincia: nombreProvincia, PaisID: idPais };


    $.post(url, data).done(resultado => {
        $('#modalCrearProvincia').modal('hide');
        CompletarTablaProvincias();
    }).fail(e => console.error(`Error cargar provincias '${e}'`))
}

const AbrirModal = () => {
    $('#idProvincia').val(0);
    $('#modalCrearProvincia').modal('show');
    $("#PaisID").val(0);
}

const VaciarFormulario = () => {

    $("#idProvincia").val(0);
    $("#nombreProvincia").val('');
}
