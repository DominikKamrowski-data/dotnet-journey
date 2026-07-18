Console.WriteLine("Welcome to BMI Calculator!");
Console.WriteLine();

Console.WriteLine("What is your name?");
string name = Console.ReadLine();
Console.WriteLine();

Console.WriteLine("Enter your weight in kilograms");
double weight = double.Parse(Console.ReadLine());
Console.WriteLine();

Console.WriteLine("Enter your height in centimeters");
double height = double.Parse(Console.ReadLine());
Console.WriteLine();

height = height / 100;

double bmi = weight / (height * height);
Console.WriteLine($"{name}, your BMI is {bmi:F2}.");
if (bmi < 18.5)
{
    Console.WriteLine("Category: Underweight");
}
else if (bmi < 25)
{
    Console.WriteLine("Category: Normal weight");
}
else if (bmi < 30)
{
    Console.WriteLine("Category: Overweight");
}
else 
{
    Console.WriteLine("Category: Obesity");
}