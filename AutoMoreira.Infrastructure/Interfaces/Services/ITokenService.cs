namespace AutoMoreira.Infrastructure.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(UserDTO userDTO);
    }
}
