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

            try
            {

                _context.Users.Add(user);

                await _context.SaveChangesAsync();


            }
            catch (Exception ex) {

                throw new Exception(ex.Message);

           
            
            }

        }

        public async Task<List<User>> GetUsers()
        {
            try
            {

                var Users = await _context.Users.ToListAsync();

                users = Users;

                return users;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);

            }
        }

    }
}
