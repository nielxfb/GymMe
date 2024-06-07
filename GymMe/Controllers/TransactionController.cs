﻿using GymMe.Handlers;
using GymMe.Models;
using GymMe.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controllers
{
	public class TransactionController
	{
		public static Response<List<TransactionHeader>> GetAllHeaders()
		{
			return TransactionHandler.GetAllHeaders();
		}

		public static Response<TransactionHeader> UpdateTransactionStatus(int id, string status)
		{
			string error = "";
			if (id == 0 || status == "")
			{
				error = "All fields are required";
			}
			else if (!status.Equals("Unhandled") && !status.Equals("Handled"))
			{
				error = "Status invalid";
			}

			if (error != "")
			{
				return new Response<TransactionHeader>(false, error, null);
			}

			return TransactionHandler.UpdateTransactionStatus(id, status);
		}

		public static Response<TransactionHeader> AddHeader(int userID, DateTime transactionDate, string status)
		{
			string error = "";
			if (userID == 0 || transactionDate.Equals(DateTime.MinValue) || status == "")
			{
				error = "All fields are required";
			}
			else if (!transactionDate.Equals(DateTime.Now))
			{
				error = "Transaction date must be today";
			}
			else if (!status.Equals("Unhandled"))
			{
				error = "Status invalid";
			}

			if (error != "")
			{
				return new Response<TransactionHeader>(false, error, null);
			}

			return TransactionHandler.AddHeader(userID, transactionDate, status);
		}

		public static Response<TransactionDetail> AddDetail(int transactionID, int supplementID, int quantity)
		{
			if (transactionID == 0 || supplementID == 0 || quantity == 0)
			{
				return new Response<TransactionDetail>(false, "All fields are required", null);
			}

			return TransactionHandler.AddDetail(transactionID, supplementID, quantity);
		}
	}
}