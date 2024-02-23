namespace AutoMoreira.Core.Domains
{
    public class VehicleImage : AuditableEntity
    {
        public string Url { get; private set; } = null!;

        public int VehicleId { get; private set; }
        public virtual Vehicle Vehicle { get; private set; } = null!;

        public VehicleImage() { }
    }
}
