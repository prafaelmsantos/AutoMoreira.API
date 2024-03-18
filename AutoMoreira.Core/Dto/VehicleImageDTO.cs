namespace AutoMoreira.Core.Domains
{
    public class VehicleImageDTO : EntityBaseDTO
    {
        public string Url { get; set; } = null!;

        public int VehicleId { get; set; }
        public VehicleDTO? Vehicle { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
