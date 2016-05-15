using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN_IDC_2016B_Ex2
{
    class Board
    {
        private char[,] m_Board;
        private int[] m_NextPlaceToInsert;
        private int m_NumOfRows;
        private int m_NumOfColumns;

       public Board (int i_NumOfRows, int i_NumOfCol)
        {
            m_Board = new char[i_NumOfRows, i_NumOfCol];
            m_NumOfRows = i_NumOfRows;
            m_NumOfColumns = i_NumOfCol;
            m_NextPlaceToInsert = new int[i_NumOfCol];
            initNextPlaceToInsert(i_NumOfRows);
        }

       public char[,] getBoard()
        {
            return m_Board;
        }

       public eGameStatus insert(int i_Col , char i_Symbol)
       {
            eGameStatus status;    
            if (m_NextPlaceToInsert[i_Col] > - 1)
            {
                m_Board[m_NextPlaceToInsert[i_Col], i_Col] = i_Symbol;
                m_NextPlaceToInsert[i_Col]--;
                if (checkPlace(i_Col))
                {
                    status = eGameStatus.win;
                }
                else if (isBoardFull())
                {
                    status = eGameStatus.tie;
                }
                else
                {
                    status = eGameStatus.succeedd;
                }

            }
            else
            {
                status = eGameStatus.failure;
            }
            return status;   
        }

        
      

        private bool isBoardFull()
        {
            bool isFull = true;
            for(int i = 0; i < m_NextPlaceToInsert.Length; i++)
            {
                if( m_NextPlaceToInsert[i] != -1)
                {
                    isFull =  false;
                    break;
                }
            }
            return isFull;
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
            int rowNumber = m_NextPlaceToInsert[i_Col] + 1;
            char symbolOfPlayer = m_Board[rowNumber, i_Col];
            string pattern = string.Format("{0}{0}{0}{0}", symbolOfPlayer);
            bool isWinner = checkRow(rowNumber, pattern) || checkCol(i_Col, pattern) || checkLeftDiag(i_Col, rowNumber, pattern) || checkRightDiag(i_Col,rowNumber,pattern);
            return isWinner;         
        }

        private bool checkRow(int i_Row,string i_Pattern)
        { 
            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(getRowStr(i_Row), i_Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return isMatch;
        }

        private bool checkCol(int i_Col,string i_Pattern)
        {
            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(getColStr(i_Col), i_Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return isMatch;
        }

        private bool checkLeftDiag(int i_Col , int i_Row , string i_Pattern)
        {
            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(getLeftDiagStr(i_Col, i_Row), i_Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return isMatch;
        }

        private bool checkRightDiag(int i_Col, int i_Row, string i_Pattern)
        {
            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(getRightDiagStr(i_Col,i_Row), i_Pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return isMatch;
        }


        private string getRowStr(int i_Row)
        {
            StringBuilder row = new StringBuilder();
            for(int i = 0; i <  m_NumOfColumns ; i++)
            {
                char symbol = m_Board[i_Row,i];
                row.Append(symbol); 
            }
            return row.ToString();
        }

        private string getColStr(int i_Col)
        {
            StringBuilder col = new StringBuilder();
            for (int i = 0; i < m_NumOfRows; i++)
            {
                char symbol = m_Board[i, i_Col];
                col.Append(symbol);
            }
            return col.ToString();
        }


        private string getLeftDiagStr(int i_Col,int i_Row)
        {
            StringBuilder diag = new StringBuilder();
            while (i_Row > 0 && i_Col>0)
            {
                i_Row--;
                i_Col--;
            }

            while(i_Row < m_NumOfRows && i_Col < m_NumOfColumns )
            {
                diag.Append(m_Board[i_Row, i_Col]);
                i_Row++;
                i_Col++;

            }
            return diag.ToString();    
        }
        
        private string getRightDiagStr(int i_Col, int i_Row)
        {
            StringBuilder diag = new StringBuilder();
            while (i_Row > 0 && i_Col < m_NumOfColumns - 1)
            {
                i_Row--;
                i_Col++;
            }

            while (i_Row < m_NumOfRows && i_Col >= 0)
            {
               
                diag.Append(m_Board[i_Row, i_Col]);
                i_Row++;
                i_Col--;


            }
            return diag.ToString();
        }
        

    }
    
}

