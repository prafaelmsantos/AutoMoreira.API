namespace AutoMoreira.Persistence.Mapping
{
    public class MarkMap : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> entity)
        {
            entity.ToTable("marks");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            entity.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired(true);

            entity.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired(false);

            entity.Property(x => x.LastModifiedDate)
                .HasColumnName("last_modified_date")
                .IsRequired(false);

            entity.HasMany(x => x.Models)
                .WithOne(x => x.Mark)
                .HasForeignKey(x => x.MarkId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
