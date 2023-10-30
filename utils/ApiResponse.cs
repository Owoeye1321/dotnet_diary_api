using System.Net;
using Notepad.Dtos;

namespace Notepad.utils
{
  //this is an object construction for response type
  public class ApiResponse
  {
    public HttpStatusCode responseCode { get; init; }
    public string message { get; init; }
    public object? data { get; init; }
    public ApiResponse(HttpStatusCode responseCode, string message, object data)
    {
      this.responseCode = responseCode;
      this.message = message;
      this.data = data;
    }
    public ApiResponse(HttpStatusCode responseCode, string message)
       : this(responseCode, message, null) // Calls the full constructor with data set to null
    {
    }


  }
}