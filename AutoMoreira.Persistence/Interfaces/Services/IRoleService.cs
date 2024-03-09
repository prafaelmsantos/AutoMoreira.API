namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IRoleService
    {
        Task<RoleDTO> AddRoleAsync(RoleDTO roleDTO);
        Task<RoleDTO> UpdateRoleAsync(RoleDTO roleDTO);

        Task<List<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO> GetRoleByIdAsync(int roleId);

        Task<List<ResponseMessageDTO>> DeleteRolesAsync(List<int> rolesIds);
    }
}
