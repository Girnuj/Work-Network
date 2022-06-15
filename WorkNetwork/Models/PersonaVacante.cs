using System.ComponentModel.DataAnnotations; 
namespace WorkNetwork.Models
{
	public class PersonaVacante
	{
		[Key]
		public int PersonaVacanteID { get; set; }
		public int PersonaID { get; set; }
		public virtual Persona? Persona { get; set; }
		public int VacanteID { get; set; }
		public virtual Vacante? Vacante { get; set; }
	}

}
