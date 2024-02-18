﻿namespace SchoolProject.Data.AppMetaData
{
	public static class Router
	{
		public const string root = "Api";
		public const string version = "V1";
		public const string Rule = root + "/" + version + "/";
		public const string singleRoute = "{id}";
		public static class StudentRouting
		{
			public const string Prefix = Rule + "Student/";
			public const string List = Prefix + "List";
			public const string GetById = Prefix + singleRoute;
			public const string Create = Prefix + "Create";
			public const string Edit = Prefix + "Edit";
			public const string Delete = Prefix + singleRoute;
			public const string Paginated = Prefix + "Paginated";
		}
		public static class DepartmentRouting
		{
			public const string Prefix = Rule + "Department/";
			public const string GetById = Prefix + "Id";
		}
		public static class UserRouting
		{
			public const string Prefix = Rule + "User/";
			public const string Create = Prefix + "Create";
			public const string Paginated = Prefix + "Paginated";
			public const string GetById = Prefix + singleRoute;
			public const string Edit = Prefix + "Edit";
			public const string Delete = Prefix + singleRoute;
			public const string ChangePassword = Prefix + "Change-Password";
		}

		public static class AuthenticationRouting
		{
			public const string Prefix = Rule + "Authentication/";
			public const string SignIn = Prefix + "Sign-In";
			public const string IsValidToken = Prefix + "Is-Valid-Token";
			public const string RefreshToken = Prefix + "Generate-Refresh-Token";
		}

		public static class AuthoriztionRouting
		{
			public const string Prefix = Rule + "Authorization/";
			public const string AddRole = Prefix + "Add-Role";
			public const string EditRole = Prefix + "Edit-Role";
			public const string DeleteRole = Prefix + "Delete-Role/" + singleRoute;
			public const string GetRolesList = Prefix + "Get-Roles-List";
			public const string GetRoleById = Prefix + "Get-Role-By-Id/" + singleRoute;
			public const string ManageUserRoles = Prefix + "Manage-User-Roles/" + singleRoute;
			public const string UpdateUserRoles = Prefix + "Update-User-Roles";
		}
	}
}
