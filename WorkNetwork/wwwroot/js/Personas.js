function CompletarTablaPersonas() {
    //VaciarFormulario()
    $.ajax({
        type: "POST",
        url: '../../Personas/TablaPersonas',
        data: {},
        success: function (personas) {
            $('#tbody-personas').empty();
            $.each(personas, function (index, persona) {
                console.log(persona)
                let claseEliminado = '';
                //let botones = `<btn type='button' class= 'btn btn-outline-success btn-sm me-3' onclick = "BuscarRubro(${persona.idPersona})"><i class="bi bi-pencil-square"></i> Editar</btn>
                //                <btn type='button' class = 'btn btn-outline-danger btn-sm'onclick = "EliminarRubro(${rubro.rubroID},1)"><i class="bi bi-trash3"></i> Eliminar</btn>`

                //if (rubro.eliminado) {
                //    claseEliminado = 'table-danger';
                //    botones = `<btn type='button' class = 'btn btn-outline-warning btn-sm'onclick = "EliminarRubro(${rubro.rubroID},0)"><i class="bi bi-recycle"></i> Activar</btn>`
                //}
                $("#tbody-personas").append(
                    `<tr class= 'tabla-hover ${claseEliminado}'>
                        <td class='texto'>${persona.nombrePersona}</td>
                        <td class='texto'>${persona.apellidoPersona}</td>
                        <td class = 'text-center'>
                           
                        </td>
                    </tr>`



                )
                $('#cards').append(
                    `<div class="card">
						<div class="content">
							<div class="img">
								<!--- <img src="images/img1.jpg" alt="">-->
							</div>
							<div class="details">
								<div class="name">${persona.nombrePersona}</div>
								<div class="job">${persona.apellidoPersona}</div>
							</div>
							<div class="media-icons">
								<a href="#"><i class="fab fa-facebook-f"></i></a>
								<a href="#"><i class="fab fa-twitter"></i></a>
								<a href="#"><i class="fab fa-instagram"></i></a>
								<a href="#"><i class="fab fa-youtube"></i></a>
							</div>
						</div>
					</div>`
                )
            });
        },
        error: function (data) { }
    });
}

const GuardarPersona = () => {
    let idPersona = $('#idPersona').val();
    let nombrePersona = $('#nombrePersona').val();
    let apellidoPersona = $('#apellidoPersona').val();
    $.ajax({
        type: "POST",
        url: '../../Personas/CrearPersona',
        data: { IdPersona: idPersona, NombrePersona: nombrePersona, ApellidoPersona: apellidoPersona },
        success: (resultado)=>{
            if (resultado == false) {
                $('#modalCrearPersona').modal('hide')
                CompletarTablaPersonas()
            }
        },
        error: (data) => {}
    })

}
const AbrirModal = () => {
    $('#idPersona').val(0);
    $('#modalCrearPersona').modal('show');

}