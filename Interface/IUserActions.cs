using Notepad.Dtos;
using Notepad.Models;

namespace Notepad.Controllers
{
  public interface IUserActions
  {
    Task CreateUserAsync(User user);
    Task<UserDto> GetUserAsync(Guid Id);
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(Guid Id);
    Task ResetPasswordAsync(ResetPasswordDto password);
  }
}