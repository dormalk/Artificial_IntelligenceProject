using System;
using System.Collections.Generic;
using AI;

namespace MazeProject
{
    public class Maze : ISearchable
    {
        public char[,] board;

        public Maze(char[,] _board)
        {
            this.board = new char[_board.GetLength(0), _board.GetLength(1)];
            this.innerCopy(_board);
        }

        private void innerCopy(char[,] _board)
        {
            for (int i = 0; i < _board.GetLength(0); i++)
                for (int j = 0; j < _board.GetLength(1); j++)
                    this.board[i, j] = _board[i, j];
        }

        private double getHiuristic(Grid g)
        {
            return Math.Abs(g.Row - this.getGoal().Row) + Math.Abs(g.Col - this.getGoal().Col);
        }
        
        private Grid getGoal()
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (this[i, j] == 'g')
                        return new Grid(i, j);
            return null;
        }

        public State<T> getInitialState<T>()
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (this[i, j] == 's')
                    {
                        object state= new State<Grid>(new Grid(i,j), getHiuristic(new Grid(i, j)), null);
                        return (State<T>)Convert.ChangeType(state,typeof(State<T>));
                    }
            return null;
        }

        public int GetLength(int i)
        {
            return board.GetLength(i);
        }
        public bool isGoal<T>(State<T> s)
        {
            Grid curr=(Grid)Convert.ChangeType(s.state, typeof(Grid));
            if (curr == getGoal())
                return true;
            return false;
        }

        public List<State<T>> getSuccessors<T>(State<T> s)
        {
            Grid curr = (Grid)Convert.ChangeType(s.state, typeof(Grid));
            List<State<T>> list = new List<State<T>>();
            if (isFit(curr.Row + 1, curr.Col))
            {
                object state = new State<Grid>(new Grid(curr.Row + 1, curr.Col), getHiuristic(new Grid(curr.Row + 1, curr.Col)), (State<Grid>)Convert.ChangeType(s, typeof(State<Grid>)));
                list.Add((State<T>)Convert.ChangeType(state, typeof(State<T>)));
            }
            if (isFit(curr.Row, curr.Col+1))
            {
                object state = new State<Grid>(new Grid(curr.Row , curr.Col+1), getHiuristic(new Grid(curr.Row, curr.Col+1)), (State<Grid>)Convert.ChangeType(s, typeof(State<Grid>)));
                list.Add((State<T>)Convert.ChangeType(state, typeof(State<T>)));
            }
            if (isFit(curr.Row-1, curr.Col))
            {
                object state = new State<Grid>(new Grid(curr.Row-1, curr.Col), getHiuristic(new Grid(curr.Row-1, curr.Col)), (State<Grid>)Convert.ChangeType(s, typeof(State<Grid>)));
                list.Add((State<T>)Convert.ChangeType(state, typeof(State<T>)));
            }
            if (isFit(curr.Row, curr.Col - 1))
            {
                object state = new State<Grid>(new Grid(curr.Row, curr.Col - 1), getHiuristic(new Grid(curr.Row, curr.Col - 1)), (State<Grid>)Convert.ChangeType(s, typeof(State<Grid>)));
                list.Add((State<T>)Convert.ChangeType(state, typeof(State<T>)));
            }

            return list;
        }

        private bool isFit(int i,int j)
        {
            if (((i >= 0) && (i < board.GetLength(0))) &&
                    ((j >= 0) && (j < board.GetLength(1))) &&
                        ((this[i, j] != '1'))) return true;
            return false;
        }

        public char this[int i, int j]
        {
            get
            {
                return board[i, j];
            }
            set
            {
                board[i, j] = value;
            }
        }

        public class Grid
        {
            private int row;
            private int col;

            public Grid(int _row, int _col)
            {
                this.row = _row;
                this.col = _col;
            }

            public int Row
            {
                get
                {
                    return row;
                }
                set
                {
                    if (value > 0)
                        row = value;
                }
            }
            public int Col
            {
                get
                {
                    return col;
                }
                set
                {
                    if (value > 0)
                        col = value;
                }
            }
            
            public static bool operator==(Grid g1,Grid g2)
            {
                if ((g1.row == g2.row) && (g1.col == g2.col))
                    return true;
                return false;
            }

            public static bool operator !=(Grid g1, Grid g2)
            {
                if ((g1.row == g2.row) && (g1.col == g2.col))
                        return false;
                    return true;
            }

            public override bool Equals(object obj)
            {
                Grid otr = (Grid)Convert.ChangeType(obj, typeof(Grid));
                if ((this.Row == otr.Row) && (this.Col == otr.Col))
                    return true;
                return false;
            }

            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }

            public override string ToString()
            {
                return "[" + this.Row.ToString() + "," + this.Col.ToString() + "]";
            }

        }

    }
}
