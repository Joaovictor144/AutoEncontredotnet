using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoEncontredotnet.Entities;
using Microsoft.IdentityModel.Tokens;

namespace AutoEncontredotnet.Core.Services
{
	public class TokenService
	{
		public static object GenerateToken(User user)
		{
			var key = Encoding.ASCII.GetBytes(Key.Secret);

            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("username", user.Username),
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString
            };
        }
	}
}

