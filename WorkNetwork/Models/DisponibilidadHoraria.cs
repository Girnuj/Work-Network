using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
	public class DisponibilidadHoraria
	{
		[Key]
		public int DisponibilidadHorariaID { get; set; }
		public string? Descripcion { get; set; }
		public ICollection<Vacante>? Vacantes { get; set; }


	}

}
