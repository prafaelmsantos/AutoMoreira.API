namespace AutoMoreira.Infrastructure.Mapping
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

            entity.Property(x => x.IsMain)
                .HasColumnName("is_main")
                .HasDefaultValue("false")
                .IsRequired(true);
        }

    }
}
