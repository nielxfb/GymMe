using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class DatabaseSingleton
	{

		private static LocalDatabaseEntities _instance;

		public static LocalDatabaseEntities GetInstance()
		{
			return _instance ?? (_instance = new LocalDatabaseEntities());
		}

	}
}