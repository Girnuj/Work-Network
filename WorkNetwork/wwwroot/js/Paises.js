const CrearPais = () => {
    let nombrePais = $("#Nombre").val();
    $.ajax({
        type: 'POST',
        url: '../../Paises/CrearPais',
        data: { Nombre: nombrePais },
        success: (pais) => {
            console.log(pais)
        },
        error: (err) => { console.log('error de pais', err) }
    }
    );
};