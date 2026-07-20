

Console.WriteLine("Whats your name?");
string owner = Console.ReadLine();
if (string.IsNullOrWhiteSpace(owner))
{
    Console.WriteLine("Contact name cannot be empty.");
    return;
}
BankAccount account = new BankAccount(owner);

bool isRunning = true;
while (isRunning)
{
    Console.WriteLine("1. Deposit money");
    Console.WriteLine("2. Withrdaw money");
    Console.WriteLine("3. Show account information");
    Console.WriteLine("4. Exit");
    Console.WriteLine();
    Console.WriteLine("Select option:");
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            DepositMoney(account);
            break;

        case "2":
            WithdrawMoney(account);
            break;

        case "3":
            ShowAccount(account);
            break;

        case "4":
            isRunning = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
    if (isRunning)
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the main menu...");
        Console.ReadLine();
        Console.Clear();
    }
}
Console.WriteLine("Goodbye!");


void DepositMoney(BankAccount account)
{
    Console.WriteLine("Enter the amount to deposit:");
    string input = Console.ReadLine();

    if (!decimal.TryParse(input, out decimal amount))
    {
        Console.WriteLine("Invalid amount.");
        return;
    }

    bool depositSucceeded = account.Deposit(amount);

    if (depositSucceeded)
    {
        Console.WriteLine($"Deposit successful. Current balance: {account.Balance:F2}");
    }
    else
    {
        Console.WriteLine("Deposit failed. The amount must be greater than zero.");
    }
}
void WithdrawMoney(BankAccount account)
{
    Console.WriteLine("Enter the amount to withdraw:");
    string input = Console.ReadLine();
    if (!decimal.TryParse(input, out decimal amount))
    {
        Console.WriteLine("Invalid amount.");
        return;
    }

    bool withdrawSucceeded = account.Withdraw(amount);

    if (withdrawSucceeded)
    {
        Console.WriteLine($"Withdrawal successful. Current balance: {account.Balance:F2}");
    }
    else if (amount <= 0)
    {
        Console.WriteLine("Withdrawal failed. The amount must be greater than zero.");
    }
    else
    {
        Console.WriteLine("Withdrawal failed. You cannot withdraw more than your current balance.");
    }
}
void ShowAccount(BankAccount account)
{
    Console.WriteLine($"Owner: {account.Owner}");
    Console.WriteLine($"Balance: {account.Balance:F2}");
}