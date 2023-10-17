using Microsoft.AspNetCore.Mvc;
using Notepad.Models;
using Notepad.Dtos;
using Notepad.Repository;

namespace Notepad.Controllers
{
  public class UserController : IUserActions
  {

    public readonly IUserActions userRepository;
    public UserController(IUserActions userRepository)
    {
      this.userRepository = userRepository;
    }
    public async Task<User> CreateUserAsync(User user)
    {
      throw new NotImplementedException();
    }

    public async Task DeleteUserAsync(Guid Id)
    {
      throw new NotImplementedException();
    }

    public async Task<UserDto> GetUserAsync(Guid Id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
      throw new NotImplementedException();
    }

    public async Task ResetPasswordAsync(ResetPasswordDto password)
    {
      throw new NotImplementedException();
    }

    public Task ResetPasswordAsync(Guid Id)
    {
      throw new NotImplementedException();
    }
    public async Task UpdateUserAsync(User user)
    {
      throw new NotImplementedException();
    }
  }
}