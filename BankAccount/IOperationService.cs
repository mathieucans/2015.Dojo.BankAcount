using System.Collections.Generic;

namespace BankAccount
{
	public interface IOperationService
	{
		void StoreDeposit(int amount);
		IEnumerable<IOperation> Operations { get; }
		void StoreWithdraw(int amount);
	}
}