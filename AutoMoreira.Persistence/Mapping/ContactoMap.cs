namespace AutoMoreira.Persistence.Mapping
{
    public class ContactoMap : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> entity)
        {
            entity.ToTable("contacto");

            entity.HasKey(x => x.ContactoId);

            entity.Property(x => x.ContactoId)
                .HasColumnName("contacto_id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            entity.Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired();

            entity.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();

            entity.Property(x => x.Telefone)
                .HasColumnName("telefone")
                .IsRequired();

            entity.Property(x => x.Mensagem)
                .HasColumnName("mensagem")
                .IsRequired();

            entity.Property(x => x.DataHora)
                .HasColumnName("data_hora")
                .IsRequired();

        }

    }
}