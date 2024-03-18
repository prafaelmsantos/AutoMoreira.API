namespace AutoMoreira.Core.Domains
{
    public class VehicleImage : EntityBase
    {
        public string Url { get; private set; } = null!;

        public int VehicleId { get; private set; }
        public virtual Vehicle Vehicle { get; private set; } = null!;
        public bool IsMain { get; private set; } = false;

        public VehicleImage() { }

        public VehicleImage(string url, int vehicleId, bool isMain)
        {
            Url = url;
            VehicleId = vehicleId;
            IsMain = isMain;
        }
    }
}
