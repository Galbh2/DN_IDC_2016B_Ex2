using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN_IDC_2016B_Ex2
{
    class Player
    {

        protected string m_Name;
        protected int m_Points;
        protected bool m_IsComputer;
        protected char m_Symbol;
        protected Board m_Board;

        public Player (string i_Name, bool i_IsComputer, char i_Symbol, Board i_Board)
        {
            m_Name = i_Name;
            m_IsComputer = i_IsComputer;
            m_Symbol = i_Symbol;
            m_Points = 0;
            m_Board = i_Board;
        }

        public virtual eGameStatus Insert(int i_Col)
        {
            return m_Board.insert(i_Col, m_Symbol);
        }

        public void AddPoint()
        {
            m_Points++;
        }

        public Board M_Board
        {
            get
            {
                return m_Board;
            }
            set
            {
                m_Board = value;
            }
        }

        public int M_Points {
            get
            {
                return m_Points;
            }
            set
            {
                m_Points = value;
            }
        }

        public bool M_IsComputer
        {
            get
            {
                return m_IsComputer;
            }
        }

        public char M_Symbol
        {
            get
            {
                return m_Symbol;
            }
        }

        public string M_Name
        {
            get
            {
                return m_Name;
            }
        }
    }
}
