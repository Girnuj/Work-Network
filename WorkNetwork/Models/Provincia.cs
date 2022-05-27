using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
    public class Provincia
    {
        [Key]
        public int idProvincia { get; set; }

        public string? nombreProvincia { get; set; }

        public virtual Pais Pais { get; set;}

        public ICollection<Localidad>? Localidades { get; set; }

    }
}
