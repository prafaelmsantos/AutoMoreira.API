namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> UserExists(string username);
        Task<UserUpdateDTO[]> GetAllUsersAsync();
        Task<UserUpdateDTO> GetUserByIdAsync(int id);
        Task<UserUpdateDTO> GetUserByUserNameAsync(string username);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDto, string password);
        Task<UserUpdateDTO> CreateAccountAsync(UserDTO userDto);
        Task<UserUpdateDTO> UpdateAccount(UserUpdateDTO userUpdateDto);
    }
}
