using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
    public class Persona
    {
        [Key]
        public int idPersona { get; set; }
        public string? nombrePersona { get; set; }
        public string? apellidoPersona { get; set; }
        public enum tipoDocumento { dni, LE, }
        public int numeroDocumento { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string? correoElectronico { get; set; }
        public string? domicilioPersona { get; set; }
        public int idLocalidad { get; set; }
        public virtual Localidad? Localidad { get; set; }
        public enum situacionLaboral {Empleado, Desempleado }
        public string? Genero { get; set; }
        public int telefono1 { get; set; }
        public int telefono2 { get; set; }
        public string? estadoCivil { get; set; }
        public string? tituloAcademico { get; set; }
        public int idSubRubro { get; set; }
        public virtual SubRubro? SubRubro { get; set; }
        public int  cantidadHijos { get; set; }
        public string? imagen { get; set; }
        public virtual ICollection<Usuario>? Usuarios { get; set; }
        public virtual ICollection<Vacante>? Vacantes { get; set; }
        public virtual ICollection<PersonaVacante>? PersonaVacante { get; set; }


    }
}
