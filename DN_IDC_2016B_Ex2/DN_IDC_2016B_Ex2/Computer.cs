using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN_IDC_2016B_Ex2
{
    class Computer : Player
    {
        public Computer(string i_Name, bool i_IsComputer, char i_Symbol, Board i_Board) : base(i_Name, i_IsComputer, i_Symbol, i_Board)
        {
        }


        public override eGameStatus Insert(int i_Col)
        {
            Random random = new Random();
            int col = random.Next(0, m_Board.getBoard().GetLength(1));
            return m_Board.insert(col, m_Symbol);

        }

        public int getBestCol()
        {
            int counter = 0;
            int max = 0;
            int bestCol = 0;
            char[,] board = m_Board.getBoard();

            for (int i = 0; i < board.GetLength(1); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[j,1] == M_Symbol)
                    {
                        counter++;
                    }
                }
                if (counter > max)
                {
                    max = counter;
                    bestCol = i;
                }
                counter = 0;
            }
            return bestCol;
        }
    }
}
