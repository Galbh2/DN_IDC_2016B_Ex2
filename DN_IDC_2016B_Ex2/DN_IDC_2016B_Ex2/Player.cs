using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN_IDC_2016B_Ex2
{
    class Player
    {

        private string m_Name;
        private int m_Points;
        private bool m_IsComputer;
        private char m_Symbol;

        public Player (string i_Name, bool i_IsComputer, char i_Symbol)
        {
            m_Name = i_Name;
            m_IsComputer = i_IsComputer;
            m_Symbol = i_Symbol;
            m_Points = 0;
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
