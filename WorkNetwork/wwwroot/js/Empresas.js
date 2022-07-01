const CompletarTablaEmpresas = () => {
    VaciarFormulario();

    let url = '../../Empresas/TablaEmpresas'

    $.get(url).done(empresas=> {
        $('#tbody-empresa').empty();
        $.each(empresas,function (index, empresas) {
            $("#tbody-empresa").append(
                `<tr class= 'tabla-hover '>
                        <td class='texto'>${empresas.razonSocial}</td>
                        <td class='texto'>${empresas.cuit}</td>
                        <td class = 'text-center'>botonsitos 
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
    console.log('el cuit perro: ' + cuitEmpresa)
    let correoEmpresa = $('#correoEmpresa').val();
    let paisID = $('#PaisID').val();
    let provinciaID = $('#ProvinciaID').val();
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

$('#PaisID').change(() => BuscarProvincia());

const BuscarProvincia = () => {
    $('#ProvinciaID').empty();
    let url = '../../Provincias/ComboProvincia';
    let data = { id: $('#PaisID').val() };
    $.post(url, data).done(provincias => {
        if (provincias.length === 0) {
            $('#ProvinciaID').append(`<option value=${0}>[NO EXISTEN PROVINCIAS]</option>`);
        }
        else {
            $.each(provincias, (i, provincia) => {
                $('#ProvinciaID').append(`<option value=${provincia.value}>${provincia.text}</option>`)
            });
        }
    }).fail(e => console.log('error en combo provincias ' + e));
    return false
}

$('#ProvinciaID').change(() => BuscarLocalidad());
const BuscarLocalidad = () => {
    $('#LocalidadID').empty();
    let url = '../../Localidades/ComboLocalidades';
    let data = { id: $('#ProvinciaID').val() };
    $.post(url, data).done(localidades => {
        if (localidades.length === 0) {
            $('#LocalidadID').append(`<option value=${0}>[NO EXISTEN LOCALIDADES]</option>`);
        }
        else {
            $.each(localidades, (i, localidad) => {
                $('#LocalidadID').append(`<option value=${localidad.value}>${localidad.text}</option>`)
            });
        }
    }).fail(e => console.log('error en combo localidades' + e))
    return false
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
