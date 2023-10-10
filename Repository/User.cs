using Notepad.Controllers;
using Notepad.Models;

namespace Notepad.Repository
{
  public class UserRepository : IUserActions
  {
    public Task<User> CreateUser(User user)
    {
      throw new NotImplementedException();
    }

    public Task DeleteUser(Guid Id)
    {
      throw new NotImplementedException();
    }

    public Task<User> GetUser(Guid Id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsers()
    {
      throw new NotImplementedException();
    }

    public Task ResetPassword(string Password)
    {
      throw new NotImplementedException();
    }

    public Task UpdateUser(User user)
    {
      throw new NotImplementedException();
    }
  }
}