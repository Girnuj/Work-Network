namespace WorkNetwork.Models

{
    public class Empresa
    {
        [Key]
        public int EmpresaID { get; set; }
        public string? RazonSocial { get; set; }
        public int CUIT { get; set; }
        public enum TipoDeDocumento { DNI, Pasaporte }
        public int? NumeroDeDocumento { get; set; }
        public string? Email { get; set; }
        public int LocalidadID { get; set; }
        public virtual Localidad? Localidad { get; set; }
        public int Telefono1 { get; set; }
        public int? Telefono2 { get; set; }
        public byte[]? Imagen { get; set; }
        public string? TipoImagen { get; set; }
        public string? ImagenRecortada {get; set;}
        public int RubroID { get; set; }
        public bool Eliminado { get; set; }

        public virtual Rubro? Rubro { get; set; }
        public TipoEmpresa TipoEmpresa { get; set; }
        public virtual ICollection<Vacante>? Vacantes { get; set; }
    }
    public enum TipoEmpresa
    {
        Unipersonal, Sociedad
    }
}