using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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
        public bool Exists { get; set; }

        public async Task AddUser(UserDTO userdto)
        {

            try
            {

                SqlParameter email = new SqlParameter("@email", userdto.Email);

                var userexists = _context.Users.FromSqlRaw("dbo.GetUser @email",email).AsEnumerable().FirstOrDefault();

                if (userexists == null)
                {

                    Exists = false;

                    CreatePasswordHash(userdto.Password, out byte[] passwordhash, out byte[] passwordsalt);

                    User user = new User { 
                    
                        Email = userdto.Email,
                        PasswordHash = passwordhash,
                        PasswordSalt = passwordsalt,
                        Username = userdto.Username
                    
                    };

                    _context.Users.Add(user);

                    await _context.SaveChangesAsync();

                }
                else if(userexists != null){


                    Exists = true;
                
                }

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);

            }

        }

        private void CreatePasswordHash(string password, out byte[] passwordhash, out byte[] passwordsalt) {

            try
            {

                using (var hmac = new HMACSHA512())
                {

                    passwordsalt = hmac.Key;
                    passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {

                var Users = _context.Users.FromSqlRaw("dbo.GetUsers").AsEnumerable().ToList();

                users = Users;

                return users;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);

            }
        }

    }
}
