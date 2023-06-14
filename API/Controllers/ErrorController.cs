using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	public class ErrorController : BaseApiController
	{
		private readonly DataContext _context;

		public ErrorController(DataContext context)
		{
			this._context = context;
		}

		[Authorize]
		[HttpGet("auth")]
		public ActionResult<string> GetSecret()
		{
			return "secret text";
		}

		[HttpGet("not-found")]
		public ActionResult<AppUser> GetNotFount()
		{
			var user = _context.Users.Find(-1);
			if (user == null) return NotFound();
			return Ok(user);
		}
		[HttpGet("server-error")]
		public ActionResult<string> GetServerError()
		{
			var user = _context.Users.Find(-1);
			var UserToReturn = user.ToString();
			return UserToReturn;
		}

		[HttpGet("bad-request")]
		public ActionResult<string> GetBadRequest()
		{
			return BadRequest("This is not a good request");
		}

	}
}
