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
        private int m_NumOfRows = 4;
        private int m_NumOfCol = 4;

        public event Action<int> FullColNotifier;

        public GameManager(string i_NameA, string i_NameB,
                            bool i_IsComputer, int i_NumOfRows,
                            int i_NumOfCol)
        {
            m_IsComputerMode = i_IsComputer;
            m_Board = new Board(i_NumOfRows, i_NumOfCol);
            m_Player_a = new Player(i_NameA, false, 'X', m_Board);

            if (i_IsComputer)
            {
                m_Player_b = new Computer(i_NameB, i_IsComputer, 'O', m_Board);
            }
            else
            {
                m_Player_b = new Player(i_NameB, i_IsComputer, 'O', m_Board);
            }

            m_NumOfRows = i_NumOfRows;
            m_NumOfCol = i_NumOfCol;

            m_Board.FullColNotifier += this.OnColFull;
        }

        public Board Insert (int i_Col, out eGameStatus o_Status, out string o_TurnName)
        {

            eGameStatus result;

            if (m_Turn == eTurn.turn_player_a) // Player A Turn
            {
                result = m_Player_a.Insert(i_Col);
                if (result == eGameStatus.win)
                {
                    result = eGameStatus.win_player_a;
                    m_Turn = eTurn.turn_player_a; //the player who wins will start the next game
                    m_Player_a.AddPoint();
                }
            } else // Player B Turn
            {
                result = m_Player_b.Insert(i_Col);
                if (result == eGameStatus.win)
                {
                    result = eGameStatus.win_player_b;
                    m_Turn = eTurn.turn_player_b;
                    m_Player_b.AddPoint();
                }
            }

            // In case of a tie or an insert which succeed we will switch the turn
            if (result == eGameStatus.tie || result ==eGameStatus.succeedd)
            {
                m_Turn = getNextTurn();
            }

            o_Status = result;
            o_TurnName = GetTurnName();
            return m_Board;
        }

        protected virtual void OnColFull(int i_Index)
        {
            if (FullColNotifier != null)
            {
                FullColNotifier.Invoke(i_Index);
            }
        }

        public string OnPlayerSurrended()
        {
            string name = null;

            if (m_Turn == eTurn.turn_player_a)
            {
                m_Player_b.AddPoint();
                name = m_Player_a.M_Name;
            }
            else
            {
                m_Player_a.AddPoint();
                name = m_Player_b.M_Name;
            }
            m_Turn = getNextTurn();
            return name;
            
        }

        public eTurn GetTurn()
        {
            return m_Turn;
        }

        public string GetGamesPoints()
        {
            return string.Format("-----------\n   Score  |\n   -----  |\n{0} {1}|\n{2} {3}|\n-----------",
                m_Player_a.M_Name, m_Player_a.M_Points,
               m_Player_b.M_Name, m_Player_b.M_Points);
        }

        public Board NewGame()
        {
            m_Board = new Board(m_NumOfRows, m_NumOfCol);
            m_Player_a.M_Board = m_Board;
            m_Player_b.M_Board = m_Board;
            return m_Board;
        }

        public string GetTurnName()
        {
            if (m_Turn == eTurn.turn_player_a)
            {
                return m_Player_a.M_Name;
            }
            else
            {
                return m_Player_b.M_Name;
            }
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

        public Board M_Board
        {
            get
            {
                return m_Board;
            }
        }

        public int Rows
        {
            get
            {
                return m_NumOfRows;
            }
        }

        public int Cols
        {
            get
            {
                return m_NumOfCol;
            }
        }

        public bool Computermode
        {
            get
            {
                return m_IsComputerMode;
            }
        }

        public string PlayerA
        {
            get
            {
                return m_Player_a.M_Name;
            }
        }

        public string PlayerB        {
            get
            {
                return m_Player_b.M_Name;
            }
        }
    }

 

    public enum eGameStatus
    {
        win_player_a,
        win_player_b,
        succeedd,
        surrender,
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
