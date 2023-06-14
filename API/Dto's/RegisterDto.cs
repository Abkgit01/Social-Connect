using System.ComponentModel.DataAnnotations;

namespace API.Dto_s
{
	public class RegisterDto
	{
		[Required]
        public string UserName { get; set; }
		
		[Required]
		[StringLength(8), MinLength(4)]
		public string Password { get; set; }
    }
}
