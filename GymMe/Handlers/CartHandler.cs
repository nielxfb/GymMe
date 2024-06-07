using GymMe.Controllers;
using GymMe.Factories;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace GymMe.Handlers
{
	public class CartHandler
	{
		public static Response<MsCart> AddToCart(int userID, int supplementID, int quantity)
		{
			MsCart cart = CartFactory.CreateCart(userID, supplementID, quantity);
			CartRepository.AddToCart(cart);
			return new Response<MsCart>(true, "Successfully added to cart", cart);
		}

		public static Response<Boolean> CheckoutCart(int userID)
		{
			List<MsCart> carts = CartRepository.GetAllCarts(userID);

			if (carts.Count == 0)
			{
				return new Response<Boolean>(false, "No carts found", false);
			}

			Response<TransactionHeader> responseHeader = TransactionController.AddHeader(userID, DateTime.Now, "Unhandled");

			if (!responseHeader.Success)
			{
				return new Response<Boolean>(false, responseHeader.Message, false);
			}

			foreach (MsCart cart in carts)
			{
				Response<TransactionDetail> responseDetail = TransactionController.AddDetail(responseHeader.Data.TransactionID, cart.SupplementID, cart.Quantity);

				if (!responseDetail.Success)
				{
					return new Response<Boolean>(false, responseDetail.Message, false);
				}
			}

			return new Response<Boolean>(true, "Successfully checkout cart!", true);
		}
	}
}