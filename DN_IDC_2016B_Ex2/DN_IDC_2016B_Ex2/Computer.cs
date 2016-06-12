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
            int col;
            col = getColForWin();////try to win the game
            if (col == -1)
            {
                col = getColForBlock();///try to block the other player from win
                if (col == -1)
                {
                    col = random.Next(0, m_Board.getBoard().GetLength(1));////get random column

                }
            }

           
            return m_Board.insert(col, m_Symbol);

        }

      

        

         private int getColForWin()
        {
            int col = -1;
            for(int i = 0; i < m_Board.getBoard().GetLength(1); i++)
            {

                eGameStatus stat = m_Board.insert(i, m_Symbol);
                m_Board.Delelte(i);
                if (stat == eGameStatus.win)
                {
                    col = i;
                    break;

                }
            }

            return col;
        }

        private int getColForBlock()
        {
            int col = -1;
            char playerAsymbol = 'X';
            for (int i = 0; i < m_Board.getBoard().GetLength(1); i++)
            {

                eGameStatus stat = m_Board.insert(i, playerAsymbol);
                m_Board.Delelte(i);
                if (stat == eGameStatus.win)
                {
                    col = i;
                    break;
                }
            }

            return col;
        }





    }
}
