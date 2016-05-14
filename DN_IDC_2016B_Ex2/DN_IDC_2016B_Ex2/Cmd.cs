using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN_IDC_2016B_Ex2
{
    class Cmd
    {

        private string m_AskForRows = "Enter the number of rows (min = 4, max = 8), or Q to Exit:";
        private string m_AskForCols = "Enter the number of columns (min = 4, max = 8) or Q to Exit:";
        private string m_AskForNumOfPlayers = "Enter the number of players (if 1 you will play aginst the computer):";
        private string m_TurnMsg = "Player's {0} turn";
        private string m_AskForAMove = "Enter a column number:";
        private string m_WinMsg = "Player {0} Won !";
        private string m_TieMsg = "It's a Tie !";
        private string m_PlayAgainMsg = "Do you want to play again ?";

        private readonly int m_MinNum = 4;
        private readonly int m_MaxNum = 8;


        private GameManager m_GameManager;
        private Drawer m_Drawer;
        private bool m_ComputerMode;

        public Cmd()
        {
            m_Drawer = new Drawer();
        }

        public void Run()
        {
           // Ex02.ConsoleUtils.Screen.Clear();
        }

        private void startFirstGame()
        {
            int numOfRows, numOfCols;
            bool computerMode;

            numOfRows = getNumFromUser(m_AskForRows);
            numOfCols = getNumFromUser(m_AskForCols);

      
        }

        private int getNumFromUser(string i_Msg)
        {
            bool succeed = false;
            int result = -1;
            string input;

            while (!succeed)
            {
                System.Console.WriteLine(i_Msg);
                input = System.Console.ReadLine();

                if (input.Equals('Q'))
                {
                    return -1;
                }
                succeed = int.TryParse(input, out result);
                succeed = succeed && (m_MinNum <= result && result <= m_MaxNum);
            }

            return result;
        }
    }
}
