namespace AutoMoreira.Tests.Core.Builders
{
    public class MarkBuilder
    {
        private static readonly Faker _data = new("en");

        public static Mark Mark()
        {
            return new(_data.Company.CompanyName());
        }
        public static MarkDTO MarkDTO()
        {
            return new() { 
                Id = _data.Random.Int(1), 
                Name = _data.Company.CompanyName() 
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
        public static List<ResponseMessageDTO> ResponseMessageDTOList(Mark mark)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new() { 
                new ResponseMessageDTO {
                    Entity = new MinimumDTO() { Id = mark.Id, Name = mark.Name },
                    OperationSuccess = true,
                    ErrorMessage = null
                }
            };
            return responseMessageDTOs;
        }
    }
}
