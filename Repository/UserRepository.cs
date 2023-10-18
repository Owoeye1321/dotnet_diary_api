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

    public Task<UserDto> GetUserAsync(Guid Id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetUsersAsync()
    {
      throw new NotImplementedException();
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