using MongoDB.Driver;
using Notepad.Interface;
using Notepad.Models;

namespace Notepad.Repository
{
  public class NoteRepository : INoteActions
  {
    private const string DatabaseName = "notepad";
    private const string ItemcollectionName = "Notes";
    private readonly IMongoCollection<Note> UserCollections;
    private readonly FilterDefinitionBuilder<Note> filterBuilder = Builders<Note>.Filter;
    public NoteRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
      UserCollections = database.GetCollection<Note>(ItemcollectionName);
    }
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