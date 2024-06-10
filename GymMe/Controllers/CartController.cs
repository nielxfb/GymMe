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
		public static Response<List<MsCart>> GetAllCarts(int userID)
		{
			if (userID == 0)
			{
				return new Response<List<MsCart>>(false, "User ID invalid", null);
			}

			return CartHandler.GetAllCarts(userID);
		}

		public static Response<MsCart> AddToCart(int userID, int supplementID, int quantity)
		{
			string error = "";
			if (userID == 0 || supplementID == 0 || quantity <= 0)
			{
				error = "Please input a valid ID";
			}
			else if (quantity <= 0)
			{
				error = "Quantity must be more than 0";
			}

			if (error != "")
			{
				return new Response<MsCart>(false, error, null);
			}

			return CartHandler.AddToCart(userID, supplementID, quantity);
		}

		public static Response<MsCart> CheckoutCart(int userID)
		{
			if (userID == 0)
			{
				return new Response<MsCart>(false, "User ID invalid", null);
			}

			return CartHandler.CheckoutCart(userID);
		}

		public static Response<MsCart> ClearCart(int userID)
		{
			if (userID == 0)
			{
				return new Response<MsCart>(false, "User ID invalid", null);
			}

			return CartHandler.ClearCart(userID);
		}
	}
}