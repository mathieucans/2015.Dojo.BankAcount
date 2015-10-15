using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BankAccount;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountTest
{
	[TestClass]
	public class OperationServiceShould
	{
		[TestMethod]
		public void create_and_add_deposit_operation_in_operations_list()
		{
			var operationService = new OperationService();
			int amount = 100;
			operationService.StoreDeposit(amount);

			var lastOperation = operationService.Operations.Last();
			Assert.AreEqual(OperationType.Deposit, lastOperation.Type);
			Assert.AreEqual(amount, lastOperation.Amount);
		}
	}


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
			A.CallTo(() => _operationService.StoreDeposit(amount)).MustHaveHappened(Repeated.Exactly.Once);
		}


		[TestMethod]
		public void store_withdraw_operation()
		{
			var accountService = Create();

			// when
			int amount = 100;
			accountService.Withdraw(amount);

			// then
			A.CallTo(() => _operationService.StoreWithdraw(amount)).MustHaveHappened(Repeated.Exactly.Once);
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
