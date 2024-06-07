using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class SupplementRepository
	{
		public static List<MsSupplement> GetAllSupplements()
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsSupplements.ToList();
		}

		public static void AddSupplement(MsSupplement supplement)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			db.MsSupplements.Add(supplement);
			db.SaveChanges();
		}

		public static MsSupplement GetSupplementById(int id)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsSupplements.Find(id);
		}

		public static void UpdateSupplement(MsSupplement newSupplement)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			MsSupplement oldSupplement = db.MsSupplements.Find(newSupplement.SupplementID);
			oldSupplement.SupplementName = newSupplement.SupplementName;
			oldSupplement.SupplementExpiryDate = newSupplement.SupplementExpiryDate;
			oldSupplement.SupplementPrice = newSupplement.SupplementPrice;
			oldSupplement.SupplementTypeID = newSupplement.SupplementTypeID;
			db.SaveChanges();
		}
	}
}