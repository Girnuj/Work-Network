using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models

{
	public class Vacante
	{	
		[Key]
		public int idVacante { get; set; }

		public int idEmpresa { get; set; }
		public virtual Empresa? Empresa { get; set; }


		public int idPersona { get; set; }
		public virtual Persona? Persona { get; set; }


		public string? nombre { get; set; }

		public string? descripcion {get; set; }

		public string? experienciaRequerida { get; set; }

		public int idSubrubro { get; set; }
		public virtual SubRubro? SubRubro { get; set; }

		public int idLocalidad { get; set; }
		public virtual Localidad? Localidad { get; set; }

		public enum modalidad {Presencial, SemiPresencial, Remoto }

		public DateTime fechaDeFinalizacion { get; set; }

		public string? idiomas { get; set; }

		public string? imagen { get; set; }

		public string? estado { get; set; }

		public int idDisponibilidadHoraria { get; set; }
		public virtual DisponibilidadHoraria? DisponibilidadHoraria { get; set; }

		public virtual ICollection<PersonaVacante>? PersonaVacante { get; set; }





	}
}
