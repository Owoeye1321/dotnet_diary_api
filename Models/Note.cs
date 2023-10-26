using System.ComponentModel.DataAnnotations;
using Notepad.Interface;

namespace Notepad.Models
{
  public record Note : INotepadInterface
  {
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }

    [Required]
    public Guid UserId { get; set; }
    public DateTimeOffset CreatedDate { get; set; }

  }
}