using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
	public class PersonaVacante
	{
		public int idPersonaVacante { get; set; }

		public int idPersona { get; set; }
		public virtual Persona Persona

		public int idVacante { get; set; }
		public virtual Vacante Vacante
	}

}
