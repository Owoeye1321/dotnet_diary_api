using System.Text;
using Notepad.Models;

namespace Notepad.Helpers
{
  public class JwtService
  {
    private string securityKey = 'hello world';
    public string Generatejwt(User user)
    {
      var symmentricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
      var credentials = new SigningCredentials(symmentricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
      var header = new JwtHeader(credentials);
      var payload = new jwtPayloca(user, null, null, null, DateTime.Today.AddDays(1));
      var securityToken = new JwtSecurityToken(header, payload);
      return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
    public string VerifyJwt()
    {
      return "";
    }
  }

}