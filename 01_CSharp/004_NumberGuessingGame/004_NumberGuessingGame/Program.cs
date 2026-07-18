Console.WriteLine("Welcome to the Number Guessing Game!");
Console.WriteLine("I have selected a number between 1 and 100.");
Random random = new Random();
int secretNumber = random.Next(1, 101);
Console.WriteLine();
Console.WriteLine("Enter your guess:");
int attempts = 0;
int userNumber = 0;
while (userNumber != secretNumber)
{
    userNumber = int.Parse(Console.ReadLine());
    attempts++;
    if (userNumber > secretNumber)
    {
        Console.WriteLine("Too high!");
        Console.WriteLine("Try again:");
    }
    else if (userNumber < secretNumber)
    {
        Console.WriteLine("Too low!");
        Console.WriteLine("Try again:");
    }
}
if (attempts == 1)
{
    Console.WriteLine($"Correct! The secret number was {secretNumber}. You guessed it in {attempts} attempt.");
}
else
{
    Console.WriteLine($"Correct! The secret number was {secretNumber}. You guessed it in {attempts} attempts.");
}