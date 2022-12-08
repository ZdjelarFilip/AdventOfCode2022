var gameData = File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(), "input.txt")).ToArray();

do_work(gameData);

void do_work(string[] lines)
{
    int[,] left_max = new int[lines.Length, lines[0].Length];
    int[,] right_max = new int[lines.Length, lines[0].Length];
    int[,] top_max = new int[lines.Length, lines[0].Length];
    int[,] bottom_max = new int[lines.Length, lines[0].Length];
    int width = lines[0].Length;
    for (int i = 0; i < lines.Length; i++)
    {
        left_max[i, 0] = int.Parse(lines[i][0].ToString());
        right_max[i, width - 1] = int.Parse(lines[i][width - 1].ToString());
        for (int j = 1; j < lines[i].Length; j++)
        {
            left_max[i, j] = Math.Max(int.Parse(lines[i][j - 1].ToString()), left_max[i, j - 1]);
        }

        for (int j = lines[i].Length - 2; j >= 0; j--)
        {
            right_max[i, j] = Math.Max(int.Parse(lines[i][j + 1].ToString()), right_max[i, j + 1]);
        }
    }

    for (int i = 0; i < width; i++)
    {
        top_max[0, i] = int.Parse(lines[0][i].ToString());
        bottom_max[lines.Length - 1, i] = int.Parse(lines[lines.Length - 1][i].ToString());
        for (int j = 1; j < lines.Length; j++)
        {
            top_max[j, i] = Math.Max(int.Parse(lines[j - 1][i].ToString()), top_max[j - 1, i]);
        }

        for (int j = lines.Length - 2; j >= 0; j--)
        {
            bottom_max[j, i] = Math.Max(int.Parse(lines[j + 1][i].ToString()), bottom_max[j + 1, i]);
        }
    }

    int res = 0;
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            int val = int.Parse(lines[i][j].ToString());

            if (i == 0 || i == lines.Length - 1 || j == 0 || j == lines[i].Length - 1)
            {
                res++;
            }
            else if (val > left_max[i, j] || val > right_max[i, j]
                || val > top_max[i, j] || val > bottom_max[i, j])
            {
                res++;
            }
        }
    }
    Console.WriteLine(res);

    int max = 0;
    for (int i = 0; i < lines.Length; i++)
    {
        for (int j = 0; j < lines[i].Length; j++)
        {
            int val = int.Parse(lines[i][j].ToString());
            int left = 0;
            int right = 0;
            int up = 0;
            int down = 0;

            for (int l = j - 1; l >= 0; l--)
                if (val >= int.Parse(lines[i][l].ToString()))
                {
                    left++;
                    if (val == int.Parse(lines[i][l].ToString()))
                        break;
                }
            for (int r = j + 1; r < lines[0].Length; r++)
                if (val >= int.Parse(lines[i][r].ToString()))
                {
                    right++;
                    if (val == int.Parse(lines[i][r].ToString()))
                        break;
                }

            for (int u = i - 1; u >= 0; u--)
                if (val >= int.Parse(lines[u][j].ToString()))
                {
                    up++;
                    if (val == int.Parse(lines[u][j].ToString()))
                        break;
                }

            for (int d = i + 1; d < lines.Length; d++)
                if (val >= int.Parse(lines[d][j].ToString()))
                {
                    down++;
                    if (val == int.Parse(lines[d][j].ToString()))
                        break;
                }
            max = Math.Max(max, left * right * up * down);
        }
    }
    Console.WriteLine(max);
}