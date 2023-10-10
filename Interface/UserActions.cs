using Notepad.Models;

namespace Notepad.Controllers
{
  public interface IUserActions
  {
    Task<User> CreateUser(User user);
    Task<User> GetUser(Guid Id);
    Task<IEnumerable<User>> GetUsers();
    Task UpdateUser(User user);
    Task DeleteUser(Guid Id);
    Task ResetPassword(string Password);
  }
}