using System;
using System.Collections.Generic;

namespace BankAccount
{
	public class PrintService : IPrintService
	{
		public void Print(IEnumerable<IOperation> operationList)
		{
			throw new NotImplementedException();
		}
	}
}