using System.Collections.Generic;

namespace BankAccount
{
	public interface IPrintService
	{
		void Print(IEnumerable<IOperation> operationList);
	}
}