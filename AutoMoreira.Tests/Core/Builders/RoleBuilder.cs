namespace AutoMoreira.Tests.Core.Builders
{
    public class RoleBuilder
    {
        private static readonly Faker _data = new("en");

        public static Role Role()
        {
            return new(_data.Company.CompanyName());
        }
        public static RoleDTO RoleDTO()
        {
            return new() { 
                Id = _data.Random.Int(1), 
                Name = _data.Company.CompanyName(),
                IsDefault = _data.Random.Bool(),
                IsReadOnly = _data.Random.Bool()
            };
        }
        public static Role Role(RoleDTO dto)
        {
            return new(dto.Name);
        }
        public static Role FullRole(RoleDTO dto)
        {
            return new(dto.Id, dto.Name, dto.IsReadOnly, dto.IsDefault);
        }
        public static List<Role> RoleList(RoleDTO dto)
        {
            return new List<Role>() { Role(dto) };
        }
        public static List<Role> FullRoleList(RoleDTO dto)
        {
            return new List<Role>() { FullRole(dto) };
        }
        public static List<RoleDTO> RoleListDTO(RoleDTO dto)
        {
            return new List<RoleDTO>() { dto };
        }
        public static IQueryable<Role> IQueryable(RoleDTO dto)
        {
            return RoleList(dto).AsQueryable();
        }
        public static IQueryable<Role> FullIQueryable(RoleDTO dto)
        {
            return FullRoleList(dto).AsQueryable();
        }
        public static IQueryable<Role> IQueryableEmpty()
        {
            return new List<Role>().AsQueryable();
        }
        public static List<ResponseMessageDTO> ResponseMessageDTOList(Role role)
        {
            List<ResponseMessageDTO> responseMessageDTOs = new() { 
                new ResponseMessageDTO {
                    Entity = new MinimumDTO() { Id = role.Id, Name = role.Name },
                    OperationSuccess = true,
                    ErrorMessage = null
                }
            };
            return responseMessageDTOs;
        }
    }
}
