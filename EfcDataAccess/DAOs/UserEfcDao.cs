using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        private readonly RedditContext context;

        public UserEfcDao(RedditContext context)
        {
            this.context = context;
        }
        public async Task<User> CreateAsync(User user)
        {
            EntityEntry<User> newUser = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return newUser.Entity;
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User?>> GetAsync(SearchUserParametersDto searchParameters)
        {
            IQueryable<User> usersQuery = context.Users.AsQueryable();
            if (searchParameters.UsernameContains != null)
            {
                usersQuery = usersQuery.Where(u => u.UserName.ToLower().Contains(searchParameters.UsernameContains.ToLower()));
            }
            Console.WriteLine("testtyy");
           
            IEnumerable<User> result = await usersQuery.ToListAsync();
            return result;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            User? user = await context.Users.FindAsync(id);
            return user;
        }

        public async Task<User?> GetByUsernameAsync(string userName)
        {
            User? existing = await context.Users.FirstOrDefaultAsync(u =>
       u.UserName.ToLower().Equals(userName.ToLower())
   );
            return existing;
        }

        Task<IEnumerable<User?>> IUserDao.GetAsync(UserLoginDto searchParameters)
        {
            throw new NotImplementedException();
        }
    }
}
