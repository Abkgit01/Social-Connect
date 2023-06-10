using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [Authorize]
        [HttpGet("GetUser/id")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _context.Users.FindAsync(id));
        }
    }
}
