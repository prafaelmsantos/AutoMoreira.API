namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> UserExists(string username);
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByUserNameAsync(string username);
        Task<SignInResult> CheckUserPasswordAsync(UserDTO userDTO, string password);
        Task<UserDTO> CreateUserAsync(UserDTO userDTO);
        Task<UserDTO> UpdateUserAsync(UserDTO userDTO);
        Task<UserDTO> UpdateUserModeAsync(UserUpdateModeDTO userUpdateModeDTO);
        Task<UserDTO> UpdateUserImageAsync(UserUpdateImageDTO userUpdateImageDTO);
    }
}
