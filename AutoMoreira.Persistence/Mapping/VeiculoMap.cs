namespace AutoMoreira.Persistence.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> entity)
        {
            entity.ToTable("veiculo");

            entity.HasKey(x => x.VeiculoId);

            entity.Property(x => x.VeiculoId)
                .HasColumnName("veiculo_id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(x => x.MarcaId)
                .HasColumnName("marca_id")
                .IsRequired();

            entity.Property(x => x.ModeloId)
                .HasColumnName("modelo_id")
                .IsRequired();

            entity.Property(x => x.Versao)
                .HasColumnName("versao")
                .IsRequired();

            entity.Property(x => x.Combustivel)
                .HasColumnName("combustivel")
                .IsRequired();

            entity.Property(x => x.Preco)
                .HasColumnName("preco")
                .IsRequired();

            entity.Property(x => x.Ano)
                .HasColumnName("ano")
                .IsRequired();

            entity.Property(x => x.Cor)
                .HasColumnName("cor")
                .IsRequired();

            entity.Property(x => x.NumeroPortas)
                .HasColumnName("numero_portas")
                .IsRequired();

            entity.Property(x => x.Transmissao)
                .HasColumnName("transmissao")
                .IsRequired();

            entity.Property(x => x.Cilindrada)
                .HasColumnName("cilindrada")
                .IsRequired();

            entity.Property(x => x.Potencia)
                .HasColumnName("potencia")
                .IsRequired();

            entity.Property(x => x.Observacoes)
                .HasColumnName("observacoes")
                .IsRequired();

            entity.Property(x => x.ImagemURL)
                .HasColumnName("imagem_url")
                .IsRequired();

            entity.Property(x => x.Novidade)
                .HasColumnName("novidade")
                .IsRequired();

        }

    }
}
