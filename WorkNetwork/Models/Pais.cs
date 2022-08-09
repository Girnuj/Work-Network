using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
    public class Pais
    {
        [Key]
        public int PaisID { get; set; }

        public string? NombrePais { get; set; }
        public bool Eliminado { get; set; }
        public virtual ICollection<Provincia>? Provincias { get; set; }
    }
}
