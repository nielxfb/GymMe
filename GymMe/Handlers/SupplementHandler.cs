using GymMe.Factories;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace GymMe.Handlers
{
	public class SupplementHandler
	{
		public static Response<List<MsSupplement>> GetAllSupplements()
		{
			List<MsSupplement> supplements = SupplementRepository.GetAllSupplements();

			if (supplements.Count == 0)
			{
				return new Response<List<MsSupplement>>(false, "No supplements found", null);
			}

			return new Response<List<MsSupplement>>(true, "Supplements found", supplements);
		}

		public static Response<MsSupplement> AddSupplement(string name, DateTime expiry, int price, int typeID)
		{
			MsSupplement supplement = SupplementFactory.CreateSupplement(name, expiry, price, typeID);
			SupplementRepository.AddSupplement(supplement);
			return new Response<MsSupplement>(true, "Successfully added supplement", supplement);
		}

		public static Response<MsSupplement> UpdateSupplement(int id, string name, DateTime expiry, int price, int typeID)
		{
			MsSupplement oldSupplement = SupplementRepository.GetSupplementById(id);

			if (oldSupplement == null)
			{
				return new Response<MsSupplement>(false, "Supplement not found", null);
			}

			MsSupplement newSupplement = SupplementFactory.CreateSupplement(name, expiry, price, typeID);
			newSupplement.SupplementID = id;
			SupplementRepository.UpdateSupplement(newSupplement);

			return new Response<MsSupplement>(true, "Successfully updated supplement", newSupplement);
		}

		public static Response<MsSupplement> GetSupplementById(int id)
		{
			MsSupplement supplement = SupplementRepository.GetSupplementById(id);

			if (supplement == null)
			{
				return new Response<MsSupplement>(false, "Supplement not found", null);
			}

			return new Response<MsSupplement>(true, "Supplement found", supplement);
		}
	}
}