﻿using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Abstractions;
using SchoolProject.Service.AuthServices.Implementations;
using SchoolProject.Service.AuthServices.Interfaces;
using SchoolProject.Service.Implementations;

namespace SchoolProject.Service
{
	public static class ModuleServiceDpendencies
	{
		public static IServiceCollection AddServiceDpendencies(this IServiceCollection services)
		{
			services.AddTransient<IStudentService, StudentService>();
			services.AddTransient<IDepartmentService, DepartmentService>();
			services.AddTransient<IAuthenticationService, AuthenticationService>();
			services.AddTransient<IAuthorizationServices, AuthorizationServices>();
			services.AddTransient<IEmailServices, EmailServices>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IInstructorService, InstructorService>();
			services.AddTransient<IFileService, FileService>();
			services.AddTransient<ICurrentUserServices, CurrentUserServices>();
			return services;
		}
	}
}
