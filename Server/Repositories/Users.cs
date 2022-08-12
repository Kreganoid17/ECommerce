using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Server.Repositories
{
    public class Users : IUsers
    {

        private readonly DataContext _context;

        public Users(DataContext context)
        {
            _context = context;

        }

        public List<User> users { get; set; }

        public async Task AddUser(User user)
        {
            
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

        }

        public async Task<List<User>> GetUsers()
        {
            var Users = await _context.Users.ToListAsync();

            users = Users;

            return users;
        }

        


    }
}
