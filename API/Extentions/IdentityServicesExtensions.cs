using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extentions
{
	public static class IdentityServicesExtensions
	{
		public static IServiceCollection IdentityServices(this IServiceCollection Services, IConfiguration configuration)
		{
			Services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ClockSkew = TimeSpan.Zero,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value)),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			return Services;
		}
	}
}
