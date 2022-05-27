using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkNetwork.Models;

namespace WorkNetwork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Provincia> Provincia{ get; set; }
        public DbSet<Localidad> Localidad{ get; set; }
        public DbSet<Empresa> Empresa{ get; set; }
        public DbSet<Persona> Persona{ get; set; }
        public DbSet<PersonaVacante> PersonaVacante{ get; set; }
        public DbSet<Rubro> Rubro{ get; set; }
        public DbSet<SubRubro> SubRubro{ get; set; }
        public DbSet<Usuario> Usuario{ get; set; }
        public DbSet<Vacante> Vacante{ get; set; }
        public DbSet<DisponibilidadHoraria> DisponibilidadHoraria{ get; set; }

            
    }
}