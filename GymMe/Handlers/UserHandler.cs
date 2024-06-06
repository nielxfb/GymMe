﻿using GymMe.Factories;
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
		public static Response<List<MsUser>> GetAllCustomers()
		{
			List<MsUser> users = UserRepository.GetAllCustomers();

			if (users.Count == 0)
			{
				return new Response<List<MsUser>>(false, "No users found", null);
			}

			return new Response<List<MsUser>>(true, "Users found", users);
		}

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

		public static Response<MsUser> GetUserById(int id)
		{
			MsUser user = UserRepository.GetUserById(id);

			if (user == null)
			{
				return new Response<MsUser>(false, "User not found", null);
			}

			return new Response<MsUser>(true, "User found", user);
		}

		public static Response<MsUser> UpdateUser(int id, string username, string email, string password, DateTime dob, string gender, string role)
		{
			MsUser user = UserRepository.GetUserById(id);

			if (user == null)
			{
				return new Response<MsUser>(false, "User not found", null);
			}

			MsUser newUser = UserFactory.CreateUser(username, email, dob, gender, role, password);
			newUser.UserID = id;

			UserRepository.UpdateUser(newUser);

			return new Response<MsUser>(true, "Successfully updated user!", newUser);
		}

		public static Response<MsUser> LoginUserByCookie(int cookieValue)
		{
			MsUser user = UserRepository.GetUserById(cookieValue);

			if (user == null)
			{
				return new Response<MsUser>(false, "User not found", null);
			}

			return new Response<MsUser>(true, "Login success", user);
		}
	}
}