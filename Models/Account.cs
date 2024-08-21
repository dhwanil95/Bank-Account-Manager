namespace BankAccManagerApp.Models
{
    public class Account
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount, Currency currency)
        {
            Balance += amount / currency.ExchangeRateToCAD;
        }

        public void Withdraw(decimal amount, Currency currency)
        {
            // Convert the amount to CAD
            var amountInCAD = amount / currency.ExchangeRateToCAD;
            
            // Ensure sufficient balance
            if (Balance >= amountInCAD)
            {
                Balance -= amountInCAD;
            }
            else
            {
                // Handle the case where the balance is insufficient
                throw new InvalidOperationException("Insufficient funds.");
            }
        }
    }
}
