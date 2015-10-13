using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
		private IOperationService _operationService;
		private IPrintService _printService;

		[TestInitialize]
		public void TestInitialize()
		{
			_operationService = A.Fake<IOperationService>();
			_printService = A.Fake<IPrintService>();
		}

		[TestMethod]
		public void store_deposit_operation()
		{
			var accountService = Create();

			// when
			int amount = 100;
			accountService.Deposit(amount);

			// then
			A.CallTo(() => _operationService.Store(amount)).MustHaveHappened(Repeated.Exactly.Once);
		}

		private AccountService Create()
		{
			var accountService = new AccountService(_operationService, _printService);
			return accountService;
		}

		[TestMethod]
		public void give_all_operations_to_statement_printer()
		{
			var operationList = A.Fake<IEnumerable<IOperation>>();
			A.CallTo(() => _operationService.Operations).Returns(operationList);
			var accountServce = Create();

			accountServce.PrintStatement();

			A.CallTo(() => _printService.Print(operationList)).MustHaveHappened(Repeated.Exactly.Once);
		}
	}
}
