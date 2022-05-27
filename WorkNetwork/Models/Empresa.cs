using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models

{
    public class Empresa
    {
        [Key]
        public int idEmpresa { get; set; }

        public string? razonSocial { get; set; }

        public int CUIT { get; set; }

        public enum tipoDeDocumento { DNI, Pasaporte }

        public int numeroDeDocumento { get; set; }

        public string? email { get; set; }

        public int idLocalidad { get; set; }

        public virtual Localidad? Localidad { get; set; }

        public int telefono1 { get; set; }

        public int telefono2 { get; set; }

        public int idRubro { get; set; }

        public virtual Rubro? Rubro { get; set; }

        public enum tipoEmpresa { Unipersonal, Sociedad }

        public virtual ICollection<Usuario>? Usuarios { get; set; }
        public virtual ICollection<Vacante>? Vacantes { get; set; }



    }
}