namespace AutoMoreira.Infrastructure.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, int,
                                                   IdentityUserClaim<int>,
                                                   UserRole,
                                                   IdentityUserLogin<int>,
                                                   IdentityRoleClaim<int>,
                                                   IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleImage> VehicleImages { get; set; } = null!;
        public DbSet<Mark> Marks { get; set; } = null!;
        public DbSet<Model> Models { get; set; } = null!;
        public DbSet<ClientMessage> ClientMessages { get; set; } = null!;
        public DbSet<Visitor> Visitors { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Necessario para o IdentityDbContext

            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new VehicleImageMap());
            modelBuilder.ApplyConfiguration(new MarkMap());
            modelBuilder.ApplyConfiguration(new ModelMap());
            modelBuilder.ApplyConfiguration(new ClientMessageMap());
            modelBuilder.ApplyConfiguration(new VisitorMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());

            modelBuilder.ApplyConfiguration(new IdentityRoleClaimMap());
            modelBuilder.ApplyConfiguration(new IdentityUserClaimMap());
            modelBuilder.ApplyConfiguration(new IdentityUserLoginMap());
            modelBuilder.ApplyConfiguration(new IdentityUserTokenMap());

            modelBuilder.AddInitialSeed();
        }
    }
}
