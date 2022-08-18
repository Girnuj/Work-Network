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
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<PersonaVacante> PersonaVacante { get; set; }
        public DbSet<Rubro> Rubro { get; set; }
        public DbSet<Vacante> Vacante { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if (modelBuilder == null)
            //    throw new ArgumentNullException("modelBuilder");

            //// for the other conventions, we do a metadata model loop
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //    entityType.SetTableName(entityType.DisplayName());

            //    // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //    entityType.GetForeignKeys()
            //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
            //        .ToList()
            //        .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            //}
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

    }
}