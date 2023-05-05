using Domain.DTOs;
using Domain.Models;
using Shared.Dtos;

namespace Application.DaoInterfaces;
 
public interface IUserDao 
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);
     Task<IEnumerable <User?>> GetAsync(UserLoginDto searchParameters);
    Task<IEnumerable<User?>> GetAsync(SearchUserParametersDto searchParameters);
    
    Task<User?> GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
}