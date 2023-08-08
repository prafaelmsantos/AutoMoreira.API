namespace AutoMoreira.Persistence.Mapping
{
    public class VehicleImageMap : IEntityTypeConfiguration<VehicleImage>
    {
        public void Configure(EntityTypeBuilder<VehicleImage> entity)
        {
            entity.ToTable("vehicle_image");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            entity.Property(x => x.Url)
                .HasColumnName("url")
                .IsRequired(true);

            entity.Property(x => x.Order)
                .HasColumnName("order")
                .IsRequired(true);

        }

    }
}
