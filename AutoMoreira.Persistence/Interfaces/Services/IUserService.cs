namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> UserExists(string username);
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByEmailAsync(string email);
        Task<SignInResult> CheckUserPasswordAsync(UserDTO userDTO, string password);
        Task<UserDTO?> CreateUserAsync(UserDTO userDTO);
        Task<UserDTO> UpdateUserAsync(UserDTO userDTO);
        Task UserResetPasswordAsync(string userName);
        Task UserUpdateUserPasswordAsync(UserLoginDTO userLoginDTO);
        Task<UserDTO> UpdateUserModeAsync(int id, bool mode);
        Task<UserDTO> UpdateUserImageAsync(int id, string image);
        Task<List<ResponseMessageDTO>> DeleteUsersAsync(List<int> usersIds);
    }
}
