namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> UserExists(string username);
        Task<List<UserUpdateDTO>> GetAllUsersAsync();
        Task<UserUpdateDTO> GetUserByIdAsync(int id);
        Task<UserUpdateDTO> GetUserByUserNameAsync(string username);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDto, string password);
        Task<UserUpdateDTO> CreateUserAsync(UserDTO userDto);
        Task<UserUpdateDTO> UpdateUserAsync(UserUpdateDTO userUpdateDTO);
        Task<UserUpdateDTO> UpdateUserModeAsync(UserUpdateModeDTO userUpdateModeDTO);
    }
}
