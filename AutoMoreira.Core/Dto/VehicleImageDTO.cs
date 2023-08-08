namespace AutoMoreira.Core.Domains
{
    public class VehicleImageDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }

        public int VehicleId { get; set; }
        public virtual VehicleDTO Vehicle { get; set; }

    }
}
