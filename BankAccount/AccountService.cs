namespace BankAccount
{
	public class AccountService : IAccountService
	{
		private IOperationService _operationService;
		private IPrintService _printService;

		public AccountService(IOperationService operationService, IPrintService printService)
		{
			_operationService = operationService;
			_printService = printService;
		}

		public void Deposit(int amount)
		{
			_operationService.StoreDeposit(amount);
		}

		public void Withdraw(int amount)
		{
			_operationService.StoreWithdraw(amount);
		}

		public void PrintStatement()
		{
			_printService.Print(_operationService.Operations);
		}
	}
}