namespace Notepad.Settings
{
  public class MongoDbSettings
  {
    //mongodb url settings contrustructed here
    public string Host { get; set; }
    public int Port { get; set; }
    public string ConnectionString
    {
      get
      {
        return $"mongodb://{Host}:{Port}";
      }
    }
  }
}