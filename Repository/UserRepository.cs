using MongoDB.Bson;
using MongoDB.Driver;
using Notepad.Controllers;
using Notepad.Dtos;
using Notepad.Models;

namespace Notepad.Repository
{
  public class UserRepository : IUserActions
  {

    private const string DatabaseName = "notepad";
    private const string UserCollectionName = "Users";
    private readonly IMongoCollection<User> UserCollections;
    private readonly FilterDefinitionBuilder<User> filterBuilder = Builders<User>.Filter;
    public UserRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
      UserCollections = database.GetCollection<User>(UserCollectionName);

    }
    public async Task CreateUserAsync(User user)
    {
      await UserCollections.InsertOneAsync(user);
    }

    public Task DeleteUserAsync(Guid Id)
    {
      throw new NotImplementedException();
    }

    public async Task<User> GetUserAsync(Guid Id)
    {

      var filter = filterBuilder.Eq(user => user.Id, Id);
      return await UserCollections.Find(filter).SingleOrDefaultAsync();


    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
      return await UserCollections.Find(new BsonDocument()).ToListAsync();
    }

    public Task ResetPasswordAsync(ResetPasswordDto password)
    {
      throw new NotImplementedException();
    }

    public Task UpdateUserAsync(User user)
    {
      throw new NotImplementedException();
    }
  }


}