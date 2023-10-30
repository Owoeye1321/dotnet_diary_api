using MongoDB.Driver;
using Notepad.Dtos;
using Notepad.Interface;
using Notepad.Models;

namespace Notepad.Repository
{
  public class NoteRepository : INoteActions
  {
    private const string DatabaseName = "notepad";
    private const string ItemcollectionName = "Notes";
    private readonly IMongoCollection<Note> NoteCollections;
    private readonly FilterDefinitionBuilder<Note> filterBuilder = Builders<Note>.Filter;
    public NoteRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
      NoteCollections = database.GetCollection<Note>(ItemcollectionName);
    }
    public async Task CreateNoteAsync(Note note)
    {
      await NoteCollections.InsertOneAsync(note);

    }
    public async Task UpdateNoteAsync(UpdateNotepadDto note, Guid Id)
    {
      var filter = filterBuilder.Eq(existingNotes => existingNotes.Id, Id);
      var update = Builders<Note>.Update.Set("Content", note.Content);
      await NoteCollections.UpdateOneAsync(filter, update);
    }
    public async Task DeleteNoteAsync(Guid Id)
    {
      var filter = filterBuilder.Eq(existingNotes => existingNotes.Id, Id);
      await NoteCollections.DeleteOneAsync(filter);
    }
    public async Task<IEnumerable<Note>> GetNotesAsync(Guid UserId)
    {
      var filter = filterBuilder.Eq(existingNotes => existingNotes.UserId, UserId);
      return await NoteCollections.Find(filter).ToListAsync();
    }
  }
}