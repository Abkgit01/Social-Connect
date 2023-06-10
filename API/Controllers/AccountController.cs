using API.Data;
using API.Dto_s;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
	public class AccountController : BaseApiController
	{
		private readonly DataContext _context;

		private ITokenService _tokenService;

		public AccountController(DataContext context, ITokenService tokenService)
		{
			_context = context;
			_tokenService = tokenService;
		}

		[HttpPost]
		[Route("Register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			if(await UserExist(registerDto.UserName))  return BadRequest("User already taken");

			using var hmac = new HMACSHA512();
			var user = new AppUser()
			{
				UserName = registerDto.UserName.ToLower(),
				PasswordHash = hmac.ComputeHash(Encoding.ASCII.GetBytes(registerDto.Password)),
				PasswordSalt = hmac.Key
			};
			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return new UserDto
			{
				UserName = registerDto.UserName,
				Token = _tokenService.CreateToken(user)
			};
		}

		[HttpPost("Login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto request)
		{
			var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
			if (user == null) return BadRequest("User does not exist");

			using var hmac = new HMACSHA512(user.PasswordSalt);

			var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
			for (int i = 0; i < ComputedHash.Length; i++)
			{
				if (ComputedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
			}

			return new UserDto
			{
				UserName = request.UserName,
				Token = _tokenService.CreateToken(user)
			};
		}

		private async Task<bool> UserExist(string username)
		{
			return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
		}
	}
}
