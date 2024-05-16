namespace AutoMoreira.Persistence.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(UserDTO userDTO);
    }
}
