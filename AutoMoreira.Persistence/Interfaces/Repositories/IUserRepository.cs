namespace AutoMoreira.Persistence.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository
    {
        
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string userName);
    }
}
