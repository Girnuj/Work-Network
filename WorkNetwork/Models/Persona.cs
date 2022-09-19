namespace WorkNetwork.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string? DomicilioPersona { get; set; }
        public int LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }
        public SituacionLaboral SituacionLaboral { get; set; }
        public Genero Genero { get; set; }
        public int Telefono1 { get; set; }
        public int? Telefono2 { get; set; }
        public string? EstadoCivil { get; set; }
        public string? TituloAcademico { get; set; }
        public int? CantidadHijos { get; set; }
        public byte[]? Imagen { get; set; }
        [NotMapped]
        public string? ImagenString { get; set; }
        public bool Eliminado { get; set; }

        //public virtual ICollection<PersonaVacante>? PersonaVacante { get; set; }

        //RELACION UNA PERSONA A MUCHOS RUBROS
    }
    public enum SituacionLaboral
    {
        Empleado, Desempleado,
    }

    public enum Genero
    {
        Masculino, Femenino, Otro
    }

    public enum TipoDocumento
    {
        dni, LE
    }

}
