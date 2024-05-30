using GymMe.Factories;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handlers
{
	public class UserHandler
	{

		public static Response<MsUser> LoginUser(string username, string password)
		{
			MsUser user = UserRepository.GetUserByUsername(username);

			if (user == null)
			{
				return new Response<MsUser>(false, "User not found", null);
			}

			if (!user.UserPassword.Equals(password))
			{
				return new Response<MsUser>(false, "Password is incorrect", null);
			}

			return new Response<MsUser>(true, "Login success", user);
		}

		public static Response<MsUser> RegisterUser(string username, string userEmail, DateTime userDOB, string userGender, string userRole, string userPassword)
		{
			MsUser user = UserFactory.CreateUser(username, userEmail, userDOB, userGender, userRole, userPassword);
			UserRepository.AddUser(user);
			return new Response<MsUser>(true, "Successfully registered", user);
		}

	}
}