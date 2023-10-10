using System.ComponentModel.DataAnnotations;
using Notepad.Interface;

namespace Notepad.Models
{
  public record Notepad : INotepadInterface
  {
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Note { get; set; }
    public DateTimeOffset CreatedDate { get; set; }

  }
}