using Application.DaoInterfaces;
using Domain.Models;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcDataAccess.DAOs
{
    public class UserEfcDao : IUserDao
    {
        public Task<User> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetAsync(UserLoginDto searchParameters)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByUsernameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
