using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkNetwork.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        public string? NombrePersona { get; set; }
        public string? ApellidoPersona { get; set; }
        public enum TipoDocumento { dni, LE, }
        public int NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? DomicilioPersona { get; set; }
        public int LocalidadID { get; set; }
        public virtual Localidad? Localidad { get; set; }
        public enum SituacionLaboral {Empleado, Desempleado }
        public enum Genero { Masculino, Femenino, Otro }
        public int Telefono1 { get; set; }
        public int Telefono2 { get; set; }
        public string? EstadoCivil { get; set; }
        public string? TituloAcademico { get; set; }
        //RELACION DE MUCHOS A MUCHOS - TABLA RUBROS PERSONA
        //public int idSubRubro { get; set; }
        //public virtual SubRubro? SubRubro { get; set; }
        public int  CantidadHijos { get; set; }
        public byte[] Imagen { get; set; }
        [NotMapped]
        public string? ImagenString { get; set; }
        //public virtual ICollection<PersonaVacante>? PersonaVacante { get; set; }
    }
}
