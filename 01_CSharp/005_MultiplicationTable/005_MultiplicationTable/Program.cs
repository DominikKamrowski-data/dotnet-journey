Console.WriteLine("Welcome to the Multiplication Table!");
Console.WriteLine();

string another = "y";

while (another == "y")
{
    Console.WriteLine("Enter a number:");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine($"Multiplication table for {number}");


    for (int i = 1; i <= 10; i++)
    {
        int multiplied = number * i;
        Console.WriteLine($"{number} x {i} = {multiplied}");
    }

    Console.WriteLine("Would you like to generate another table? (y/n)");
    another = Console.ReadLine().ToLower();
}

Console.WriteLine("Goodbye!");
