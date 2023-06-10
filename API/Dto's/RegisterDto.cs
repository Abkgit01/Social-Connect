using System.ComponentModel.DataAnnotations;

namespace API.Dto_s
{
	public class RegisterDto
	{
		[Required]
        public string UserName { get; set; }
		
		[Required]
		public string Password { get; set; }
    }
}
