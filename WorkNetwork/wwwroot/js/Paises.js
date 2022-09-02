const CompletarTablaPaises = async () => {
    await VaciarFormulario()
    const url = '../../Paises/TablaPaises'


    $.get(url).done(
        async paises => {
            $('#tbody-paises').empty();
            $.each(paises, await function (index, pais) {
                
                let claseEliminado = '';
                let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarRubro(${pais.paisID})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarRubro(${pais.paisID},1)"><i class="bi bi-trash3"></i> Eliminar</btn>`

                if (pais.eliminado) {
                    claseEliminado = 'table-danger';
                    botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarRubro(${pais.paisID},0)"><i class="bi bi-recycle"></i> Activar</btn>`

                }
                $('#tbody-paises').append(`<tr class= 'tabla-hover ${claseEliminado} '>
                        <td class='texto'>${pais.nombrePais}</td>
                        <td class = 'text-center'>
                            ${botones}
                        </td>
                    </tr>`)
            })
        }
    ).fail(e => console.log('cargar paises', e))
}

const AbrirModal = () => {
    $('#idPais').val(0);
    $('#titulo-modal-pais').val('Nuevo Pais');
    $('#alertPais').addClass('visually-hidden');
    $('#modalCrearPais').modal('show');
}

const VaciarFormulario = () => {

    $("#idPais").val(0);
    $("#nombrePais").val('');
}

const GuardarPais = () => {
    let idPais = $('#idPais').val();
    let nombrePais = $('#nombrePais').val().trim();
    let alertPais = $('#alertPais')
    let url = '../../Paises/CrearPais';
    let data = { NombrePais: nombrePais, PaisID: idPais };

    if (nombrePais != '' && nombrePais != null) {
        $.post(url, data).done((resultado) =>{
            if (resultado == 0) {
                $('#modalCrearPais').modal('hide');
                CompletarTablaPaises();
            }
            if (resultado == 2) {
                alertPais.removeClass('visually-hidden').text('El pais ingresado ya existe');
            }
        }).fail(err => console.log('error en crear Pais: ', err));
    } else {
        alertPais.removeClass('visually-hidden').text('El campo nombre no puede estar vacio');
    }
    }


//const BuscarPais = () => {
//    $('#PaisID').empty();
//    let url = '../../Paises/ComboProvincia';
//    let data = { id: $('#PaisID').val() };
//    $.post(url, data).done(provincias => {
//        if (provincias.length === 0) {
//            $('#ProvinciaID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`);
//        }
//        else {
//            $.each(provincias, (i, provincia) => {
//                $('#ProvinciaID').append(`<option value=${provincia.value}>${provincia.text}</option>`)
//            });
//        }
//    }).fail(e => console.log('error en combo provincias ' + e))
//    return false
//}


const EliminarPais(paisID, elimina) {
    $.ajax({
        type: "POST",
        url: '../../Pais/EliminarPais',
        data: { PaisID: paisID, Elimina: elimina },
        success: function (resultado) {
            if (resultado == 0) {
                CompletarTablaPaises();
            }
            else {
                alert("Error al eliminar el pais ya que hay provincias.");
            }
        },
        error: function (data) {
        }
    });
}