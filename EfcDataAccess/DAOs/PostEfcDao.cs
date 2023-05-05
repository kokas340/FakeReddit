using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcDataAccess.DAOs
{
    public class PostEfcDao : IPostDao
    {
        public Task<Post> CreateAsync(Post todo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
        {
            throw new NotImplementedException();
        }

        public Task<Post?> GetByIdAsync(int todoId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Post todo)
        {
            throw new NotImplementedException();
        }
    }
}
