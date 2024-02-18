namespace AutoMoreira.Persistence.Mapping
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> entity)
        {
            entity.ToTable("vehicles");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .IsRequired(true);

            entity.Property(x => x.ModelId)
                .HasColumnName("model_id")
                .IsRequired(true);

            entity.Property(x => x.Version)
                .HasColumnName("version")
                .IsRequired(false);

            entity.Property(x => x.FuelType)
                .HasColumnName("fuel_type")
                .IsRequired(true);

            entity.Property(x => x.Price)
                .HasColumnName("price")
                .IsRequired(true);

            entity.Property(x => x.Mileage)
                .HasColumnName("mileage")
                .IsRequired(true);

            entity.Property(x => x.Year)
                .HasColumnName("year")
                .IsRequired(true);

            entity.Property(x => x.Color)
                .HasColumnName("color")
                .IsRequired(true);

            entity.Property(x => x.Doors)
                .HasColumnName("doors")
                .IsRequired(true);

            entity.Property(x => x.Transmission)
                .HasColumnName("transmission")
                .IsRequired(true);

            entity.Property(x => x.EngineSize)
                .HasColumnName("engine_size")
                .IsRequired(true);

            entity.Property(x => x.Power)
                .HasColumnName("power")
                .IsRequired(true);

            entity.Property(x => x.Observations)
                .HasColumnName("observations")
                .IsRequired(false);

            entity.Property(x => x.Opportunity)
                .HasColumnName("opportunity")
                .HasDefaultValue("false")
                .IsRequired(true);

            entity.Property(x => x.Sold)
                .HasColumnName("sold")
                .HasDefaultValue("false")
                .IsRequired(true);

            entity.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .IsRequired(false);

            entity.Property(x => x.LastModifiedDate)
                .HasColumnName("last_modified_date")
                .IsRequired(false);

            entity.HasMany(x => x.VehicleImages)
                .WithOne(x => x.Vehicle)
                .HasForeignKey(x => x.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
