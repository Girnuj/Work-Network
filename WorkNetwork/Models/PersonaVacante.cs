namespace WorkNetwork.Models
{
    public class PersonaVacante
    {
        [Key]
        public int PersonaVacanteID { get; set; }
        public int PersonaID { get; set; }
        public int VacanteID { get; set; }
        public bool NotificacionVista { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string DescripcionDePersona { get; set; }
    }

}
