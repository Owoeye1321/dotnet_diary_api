using Microsoft.AspNetCore.Mvc;
using Notepad.Repository;

namespace Notepad
{
  public class NoteController : ControllerBase
  {
    private NoteRepository noteRepository;
    public NoteController(NoteRepository noteRepository)
    {
      this.noteRepository = noteRepository;
    }
  }
}