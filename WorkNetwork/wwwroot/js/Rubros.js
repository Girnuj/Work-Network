const CompletarTablaRubro = async () => {
    await VaciarFormulario()
    let url = '../../Rubros/TablaRubros'


    $.get(url).done(async rubros => {
        $('#tbody-rubros').empty();
        $.each(rubros, await function (i, rubro) {

            let claseEliminado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarRubro(${rubro.rubroID})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarRubro(${rubro.rubroID},1)"><i class="bi bi-trash3"></i> Eliminar</btn>`

            if (rubro.eliminado) {
                claseEliminado = 'table-danger';
                botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarRubro(${rubro.rubroID},0)"><i class="bi bi-recycle"></i> Activar</btn>`
            }
            $('#tbody-rubros').append(
                `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${rubro.nombreRubro}</td>
                        <td class = 'text-center'>
                            ${botones}
                        </td>
                    </tr>`
            )
        })
    })
}

const GuardarRubro = () => {
    let idRubro = $('#idRubro').val();
    let nombreRubro = $('#nombreRubro').val().trim();
    let alertRubro = $('#alertRubro')
    let url = '../../Rubros/GuardarRubro'
    let data = { idRubro: idRubro, NombreRubro: nombreRubro }
    if (nombreRubro != '' && nombreRubro != null) {
        $.post(url, data).done(resultado => {
            if (resultado == 0) {
                $('#modalCrearRubro').modal('hide')
                CompletarTablaRubro();
            }
            if (resultado == 2) {
                alertRubro.removeClass('visually-hidden').text('El rubro ingresado ya existe')
            }
        }).fail(e => console.log('error en guardar rubro' + e))
    } else {
        alertRubro.removeClass('visually-hidden')
    }

}

const AbrirModal = () => {
    $('#titulo-modal-rubro').text('Nuevo Rubro')
    $('#idRubro').val(0);
    $('#modalCrearRubro').modal('show');
    $('#alertRubro').addClass('visually-hidden')
}
const VaciarFormulario = () => {
    $("#idRubro").val(0);
    $('#nombreRubro').val('');
    $('#alertRubro').addClass('visually-hidden')
}


const BuscarRubro(rubroID) {
    $("#titulo-modal-rubro").text("Editar Rubro");
    $("#RubroID").val(rubroID);
    $.ajax({
        type: "POST",
        url: '../../Rubros/BuscarRubro',
        data: { RubroID: rubroID },
        success: function (rubro) {
            $("#RubroNombre").val(rubro.descripcion);
            $("#exampleModal").modal("show");
        },
        error: function (data) {
        }
    });
}


const EliminarRubro(rubroID, elimina) {
    $.ajax({
        type: "POST",
        url: '../../Rubros/EliminarRubro',
        data: { RubroID: rubroID, Elimina: elimina },
        success: function (resultado) {
            if (resultado == 0) {
                CompletarTablaRubros();
            }
            else {
                alert("No se puede eliminar el rubro.");
            }
        },
        error: function (data) {
        }
    });
}
