﻿namespace AutoMoreira.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, int, 
                                                   IdentityUserClaim<int>, 
                                                   UserRole, 
                                                   IdentityUserLogin<int>, 
                                                   IdentityRoleClaim<int>, 
                                                   IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Necessario para o User se não, não funciona
            
            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new VehicleImageMap());
            modelBuilder.ApplyConfiguration(new MarkMap());
            modelBuilder.ApplyConfiguration(new ModelMap());
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.AddInitialSeed();

        }
    }
}
