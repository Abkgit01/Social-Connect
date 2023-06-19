using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace API.Data
{
	public static class Seed
	{
		public static async Task SeedUsers(DataContext context)
		{

			var userData = await File.ReadAllTextAsync("Data/UserSeed.json");
			var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

			foreach (var user in users)
			{
				using var hmac = new HMACSHA512();

				user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
				user.PasswordSalt = hmac.Key;

				context.Users.Add(user);
			}
			await context.SaveChangesAsync();
		}
	}
}
