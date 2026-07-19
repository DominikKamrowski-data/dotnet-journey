Console.WriteLine("Welcome to the Simple Calculator!");
Console.WriteLine();

string another = "y";

while (another == "y")
{
    Console.WriteLine("Enter the first number:");
    double first = double.Parse(Console.ReadLine());

    Console.WriteLine();

    Console.WriteLine("Enter an operation (+, -, *, /)");
    string symbol = Console.ReadLine();

    Console.WriteLine("Enter the second number:");
    double second = double.Parse(Console.ReadLine());

    double result = 0;
    bool calculationSucceeded = true;


    switch (symbol)
    {
        case "+":
            result = Add(first, second);
            break;

        case "-":
            result = Subtract(first, second);
            break;

        case "*":
            result = Multiply(first, second);
            break;

        case "/":
            if (second == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                calculationSucceeded = false;
            }
            else
            {
                result = Divide(first, second);
            }
            break;

        default:
            Console.WriteLine("Invalid operation.");
            calculationSucceeded = false;
            break;
    }

    if (calculationSucceeded)
    {
        Console.WriteLine($"Result: {first} {symbol} {second} = {result:F2}");
    }

    Console.WriteLine();
    Console.WriteLine("Would you like to perform another calculation? (y/n)");
    another = Console.ReadLine().ToLower();

}
Console.WriteLine("Goodbye!");


double Add(double first, double second)
{
    return first + second;
}
double Subtract(double first, double second)
{
    return first - second;
}
double Multiply(double first, double second)
{
    return first * second;
}
double Divide(double first, double second)
{
    return first / second;
}
