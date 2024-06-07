using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controllers
{
	public class CartController
	{
		public static Response<MsCart> AddToCart(int userID, int supplementID, int quantity)
		{
			if (userID == 0 || supplementID == 0 || quantity == 0)
			{
				return new Response<MsCart>(false, "Please input a valid ID", null);
			}

			return CartHandler.AddToCart(userID, supplementID, quantity);
		}

		public static Response<Boolean> CheckoutCart(int userID)
		{
			if (userID == 0)
			{
				return new Response<Boolean>(false, "User ID invalid", false);
			}

			return CartHandler.CheckoutCart(userID);
		}
	}
}