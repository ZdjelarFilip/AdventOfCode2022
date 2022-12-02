var gameData = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "input.txt")).ToList();

List<GameResult> gameResultsEasy = new();
List<GameResult> gameResultsHard = new();

foreach (string line in gameData)
{
    if (line[0] == 'A' && line[2] == 'X') gameResultsEasy.Add(new GameResult(line[0], line[2], 3 + 1));
    if (line[0] == 'A' && line[2] == 'Y') gameResultsEasy.Add(new GameResult(line[0], line[2], 6 + 2));
    if (line[0] == 'A' && line[2] == 'Z') gameResultsEasy.Add(new GameResult(line[0], line[2], 0 + 3));

    if (line[0] == 'B' && line[2] == 'X') gameResultsEasy.Add(new GameResult(line[0], line[2], 0 + 1));
    if (line[0] == 'B' && line[2] == 'Y') gameResultsEasy.Add(new GameResult(line[0], line[2], 3 + 2));
    if (line[0] == 'B' && line[2] == 'Z') gameResultsEasy.Add(new GameResult(line[0], line[2], 6 + 3));

    if (line[0] == 'C' && line[2] == 'X') gameResultsEasy.Add(new GameResult(line[0], line[2], 6 + 1));
    if (line[0] == 'C' && line[2] == 'Y') gameResultsEasy.Add(new GameResult(line[0], line[2], 0 + 2));
    if (line[0] == 'C' && line[2] == 'Z') gameResultsEasy.Add(new GameResult(line[0], line[2], 3 + 3));
}

foreach (string line in gameData)
{
    if (line[0] == 'A' && line[2] == 'X') gameResultsHard.Add(new GameResult(line[0], line[2], 0 + 3));
    if (line[0] == 'A' && line[2] == 'Y') gameResultsHard.Add(new GameResult(line[0], line[2], 3 + 1));
    if (line[0] == 'A' && line[2] == 'Z') gameResultsHard.Add(new GameResult(line[0], line[2], 6 + 2));

    if (line[0] == 'B' && line[2] == 'X') gameResultsHard.Add(new GameResult(line[0], line[2], 0 + 1));
    if (line[0] == 'B' && line[2] == 'Y') gameResultsHard.Add(new GameResult(line[0], line[2], 3 + 2));
    if (line[0] == 'B' && line[2] == 'Z') gameResultsHard.Add(new GameResult(line[0], line[2], 6 + 3));

    if (line[0] == 'C' && line[2] == 'X') gameResultsHard.Add(new GameResult(line[0], line[2], 0 + 2));
    if (line[0] == 'C' && line[2] == 'Y') gameResultsHard.Add(new GameResult(line[0], line[2], 3 + 3));
    if (line[0] == 'C' && line[2] == 'Z') gameResultsHard.Add(new GameResult(line[0], line[2], 6 + 1));
}

Console.WriteLine($"resultEasy: {gameResultsEasy.Select(x => x.Score).Sum()}");
Console.WriteLine($"resultHard: {gameResultsHard.Select(x => x.Score).Sum()}");

public class GameResult
{
    public char Col1 { get; set; }
    public char Col2 { get; set; }
    public int Score { get; set; }

    public GameResult(char Col1, char Col2, int Score)
    {
        this.Col1 = Col1;
        this.Col2 = Col2;
        this.Score = Score;
    }
}