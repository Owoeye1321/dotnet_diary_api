namespace Notepad.Interface
{
  public interface INotepadInterface
  {
    Guid Id { get; set; }
    string Title { get; set; }
    string Content { get; set; }
    Guid s { get; set; }
    DateTimeOffset CreatedDate { get; set; }
  }
}