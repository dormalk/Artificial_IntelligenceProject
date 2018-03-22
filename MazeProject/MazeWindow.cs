using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AI;

namespace MazeProject
{
    public partial class MazeWindow : Form
    {
        Maze board = null;
        Color[,] bgColors;
        public MazeWindow(Maze m)
        {
            setBoard(m);
            InitializeComponent();

        }
        private void setBoard(Maze m)
        {
            this.board = m;
            bgColors = new Color[m.GetLength(0), m.GetLength(1)];
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    bgColors[i, j] = SystemColors.Control;

        }
        private void MazeWindow_Load(object sender, EventArgs e)
        {
            createNewBoard();
        }

        private void createNewBoard() {
            boardLayout.RowCount = board.GetLength(0);
            boardLayout.ColumnCount = board.GetLength(1);

            for (int i = 0; i < board.GetLength(0); i++)
            {
                boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                }
            }
        }

        private void boardLayout_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
 
            if (board[e.Row, e.Column] == '1')
                 using (SolidBrush brush = new SolidBrush(Color.Black))
                     e.Graphics.FillRectangle(brush, e.CellBounds);
             else if (board[e.Row, e.Column] == 's')
                 using (SolidBrush brush = new SolidBrush(Color.Red))
                     e.Graphics.FillRectangle(brush, e.CellBounds);
             else if (board[e.Row, e.Column] == 'g')
                 using (SolidBrush brush = new SolidBrush(Color.Blue))
                     e.Graphics.FillRectangle(brush, e.CellBounds);
             else
                using (var b = new SolidBrush(bgColors[e.Row, e.Column]))
                    e.Graphics.FillRectangle(b, e.CellBounds);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ISearcher searcher = new AStar();
            String solution = searcher.Search<Maze.Grid>(board).ToString();
            String[] vals = solution.Split('-');
            int Count=vals.GetLength(0);
            for(int i=0;i<Count-1;i++)
            {
                string[] cords = vals[i].Split(',');
                int Row = int.Parse(cords[0].Split('[')[1]);
                int Col = int.Parse(cords[1].Split(']')[0]);
                bgColors[Row, Col] = Color.Aqua;
                boardLayout.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[,] maze = Program.generateMaze();
            Maze m = new Maze(maze);
            setBoard(m);
            createNewBoard();
        }
    }
}
