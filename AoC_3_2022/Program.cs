using System.Collections.Immutable;

var gameData = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "input.txt")).ToList();

static int CalculateAlphabet(char c)
{
    return c % 32 + (char.IsUpper(c) ? 26 : 0);
}

var easy = gameData
    .Select(x => x
        .Chunk(x.Length / 2)
        .Select(y => y.ToImmutableHashSet())
            .Aggregate((a, b) => a.Intersect(b))
            .First()).Sum(CalculateAlphabet);

var hard = gameData
    .Select(x => x.ToImmutableHashSet())
        .Chunk(3)
        .Select(y => y.Aggregate((a, b) => a.Intersect(b)).First())
            .Sum(CalculateAlphabet);

Console.WriteLine($"resultEasy: {easy}");
Console.WriteLine($"resultEasy: {hard}");