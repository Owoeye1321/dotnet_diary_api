using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Notepad.Interface;

namespace Notepad.Helpers
{
  public class JwtService : IJwtService
  {

    //Authentication via jwt is written here
    private string securityKey = "hello world what exactly is happening";
    public string Generatejwt(Guid id)
    {
      var symmentricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
      var credentials = new SigningCredentials(symmentricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
      var header = new JwtHeader(credentials);
      var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
      var securityToken = new JwtSecurityToken(header, payload);
      return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
    public JwtSecurityToken VerifyJwt(string jwt)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(securityKey);
      tokenHandler.ValidateToken(jwt, new TokenValidationParameters
      {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false
      }, out SecurityToken validatedToken);

      return (JwtSecurityToken)validatedToken;
    }
  }

}