using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcDataAccess.DAOs
{
    public class PostEfcDao : IPostDao
    {
        private readonly RedditContext context;

        public PostEfcDao(RedditContext context)
        {
            this.context = context;
        }
        public async Task<Post> CreateAsync(Post post)
        {
            EntityEntry<Post> added = await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
            return added.Entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
        {
            IQueryable<Post> usersQuery = context.Posts.AsQueryable();
            if (searchParameters.TitleContains != null)
            {
                usersQuery = usersQuery.Where(u => u.Title.ToLower().Contains(searchParameters.TitleContains.ToLower()));
            }

            IEnumerable<Post> result = await usersQuery.ToListAsync();
            return result;

        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            Post? post = await context.Posts.FindAsync(id);
            return post;
        }

        public Task UpdateAsync(Post todo)
        {
            throw new NotImplementedException();
        }
    }
}
