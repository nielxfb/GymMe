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

		public static Response<MsUser> RegisterUser(string username, string userEmail, DateTime userDob, string userGender, string userPassword, string confPassword)
		{
			string error = "";
			if (username == "" || userEmail == "" || userDob.Equals(DateTime.MinValue) || userGender == "" ||  userPassword == "" || confPassword == "")
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

			return UserHandler.RegisterUser(username, userEmail, userDob, userGender, "Customer", userPassword);
		}

	}
}