using System.Collections.Generic;
using BankAccount;

namespace BankAccountTest
{
	public class OperationService : IOperationService
	{
		public void Store(int amount)
		{
			
		}

		public IEnumerable<IOperation> Operations { get; private set; }
	}
}