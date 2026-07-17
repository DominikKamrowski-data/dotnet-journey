Console.WriteLine("=========================");
Console.WriteLine("Wypożyczalnia samochodów");
Console.WriteLine("=========================");
Console.WriteLine();

Console.WriteLine("Jak masz na imię?");
string name = Console.ReadLine();
Console.WriteLine();

Console.WriteLine("Ile masz lat?");
int age = int.Parse(Console.ReadLine());
Console.WriteLine();

Console.WriteLine("Czy masz prawo jazdy? (t/n)");
string drivingLicense = Console.ReadLine();
drivingLicense = drivingLicense.ToLower();
Console.WriteLine();

Console.WriteLine("Czy masz dowód osobisty? (t/n)");
string identityCard = Console.ReadLine();
identityCard = identityCard.ToLower();

Console.WriteLine();

if (age >= 18 && drivingLicense == "t" && identityCard == "t")
{
    Console.WriteLine($"{name}, możesz wypożyczyć samochód");
}
else
{
    Console.WriteLine($"{name}, nie możesz wypożyczyć samochodu");
}
