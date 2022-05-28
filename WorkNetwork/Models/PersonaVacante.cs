using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
	public class PersonaVacante
	{
		[Key]
		public int idPersonaVacante { get; set; }

		public int idPersona { get; set; }
		public virtual Persona? Persona { get; set; }

		public int idVacante { get; set; }
		public virtual Vacante? Vacante { get; set; }
	}

}
