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
              new(1, 1, "Sportline", FUEL.Diesel, 20000, 20000, 2020, "Azul", 5, TRANSMISSION.Manual, 1999, 140, "Garantia de 2 anos", true, false),
              new(2, 2, "AMG", FUEL.Hybrid, 20000, 20000, 2020, "Cinza", 5, TRANSMISSION.Automatic, 1999, 140, "Garantia de 2 anos", true, false),
              new(3, 3, "Sport", FUEL.Petrol, 20000, 20000, 2020, "Vermelho", 5, TRANSMISSION.Automatic, 1999, 140, "Garantia de 2 anos", true, false),
              new(4, 4, "GTI", FUEL.Petrol, 10000, 20000, 2020, "Verde", 5, TRANSMISSION.Manual, 1999, 140, "Garantia de 2 anos", false, false)
              );

            modelBuilder.Entity<Role>().HasData(new(1,"Administrador"), new(2, "Colaborador"));
        }
    }
}
