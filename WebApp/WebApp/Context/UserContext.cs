using Microsoft.EntityFrameworkCore;

namespace WebApp.Context
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):base(options)
        {

        }

        DbSet<UserContext> Users { get; set; }  
    }
}
