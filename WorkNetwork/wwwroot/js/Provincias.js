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
    let nombreProvincia = $('#nombreProvincia').val().trim();
    let idPais = $('#PaisID').val();
    let alertProvincia= $('#alertProvincia')
    let url = '../../Provincias/CrearProvincia';
    let data = { IdProvincia: idProvincia, NombreProvincia: nombreProvincia, PaisID: idPais };

    if(nombreProvincia != '' && nombreProvincia != null){
    $.post(url, data).done(resultado => {
        if (resultado == 0) {
        $('#modalCrearProvincia').modal('hide');
        CompletarTablaProvincias();
        }
        if (resultado == 2){
            alertProvincia.removeClass('visually-hidden').text('La provincia ingesada ya existe')
        }
    }).fail(e => console.error(`Error cargar provincias '${e}'`))
    }else{
        alertProvincia.removeClass('visually-hidden').text("El campo nombre no puede estar vacio")
    }
}

const AbrirModal = () => {
    $('#idProvincia').val(0);
    $('#modalCrearProvincia').modal('show');
    $("#PaisID").val(0);
    $('#alertProvincia').addClass('visually-hidden');
}

const VaciarFormulario = () => {

    $("#idProvincia").val(0);
    $("#nombreProvincia").val('');
}
