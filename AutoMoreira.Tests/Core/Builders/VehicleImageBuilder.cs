namespace AutoMoreira.Tests.Core.Builders
{
    public class VehicleImageBuilder
    {
        private static readonly Faker data = new("en");

        public static VehicleImage VehicleImage()
        {
            return new(data.Internet.Url());
        }
        public static VehicleImageDTO VehicleImageDTO()
        {
            return new()
            {
                Id = data.Random.Int(1),
                Url = data.Internet.Url(),
                VehicleId = data.Random.Int(1),
                IsMain = data.Random.Bool()
            };
        }
        public static VehicleImage VehicleImage(VehicleImageDTO dto)
        {
            return new(dto.Url);
        }
        public static List<VehicleImage> VehicleImageList(VehicleImageDTO dto)
        {
            return new List<VehicleImage>() { VehicleImage(dto) };
        }
        public static List<VehicleImageDTO> VehicleImageDTOList(VehicleImageDTO dto)
        {
            return new List<VehicleImageDTO>() { dto };
        }
        public static IQueryable<VehicleImage> IQueryable(VehicleImageDTO dto)
        {
            return VehicleImageList(dto).AsQueryable();
        }
        public static IQueryable<VehicleImage> IQueryableEmpty()
        {
            return new List<VehicleImage>().AsQueryable();
        }
    }
}
