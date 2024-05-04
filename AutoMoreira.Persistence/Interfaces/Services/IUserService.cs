namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByEmailAsync(string email);
        Task<bool> LoginUserAsync(UserLoginDTO userLoginDTO);
        Task<UserDTO> AddUserAsync(UserDTO userDTO);
        Task<UserDTO> UpdateUserAsync(UserDTO userDTO);    
        Task<UserDTO> UpdateUserModeAsync(int id, bool mode);
        Task<UserDTO> UpdateUserImageAsync(int id, string? image);
        Task<UserDTO> UpdateUserPasswordAsync(UserLoginDTO userLoginDTO);
        Task<UserDTO> ResetUserPasswordAsync(string userName);     
        Task<List<ResponseMessageDTO>> DeleteUsersAsync(List<int> usersIds);
    }
}
