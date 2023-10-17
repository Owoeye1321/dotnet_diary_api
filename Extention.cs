using Notepad.Models;
using Notepad.Dtos;

namespace Notepad
{

  public static class Extention
  {
    public static NotepadDto parseNoteDto(this Note note)
    {
      return new NotepadDto(note.Id, note.Title, note.Content, note.CreatedDate);
    }
    public static UserDto parseUserDto(this User user)
    {
      return new UserDto(user.Id, user.Email, user.Username);
    }
  }

}