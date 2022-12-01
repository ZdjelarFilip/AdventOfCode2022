List<string> data = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "input.txt")).ToList();
List<int> sums = new();

int calories;
int sum = 0;

foreach (string line in data)
{
    if (int.TryParse(line, out calories))
    {
        sum += calories;
    }
    else
    {
        sums.Add(sum);
        sum = 0;
    }
}

Console.WriteLine($"resultEasy: {sums.Max()}");
Console.WriteLine($"resultHard: {sums.OrderByDescending(x => x).Take(3).Sum()}");
