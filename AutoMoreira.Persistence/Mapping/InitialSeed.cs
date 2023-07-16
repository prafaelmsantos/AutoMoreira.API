namespace AutoMoreira.Persistence.Mapping
{
    public static class InitialSeed
    {
        public static void AddInitialSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>().HasData(
                new Marca(1, "Audi"),
                new Marca(2, "Mercedes"),
                new Marca(3, "BMW"),
                new Marca(4, "Peugeot"),
                new Marca(5, "Volkswagen"),
                new Marca(6, "Citroën"),
                new Marca(7, "Renault"),
                new Marca(8, "Volvo"),
                new Marca(9, "Fiat")
                );

          
            modelBuilder.Entity<Modelo>().HasData(
              new Modelo(1, "A3", 1),
              new Modelo(2, "Classe A", 2),
              new Modelo(3, "Serie 1", 3),
              new Modelo(4, "208", 4), 
              new Modelo(5, "Golf", 5),
              new Modelo(6, "C4", 6),
              new Modelo(7, "Megane", 7),
              new Modelo(8, "V40", 8),
              new Modelo(9, "Punto", 9)
              );

            Veiculo veiculo = new Veiculo(1,1, 1, "Sport", COMBUSTIVEL.Diesel, 20000,2020, "Azul", 5, "Automatica", 1999, 140, "Garantia de 2 anos","exemplo.jpg", false);

            modelBuilder.Entity<Veiculo>().HasData(veiculo);
        }
    }
}
