namespace AutoMoreira.Tests.Core.Builders
{
    public class VehicleImageBuilder
    {
        private static readonly Faker _data = new("en");

        public static VehicleImage VehicleImage()
        {
            return new(_data.Internet.Url());
        }
        public static VehicleImageDTO VehicleImageDTO()
        {
            return new() { 
                Id = _data.Random.Int(1), 
                Url = _data.Internet.Url(),
                VehicleId = _data.Random.Int(1),
                IsMain = _data.Random.Bool()
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
        public static List<VehicleImageDTO> VehicleImageListDTO(VehicleImageDTO dto)
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
