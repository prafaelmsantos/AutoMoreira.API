namespace AutoMoreira.Tests.Core.Builders
{
    public class ModelBuilder
    {
        private static readonly Faker data = new("en");

        public static Model Model()
        {
            return new(data.Company.CompanyName(), data.Random.Int(1));
        }
        public static ModelDTO ModelDTO()
        {
            return new()
            {
                Id = data.Random.Int(1),
                Name = data.Company.CompanyName(),
                MarkId = data.Random.Int(1),
            };
        }
        public static Model Model(ModelDTO dto)
        {
            return new(dto.Name, dto.MarkId);
        }
        public static Model FullModel(ModelDTO dto)
        {
            return new(dto.Id, dto.Name, dto.MarkId);
        }
        public static List<Model> ModelList(ModelDTO dto)
        {
            return new List<Model>() { Model(dto) };
        }
        public static List<ModelDTO> ModelListDTO(ModelDTO dto)
        {
            return new List<ModelDTO>() { dto };
        }
        public static IQueryable<Model> IQueryable(ModelDTO dto)
        {
            return ModelList(dto).AsQueryable();
        }
        public static IQueryable<Model> IQueryableEmpty()
        {
            return new List<Model>().AsQueryable();
        }
    }
}
