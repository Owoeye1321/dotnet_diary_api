using Notepad.Models;

namespace Notepad.Controllers
{
  public interface IUserActions
  {
    Task<User> CreateUserAsync(User user);
    Task<User> GetUserAsync(Guid Id);
    Task<IEnumerable<User>> GetUsersAsync();
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid Id);
    Task ResetPasswordAsync(string Password);
  }
}