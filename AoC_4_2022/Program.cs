var gameData = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "input.txt"));

var easy = gameData
    .Select(x => x.Split(',')
        .Select(x => x.Split('-').Select(int.Parse))
        .Select(x => Enumerable.Range(x.First(), x.Last() - x.First() + 1))
        .OrderBy(x => x.Count()));

Console.WriteLine($"resultEasy: {easy.Select(group => group.First()
                                .All(i => group.First()
                                .Intersect(group.Last()).Contains(i)) ||
                                 group.Last()
                                .All(i => group.First()
                                .Intersect(group.Last()).Contains(i)))
                                .Select(i => Convert.ToInt32(i))
                                .Sum()}");

Console.WriteLine($"resultHard: {easy.Select(group => group.First()
                                .Any(i => group.First()
                                .Intersect(group.Last()).Contains(i)) ||
                                group.Last().Any(i => group.First()
                                .Intersect(group.Last()).Contains(i)))
                                .Select(i => Convert.ToInt32(i))
                                .Sum()}");