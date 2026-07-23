using System.Net;
using System.Security.Cryptography;

List<Expense> expenses = new List<Expense>();
bool isRunning = true;
Console.WriteLine("Welcome to Expense Tracker!");
Console.WriteLine();
while (isRunning)
{
    Console.WriteLine("1. Add expense");
    Console.WriteLine("2. Show all expenses");
    Console.WriteLine("3. Show expenses by category");
    Console.WriteLine("4. Show total expenses");
    Console.WriteLine("5. Remove expense");
    Console.WriteLine("6. Exit");
    Console.WriteLine();
    Console.WriteLine("Select option:");
    string? option = Console.ReadLine();
    switch (option)
    {
        case "1":
            AddExpense(expenses);
            break;

        case "2":
            ShowExpenses(expenses);
            break;

        case "3":
            ShowExpensesByCategory(expenses);
            break;

        case "4":
            ShowTotalExpenses(expenses);
            break;

        case "5":
            RemoveExpense(expenses);
            break;

        case "6":
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


void AddExpense(List<Expense> expenses)
{
    Console.WriteLine("Enter the expense description: ");
    string? description = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(description))
    {
        Console.WriteLine("Expense description cannot be empty");
        return;
    }
    Console.WriteLine("Enter the amount: ");
    string? amountInput = Console.ReadLine();

    if (!decimal.TryParse(amountInput, out decimal amount))
    {
        Console.WriteLine("Invalid amount.");
        return;
    }
    if (amount <= 0)
    {
        Console.WriteLine("Amount must be greater than zero.");
        return;
    }

    Console.WriteLine("Available categories:");
    Console.WriteLine("Food, Transport, Entertainment, Bills, Other");
    Console.WriteLine("Enter the category:");

    string? categoryInput = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(categoryInput))
    {
        Console.WriteLine("Category cannot be empty");
        return;
    }
    if (!Enum.TryParse<ExpenseCategory>(
    categoryInput,
    true,
    out ExpenseCategory category))
    {
        Console.WriteLine("Invalid category.");
        return;
    }

    Expense newExpense = new Expense(
        description,
        amount,
        category,
        DateTime.Now);

    expenses.Add(newExpense);

    Console.WriteLine("Expense added successfully.");


}
void ShowExpenses(List<Expense> expenses)
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("Your expense list is empty.");
        return;
    }
    Console.WriteLine("Your expenses:"); 

    for (int i = 0; i < expenses.Count; i++)
    {
        Console.WriteLine($"Expense {i + 1}:");
        Console.WriteLine($"Description: {expenses[i].Description}");
        Console.WriteLine($"Amount: {expenses[i].Amount:F2}");
        Console.WriteLine($"Category: {expenses[i].Category}");
        Console.WriteLine($"Date: {expenses[i].Date:dd.MM.yyyy}");
        Console.WriteLine();

    }
}
void ShowExpensesByCategory(List<Expense> expenses)
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("Your expense list is empty.");
        return;
    }

    Console.WriteLine("Available categories:");
    Console.WriteLine("Food, Transport, Entertainment, Bills, Other");
    Console.WriteLine("Enter the category:");

    string? input = Console.ReadLine();

    if (!Enum.TryParse<ExpenseCategory>(
        input,
        true,
        out ExpenseCategory selectedCategory))
    {
        Console.WriteLine("Invalid category.");
        return;
    }

    bool expenseFound = false;

    Console.WriteLine($"Expenses in category {selectedCategory}:");

    for (int i = 0; i < expenses.Count; i++)
    {
        if (expenses[i].Category == selectedCategory)
        {
            Console.WriteLine(
                $"{i + 1}. {expenses[i].Description} | " +
                $"Amount: {expenses[i].Amount:F2} | " +
                $"Date: {expenses[i].Date:dd.MM.yyyy}");

            expenseFound = true;
        }
    }

    if (!expenseFound)
    {
        Console.WriteLine("No expenses found in this category.");
    }
}
void ShowTotalExpenses(List<Expense> expenses)
{
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("Your expense list is empty.");
            return;
        }

        decimal total = 0;

        foreach (Expense expense in expenses)
        {
            total += expense.Amount;
        }
        Console.WriteLine($"Total expenses: {total:F2}");
    }
}
void RemoveExpense(List<Expense> expenses)
{
    if (expenses.Count == 0)
    {
        Console.WriteLine("Your expense list is empty.");
        return;
    }

    ShowExpenses(expenses);

    Console.WriteLine("Enter the number of the expense to remove:");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int expenseNumber))
    {
        Console.WriteLine("Invalid expense number.");
        return;
    }

    int index = expenseNumber - 1;

    if (index < 0 || index >= expenses.Count)
    {
        Console.WriteLine("Expense number does not exist.");
        return;
    }

    Expense removedExpense = expenses[index];
    expenses.RemoveAt(index);

    Console.WriteLine(
        $"Expense \"{removedExpense.Description}\" removed successfully.");
}