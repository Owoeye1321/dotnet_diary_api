using Notepad.Interface;
using Notepad.Models;

namespace Notepad.Repository
{
  public class NoteRepository : INoteActions
  {
    public async Task<Note> CreateNoteAsync(Note note)
    {
      throw new NotImplementedException();
    }
    public async Task UpdateNoteAsync(Note note)
    {
      throw new NotImplementedException();
    }
    public async Task DeleteNoteAsync(Guid Id)
    {
      throw new NotImplementedException();
    }
  }
}