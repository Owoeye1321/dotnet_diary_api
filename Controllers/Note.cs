using System.Net;
using Microsoft.AspNetCore.Mvc;
using Notepad.Controllers;
using Notepad.Dtos;
using Notepad.Helpers;
using Notepad.Interface;
using Notepad.Models;
using Notepad.Repository;

namespace Notepad
{

  //this brings a bunch of additional default behaviour for your controller 
  [ApiController]
  // //adding a route
  // //[Route("[controller]")] //this would make the route inherit the controller name e.g GET /items
  [Route("note")]
  public class NoteController : ControllerBase
  {

    private INoteActions noteRepository;
    private IJwtService jwtService;
    private IUserActions userRepository;
    public NoteController(INoteActions noteRepository, IJwtService jwtService, IUserActions userRepository)
    {
      this.noteRepository = noteRepository;
      this.jwtService = jwtService;
      this.userRepository = userRepository;
    }

    [HttpPost]
    public async Task<ActionResult> CreateNoteAsync(NotepadDto note)
    {
      try
      {
        //var jwt = Request.Cookies["jwt"]
        // Retrieve the JWT token from the request header
        string jwt = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
        if (string.IsNullOrEmpty(jwt))
        {
          return Unauthorized("Jwt is not provided");
        };
        try
        {
          var token = jwtService.VerifyJwt(jwt);
          Guid userId = new Guid(token.Issuer);
          var user = await userRepository.GetUserAsync(userId);
          if (user is null) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid User" });
          Note data = new()
          {
            Id = new Guid(),
            Title = note.Title,
            Content = note.Content,
            UserId = userId,
            CreatedDate = DateTimeOffset.UtcNow
          };

          await noteRepository.CreateNoteAsync(data);
          return Ok(new { statusCode = HttpStatusCode.OK, message = "Saved Successfully" });

        }
        catch (System.Exception)
        {

          return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Unauthorized identity" });
        }

      }
      catch (System.Exception)
      {

        return BadRequest(new { status = HttpStatusCode.BadGateway, message = "An error occured" });
      }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotepadDto>>> GetNotesAsync()
    {
      try
      {
        var jwt = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
        if (string.IsNullOrEmpty(jwt)) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid jwt" });
        try
        {
          var token = jwtService.VerifyJwt(jwt);
          Guid userId = new Guid(token.Issuer);
          var user = await userRepository.GetUserAsync(userId);
          if (user is null) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid User" });
          var notes = (await noteRepository.GetNotesAsync(userId)).Select(note => note.parseNoteDto());
          return Ok(new { statusCode = HttpStatusCode.OK, message = "success", data = notes });
        }
        catch (System.Exception)
        {

          return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Unauthorized identity" });
        }

      }
      catch (System.Exception)
      {

        return BadRequest(new { status = HttpStatusCode.BadGateway, message = "An error occured" });
      }

    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateNoteAsync(Guid id, UpdateNotepadDto note)
    {
      try
      {
        try
        {
          var jwt = Request.Headers["Authorization"].SingleOrDefault()?.Replace("Bearer ", "");
          var token = jwtService.VerifyJwt(jwt);
          Guid userId = new Guid(token.Issuer);
          var user = await userRepository.GetUserAsync(userId);
          if (user is null) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid User" });
          await noteRepository.UpdateNoteAsync(note, id);
          return Ok(new { statusCode = HttpStatusCode.OK, message = "Updated successfully" });

        }
        catch (System.Exception)
        {

          return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Unauthorized identity" });
        }

      }
      catch (System.Exception)
      {
        return BadRequest(new { status = HttpStatusCode.BadGateway, message = "An error occured" });

      }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Note>> GetNoteAsync(Guid Id)
    {
      try
      {
        try
        {
          var jwt = Request.Headers["Authorization"].SingleOrDefault()?.Replace("Bearer ", "");
          var token = jwtService.VerifyJwt(jwt);
          Guid userId = new Guid(token.Issuer);
          var user = await userRepository.GetUserAsync(userId);
          if (user is null) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid User" });
          var singleNote = await noteRepository.GetNoteAsync(Id);
          return Ok(new { statusCode = HttpStatusCode.OK, message = "Note Returned successfully", note = singleNote.parseNoteDto() });

        }
        catch (System.Exception)
        {

          return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Unauthorized identity" });
        }
      }
      catch (System.Exception)
      {

        return BadRequest(new { status = HttpStatusCode.BadGateway, message = "An error occured" });
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Note>> DeleteNoteAsync(Guid Id)
    {
      try
      {
        try
        {
          var jwt = Request.Headers["Authorization"].SingleOrDefault()?.Replace("Bearer ", "");
          var token = jwtService.VerifyJwt(jwt);
          Guid userId = new Guid(token.Issuer);
          var user = await userRepository.GetUserAsync(userId);
          if (user is null) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid User" });
          await noteRepository.DeleteNoteAsync(Id);
          return Ok(new { statusCode = HttpStatusCode.OK, message = "Note deleted successfully" });

        }
        catch (System.Exception)
        {

          return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Unauthorized identity" });
        }
      }
      catch (System.Exception)
      {

        return BadRequest(new { status = HttpStatusCode.BadGateway, message = "An error occured" });
      }
    }
  }

}