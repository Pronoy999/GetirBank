using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GetirBank.Authentication
{
    public class Authentication : IAuthentication
    {
        private readonly IConfiguration _configuration;

        public Authentication(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetToken(string id)
        {
            var key = _configuration.GetSection("Jwt").GetValue<string>("Key");
            var issuer = _configuration.GetSection("Jwt").GetValue<string>("Issuer");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("id", id)
            };
            var token = new JwtSecurityToken(issuer, issuer,
                claims, expires: DateTime.Now.AddMinutes(240), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}