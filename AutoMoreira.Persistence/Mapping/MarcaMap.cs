namespace AutoMoreira.Persistence.Mapping
{
    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> entity)
        {
            entity.ToTable("marca");

            entity.HasKey(x => x.MarcaId);

            entity.Property(x => x.MarcaId)
                .HasColumnName("marca_id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(x => x.MarcaNome)
                .HasColumnName("nome")
                .IsRequired();

            entity.HasMany(x => x.Modelos)
               .WithOne(x => x.Marca)
               .HasForeignKey(x => x.ModeloId)
               .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.Veiculos)
                .WithOne(x => x.Marca)
                .HasForeignKey(x => x.VeiculoId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
