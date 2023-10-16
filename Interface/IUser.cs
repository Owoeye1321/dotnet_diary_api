namespace Notepad.Interface
{
  public interface IUser
  {
    Guid Id { get; set; }
    string Email { get; set; }
    string Role { get; set; }
    string Username { get; set; }
    string Password { get; set; }
  }
}