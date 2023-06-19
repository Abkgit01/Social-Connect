using API.Data;
using API.Dtos;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UsersController(IUserRepository userRepository, IMapper mapper)
        {
			this._userRepository = userRepository;
			this._mapper = mapper;
		}

        [AllowAnonymous]
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();
            return Ok(users);

		}

        [Authorize]
        [HttpGet("GetUser/username")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }

		[HttpGet("SeedMethod")]
		public async Task<IActionResult> SeedMethod(DataContext context) 
        {
            try
            {
				await Seed.SeedUsers(context);
			}catch (Exception ex)
            {

            }
            return Ok();
        }
    }
}
