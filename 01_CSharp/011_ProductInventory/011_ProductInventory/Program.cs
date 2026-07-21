List<Product> products = new List<Product>();
bool isRunning = true;

Console.WriteLine("Welcome to Product Inventory");
Console.WriteLine();

while (isRunning)
{
    Console.WriteLine("1. Add product");
    Console.WriteLine("2. Show products");
    Console.WriteLine("3. Restock product");
    Console.WriteLine("4. Sell product");
    Console.WriteLine("5. Show total inventory value");
    Console.WriteLine("6. Exit");
    Console.WriteLine();
    Console.WriteLine("Select option:");
    string? option = Console.ReadLine();
    switch (option)
    {
        case "1":
            AddProduct(products);
            break;

        case "2":
            ShowProducts(products);
            break;

        case "3":
            RestockProduct(products);
            break;

        case "4":
            SellProduct(products);
            break;

        case "5":
            InventoryValue(products);
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

void AddProduct(List<Product> products)
{
    Console.WriteLine("Enter the product name: ");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Product name cannot be empty.");
        return;
    }

    Console.WriteLine("Enter the product price: ");
    string? priceInput = Console.ReadLine();
    if (!decimal.TryParse(priceInput, out decimal price))
    {
        Console.WriteLine("Invalid price.");
        return;
    }

    if (price <= 0)
    {
        Console.WriteLine("Product price must be greater than zero.");
        return;
    }

    Console.WriteLine("Enter the product Quantity: ");

    string? quantityInput = Console.ReadLine();

    if (!int.TryParse(quantityInput, out int quantity))
    {
        Console.WriteLine("Invalid quantity.");
        return;
    }

    if (quantity < 0)
    {
        Console.WriteLine("Product quantity cannot be negative.");
        return;
    }

    Product newProduct = new Product(name, price, quantity);
    products.Add(newProduct);

    Console.WriteLine("Product added successfully.");
}
void ShowProducts(List<Product> products)
{
    if (products.Count == 0)
    {
        Console.WriteLine("Your product list is empty");
        return;
    }

    Console.WriteLine("Your products: ");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine(
                          $"{i + 1}. {products[i].Name} | " +
                          $"Price: {products[i].Price:F2} | " +
                          $"Quantity: {products[i].Quantity} | " +
                          $"Total value: {products[i].GetTotalValue():F2}");
    }
}

void RestockProduct(List<Product> products)
{
    if (products.Count == 0)
    {
        Console.WriteLine("Your product list is empty.");
        return;
    }

    ShowProducts(products);
    Console.WriteLine();

    Console.WriteLine("Enter the number of the product to restock:");
    string? productInput = Console.ReadLine();

    if (!int.TryParse(productInput, out int productNumber))
    {
        Console.WriteLine("Invalid product number.");
        return;
    }

    int index = productNumber - 1;

    if (index < 0 || index >= products.Count)
    {
        Console.WriteLine("Product number does not exist.");
        return;
    }

    Product productToRestock = products[index];

    Console.WriteLine("Enter the quantity to add:");
    string? amountInput = Console.ReadLine();

    if (!int.TryParse(amountInput, out int amount))
    {
        Console.WriteLine("Invalid quantity.");
        return;
    }

    bool restockSucceeded = productToRestock.Restock(amount);

    if (!restockSucceeded)
    {
        Console.WriteLine("Restock failed. The amount must be greater than zero.");
        return;
    }

    Console.WriteLine($"Product \"{productToRestock.Name}\" restocked successfully.");
    Console.WriteLine($"Current quantity: {productToRestock.Quantity}.");
}
void SellProduct(List<Product> products)
{
    if (products.Count == 0)
    {
        Console.WriteLine("Your product list is empty.");
        return;
    }

    ShowProducts(products);
    Console.WriteLine();

    Console.WriteLine("Enter the number of the product to sell:");
    string? productInput = Console.ReadLine();

    if (!int.TryParse(productInput, out int productNumber))
    {
        Console.WriteLine("Invalid product number.");
        return;
    }

    int index = productNumber - 1;

    if (index < 0 || index >= products.Count)
    {
        Console.WriteLine("Product number does not exist.");
        return;
    }

    Product productToSell = products[index];

    Console.WriteLine("Enter the quantity to sell:");
    string? amountInput = Console.ReadLine();

    if (!int.TryParse(amountInput, out int amount))
    {
        Console.WriteLine("Invalid quantity.");
        return;
    }

    bool sellSucceeded = productToSell.Sell(amount);

    if (!sellSucceeded)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Sale failed. The amount must be greater than zero.");
        }
        else
        {
            Console.WriteLine("Sale failed. Not enough products in stock.");
        }

        return;
    }

    Console.WriteLine($"Product \"{productToSell.Name}\" sold successfully.");
    Console.WriteLine($"Current quantity: {productToSell.Quantity}.");
}

void InventoryValue(List<Product> products)
{
    if (products.Count == 0)
    {
        Console.WriteLine("Your product list is empty.");
        return;
    }

    decimal totalValue = 0;

    foreach (Product product in products)
    {
        totalValue += product.GetTotalValue();
    }

    Console.WriteLine($"Total inventory value: {totalValue:F2}");
}
 
