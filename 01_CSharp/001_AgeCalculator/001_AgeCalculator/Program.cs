//17.07
//program nr1

Console.WriteLine("====================");
Console.WriteLine("Kalkulator wieku");
Console.WriteLine("====================");
Console.WriteLine();

Console.WriteLine("Jak masz na imię?");
string name = Console.ReadLine();

Console.WriteLine();
Console.WriteLine("Ile masz lat?");

int age = int.Parse(Console.ReadLine());

if (age < 18)
{
    Console.WriteLine("Jesteś niepełnoletni.");
}
else
{
    Console.WriteLine("Jesteś pełnoletni");
    Console.WriteLine();
}
Console.WriteLine("Który mamy rok?");
int year = int.Parse(Console.ReadLine());

Console.WriteLine();
Console.WriteLine("Cześć " + name + "!");
Console.WriteLine();
Console.WriteLine($"Urodziłeś się w {(year - age)} roku!");
Console.WriteLine();
Console.WriteLine("Za rok będziesz miał " + (age + 1) + " lat");
Console.WriteLine();
Console.WriteLine("Za 5 lat będziesz miał " + (age + 5) + " lat");
Console.WriteLine();
Console.WriteLine("Za 10 lat będziesz miał " + (age + 10) + " lat");

Console.WriteLine("Czy chcesz poznać swój wiek za 20 lat? (t/n)");
string answer = Console.ReadLine();

if (answer == "t")
{
    Console.WriteLine($"Za 20 lat będziesz miał {(age + 20)} lat!");
}