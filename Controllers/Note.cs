using Microsoft.AspNetCore.Mvc;
using Notepad.Dtos;
using Notepad.Interface;

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
    public ActionResult CreateNote(NotepadDto note)
    {

      string jwt = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer", "");
      if (string.IsNullOrEmpty(jwt))
      {
        return Unauthorized("Jwt is not provided");
      };
      var token = jwtService.VerifyJwt(jwt);
      Guid userId = new Guid(token.Issuer);
      return Ok(new { userId = userId });
      // Note data = new
      // {
      //   Id = new Guid(),
      //   Title = note.Title,
      //   Content = note.Content,
      //   UserId =
      // }
    }


  }
}