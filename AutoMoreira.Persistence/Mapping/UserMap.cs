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

            entity.Property(x => x.ImageUrl)
                .HasColumnName("image_url")
                .IsRequired(false);

            entity.Property(x => x.DarkMode)
                .HasColumnName("dark_mode")
                .HasDefaultValue(false)
                .IsRequired(true);

            entity.HasMany(x => x.Roles)
               .WithMany(x => x.Users)
               .UsingEntity<UserRole>(
                   x => x.HasOne(x => x.Role)
                   .WithMany().HasForeignKey(x => x.RoleId),
                   x => x.HasOne(x => x.User)
                  .WithMany().HasForeignKey(x => x.UserId));

        }

    }
}
