﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Identity;
using SchoolProject.Service.AuthServices.Interfaces;

namespace SchoolProject.Service.AuthServices.Implementations
{
	public class CurrentUserServices : ICurrentUserServices
	{
		#region Fields
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<User> _userManager;
		#endregion
		#region Constructors
		public CurrentUserServices(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
		{
			_httpContextAccessor = httpContextAccessor;
			_userManager = userManager;
		}
		#endregion
		#region Functions
		public int GetUserId()
		{
			var userId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "UserId").Value;
			if (userId == null)
			{
				throw new UnauthorizedAccessException();
			}
			return int.Parse(userId);
		}

		public async Task<User> GetUserAsync()
		{
			var userId = GetUserId();
			var user = await _userManager.FindByIdAsync(userId.ToString());
			if (user == null)
			{ throw new UnauthorizedAccessException(); }
			return user;
		}

		public async Task<List<string>> GetCurrentUserRolesAsync()
		{
			var user = await GetUserAsync();
			var roles = await _userManager.GetRolesAsync(user);
			return roles.ToList();
		}
		#endregion
	}
}