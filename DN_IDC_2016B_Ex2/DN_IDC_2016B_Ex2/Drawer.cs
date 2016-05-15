using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN_IDC_2016B_Ex2
{


    
    class Drawer
    {
       
        public void printBoard(char[,] i_Board)
        {
            printHeader(i_Board.GetLength(1));
            System.Console.WriteLine();
            printRows(i_Board);
        }


        private void printHeader(int i_NumOfColumns)
        {
            StringBuilder colNum = new StringBuilder();
            colNum.Append(" ");
            for (int i = 1; i <= i_NumOfColumns; i++)
            {
                colNum.Append("  " + i + "  ");

            }
            Console.WriteLine(colNum.ToString());
        }

        private void printBottom(int i_NumOfColumns)
        {
            StringBuilder bottomOfRow = new StringBuilder();

            for (int i = 0; i < i_NumOfColumns; i++)
            {
                bottomOfRow.Append("=====");

            }

            bottomOfRow.Append("=");
            Console.WriteLine(bottomOfRow.ToString());

        }


        private void printRows(char[,] i_Board)
        {
            
            string format = string.Empty;
            StringBuilder rowStr;
            int numOfRows = i_Board.GetLength(0);
            int numOfColumns = i_Board.GetLength(1);
            for (int i = 0; i < numOfRows; i++)
            {
                rowStr = new StringBuilder();
                for (int j = 0; j < numOfColumns; j++)
                {
                    format = string.Format("|  {0} ", i_Board[i, j]);
                    rowStr.Append(format);
                }
                rowStr.Append("|");
                System.Console.WriteLine(rowStr);
                printBottom(numOfColumns);
            }
           
           

        }
    }
    }





    

