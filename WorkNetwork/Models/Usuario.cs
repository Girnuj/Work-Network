using System.ComponentModel.DataAnnotations;    

namespace WorkNetwork.Models
{
	public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        public int idPersona { get; set; }

        public virtual Persona? Persona { get; set; }

        public int idEmpresa { get; set; }

        public virtual Empresa? Empresa { get; set; }

        public int password { get; set; }
        
        public DateTime ultActualizacion { get; set; }

        public enum Estado {Activo, Eliminado }
    }
}