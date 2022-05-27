using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models

{
	public class Vacante
	{	
		[Key]
		public int idVacante { get; set; }

		public int idEmpresa { get; set; }
		public virtual Empresa Empresa


		public int idPersona { get; set; }
		public virtual Persona Persona


		public string nombre { get; set; }

		public string descripcion {get; set; }

		public string experienciaRequerida { get; set; }

		public int idSubrubro { get; set; }
		public virtual SubRubro SubRubro

		public int idLocalidad { get; set; }
		public virtual Localidad Localidad

		public enum modalidad {Presencial, Semi-Presencial, Remoto }

		public DateTime fechaDeFinalizacion { get; set; }

		public string idiomas { get; set; }

		public string imagen { get; set; }

		public string estado { get; set; }

		public int idDisponibilidadHoraria { get; set; }
		public virtual DisponiblidadHoraria DisponiblidadHoraria

        public virtual ICollection<Vacante> Vacante { get; set; }





	}
}
