static class Program
{
    static void Main()
    {
        var gameData = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "input.txt"));
        Console.WriteLine($"easy: {HillClimb.ProcessEasy(gameData)}");
        Console.WriteLine($"hard: {HillClimb.ProcessHard(gameData)}");
    }
}