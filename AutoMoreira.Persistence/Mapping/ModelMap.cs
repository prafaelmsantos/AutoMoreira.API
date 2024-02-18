namespace AutoMoreira.Persistence.Mapping
{
    public class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> entity)
        {
            entity.ToTable("models");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            entity.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired(true);

            entity.Property(x => x.MarkId)
                .HasColumnName("mark_id")
                .IsRequired(true);

            entity.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired(false);

            entity.Property(x => x.LastModifiedDate)
                .HasColumnName("last_modified_date")
                .IsRequired(false);

            entity.HasMany(x => x.Vehicles)
                .WithOne(x => x.Model)
                .HasForeignKey(x => x.ModelId)
                .OnDelete(DeleteBehavior.Cascade);


        }

    }
}
