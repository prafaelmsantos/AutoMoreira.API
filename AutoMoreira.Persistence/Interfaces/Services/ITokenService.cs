namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserDTO userDTO);
    }
}
