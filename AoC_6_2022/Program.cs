string gameData = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "input.txt"));

Console.WriteLine("easy:" + $"{Enumerable.Range(4, gameData.Length).First(i => gameData[(i - 4)..i].Distinct().Count() == 4)}");
Console.WriteLine("easy:" + $"{Enumerable.Range(14, gameData.Length).First(i => gameData[(i - 14)..i].Distinct().Count() == 14)}");