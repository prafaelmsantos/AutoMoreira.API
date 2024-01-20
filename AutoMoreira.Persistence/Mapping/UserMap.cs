namespace AutoMoreira.Persistence.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("users");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            entity.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired(true);

            entity.Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired(true);

            entity.Property(x => x.Description)
                .HasColumnName("description")
                .IsRequired(false);

            entity.Property(x => x.ImageUrl)
                .HasColumnName("image_url")
                .IsRequired(false);

            entity.Property(x => x.DarkMode)
                .HasColumnName("dark_mode")
                .HasDefaultValue(false)
                .IsRequired(true);


        }

    }
}
