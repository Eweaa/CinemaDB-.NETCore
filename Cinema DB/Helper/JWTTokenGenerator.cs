using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cinema_DB.Helper
{
    public class JWTTokenGenerator
    {
        public static string Generate(string userId, string userName)
        {
            List<Claim> claims = new();
            claims.Add(new Claim("UserId", userId));
            claims.Add(new Claim("UserName", userName));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_123456"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
