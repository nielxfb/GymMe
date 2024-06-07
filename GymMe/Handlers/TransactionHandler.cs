using GymMe.Factories;
using GymMe.Models;
using GymMe.Modules;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handlers
{
	public class TransactionHandler
	{
		public static Response<List<TransactionHeader>> GetAllHeaders()
		{
			List<TransactionHeader> headers = TransactionRepository.GetAllHeaders();

			if (headers.Count == 0)
			{
				return new Response<List<TransactionHeader>>(false, "No transactions found", null);
			}

			return new Response<List<TransactionHeader>>(true, "Transactions found", headers);
		}

		public static Response<TransactionHeader> UpdateTransactionStatus(int id, string status)
		{
			TransactionHeader header = TransactionRepository.GetHeaderById(id);

			if (header == null)
			{
				return new Response<TransactionHeader>(false, "Transaction not found", null);
			}

			header.Status = status;

			TransactionRepository.UpdateTransactionHeader(header);

			return new Response<TransactionHeader>(true, "Successfully updated status", header);
		}

		public static Response<TransactionHeader> AddHeader(int userID, DateTime transactionDate, string status)
		{
			TransactionHeader header = TransactionFactory.CreateHeader(userID, transactionDate, status);
			TransactionRepository.AddHeader(header);
			return new Response<TransactionHeader>(true, "Successfully created header", header);
		}

		public static Response<TransactionDetail> AddDetail(int transactionID, int supplementID, int quantity)
		{
			TransactionHeader header = TransactionRepository.GetHeaderById(transactionID);

			if (header == null)
			{
				return new Response<TransactionDetail>(false, "Transaction not found", null);
			}

			TransactionDetail detail = TransactionFactory.CreateDetail(transactionID, supplementID, quantity);
			TransactionRepository.AddDetail(detail);
			return new Response<TransactionDetail>(true, "Successfully created detail", detail);
		}
	}
}