using Notepad.Controllers;
using Notepad.Models;

namespace Notepad.Repository
{
  public class UserRepository : IUserActions
  {
    public Task<User> CreateUserAsync(User user)
    {
      throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid Id)
    {
      throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(Guid Id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsersAsync()
    {
      throw new NotImplementedException();
    }

    public Task ResetPasswordAsync(string Password)
    {
      throw new NotImplementedException();
    }

    public Task UpdateUserAsync(User user)
    {
      throw new NotImplementedException();
    }
  }
}