﻿using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class UserRepository
	{
		public static List<MsUser> GetAllCustomers()
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsUsers.Where(u => u.UserRole.Equals("Customer")).ToList();
		}

		public static MsUser GetUserByUsername(string username)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsUsers.Where(u => u.UserName.Equals(username)).ToList().FirstOrDefault();
		}

		public static void AddUser(MsUser user)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			db.MsUsers.Add(user);
			db.SaveChanges();
		}

		public static MsUser GetUserById(int id)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsUsers.Find(id);
		}

		public static void UpdateUser(MsUser newUser)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			MsUser oldUser = db.MsUsers.Find(newUser.UserID);
			oldUser.UserName = newUser.UserName;
			oldUser.UserEmail = newUser.UserEmail;
			oldUser.UserDOB = newUser.UserDOB;
			oldUser.UserGender = newUser.UserGender;
			oldUser.UserRole = newUser.UserRole;
			oldUser.UserPassword = newUser.UserPassword;
			db.SaveChanges();
		}


	}
}