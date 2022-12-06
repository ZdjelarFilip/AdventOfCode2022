string sample = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "input.txt"));

string SolveEasy(string input) => $"{Enumerable.Range(4, input.Length).First(i => input[(i - 4)..i].Distinct().Count() == 4)}";
string SolveHard(string input) => $"{Enumerable.Range(14, input.Length).First(i => input[(i - 14)..i].Distinct().Count() == 14)}";

Console.WriteLine("easy:" + SolveEasy(sample));
Console.WriteLine("hard:" + SolveHard(sample));