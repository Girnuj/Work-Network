using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
    public class Pais
    {
        [Key]
        public int idPais { get; set; }

        public string? nombrePais { get; set; }

        public virtual ICollection<Provincia>? Provincias { get; set; }
        public object Pais { get; internal set; }
    }
}
