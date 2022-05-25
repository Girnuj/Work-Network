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
            
    }
}