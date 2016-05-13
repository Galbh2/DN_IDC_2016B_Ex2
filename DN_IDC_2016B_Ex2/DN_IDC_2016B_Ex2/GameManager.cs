using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN_IDC_2016B_Ex2
{
    class GameManager
    {

        private Player m_Player_a, m_Player_b;
        private Board m_Board;
        private eTurn m_Turn;
        private bool m_IsComputerMode;

        public GameManager(string i_NameA, string i_NameB,
                            bool i_IsComputer, int i_NumOfRows,
                            int i_NumOfCol)
        {
            m_Player_a = new Player(i_NameA, false, 'X');
            m_Player_b = new Player(i_NameB, i_IsComputer, 'O');
            m_IsComputerMode = i_IsComputer;
            m_Board = new Board(i_NumOfRows, i_NumOfCol);

        }

        public Board insert (int i_Col, out eGameStatus o_Status, out eTurn o_Turn)
        {

            o_Status = eGameStatus.failure;
            o_Turn = eTurn.turn_player_a;
            return m_Board;
        }

        public void newGame()
        {

        }

        private eTurn getNextTurn()
        {
            if (m_Turn == eTurn.turn_player_a)
            {
                return eTurn.turn_player_b;
            }
            else
            {
                return eTurn.turn_player_a;
            }
        }



     
    }

    public enum eGameStatus
    {
        win_player_a,
        win_player_b,
        tie,
        failure
    }

    public enum eTurn
    {
        turn_player_a,
        turn_player_b
    }
}
