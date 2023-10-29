using System.Net;
using Microsoft.AspNetCore.Mvc;
using Notepad.Dtos;
using Notepad.Interface;
using Notepad.Models;

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
    public NoteController(INoteActions noteRepository, IJwtService jwtService)
    {
      this.noteRepository = noteRepository;
      this.jwtService = jwtService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateNoteAsync(NotepadDto note)
    {
      //var jwt = Request.Cookies["jwt"]
      // Retrieve the JWT token from the request header
      string jwt = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
      if (string.IsNullOrEmpty(jwt))
      {
        return Unauthorized("Jwt is not provided");
      };
      var token = jwtService.VerifyJwt(jwt);
      Guid userId = new Guid(token.Issuer);
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

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<NotepadDto>>> GetNotesAsync()
    {
      var jwt = Request.Headers["Authorizations"].FirstOrDefault()?.Replace("Bearer ", "");
      if (string.IsNullOrEmpty(jwt)) return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Invalid jwt" });
      var token = jwtService.VerifyJwt(jwt);
      Guid userId = new Guid(token.Issuer);
      var notes = (await noteRepository.GetNotesAsync(userId)).Select(note => note.parseNoteDto());
      return Ok(new { statusCode = HttpStatusCode.OK, data = notes });

    }
  }
}