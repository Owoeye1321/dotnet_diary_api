using MongoDB.Driver;
using Notepad.Controllers;
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
    public Task<User> CreateUserAsync(User user)
    {
      throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid Id)
    {
      throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(Guid Id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsersAsync()
    {
      throw new NotImplementedException();
    }

    public Task ResetPasswordAsync(string Password)
    {
      throw new NotImplementedException();
    }

    public Task UpdateUserAsync(User user)
    {
      throw new NotImplementedException();
    }
  }


}