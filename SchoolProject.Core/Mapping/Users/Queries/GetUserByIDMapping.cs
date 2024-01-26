﻿using SchoolProject.Core.Features.User.Queries.Results;
using SchoolProject.Data.Identity;

namespace SchoolProject.Core.Mapping.Users
{
	public partial class UserProfile
	{
		public void GetUserByIDMapping()
		{
			CreateMap<User, GetUserByIDResponse>();
		}
	}
}
