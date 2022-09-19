namespace WorkNetwork.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<IdentityRole> roles = new List<IdentityRole>() {
              new IdentityRole { Name = "SuperUsuario", NormalizedName = "SUPERUSUARIO"},
              new IdentityRole { Name = "Empresa", NormalizedName = "EMPRESA"},
              new IdentityRole { Name = "Usuario", NormalizedName = "USUARIO"},
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            List<ApplicationUser> users = new List<ApplicationUser>(){
                new ApplicationUser {
                UserName = "wkntk@gmail.com",
                NormalizedUserName = "WKNTK@GMAIL.COM",
                Email = "wkntk@gmail.com",
                NormalizedEmail = "WKNTK@GMAIL.COM",
                }
            };
            modelBuilder.Entity<ApplicationUser>().HasData(users);

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "EmpleoWN.22");

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "SuperUsuario").Id
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
