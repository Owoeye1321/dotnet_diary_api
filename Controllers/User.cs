using Microsoft.AspNetCore.Mvc;
using Notepad.Models;
using Notepad.Dtos;
using System.Net;
using Notepad.utils;

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
      var userExist = await userRepository.LoginAsync(userDto.Email);
      if (userExist != null) return BadRequest(new { code = HttpStatusCode.BadRequest, message = "User with this email already exist" });
      User user = new()
      {
        Id = Guid.NewGuid(),
        Email = userDto.Email,
        Username = userDto.Username,
        Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
        Role = userDto.Role
      };
      await userRepository.CreateUserAsync(user);
      ApiResponse response = new(HttpStatusCode.OK, "Account Created Successfully", user.parseUserDto());
      return Ok(response);

    }

    // public Task DeleteUserAsync(Guid Id)
    // {
    //   throw new NotImplementedException();
    // }


    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserAsync(Guid Id)
    {
      var user = await userRepository.GetUserAsync(Id);
      if (user == null)
      {
        return NotFound();
      }
      ApiResponse response = new ApiResponse(HttpStatusCode.OK, "Account Fetched Successfully", user.parseUserDto());
      return Ok(response);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync()
    {

      var users = (await userRepository.GetUsersAsync()).Select(user => user.parseUserDto());
      ApiResponse response = new ApiResponse(HttpStatusCode.OK, "Accounts Fetched Successfully", users);
      return Ok(response);
    }

    [HttpPut("reset-password/{id}")]
    public async Task<ActionResult> ResetPasswordAsync(Guid Id, ResetPasswordDto reset)
    {
      var user = await userRepository.GetUserAsync(Id);
      if (user is null) return NotFound();
      await userRepository.ResetPasswordAsync(reset);
      return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUserAsync(Guid Id, UpdateUserDto user)
    {
      var existingUser = await userRepository.GetUserAsync(Id);
      if (existingUser is null) return NotFound();
      existingUser.Email = user.Email;
      existingUser.Password = user.Password;
      existingUser.Username = user.Username;
      existingUser.Role = user.Role;
      await userRepository.UpdateUserAsync(existingUser);
      ApiResponse response = new(HttpStatusCode.OK, "Account Updated Successfully");
      return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDto data)
    {
      var user = await userRepository.LoginAsync(data.Email);
      if (user == null) return BadRequest(new { code = HttpStatusCode.BadRequest, message = "Invalid Credentials" });
      if (!BCrypt.Net.BCrypt.Verify(data.Password, user.Password)) return BadRequest(new { code = HttpStatusCode.BadRequest, message = "Invalid Credentials" });
      ApiResponse response = new(HttpStatusCode.OK, "Logged In Successfully", user.parseUserDto());
      return Ok(response);
    }
  }
}