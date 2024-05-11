namespace AutoMoreira.Tests.Core.Builders
{
    public class MarkBuilder
    {
        private static readonly Faker data = new("en");

        public static Mark Mark()
        {
            return new(data.Company.CompanyName());
        }
        public static MarkDTO MarkDTO()
        {
            return new()
            {
                Id = data.Random.Int(1),
                Name = data.Company.CompanyName()
            };
        }
        public static Mark Mark(MarkDTO dto)
        {
            return new(dto.Name);
        }
        public static Mark FullMark(MarkDTO dto)
        {
            return new(dto.Id, dto.Name);
        }
        public static List<Mark> MarkList(MarkDTO dto)
        {
            return new List<Mark>() { Mark(dto) };
        }
        public static List<MarkDTO> MarkListDTO(MarkDTO dto)
        {
            return new List<MarkDTO>() { dto };
        }
        public static IQueryable<Mark> IQueryable(MarkDTO dto)
        {
            return MarkList(dto).AsQueryable();
        }
        public static IQueryable<Mark> IQueryableEmpty()
        {
            return new List<Mark>().AsQueryable();
        }
    }
}
