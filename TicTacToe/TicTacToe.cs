using System.Drawing;

public class TicTacToe
{
    enum STATE { GAME_RUNNING, GAME_END_WIN, GAME_END_LOSE, GAME_END_DRAW }

    int numinLineTowin;
    Tile[] lineToHighLight;

    STATE gameState;

    int height = 3;
    int width = 3;

    Tile[] tileList;

    int[] currentCursorPos = new int[2];
    public TicTacToe(int width, int height, int numinLineTowin = 3)
    {
        this.width = width;
        this.height = height;
        this.numinLineTowin = numinLineTowin;

        lineToHighLight = new Tile[numinLineTowin];

        gameState = STATE.GAME_RUNNING;

        tileList = new Tile[width * height];

        currentCursorPos[0] = width / 2; // x
        currentCursorPos[1] = height / 2; // y

        CreateTable();
    }
    void CheckGameState()
    {
        switch (gameState)
        {
            case STATE.GAME_END_WIN:
                HighLightLine(lineToHighLight);
                Console.SetCursorPosition(0, height);
                Console.WriteLine("PLAYER WIN!");
                WriteSave(gameState);
                Environment.Exit(0);
                break;
            case STATE.GAME_END_LOSE:
                HighLightLine(lineToHighLight);
                Console.SetCursorPosition(0, height);
                Console.WriteLine("PLAYER LOSE!");
                WriteSave(gameState);
                Environment.Exit(0);
                break;
            case STATE.GAME_END_DRAW:
                Console.SetCursorPosition(0, height);
                Console.WriteLine("GAME DRAW!");
                WriteSave(gameState);
                Environment.Exit(0);
                break;
        }
    }
    void CreateTable()
    {
        Console.Clear();
        int index = 0;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tileList[index] = new Tile(x, y);
                DrawTableTile(x, y);
                index++;
            }
        }
    }
    public void DrawTable()
    {
        Console.Clear();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                DrawTableTile(x, y);
            }
        }

        CheckGameState();
    }
    void DrawTableTile(int x, int y)
    {
        Tile tile = Array.Find(tileList, t => t.x == x && t.y == y);
        if (currentCursorPos[0] != x || currentCursorPos[1] != y)
        {
            if (tile?.tileType == Tile.TILETYPE.X)
            {
                DrawTile(x, y, ConsoleColor.Yellow, 'X');
            }
            else if (tile?.tileType == Tile.TILETYPE.O)
            {
                DrawTile(x, y, ConsoleColor.Yellow, 'O');
            }
            else
            {
                DrawTile(x, y, ConsoleColor.Yellow, ' ');
            }
        }
        else if (currentCursorPos[0] == x && currentCursorPos[1] == y)
        {
            if (tile?.tileType == Tile.TILETYPE.X)
            {
                DrawTile(x, y, ConsoleColor.Red, 'X');
            }
            else if (tile?.tileType == Tile.TILETYPE.O)
            {
                DrawTile(x, y, ConsoleColor.Red, 'O');
            }
            else
            {
                DrawTile(x, y, ConsoleColor.Blue, ' ');
            }
        }
    }
    public void DrawTile(int posX, int posY, ConsoleColor color, Char c)
    {
        Console.SetCursorPosition(posX, posY);
        Console.BackgroundColor = color;
        Console.Write(c);
        Console.ResetColor();
    }
    public void MoveCursorRight()
    {
        // x
        if (currentCursorPos[0] < width - 1)
        {
            currentCursorPos[0] += 1;
        }
    }
    public void MoveCursorLeft()
    {
        // x
        if (currentCursorPos[0] > 0)
        {
            currentCursorPos[0] -= 1;
        }
    }
    public void MoveCursorUp()
    {
        // y
        if (currentCursorPos[1] > 0)
        {
            currentCursorPos[1] -= 1;
        }
    }
    public void MoveCursorDown()
    {
        // y
        if (currentCursorPos[1] < height - 1)
        {
            currentCursorPos[1] += 1;
        }
    }
    public void SetTile()
    {
        Tile tile = Array.Find(tileList, t => t.x == currentCursorPos[0] && t.y == currentCursorPos[1]);

        if (tile == null || tile.tileType != Tile.TILETYPE.N) return;

        tile.tileType = Tile.TILETYPE.X;

        gameState = UpdateGameState(tile);

        if (gameState == STATE.GAME_RUNNING) BotSetTile();
    }
    void BotSetTile()
    {
        List<Tile> tmpTileList = new List<Tile>();

        foreach (Tile t in tileList)
        {
            if (t.tileType == Tile.TILETYPE.N) tmpTileList.Add(t);
        }

        if (tmpTileList.Count < 1) return;

        Random random = new Random();
        int r = random.Next(0, tmpTileList.Count);

        Tile tile = tmpTileList[r];

        tile.tileType = Tile.TILETYPE.O;
        gameState = UpdateGameState(tile);
    }
    STATE UpdateGameState(Tile tile)
    {
        if (CheckHorizontalLine(tile) && tile.tileType == Tile.TILETYPE.X) return STATE.GAME_END_WIN;
        if (CheckHorizontalLine(tile) && tile.tileType == Tile.TILETYPE.O) return STATE.GAME_END_LOSE;

        if (CheckVerticalLine(tile) && tile.tileType == Tile.TILETYPE.X) return STATE.GAME_END_WIN;
        if (CheckVerticalLine(tile) && tile.tileType == Tile.TILETYPE.O) return STATE.GAME_END_LOSE;

        if (CheckDiagonalLeftToRight(tile) && tile.tileType == Tile.TILETYPE.X) return STATE.GAME_END_WIN;
        if (CheckDiagonalLeftToRight(tile) && tile.tileType == Tile.TILETYPE.O) return STATE.GAME_END_LOSE;

        if (CheckDiagonalRightToLeft(tile) && tile.tileType == Tile.TILETYPE.X) return STATE.GAME_END_WIN;
        if (CheckDiagonalRightToLeft(tile) && tile.tileType == Tile.TILETYPE.O) return STATE.GAME_END_LOSE;

        if (CheckDraw()) return STATE.GAME_END_DRAW;

        return STATE.GAME_RUNNING;
    }

    void HighLightLine(Tile[] line)
    {
        foreach (Tile tile in line)
        {
            char c = ' ';
            if (tile.tileType == Tile.TILETYPE.X) c = 'X';
            else if (tile.tileType == Tile.TILETYPE.O) c = 'O';
            DrawTile(tile.x, tile.y, ConsoleColor.Green, c);
        }
    }

    bool CheckHorizontalLine(Tile tile)
    {
        int count = 0;

        Tile[] line = new Tile[numinLineTowin];
        int tileInLine = 0;

        for (int i = tile.x; i < width; i++)
        {
            Tile nextTile = Array.Find(tileList, t => t.x == i && t.y == tile.y);
            if (tile.tileType == nextTile.tileType)
            {
                line[tileInLine] = nextTile;
                tileInLine++;

                count++;
                continue;
            }
            break;
        }

        if (count < numinLineTowin)
        {
            for (int j = tile.x - 1; j >= 0; j--)
            {
                Tile previousTile = Array.Find(tileList, t => t.x == j && t.y == tile.y);
                if (tile.tileType == previousTile.tileType)
                {
                    line[tileInLine] = previousTile;
                    tileInLine++;

                    count++;
                    continue;
                }
                break;
            }
        }

        if (count >= numinLineTowin)
        {
            lineToHighLight = line;

            return true;
        }
        return false;
    }
    bool CheckVerticalLine(Tile tile)
    {
        int count = 0;

        Tile[] line = new Tile[numinLineTowin];
        int tileInLine = 0;

        for (int i = tile.y; i < height; i++)
        {
            Tile nextTile = Array.Find(tileList, t => t.x == tile.x && t.y == i);
            if (tile.tileType == nextTile?.tileType)
            {
                line[tileInLine] = nextTile;
                tileInLine++;

                count++;
                continue;
            }
            break;
        }

        if (count < numinLineTowin)
        {
            for (int j = tile.y - 1; j >= 0; j--)
            {
                Tile previousTile = Array.Find(tileList, t => t.x == tile.x && t.y == j);
                if (tile.tileType == previousTile.tileType)
                {
                    line[tileInLine] = previousTile;
                    tileInLine++;

                    count++;
                    continue;
                }
                break;
            }
        }

        if (count >= numinLineTowin)
        {
            lineToHighLight = line;

            return true;
        }
        return false;
    }
    bool CheckDiagonalLeftToRight(Tile tile)
    {
        int count = 0;

        Tile[] line = new Tile[numinLineTowin];
        int tileInLine = 0;

        for (int i = tile.x, j = tile.y; i < width && j < height; i++, j++)
        {
            Tile nextTile = Array.Find(tileList, t => t.x == i && t.y == j);
            if (tile.tileType == nextTile.tileType)
            {
                line[tileInLine] = nextTile;
                tileInLine++;

                count++;
                continue;
            }
            break;
        }

        if (count < numinLineTowin)
        {
            for (int i = tile.x - 1, j = tile.y - 1; i >= 0 && j >= 0; i--, j--)
            {
                Tile previousTile = Array.Find(tileList, t => t.x == i && t.y == j);
                if (tile.tileType == previousTile.tileType)
                {
                    line[tileInLine] = previousTile;
                    tileInLine++;

                    count++;
                    continue;
                }
                break;
            }
        }

        if (count >= numinLineTowin)
        {
            lineToHighLight = line;

            return true;
        }
        return false;
    }
    bool CheckDiagonalRightToLeft(Tile tile)
    {
        int count = 0;

        Tile[] line = new Tile[numinLineTowin];
        int tileInLine = 0;

        for (int i = tile.x + 1, j = tile.y - 1; i < width && j >= 0; i++, j--)
        {
            Tile nextTile = Array.Find(tileList, t => t.x == i && t.y == j);
            if (tile.tileType == nextTile.tileType)
            {
                line[tileInLine] = nextTile;
                tileInLine++;

                count++;
                continue;
            }
            break;
        }

        if (count < numinLineTowin)
        {
            for (int i = tile.x, j = tile.y; i >= 0 && j < height; i--, j++)
            {
                Tile previousTile = Array.Find(tileList, t => t.x == i && t.y == j);
                if (tile.tileType == previousTile.tileType)
                {
                    line[tileInLine] = previousTile;
                    tileInLine++;

                    count++;
                    continue;
                }
                break;
            }
        }

        if (count >= numinLineTowin)
        {
            lineToHighLight = line;

            return true;
        }
        return false;
    }
    bool CheckDraw()
    {
        foreach (Tile tile in tileList)
        {
            if (tile.tileType == Tile.TILETYPE.N) return false;
        }

        return true;
    }
    void WriteSave(STATE result)
    {
        string path = "save.txt";
        FileInfo info = new FileInfo(path);

        int[] score = new int[3];

        StreamReader reader = null;
        StreamWriter writer = null;

        try
        {
            if (info.Exists)
            {
                reader = new StreamReader(path);
                var file = reader.ReadToEnd();
                reader.Close();

                var lines = file.Split(new char[] { '\n' });

                for (int i = 0; i < lines.Count(); i++)
                {
                    string[] line = lines[i].Split(":");
                    score[i] = Int32.Parse(line[1]);
                }
            }

            writer = new StreamWriter(path);

            writer.WriteLine($"WIN: {(result == STATE.GAME_END_WIN ? score[0] + 1 : score[0])}");
            writer.WriteLine($"LOST: {(result == STATE.GAME_END_LOSE ? score[1] + 1 : score[1])}");
            writer.Write($"DRAW: {(result == STATE.GAME_END_DRAW ? score[2] + 1 : score[2])}");

            writer.Close();

        }
        catch (IOException e)
        {
            Console.WriteLine(e.StackTrace);
        }

    }
}
