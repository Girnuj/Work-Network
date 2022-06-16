const CompletarTablaProvincias = async () => {

    await VaciarFormulario();

    $.ajax({
        type: "POST",
        url: '../../Provincias/TablaProvincias',
        data: {},
        success: async (provincias) => {
            $('#tbody-provincias').empty();
            $.each(provincias, await function (index, provincia) {
                console.log(provincia)
                let claseEliminado = '';
                $("#tbody-provincias").append(
                    `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${provincia.nombreProvincia}</td>
                        <td class = 'text-center'>
                        </td>
                    </tr>`



                )
            });

        },
        error: (err) => console.log("error en CompletarTablaProvincias", err)
    });

}


const GuardarProvincia = async () => {
    let idProvincia = $('#idProvincia').val();
    let nombreProvincia = $('#nombreProvincia').val();
    let url = '../../Provincias/CrearProvincia';
    let data = { IdProvincia: idProvincia, NombreProvincia: nombreProvincia };

    //j.query
    $.post(url, data).done(await function (resultado) {
        if (resultado == false) {
            $('#modalCrearProvincia').modal('hide')
            CompletarTablaProvincias()
        }
    }).fail((err) => console.log("error al guardar la Provincia", err))
}

const AbrirModal = () => {
    $('#idProvincia').val(0);
    $('#modalCrearProvincia').modal('show');
}

const VaciarFormulario = () => {

    $("#idProvincia").val(0);
    $("#nombreProvincia").val('');
}
