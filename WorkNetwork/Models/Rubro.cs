namespace WorkNetwork.Models
{
    public class Rubro
    {
        [Key]
        public int RubroID { get; set; }
        public string? NombreRubro { get; set; }
        public bool Eliminado { get; set; }
        public ICollection<Empresa>? Empresas { get; set; }
    }
}
