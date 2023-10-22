using System.ComponentModel.DataAnnotations;

namespace Notepad.Dtos
{
  public record NotepadDto(Guid Id, [Required] string Title, [Required] string Content, DateTimeOffset CreatedDate);
  public record UserDto(Guid Id, [Required] string Email, [Required] string Password, [Required] string Username, [Required] string Role);
  public record ResetPasswordDto(Guid Id, [Required] string Password);
  public record CreateNotepadDto([Required] string Title, [Required] string Content);
  public record UpdateNotepadDto([Required] string Title, [Required] string Content);
  public record LoginDto([Required] string Email, string Password);
  public record UpdateUserDto([Required] string Email, [Required] string Username, [Required] string Password, [Required] string Role);
}