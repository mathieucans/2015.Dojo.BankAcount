namespace BankAccount
{
	public interface IOperation
	{
		OperationType Type { get; set; }
		int Amount { get; set; }
	}

	public enum OperationType	
	{
		Deposit
	}
}