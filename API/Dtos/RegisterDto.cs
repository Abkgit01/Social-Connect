﻿using System.ComponentModel.DataAnnotations;

namespace API.Dtos
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
