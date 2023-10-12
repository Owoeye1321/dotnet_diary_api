using System.ComponentModel.DataAnnotations;

namespace Notepad
{
  public record NotepadDto(Guid Id, [Required] string Title, [Required] string Content, DateTimeOffset CreatedDate);
  public record CreateNotepadDto([Required] string Title, [Required] string Content);
  public record UpdateNotepadDto([Required] string Title, [Required] string Content);

}