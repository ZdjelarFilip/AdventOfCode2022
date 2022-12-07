var gameData = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "input.txt"));

var index = Array.FindIndex(gameData, x => x.StartsWith(" 1"));
var first = gameData.Take(index).ToArray();
var second = gameData.Skip(index + 2).ToArray();

var stackEnum = gameData[index].Split(" ", StringSplitOptions.RemoveEmptyEntries);
var stackList = new List<Stack<char>>();

foreach (var s in stackEnum)
{
    stackList.Add(new Stack<char>());
}

foreach (var row in first.Reverse())
{
    for (int i = 0; i < stackList.Count; i++)
    {
        var pick = row[1 + (i * 4)];
        if (pick == ' ')
            continue;
        stackList[i].Push(pick);
    }
}

foreach (var row in second)
{

    var move = row.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    var i = int.Parse(move[1]);
    while (i > 0)
    {
        var pick = stackList[int.Parse(move[3]) - 1].Pop();
        stackList[int.Parse(move[5]) - 1].Push(pick);
        i--;
    }

}
Console.Write("easy: ");
foreach (var stack in stackList)
{
    Console.Write(stack.Pop());
}
Console.WriteLine();

for (int i = 0; i < stackList.Count(); i++)
{
    stackList[i].Clear();
}

foreach (var row in first.Reverse())
{
    for (int i = 0; i < stackList.Count; i++)
    {
        var pick = row[1 + (i * 4)];
        if (pick == ' ')
            continue;
        stackList[i].Push(pick);
    }
}

foreach (var row in second)
{
    var picker = new Stack<char>();
    var move = row.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    var i = int.Parse(move[1]);
    while (i > 0)
    {
        var pick = stackList[int.Parse(move[3]) - 1].Pop();
        picker.Push(pick);
        i--;
    }
    while (picker.Count() > 0)
    {
        stackList[int.Parse(move[5]) - 1].Push(picker.Pop());
    }

}
Console.Write("Hard: ");
foreach (var stack in stackList)
{
    Console.Write(stack.Pop());
}