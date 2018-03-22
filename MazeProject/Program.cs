using System;
using AI;
using System.Windows.Forms;

namespace MazeProject
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            char[,] maze = generateMaze();
            Maze m = new Maze(maze);
            Application.Run(new MazeWindow(m));
        }
        public static char[,] generateMaze()
        {
            Random r = new Random();
            int size = r.Next(1, 5) * 5;
            char[,] mazeA = new char[size, size];

            int currRow = r.Next(0, size - 1);
            int currCol = r.Next(0, size - 1);
            mazeA[currRow, currCol] = 's';

            int roadLen = r.Next(size/10, size);

            for (int i = 0; i < roadLen; i++)
            {
                int direction = r.Next(0, 4);
                switch (direction)
                {
                    case (0):
                        currRow++;
                        if (!(currRow >= 0 && currRow < size)||(mazeA[currRow,currCol]=='s'))
                        {
                            currRow--;
                            i--;
                            continue;
                        }
                        break;
                    case (1):
                        currRow--;
                        if (!(currRow >= 0 && currRow < size) || (mazeA[currRow, currCol] == 's'))
                        {
                            currRow++;
                            i--;
                            continue;
                        }
                        break;
                    case (2):
                        currCol++;
                        if (!(currCol >= 0 && currCol < size) || (mazeA[currRow, currCol] == 's'))
                        {
                            currCol--;
                            i--;
                            continue;
                        }

                        break;
                    case (3):
                        currCol--;
                        if (!(currCol >= 0 && currCol < size) || (mazeA[currRow, currCol] == 's'))
                        {
                            currCol++;
                            i--;
                            continue;
                        }
                        break;
                }

                mazeA[currRow, currCol] = '0';

            }
            mazeA[currRow, currCol] = 'g';

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (mazeA[i, j] == 0)
                    {
                        int value = r.Next(0, 2);
                        switch (value)
                        {
                            case (0):
                                mazeA[i, j] = '0';
                                break;
                            default:
                                mazeA[i, j] = '1';
                                break;
                        }

                    }
            return mazeA;
        }
    }
}
