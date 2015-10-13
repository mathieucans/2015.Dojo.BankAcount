using System;
using System.Text;
using System.Collections.Generic;
using BankAccount;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	/// <summary>
	/// Description résumée pour AccountServiceShould
	/// </summary>
	[TestClass]
	public class AccountServiceShould
	{
		[TestMethod]
		public void store_deposit_operation()
		{
			var operationService = A.Fake<IOperationService>();
			var accountService = new AccountService(operationService);

			// when
			int amount = 100;
			accountService.Deposit(amount);

			// then
			A.CallTo(() => operationService.Store(amount)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}
