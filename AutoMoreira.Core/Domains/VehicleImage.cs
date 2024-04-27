namespace AutoMoreira.Core.Domains
{
    public class VehicleImage : EntityBase
    {
        public string Url { get; private set; } = null!;

        public int VehicleId { get; private set; }
        public virtual Vehicle Vehicle { get; private set; } = null!;
        public bool IsMain { get; private set; } = false;

        public VehicleImage() { }

        public VehicleImage(string url)
        {
            url.ThrowIfNull(() => throw new Exception(DomainResource.VehicleImageUrlNeedsToBeSpecifiedException))
                .IfWhiteSpace();

            Url = url;
            IsMain = false;
        }

        public void SetIsMain()
        {
            IsMain = true;
        }
    }
}
