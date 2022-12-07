using System.IO;

var gameData = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "input.txt")).ToArray();

Console.WriteLine($"resultEasy: {Part1(gameData)}");
Console.WriteLine($"resultHard: {Part2(gameData)}");

int Part1(string[] lines)
{
    var directories = ExecuteCommands(lines);
    var size = directories.Where(kv => kv.Value.Size <= 100_000).Sum(kv => kv.Value.Size);
    return size;
}

int Part2(string[] lines)
{
    var directories = ExecuteCommands(lines);

    var usedSpace = directories["/"].Size;
    var freeSpaceNeeded = 30_000_000;
    var freeSpace = 70_000_000 - usedSpace;
    var toDeleteSpace = freeSpaceNeeded - freeSpace;

    var delDir = directories.Where(kv => kv.Value.Size >= toDeleteSpace).MinBy(x => x.Value.Size);

    return delDir.Value.Size;
}

Dictionary<string, DirectoryItem> ExecuteCommands(string[] commands)
{
    var currentPath = "";
    var directories = new Dictionary<string, DirectoryItem>();

    var i = 0;
    for (; i < commands.Length; i++)
    {
        var cmd = commands[i][0..4];

        switch (cmd)
        {
            case "$ cd": ChangeDirectory(commands[i][5..]); break;
            case "$ ls": ListDirectory(); break;
            default: throw new Exception();
        }
    }

    return directories;

    void ChangeDirectory(string path)
    {
        switch (path)
        {
            case "/": currentPath = "/"; break;

            case "..":
                {
                    currentPath = currentPath[0..currentPath.LastIndexOf('/')];
                    if (string.IsNullOrEmpty(currentPath))
                    {
                        currentPath = "/";
                    }
                }
                break;

            default: currentPath += "/" + path; break;
        }
    }

    void ListDirectory()
    {
        if (!directories.TryGetValue(currentPath, out var directoryItem))
        {
            directoryItem = new DirectoryItem(currentPath);
            directories[currentPath] = directoryItem;
        }

        i++;
        for (; i < commands.Length && commands[i][0] != '$'; i++)
        {
            var cmd = commands[i];
            var fileItem = ParseFileItem(cmd);
            directoryItem.Items.Add(fileItem);

            if (fileItem is DirectoryItem)
            {
                directories[currentPath + "/" + fileItem.Name] = (DirectoryItem)fileItem;
            }
        }
        i--;

        IFileItem ParseFileItem(string cmd)
        {
            if (cmd.StartsWith("dir "))
            {
                return new DirectoryItem(cmd[4..]);
            }
            else
            {
                var parts = cmd.Split(' ');
                int fileSize = int.Parse(parts[0]);
                var fileName = parts[1];
                return new FileItem(fileName, fileSize);
            }
        }
    }
}

interface IFileItem
{
    public string Name { get; }
    public int Size { get; }
}

record FileItem(string Name, int Size) : IFileItem;

class DirectoryItem : IFileItem
{
    public string Name { get; }
    public int Size => Items.Sum(x => x.Size);
    public List<IFileItem> Items { get; } = new();

    public DirectoryItem(string name)
    {
        Name = name;
    }
}
