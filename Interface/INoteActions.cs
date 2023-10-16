using Notepad.Models;
namespace Notepad.Interface
{
  public interface INoteActions {
     Task<Note> CreateNoteAsync(Note note);
     Task UpdateNoteAsync(Note note);
     Task DeleteNoteAsync(Guid Id);
  }
}