namespace AutoMoreira.Persistence.Mapping
{
    public class VehicleImageMap : IEntityTypeConfiguration<VehicleImage>
    {
        public void Configure(EntityTypeBuilder<VehicleImage> entity)
        {
            entity.ToTable("vehicle_images");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            entity.Property(x => x.Url)
                .HasColumnName("url")
                .IsRequired(true);

            entity.Property(x => x.VehicleId)
                .HasColumnName("vehicleId")
                .IsRequired(true);

            entity.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired(true);

            entity.Property(x => x.LastModifiedDate)
                .HasColumnName("last_modified_date")
                .IsRequired(true);

        }

    }
}
