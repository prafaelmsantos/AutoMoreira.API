namespace AutoMoreira.Persistence.Mapping
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> entity)
        {
            entity.ToTable("contact");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            entity.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired(true);

            entity.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired(true);

            entity.Property(x => x.Phone)
                .HasColumnName("phone")
                .IsRequired(true);

            entity.Property(x => x.Message)
                .HasColumnName("message")
                .IsRequired(true);

            entity.Property(x => x.DateTime)
                .HasColumnName("date_time")
                .IsRequired(true);

        }

    }
}