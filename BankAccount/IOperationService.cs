using System.Collections.Generic;

namespace BankAccount
{
	public interface IOperationService
	{
		void Store(int amount);
		IEnumerable<IOperation> Operations { get; }
	}
}