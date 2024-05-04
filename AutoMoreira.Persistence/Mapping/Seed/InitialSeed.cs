namespace AutoMoreira.Persistence.Mapping.Seed
{
    public static class InitialSeed
    {
        public static void AddInitialSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mark>().HasData(
                new Mark(1, "Audi"),
                new Mark(2, "Mercedes"),
                new Mark(3, "BMW"),
                new Mark(4, "Peugeot"),
                new Mark(5, "Volkswagen"),
                new Mark(6, "Citroën"),
                new Mark(7, "Renault"),
                new Mark(8, "Volvo"),
                new Mark(9, "Fiat")
                );

            modelBuilder.Entity<Model>().HasData(
              new Model(1, "A3", 1),
              new Model(2, "Classe A", 2),
              new Model(3, "Serie 1", 3),
              new Model(4, "308", 4),
              new Model(5, "Golf", 5),
              new Model(6, "C4", 6),
              new Model(7, "Megane", 7),
              new Model(8, "V40", 8),
              new Model(9, "Punto", 9)
              );

            modelBuilder.Entity<Vehicle>().HasData(
              new Vehicle(1, 1, "Sportline", FUEL.Diesel, 40000, 2000, 2022, "Azul", 5, TRANSMISSION.Manual, 1999, 140, "Garantia de 2 anos", true),
              new Vehicle(2, 2, "AMG", FUEL.Hybrid, 27000, 7000, 2021, "Cinza", 5, TRANSMISSION.Automatic, 1999, 140, "Garantia de 2 anos", true),
              new Vehicle(3, 3, "Sport", FUEL.Petrol, 29000, 0, 2023, "Vermelho", 5, TRANSMISSION.Automatic, 1999, 140, "Garantia de 2 anos", true),
              new Vehicle(4, 4, "GTI", FUEL.Petrol, 18000, 10000, 2022, "Verde", 5, TRANSMISSION.Manual, 1999, 140, "Garantia de 2 anos", false)
              );

            Role role = new(1, "Administrador", true, true);

            modelBuilder.Entity<Role>().HasData(role, new(2, "Colaborador", true), new(3, "Comercial"));

            var hasher = new PasswordHasher<User>();

            User user = new(1, "automoreiraportugal@gmail.com", "231472555", "Auto", "Moreira", true);
            user.SetPasswordHash(hasher.HashPassword(user, "123456"));

            modelBuilder.Entity<User>().HasData(user);

            modelBuilder.Entity<UserRole>().HasData(new UserRole(user.Id, role.Id));

        }
    }
}
