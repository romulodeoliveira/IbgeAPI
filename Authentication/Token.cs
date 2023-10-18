using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IbgeApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace IbgeApi.Authentication;

public class Token
{
    public string Key = "Q8$e*mZYUoNho#@w3FsCBZj8#wZB&m";
    public string CreateToken(User user, IConfiguration configuration)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Key));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}