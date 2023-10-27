using System.IdentityModel.Tokens.Jwt;
namespace Notepad.Interface

{
  public interface IJwtService
  {
    string Generatejwt(Guid Id);
    JwtSecurityToken VerifyJwt(string token);
  }
}