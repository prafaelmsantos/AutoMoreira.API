namespace AutoMoreira.Persistence.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("user");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(x => x.PrimeiroNome)
                .HasColumnName("primeiro_nome")
                .IsRequired();

            entity.Property(x => x.UltimoNome)
                .HasColumnName("ultimo_nome")
                .IsRequired();

            entity.Property(x => x.Funcao)
                .HasColumnName("funcao")
                .IsRequired();

            entity.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .IsRequired();

            entity.Property(x => x.ImagemUrl)
                .HasColumnName("imagem_url")
                .IsRequired();


        }

    }
}
