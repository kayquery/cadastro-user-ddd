
using SignIn.Domain.DTO;
using SignIn.Domain.Entities;
using SignIn.Presentation.Models;

namespace SignIn.Application.Interfaces
{
    public interface IUserService
    {
        Task<Result> CreateUser(UserDTO userDTO);
        Task<Result> GetUser(string userId);
        Task<IEnumerable<User>> GetUsers();
        Task<Result> UpdateUser(string userId, UserDTO userDTO);
    }
}