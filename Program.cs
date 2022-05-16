
int gridWidth = 115;
int gridHeight = 25;

char[] line1 = new char[gridWidth];
char[] line2 = new char[gridWidth];
char[] line3 = new char[gridWidth];
char[] line4 = new char[gridWidth];
char[] line5 = new char[gridWidth];
char[] line6 = new char[gridWidth];
char[] line7 = new char[gridWidth];
char[] line8 = new char[gridWidth];
char[] line9 = new char[gridWidth];
char[] line10 = new char[gridWidth];
char[] line11 = new char[gridWidth];
char[] line12 = new char[gridWidth];
char[] line13 = new char[gridWidth];
char[] line14 = new char[gridWidth];
char[] line15 = new char[gridWidth];
char[] line16 = new char[gridWidth];
char[] line17 = new char[gridWidth];
char[] line18 = new char[gridWidth];
char[] line19 = new char[gridWidth];
char[] line20 = new char[gridWidth];
char[] line21 = new char[gridWidth];
char[] line22 = new char[gridWidth];
char[] line23 = new char[gridWidth];
char[] line24 = new char[gridWidth];
char[] line25 = new char[gridWidth];
char[][] grid = new char[][] {line1, line2, line3, line4, line5, line6, line7, line8, line9, line10, line11, line12, line13, line14, line15, line16, line17, line18, line19, line20, line21, line22, line23, line24, line25 };
Random random = new Random();
int count;
int r;

Console.ForegroundColor = ConsoleColor.Green;

//start whole grid gen.
for (int i = 0; i < gridHeight; i++)
{

    //generate one line at start
    for(int j = 0; j < gridWidth; j++)
    {
        r = random.Next(1, 5);
        if (r == 1)
        {
            grid[i][j] = '#';
        }
        else
        {
            grid[i][j] = ' ';
        }
    }
    Console.WriteLine(grid[i]);
}

Thread.Sleep(200);

for (int frames = 0; frames < 790; frames++) 
{

    //iterate 2d grid
    for (int i = 0; i < gridHeight; i++)
    {
        

        //contents of one line
        for (int j = 0; j < gridWidth; j++)
        {
            count = 0;
            if (grid[i][j] == '+') { grid[i][j] = ' '; } //kill
            if (grid[i][j] == 'k') { grid[i][j] = '#'; } //bring to life
                                                         //normal 
            if (j > 0 && (grid[i][j - 1] == '#' || grid[i][j - 1] == '+') ) { count++; } //x- axis      full or dying counts   past #_
            if (j < gridWidth - 1 && (grid[i][j + 1] == '#' || grid[i][j + 1] == 'k')) { count++; } //x+ axis    birth counts as alive   future  #@

            if ((j > 0 && i > 0) && (grid[i-1][j - 1] == '#' || grid[i-1][j - 1] == '+')) { count++; } //x- and y axis -     full or dying counts   past?
            if ((i < gridHeight - 1 && j > 0) && (grid[i + 1][j - 1] == '#' || grid[i + 1][j - 1] == 'k')) { count++; } //x- and y axis +     full or dying counts  future?

            if ((i>0 && j < gridWidth - 1) && (grid[i - 1][j + 1] == '#' || grid[i - 1][j + 1] == '+')) { count++; } //x+ and y axis +     full or dying counts  past?
            if ((i< gridHeight-1 && j<gridWidth-1) && (grid[i + 1][j + 1] == '#' || grid[i + 1][j + 1] == 'k')) { count++; } //x+ and y axis +     full or dying counts  future?

            if (i > 0 && (grid[i - 1][j] == '#' || grid[i-1][j] == '+')) { count++; } //y axis -   full or dying counts   past?
            if (i < gridHeight-1 && (grid[i + 1][j] == '#' || grid[i + 1][j] == 'k')) { count++; } //y axis +  birth last round as alive  future?

            if (grid[i][j] == '#' && (count < 2 || count > 3)) { grid[i][j] = '+'; } //dying _
            else if (grid[i][j] == ' ' && (count == 3)) { grid[i][j] = 'k'; } //birthing @  rep , with space
        }

        Console.WriteLine(grid[i]);
    }

    Thread.Sleep(50);
    Console.Clear();
}

