﻿using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Identity
{
	public class User : IdentityUser<int>
	{
		public User()
		{
			UserRefreshTokens = new HashSet<UserRefreshToken>();
		}
		public string FullName { get; set; }
		public string? Address { get; set; }
		public string? Country { get; set; }
		[InverseProperty(nameof(UserRefreshToken.user))]
		public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }
	}
}
