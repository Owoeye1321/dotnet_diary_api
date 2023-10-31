using Notepad.Models;
using Notepad.Dtos;

namespace Notepad
{

  //this extention file help to parse the model into an ordinar object response
  public static class Extention
  {
    public static NotepadDto parseNoteDto(this Note note)
    {
      return new NotepadDto(note.Id, note.Title, note.Content, note.CreatedDate);
    }
    public static UserDto parseUserDto(this User user)
    {
      return new UserDto(user.Id, user.Email, user.Username, user.Password, user.Role);
    }
  }

}