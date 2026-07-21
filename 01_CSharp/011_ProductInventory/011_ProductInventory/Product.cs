class Product
{
    public string Name { get; }
    public decimal Price { get; }
    public int Quantity { get; private set; }

    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public bool Restock(int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        Quantity += amount;
        return true;
    }

    public bool Sell(int amount)
    {
        if (amount <= 0 || amount > Quantity)
        {
            return false;
        }
        Quantity -= amount;
        return true;
    }
    public decimal GetTotalValue()
    {
        return Price * Quantity;
    }
}