using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class UserRepository
	{

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
	}
}