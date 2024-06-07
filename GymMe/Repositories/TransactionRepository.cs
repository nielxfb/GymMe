using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
	public class TransactionRepository
	{
		public static List<TransactionHeader> GetAllHeaders()
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.TransactionHeaders.ToList();
		}

		public static TransactionHeader GetHeaderById(int id)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			return db.TransactionHeaders.Find(id);
		}

		public static void UpdateTransactionHeader(TransactionHeader newTransaction)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			TransactionHeader oldTransaction = db.TransactionHeaders.Find(newTransaction.TransactionID);
			oldTransaction.UserID = newTransaction.UserID;
			oldTransaction.TransactionDate = newTransaction.TransactionDate;
			oldTransaction.Status = newTransaction.Status;
			db.SaveChanges();
		}

		public static void AddHeader(TransactionHeader header)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			db.TransactionHeaders.Add(header);
			db.SaveChanges();
		}

		public static void AddDetail(TransactionDetail detail)
		{
			LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
			db.TransactionDetails.Add(detail);
			db.SaveChanges();
		}
	}
}