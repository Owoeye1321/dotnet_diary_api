using System.ComponentModel.DataAnnotations;
using Notepad.Interface;

namespace Notepad.Models
{
  public record User : IUser
  {
    public Guid Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public string Role { get; set; }
  }
}