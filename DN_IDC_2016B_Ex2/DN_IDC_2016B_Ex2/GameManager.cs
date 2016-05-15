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
        private int m_NumOfRows;
        private int m_NumOfCol;

        public GameManager(string i_NameA, string i_NameB,
                            bool i_IsComputer, int i_NumOfRows,
                            int i_NumOfCol)
        {
            m_IsComputerMode = i_IsComputer;
            m_Board = new Board(i_NumOfRows, i_NumOfCol);
            m_Player_a = new Player(i_NameA, false, 'X', m_Board);
            m_Player_b = new Player(i_NameB, i_IsComputer, 'O', m_Board);
        }

        public Board Insert (int i_Col, out eGameStatus o_Status, out eTurn o_Turn)
        {

            eGameStatus result;

            if (m_Turn == eTurn.turn_player_a) // Player A Turn
            {
                result = m_Player_a.Insert(i_Col);
                if (result == eGameStatus.win)
                {
                    o_Status = eGameStatus.win_player_a;
                    m_Turn = eTurn.turn_player_a; //the player who wins will start the next game
                    m_Player_a.AddPoint();
                }
            } else // Player B Turn
            {
                result = m_Player_b.Insert(i_Col);
                if (result == eGameStatus.win)
                {
                    o_Status = eGameStatus.win_player_b;
                    m_Turn = eTurn.turn_player_b;
                    m_Player_b.AddPoint();
                }
            }

            // In case of a tie we will switch the turn
            if (result == eGameStatus.tie)
            {
                m_Turn = getNextTurn();
            }

            o_Status = result;
            o_Turn = m_Turn;
            return m_Board;
        }

        public Board NewGame()
        {
            m_Board = new Board(m_NumOfRows, m_NumOfCol);
            m_Player_a.M_Board = m_Board;
            m_Player_b.M_Board = m_Board;
            return m_Board;
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
        win,
        tie,
        failure
    }

    public enum eTurn
    {
        turn_player_a,
        turn_player_b
    }
}
