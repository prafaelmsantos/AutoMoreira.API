namespace AutoMoreira.Persistence.Mapping
{
    public class ModeloMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> entity)
        {
            entity.ToTable("modelo");

            entity.HasKey(x => x.ModeloId);

            entity.Property(x => x.ModeloId)
                .HasColumnName("modelo_id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(x => x.ModeloNome)
                .HasColumnName("nome")
                .IsRequired();

            entity.HasMany(x => x.Veiculos)
                .WithOne(x => x.Modelo)
                .HasForeignKey(x => x.VeiculoId)
                .OnDelete(DeleteBehavior.NoAction);


        }

    }
}
