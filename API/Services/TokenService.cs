﻿using API.Interfaces;
using API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
	public class TokenService : ITokenService
	{
		private readonly SymmetricSecurityKey _key;
		public TokenService(IConfiguration config)
		{
			_key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection("AppSettings:Token").Value));
		}

		public string CreateToken(AppUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
			};
			var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(2),
				SigningCredentials = creds,

			};
			var tokenHandler = new JwtSecurityTokenHandler();

			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);

		}
	}
}
