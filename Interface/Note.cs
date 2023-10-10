namespace Notepad.Interface
{
  public interface INotepadInterface
  {
    Guid Id { get; set; }
    string Title { get; set; }
    string Note { get; set; }
    DateTimeOffset CreatedDate { get; set; }
  }
}