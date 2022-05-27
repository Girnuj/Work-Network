using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
    public class Localidad
    {
        [Key]
        public int idLocalidad { get; set; }

        public string? nombreLocalidad { get; set; }

        public int CP { get; set; }

        public virtual Provincia? Provincia { get; set; }

        public virtual ICollection<Persona>? Personas { get; set; }
        public virtual ICollection<Empresa>? Empresas { get; set; }
        public virtual ICollection<Vacante>? Vacantes { get; set; }


    }
}
