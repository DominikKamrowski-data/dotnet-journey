int[] scores = new int[5];

Console.WriteLine("Welcome to the Grade Analyzer!");

for (int i = 0; i < scores.Length; i++)
{
    Console.WriteLine($"Enter score {i + 1}:");
    scores[i] = int.Parse(Console.ReadLine());
}
int sum = 0;
int lowestScore = scores[0];
int highestScore = scores[0];
foreach (int score in scores)
{
    sum += score;

    if (score < lowestScore)
    {
        lowestScore = score;
    }

    if (score > highestScore)
    {
        highestScore = score;
    }
}
double averageScore = (double)sum / scores.Length;
string result;
if (averageScore >= 60)
{
    result = "Passed";
}
else
{
    result = "Failed";
}
Console.WriteLine($"Average score: {averageScore:F2}");
Console.WriteLine($"Highest score: {highestScore}");
Console.WriteLine($"Lowest score: {lowestScore}");
Console.WriteLine();
Console.WriteLine($"Final Result: {result}");