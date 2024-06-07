using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class SupplementTypeRepository
	{
		public static List<MsSupplementType> GetAllTypes()
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsSupplementTypes.ToList();
		}
	}
}