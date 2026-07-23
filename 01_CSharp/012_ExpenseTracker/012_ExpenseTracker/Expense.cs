class Expense
{
    public string Description { get; }
    public decimal Amount { get; }
    public ExpenseCategory Category { get; }
    public DateTime Date { get; }

    public Expense(string description, decimal amount, ExpenseCategory category, DateTime date)
    {
        Description = description;
        Amount = amount;
        Category = category;
        Date = date;
    }
}


