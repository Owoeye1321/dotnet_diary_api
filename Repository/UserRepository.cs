using MongoDB.Driver;
using Notepad.Controllers;
using Notepad.Models;

namespace Notepad.Repository
{
  public class UserRepository : IUserActions
  {

    private const string DatabaseName = "notepad";
    private const string ItemcollectionName = "Users";
    private readonly IMongoCollection<Item> UserCollections;
    public readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
    public UserRepository(IMongoClient mongoClient)
    {

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

  internal class Item
  {
  }
}