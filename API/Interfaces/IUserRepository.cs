using API.Dtos;
using API.Models;

namespace API.Interfaces
{
	public interface IUserRepository
	{
		void Update(AppUser user);
		Task<IEnumerable<AppUser>> GetUsersAsync();
		Task<AppUser> GetUserByIdAsync(int id);
		Task<AppUser> GetUserByUsernameAsync(string username);
		Task<bool> SaveAllChnagesAsync(string username);
		Task<MemberDto> GetMemberAsync(string username);
		Task<IEnumerable<MemberDto>> GetMembersAsync();
	}
}
