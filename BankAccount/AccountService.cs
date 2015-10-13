using System;

namespace BankAccount
{
	public class AccountService : IAccountService
	{
		private IOperationService _operationService;

		public AccountService(IOperationService operationService)
		{
			_operationService = operationService;
		}

		public void Deposit(int amount)
		{
			_operationService.Store(amount);
		}

		public void Withdraw(int amount)
		{
		}

		public void PrintStatement()
		{
		}
	}
}