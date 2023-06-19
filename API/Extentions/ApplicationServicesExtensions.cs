using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extentions
{
	public static class ApplicationServicesExtensions
	{
		public static IServiceCollection ApplicationServices(this IServiceCollection Services, IConfiguration configuration)
		{

			Services.AddDbContext<DataContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			Services.AddScoped<ITokenService, TokenService>();
			Services.AddScoped<IUserRepository, UserReposotory>();
			Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			return Services;
		}
	}
}
