﻿using System.ComponentModel.DataAnnotations;

namespace WorkNetwork.Models
{
    public class Provincia
    {
        [Key]
        public int ProvinciaID { get; set; }
        public string? NombreProvincia { get; set; }
        public int PaisID { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual ICollection<Localidad>? Localidades { get; set; }

    }
}
