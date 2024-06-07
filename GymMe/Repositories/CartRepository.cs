using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class CartRepository
	{
		public static void AddToCart(MsCart cart)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			db.MsCarts.Add(cart);
			db.SaveChanges();
		}

		public static List<MsCart> GetAllCarts(int userID)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.MsCarts.Where(c => c.UserID == userID).ToList();
		}
	}
}