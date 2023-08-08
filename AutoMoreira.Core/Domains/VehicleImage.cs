namespace AutoMoreira.Core.Domains
{
    public class VehicleImage
    {
        public int Id { get; private set; }
        public string Url { get; private set; }
        public int Order { get; private set; }

        public int VehicleId { get; private set; }
        public virtual Vehicle Vehicle { get; private set; }

        public VehicleImage() { }
    }
}
