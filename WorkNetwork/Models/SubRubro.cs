﻿namespace WorkNetwork.Models
{
    public class SubRubro
    {
        public int idSubRubro { get; set; }
        public string nombreSubRubro { get; set; }
        public int idRubro { get; set; }
        public virtual Rubro Rubro { get; set; }
        public bool eliminado { get; set; }
    }
}