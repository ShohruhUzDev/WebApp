using WebApp.Models;

namespace WebApp.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetbyIdUserAsync(Guid id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUser(Guid id);
        Task<bool> ExistUser(Guid id);
    }
}
