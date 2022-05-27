using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
    public class Rubro
    {
        [Key]
        public int idRubro { get; set; }

        public string? nombreRubro { get; set; }

        public bool eliminado { get; set; }


        public ICollection<SubRubro>? SubRubros { get; set; }
        public ICollection<Empresa>? Empresas { get; set; }
    }
}
