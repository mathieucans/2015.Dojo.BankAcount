using System.Collections.Generic;
using BankAccount;

namespace BankAccountTest
{
	public class OperationService : IOperationService
	{
		public void StoreDeposit(int amount)
		{
			
		}

		public IEnumerable<IOperation> Operations { get; private set; }
		public void StoreWithdraw(int amount)
		{
			
		}
	}
}