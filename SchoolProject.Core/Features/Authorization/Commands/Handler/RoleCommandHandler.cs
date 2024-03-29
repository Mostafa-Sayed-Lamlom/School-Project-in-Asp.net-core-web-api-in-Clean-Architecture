﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstractions;

namespace SchoolProject.Core.Features.Authorization.Commands.Handler
{
	public class RoleCommandHandler : ResponseHandler,
									  IRequestHandler<AddRoleCommand, Response<string>>,
									  IRequestHandler<EditRoleCommand, Response<string>>,
									  IRequestHandler<DeleteRoleCommand, Response<string>>,
									  IRequestHandler<UpdateUserRolesCommand, Response<string>>
	{
		#region Fields
		private readonly IStringLocalizer<SharResources> _stringLocalizer;
		private readonly IMapper _mapper;
		private readonly IAuthorizationServices _authorizationService;
		private readonly UserManager<SchoolProject.Data.Identity.User> _userManager;
		#endregion

		#region Constructors
		public RoleCommandHandler(IMapper mapper,
								  IAuthorizationServices authorizationService,
								  UserManager<SchoolProject.Data.Identity.User> userManager,
		IStringLocalizer<SharResources> stringLocalizer) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_mapper = mapper;
			_userManager = userManager;
			_authorizationService = authorizationService;
		}
		#endregion

		#region Haundels Functions
		public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
		{
			var result = await _authorizationService.AddRoleAsync(request.RoleName);
			if (result == "Success") return Success("");
			return BadRequest<string>(_stringLocalizer[SharedResourcesKey.AddFailed]);
		}

		public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
		{
			var result = await _authorizationService.EditRoleAsync(request.roleName, request.id);
			if (result == "notFound") return NotFound<string>();
			else if (result == "Success") return Success("");
			else if (result == "isExist") return BadRequest<string>("Name is already Exist");
			else
				return BadRequest<string>(result);
		}

		public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
		{
			var resultofDeletedRole = await _authorizationService.DeleteRoleAsync(request.id);
			if (resultofDeletedRole == "NotFound") return NotFound<string>();
			else if (resultofDeletedRole == "Success") return Success("");
			else if (resultofDeletedRole == "Used") return BadRequest<string>("This role is used with users");
			else
				return BadRequest<string>(resultofDeletedRole);
		}

		public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.userId.ToString());
			if (user == null) return NotFound<string>("user id not found");

			var userOldRoles = await _userManager.GetRolesAsync(user);
			var result = await _userManager.RemoveFromRolesAsync(user, userOldRoles);
			if (!result.Succeeded) return BadRequest<string>("Faild to remove old user roles");

			var userNewRoles = request.roles.Where(r => r.hasRole == true).Select(r => r.roleName);
			var resultOfAddingRoles = await _userManager.AddToRolesAsync(user, userNewRoles);
			if (resultOfAddingRoles.Succeeded)
				return Success("");
			return BadRequest<string>("Faild to update user roles");
		}
		#endregion
	}
}
