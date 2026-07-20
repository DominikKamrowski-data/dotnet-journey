class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner)
    {
        Owner = owner;
        Balance = 0;
    }

    public bool Deposit(decimal amount)
    {
        if (amount <= 0)
        {  return false; }

         Balance += amount;
         return true;
    }

    public bool Withdraw(decimal amount)
    {
        if(amount <= 0 || amount > Balance) 
        { 
            return false; 
        }

         Balance -= amount;
         return true;
    }
}