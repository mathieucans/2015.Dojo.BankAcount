using System;
using System.Collections.Generic;
using BankAccount;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	[TestClass]
	public class AcceptanceTest
	{
		[TestMethod]
		public void AnAcceptanceTest()
		{
			List<string> output = new List<string>();
			
			var service = Create();
			service.Deposit(1000);
			service.Withdraw(100);
			service.Deposit(500);
			service.PrintStatement();

			CollectionAssert.AreEqual(
				new[]{
				"DATE|AMOUNT|BALANCE",
				"10/04/2015|500,00|1400,00",
				"02/04/2015|-100,00|900,00",
				"01/04/2015|1000,00|1000,00"}, 
				output);
		}

		private static AccountService Create()
		{
			var service = new AccountService(new OperationService(), new PrintService());
			return service;
		}
	}

	
}
