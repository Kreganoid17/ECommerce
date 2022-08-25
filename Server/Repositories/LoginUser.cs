﻿using Blazored.LocalStorage;
using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ECommerceApp.Server.Repositories
{
    public class LoginUser : ILoginUser
    {

        private readonly DataContext _context;

        public LoginUser(DataContext context)
        {
            _context = context;
      
        }

        public async Task<bool> IsValidUser(LoginDTO login)
        {
            try
            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email);

                if (user == null)
                {

                    return false;

                }
                else
                {

                    if (!VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
                    {

                        return false;

                    }
                    else if(VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
                    {

                        return true;

                    }

                    return false;

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordhash, byte[] passwordsalt)
        {

            using (var hmac = new HMACSHA512(passwordsalt))
            {

                var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedhash.SequenceEqual(passwordhash);

            }

        }

        public async Task<AuthDTO> SetUser(LoginDTO login) {

            try
            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email);

                AuthDTO authdto = new AuthDTO();

                authdto.Username = user.Username;
                authdto.UserID = user.ID;
                authdto.Token = "Some Secret Token";

                return authdto;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        }
    }
}
