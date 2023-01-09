using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.IServices;
using WebApp.Models;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _userContext;


        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task CreateUserAsync(User user)
        {
            await _userContext.AddAsync(user);
           await _userContext.SaveChangesAsync();
        }

        

        public async Task DeleteUser(Guid id)
        {
            if(await ExistUser(id))
            {
                var deleteUser = await _userContext.Users.FindAsync(id);
                if(deleteUser!=null)
                {
                    _userContext.Users.Remove(deleteUser);
                    _userContext.SaveChanges(); 
                }
            }
        }

        

        

        public async Task<bool> ExistUser(Guid id)
        {
            var user = await _userContext.Users.FindAsync(id);
            if (user == null)
                return false;
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userContext.Users.ToListAsync();   
        }





        public async Task<User> GetbyIdUserAsync(Guid id) => await _userContext.Users.FindAsync(id);
        
        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
