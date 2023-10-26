using MongoDB.Driver;
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