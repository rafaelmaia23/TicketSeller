using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketSeller.Models.Models;
using TicketSeller.Models.Tokens;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class LoginTokenService : ILoginTokenService
{
    public LoginToken CreateLoginToken(User user, string? role)
    {
        Claim[] userClaims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Role, role),
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            "obL[}*Q1*Q[Yu1c5]'-Y'p;kmV,XyKGC/Vn(b@4Shd?%YPM*mF,yc:jrqra=.BM")
            );
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            claims: userClaims,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.AddHours(1)
            );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new LoginToken(tokenString);
    }
}
