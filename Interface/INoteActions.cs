using Notepad.Models;
namespace Notepad.Interface
{
  public interface INoteActions
  {
    Task CreateNoteAsync(Note note);
    Task UpdateNoteAsync(Note note);
    Task DeleteNoteAsync(Guid Id);
  }
}