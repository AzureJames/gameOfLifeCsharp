
int gridWidth = 115;
int gridHeight = 16;

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
char[][] grid = new char[][] {line1, line2, line3, line4, line5, line6, line7, line8, line9, line10, line11, line12, line13, line14, line15, line16 };
Random random = new Random();
int count;
int r;

Console.ForegroundColor = ConsoleColor.Green;

//start grid gen.
for (int i = 0; i < gridHeight; i++)
{

    //generate one line at start
    for(int j = 0; j < gridWidth; j++)
    {
        r = random.Next(1, 3);
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


for (int k = 0; k < 390; k++) //k frames to iterate
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

            //check all changing
         /*   if (j > 0 && (grid[i][j - 1] == '#' || grid[i][j - 1] == '@')) { count++; } //x axis -
            if (j < gridWidth - 1 && (grid[i][j + 1] == '#' || grid[i][j + 1] == '@')) { count++; } //x axis +
            if (i > 0 && (grid[i - 1][j] == '#' || grid[i - 1][j] == '@')) { count++; } //y axis -
            if (i < gridHeight - 1 && (grid[i + 1][j] == '#' || grid[i + 1][j] == '@')) { count++; } //y axis +
         */

            if (grid[i][j] == '#' && (count < 2 || count > 3)) { grid[i][j] = '+'; } //dying _
            else if (grid[i][j] == ' ' && (count == 3)) { grid[i][j] = 'k'; } //birthing @  rep , with space
        }

        Console.WriteLine(grid[i]);
    }

    Thread.Sleep(50);
    Console.Clear();
}


  /*
bool​ ​isBorder​(​int​ y, ​int​ x)
 ​{ 
 ​    ​if​(x <​0​|| y <​0​){​return​ ​true​; } 
 ​    ​if​(x == GRIDX || y == GRIDY){​return​ ​true​; } 
 ​    ​return​ ​false​; 
 ​} 
  
 ​void​ ​printGrid​(​char​ grid[GRIDY][GRIDX])
 ​{ 
 ​    ​for​(​short​ y =​0​; y < GRIDY; y++) 
 ​        {​for​(​short​ x =​0​; x < GRIDX; x++) 
 ​                { 
 ​                    ​putchar​(grid[y][x]); 
 ​                } 
 ​            ​putchar​(​'​\n​'​); 
 ​        } 
 ​} 
  
 ​int​ ​surroundings​(​char​ grid[GRIDY][GRIDX],​int​ y, ​int​ x)
 ​{​short​ theLiving =​0​; 
 ​    ​for​(​short​ j = -​1​; j <​2​; j++) 
 ​        { 
 ​            ​for​(​short​ i = -​1​; i <​2​; i++) 
 ​                { 
 ​                    ​if​(j ==​0​&& i ==​0​){​continue​; }​//​if myself skip 
 ​                    ​if​(​isBorder​(y + j, x + i)){​continue​; }​//​if OutOfBounds skip 
 ​                    ​if​(grid[y + j][x + i] == LIVE){ theLiving = theLiving +​1​; } 
 ​                } 
 ​        } 
 ​    ​return​ theLiving; 
 ​} 

 ​void​ ​lifeCycle​(​short​ cycles,​char​ grid[​2​][GRIDY][GRIDX])
 ​{​short​ flips =​0​; 
 ​    ​for​(​short​ c =​0​; c < cycles; c++) 
 ​        { 
 ​            ​for​(​short​ y =​0​; y < GRIDY; y++) 
 ​                { 
 ​                    ​for​(​short​ x =​0​; x < GRIDX; x++) 
 ​                        { 
 ​                           ​short​ sur = ​surroundings​(grid[flips], y, x); 
 ​                            ​switch​(grid[flips][y][x])
 ​                                { 
 ​                                ​case​ LIVE: 
 ​                                    ​if​(!(sur ==​2​ || sur ==​3​)) 
 ​                                        { grid[​1​-flips][y][x] = DEAD; } 
 ​                                    ​else
 ​                                        { grid[​1​-flips][y][x] = LIVE; } 
 ​                                    ​break​; 
 ​                                ​case​ DEAD: 
 ​                                    ​if​(sur ==​3​){ grid[​1​-flips][y][x] = LIVE; } 
 ​                                    ​else
 ​                                        { grid[​1​-flips][y][x] = DEAD; } 
 ​                                    ​break​; 
 ​                                } 
 ​                        } 
  
 ​                } 
 ​             flips =​1​-flips; 
 ​        } 
 ​    ​printGrid​(grid[flips]); 
 ​} 
  
 ​int​ ​main​(​int​ argc, ​char​ * argv[])
 ​{ 
 ​    ​if​(argc <​3​)
 ​        {​printf​(​"​To few arguments exiting..​\n​"​);​return​ -​1​; } 
 ​    ​if​(argc>​3​) 
 ​        {​printf​(​"​Too many arguments at ​%d​ args exiting..​\n​"​,argc-​1​);​return​ -​1​;} 
  
 ​    ​char​ **inputGrid=​parse_life​(argv[​1​]); 
 ​    ​char​ grids[​2​][​24​][​80​]; 
 ​    ​short​ flips=​0​; 
 ​     
 ​    ​for​(​short​ y=​0​;y<GRIDY;y++) 
 ​        {​for​ (​short​ x=​0​ ;x<GRIDX;x++) 
 ​                {   grids[​1​-flips][y][x]=DEAD; 
 ​                    grids[flips][y][x]=inputGrid[y][x]; 
 ​                }​// fills grid ​
 ​        } 
  
 ​     
 ​    ​lifeCycle​(​atof​(argv[​2​]),grids);​//​atof taken from page 251of k&r <stdlib.h> 
 ​    ​return​ ​0​; 
 ​}

*/