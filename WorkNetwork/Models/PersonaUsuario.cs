using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
    public class PersonaUsuario
    {
        [Key]
        public int PersonaUsuarioID { get; set; }   
        public string UsuarioID { get; set; }   
        public int PersonaID { get; set; }
    }
}