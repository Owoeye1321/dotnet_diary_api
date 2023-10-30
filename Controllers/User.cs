using Microsoft.AspNetCore.Mvc;
using Notepad.Models;
using Notepad.Dtos;
using System.Net;
using Notepad.utils;
using Notepad.Helpers;
using Notepad.Interface;

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
    public readonly IJwtService jwtService;
    public UserController(IUserActions userRepository, IJwtService jwtService)
    {
      this.userRepository = userRepository;
      this.jwtService = jwtService;
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

    [HttpPut("reset-password")]
    public async Task<ActionResult> ResetPasswordAsync(ResetPasswordDto reset)
    {
      var user = await userRepository.GetUserAsync(reset.Id);
      if (user is null) return NotFound("User not found");
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
      var token = jwtService.Generatejwt(user.Id);
      return Ok(new { code = HttpStatusCode.OK, message = "Logged In Successfully", data = user.parseUserDto(), token = token });
    }

    [HttpGet("profile")]
    public async Task<ActionResult<UserDto>> Profile()
    {
      try
      {
        //var jwt = Request.Cookies["jwt"]
        // Retrieve the JWT token from the request header
        string jwt = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

        if (string.IsNullOrEmpty(jwt))
        {
          return Unauthorized("JWT token is missing in the request header");
        }
        try
        {
          var token = jwtService.VerifyJwt(jwt);
          Guid userId = new Guid(token.Issuer);
          var user = await userRepository.GetUserAsync(userId);
          if (user is null)
          {
            return NotFound("User not found");
          }
          return Ok(new { code = HttpStatusCode.OK, message = "Profile retrieved", data = user.parseUserDto() });
        }
        catch (System.Exception)
        {

          return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Unauthorized token" });
        }
      }
      catch (System.Exception)
      {

        return BadRequest(new { status = HttpStatusCode.BadGateway, message = "An error occured" });
      }

    }

  }
}