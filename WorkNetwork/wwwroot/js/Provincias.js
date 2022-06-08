const CrearProvincia = () => {
    let nombre = $('#Nombre').val()
    let pais = $('#idPais').val()
    console.log(pais)
    let url = '../../Provincias/CrearProvincia'
    let data = { nombreProvincia: nombre, idPais: pais }

    $.post(url, data).done(() => { }).fail(err => console.log('error en provincia' ,err))
}