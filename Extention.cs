using Notepad.Models;

namespace Notepad
{

  public static class Extention
  {
    public static NotepadDto parseDto(this Note note)
    {
      return new NotepadDto(note.Id, note.Title, note.Content, note.CreatedDate);
    }
  }

}