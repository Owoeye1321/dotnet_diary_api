using Notepad.Dtos;
using Notepad.Models;
namespace Notepad.Interface
{
  public interface INoteActions
  {
    Task CreateNoteAsync(Note note);
    Task UpdateNoteAsync(UpdateNotepadDto note, Guid Id);
    Task DeleteNoteAsync(Guid Id);
    Task<Note> GetNoteAsync(Guid Id);
    Task<IEnumerable<Note>> GetNotesAsync(Guid UserId);
  }
}