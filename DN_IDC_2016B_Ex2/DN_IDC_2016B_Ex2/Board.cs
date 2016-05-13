using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN_IDC_2016B_Ex2
{
    class Board
    {
        char[,] m_Board;
        int[] m_NextPlaceToInsert;

        public Board (int i_NumOfRows, int i_NumOfCol)
        {
            m_Board = new char[i_NumOfRows, i_NumOfCol];
            m_NextPlaceToInsert = new int[i_NumOfCol];
            initNextPlaceToInsert(i_NumOfRows);
        }

        public eGameStatus insert(int i_Col)
        {
            
            return eGameStatus.failure;
        }

        private bool isBoardFull()
        {
            return false;
        }

        private void initNextPlaceToInsert(int i_NumOfRows)
        {
            for (int i = 0; i < m_NextPlaceToInsert.Length; i++)
            {
                m_NextPlaceToInsert[i] = i_NumOfRows - 1;
            }
        }

        private bool checkPlace(int i_Col)
        {
            return checkRow(i_Col) ||
                    checkCol(i_Col) ||
                    checkLeftDiag(i_Col) ||
                    checkRightDiag(i_Col);
        }

        private bool checkRow(int i_Col)
        {
            return false;
        }

        private bool checkCol(int i_Col)
        {
            return false;
        }

        private bool checkLeftDiag(int i_Col)
        {
            return false;
        }

        private bool checkRightDiag(int i_Col)
        {
            return false;
        }

    }
}
