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
                `<tr class= 'tabla-hover '>
                        <td class='texto'>${empresas.razonSocial}</td>
                        <td class='texto'>${empresas.cuit}</td>
                        <td class='texto'>${empresas.email}</td>
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

const GuardarEmpresa = () => {
    let idEmpresa = $('#idEmpresa').val();
    let nombreEmpresa = $('#nombreEmpresa').val();
    let cuitEmpresa = $('#cuitEmpresa').val();
    let correoEmpresa = $('#correoEmpresa').val();
    //let paisID = $('#PaisID').val();
    //let provinciaID = $('#ProvinciaID').val();
    let localidadID = $('#LocalidadID').val();
    let telefono1Empresa = $('#telefono1Empresa').val();
    let telefono2Empresa = $('#telefono2Empresa').val();
    let rubroID = $('#RubroID').val();
    let tipoEmpresa = $('#tipoEmpresa').val();
    const url = '../../Empresas/GuardarEmpresa'
    const data = {
        idEmpresa: idEmpresa, RazonSocial: nombreEmpresa, CUIT: cuitEmpresa, Email: correoEmpresa, LocalidadID: localidadID, Telefono1: telefono1Empresa, Telefono2: telefono2Empresa, RubroID: rubroID, TipoEmpresaID: tipoEmpresa
    }
    $.post(url, data).done(resultado => {
        $('#modalCrearEmpresa').modal('hide');
        CompletarTablaEmpresas()
    }).fail(e => console.log('error en guardar empresa' + e))
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

$('#ProvinciaID').change(()=>BuscarLocalidad());

const BuscarEmpresa = (EmpresaID)=> {
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
