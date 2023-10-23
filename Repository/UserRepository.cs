using MongoDB.Bson;
using MongoDB.Driver;
using Notepad.Controllers;
using Notepad.Dtos;
using Notepad.Models;
using Notepad.utils;

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

    public async Task<User> LoginAsync(string email)
    {
      var filter = filterBuilder.Eq(user => user.Email, email);
      return await UserCollections.Find(filter).FirstOrDefaultAsync();
    }

    public async Task ResetPasswordAsync(ResetPasswordDto reset)
    {
      var filter = filterBuilder.Eq(existingUser => existingUser.Id, reset.Id);
      var update = Builders<User>.Update.Set("Password", reset.Password);
      await UserCollections.UpdateOneAsync(filter, update);
    }

    public async Task UpdateUserAsync(User user)
    {
      var filter = filterBuilder.Eq(existingUser => existingUser.Id, user.Id);
      await UserCollections.ReplaceOneAsync(filter, user);

    }
  }


}