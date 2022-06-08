using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
	public class DisponibilidadHoraria
	{
		[Key]
		public int idDisponibilidadHoraria { get; set; }
		public string? descripcion { get; set; }
		public ICollection<Vacante>? Vacantes { get; set; }


	}

}
