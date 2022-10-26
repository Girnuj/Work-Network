﻿const CompletarTablaEmpresas = () => {
    VaciarFormulario();

    let url = '../../Empresas/TablaEmpresas'

    $.get(url).done(empresas => {
        $('#tbody-empresa').empty();
        $.each(empresas, function (index, empresas) {
            let claseEliminado = '';
            let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarEmpresa(${empresas.idEmpresa})"><i class="bi bi-pencil-square"></i> Editar</btn>
                                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarEmpresa(${empresas.idEmpresa},1)"><i class="bi bi-trash3"></i> Eliminar</btn>`

            if (empresas.eliminado) {
                claseEliminado = 'table-danger';
                botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarEmpresa(${empresas.idEmpresa},0)"><i class="bi bi-recycle"></i> Activar</btn>`
            }
            $("#tbody-empresa").append(
                `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${empresas.razonSocial}</td>
                        <td class='texto'>${empresas.cuit}</td>
                        <td class='texto'>${empresas.localidadID}</td>
                        <td class='texto'>${empresas.telefono1}</td>
                        <td class='texto'>${empresas.rubroID}</td>
                        <td class='texto'>${empresas.tipoEmpresa}</td>

                        <td class = 'text-center'>
                            ${botones}
                        </td>
                    </tr>`
            )
        })
    }).fail(e => console.error('Error al cargar tabla localidades ' + e));
}

const guardarEmpresa = () => {
    event.preventDefault();
    const url = '../../Empresas/GuardarEmpresa'
    const formulario = $('#registrarEmpresa')[0];
    const params = new FormData(formulario)
    $.ajax({
        type:'POST',
        url: url,
        data: params,
        contentType: false,
        processData: false,
        async: false,
        success: e => window.location.href = '/',
        error: e=>console.log('error'+e)
    })
}

const BuscarProvincia = () => {
    $('#ProvinciaID').empty();
    let paisId = $('#PaisID').val();
    let url = '../../Provincias/ComboProvincia';
    let data = { id: paisId};
    $.post(url, data).done(provincias => {
        provincias.length === 0
            ? $('#ProvinciaID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`)
            : $.each(provincias, (i, provincia) => {
                $('#ProvinciaID').append(`<option value=${provincia.value}>${provincia.text}</option>`)
            });
            BuscarLocalidad()
    }).fail(e => console.log('error en combo provincias ' + e));
    return false
}

$('#PaisID').change(()=>BuscarProvincia());

const BuscarLocalidad = () => {
    $('#LocalidadID').empty();
    let url = '../../Localidades/ComboLocalidades';
    let data = { id: $('#ProvinciaID').val() };
    $.post(url, data).done(localidades => {
        localidades.length === 0
            ? $('#LocalidadID').append(`<option value=${0}>[NO EXISTEN LOCALIDADES]</option>`)
            : $.each(localidades, (i, localidad) => {
                $('#LocalidadID').append(`<option value=${localidad.value}>${localidad.text}</option>`)
            });
    }).fail(e => console.log('error en combo localidades' + e))
    return false
}

$('#ProvinciaID').change(() => BuscarLocalidad());
const BuscarEmpresa = (empresaID)=> {
    $("#Titulo-Modal-").text("Editar Empresa");
    $("#EmpresaID").val(empresaID);
    let url = '../../Empresas/BuscarEmpresa';
    let data = { EmpresaID: empresaID };
    $.post(url, data)
        .done(empresa => {
            $("#Nombre").val(rubro.descripcion);
            $("#exampleModal").modal("show");
        })
    .fail(e => console.log(e));
}

const AbrirModal = () => {
    $('#modalCrearEmpresa').modal('show');
    $('#ProvinciaID').val(0);
    $('#LocalidadID').val(0);
}

const VaciarFormulario = () => {
    $('#idEmpresa').val(0);
    $('#nombreEmpresa').val('')
}
