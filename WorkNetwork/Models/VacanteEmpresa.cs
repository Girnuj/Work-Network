namespace WorkNetwork.Models
{
    public class VacanteEmpresa
    {
        [Key]
        public int VacanteEmpresaId { get; set; }
        public int VacanteID { get; set; }
        public int EmpresaID { get; set; }
    }
}
