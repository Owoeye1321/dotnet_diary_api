using Microsoft.AspNetCore.Mvc;
using Notepad.Models;
using Notepad.Dtos;
using System.Net;

namespace Notepad.Controllers
{

  //this brings a bunch of additional default behaviour for your controller 
  [ApiController]
  // //adding a route
  // //[Route("[controller]")] //this would make the route inherit the controller name e.g GET /items
  [Route("user")]
  public class UserController : ControllerBase
  {

    public readonly IUserActions userRepository;
    public UserController(IUserActions userRepository)
    {
      this.userRepository = userRepository;
    }

    //this controll all post request to /user
    [HttpPost]

    public async Task<ActionResult> CreateUserAsync(UserDto userDto)
    {
      User user = new()
      {
        Id = Guid.NewGuid(),
        Email = userDto.Email,
        Username = userDto.Username,
        Password = userDto.Password,
        Role = userDto.Role
      };
      // await userRepository.CreateUserAsync(user);
      var responseData = new { status = HttpStatusCode.OK, message = "Account Created Successfully", data = user.parseUserDto() };
      return Ok(responseData);

    }

    // public Task DeleteUserAsync(Guid Id)
    // {
    //   throw new NotImplementedException();
    // }

    // public Task<UserDto> GetUserAsync(Guid Id)
    // {
    //   throw new NotImplementedException();
    // }

    // public Task<IEnumerable<UserDto>> GetUsersAsync()
    // {
    //   throw new NotImplementedException();
    // }

    // public Task ResetPasswordAsync(ResetPasswordDto password)
    // {
    //   throw new NotImplementedException();
    // }
    // public Task UpdateUserAsync(User user)
    // {
    //   throw new NotImplementedException();
    // }
  }
}