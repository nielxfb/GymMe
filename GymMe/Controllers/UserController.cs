using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GymMe.Controllers
{
	public class UserController
	{
		public static Response<List<MsUser>> GetAllCustomers()
		{
			return UserHandler.GetAllCustomers();
		}

		public static Response<MsUser> LoginUser(string username, string password)
		{
			if (username == "" || password == "")
			{
				return new Response<MsUser>(false, "All fields are required", null);
			}

			return UserHandler.LoginUser(username, password);
		}

		private static bool IsAlphanumeric(string password)
		{
			foreach (char c in password)
			{
				if (!char.IsLetterOrDigit(c))
				{
					return false;
				}
			}
			return true;
		}

		public static Response<MsUser> RegisterUser(string username, string userEmail, string userDob, string userGender, string userPassword, string confPassword)
		{
			string error = "";
			if (username == "" || userEmail == "" || userDob == "" || userGender == "" ||  userPassword == "" || confPassword == "")
			{
				error = "All fields are required";
			}
			else if (username.Length < 5 || username.Length > 15)
			{
				error = "Username must be between 5 and 15 characters";
			}
			else if (!userEmail.EndsWith(".com"))
			{
				error = "Email must end with .com";
			}
			else if (userGender != "Male" && userGender != "Female")
			{
				error = "User gender invalid";
			}
			else if (!IsAlphanumeric(userPassword))
			{
				error = "Password must be alphanumeric";
			}
			else if (userPassword != confPassword)
			{
				error = "Passwords do not match";
			}

			if (error != "")
			{
				return new Response<MsUser>(false, error, null);
			}

			return UserHandler.RegisterUser(username, userEmail, DateTime.Parse(userDob), userGender, "Customer", userPassword);
		}

		public static Response<MsUser> GetUserById(int id)
		{
			if (id <= 0)
			{
				return new Response<MsUser>(false, "ID invalid", null);
			}

			return UserHandler.GetUserById(id);
		}

		public static Response<MsUser> UpdateUser(int id, string username, string userEmail, string userGender, DateTime userDob, string role, string userPassword, string confPassword)
		{
			string error = "";
			if (id <= 0 || username == "" || userEmail == "" || userDob.Equals(DateTime.MinValue) || userGender == "" || userPassword == "" || confPassword == "")
			{
				error = "All fields are required";
			}
			else if (username.Length < 5 || username.Length > 15)
			{
				error = "Username must be between 5 and 15 characters";
			}
			else if (!userEmail.EndsWith(".com"))
			{
				error = "Email must end with .com";
			}
			else if (userGender != "Male" && userGender != "Female")
			{
				error = "User gender invalid";
			}
			else if (!IsAlphanumeric(userPassword))
			{
				error = "Password must be alphanumeric";
			}
			else if (userPassword != confPassword)
			{
				error = "Passwords do not match";
			}

			if (error != "")
			{
				return new Response<MsUser>(false, error, null);
			}

			return UserHandler.UpdateUser(id, username, userEmail, userPassword, userDob, userGender, role);
		}

		public static Response<MsUser> LoginUserByCookie(string cookie)
		{
			if (cookie == "")
			{
				return new Response<MsUser>(false, "Cookie invalid", null);
			}

			return UserHandler.LoginUserByCookie(int.Parse(cookie));
		}
	}
}