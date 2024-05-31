namespace AutoMoreira.Infrastructure.Interfaces.Services
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO> GetRoleByIdAsync(int roleId);
        Task<RoleDTO> AddRoleAsync(RoleDTO roleDTO);
        Task<RoleDTO> UpdateRoleAsync(RoleDTO roleDTO);
        Task<List<ResponseMessageDTO>> DeleteRolesAsync(List<int> rolesIds);
    }
}
