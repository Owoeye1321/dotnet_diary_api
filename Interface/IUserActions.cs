using Notepad.Dtos;
using Notepad.Models;
using Notepad.utils;

namespace Notepad.Controllers
{
  public interface IUserActions
  {
    Task CreateUserAsync(User user);
    Task<User> GetUserAsync(Guid Id);
    Task<IEnumerable<User>> GetUsersAsync();
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid Id);
    Task ResetPasswordAsync(ResetPasswordDto password);
    Task<LoggedIn> LoginAsync(LoginDto login);
  }
}