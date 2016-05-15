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
        private string m_PlayAgainMsg = "Hit Q to exit, or any other key to continue play...";
        private string m_PlayerAName = "Player a";
        private string m_PlayerBName = "Player b";
        private string m_FailureMsg = "Choose another column...";
        private string m_SurrenderMsg = "{0} surrended";

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
            startFirstGame();
            Ex02.ConsoleUtils.Screen.Clear();
            if (m_ComputerMode)
            {
                runOnePlayerFlow();
            } 
            else
            {
                runTwoPlayersFlow();
            }

        }

        private void runOnePlayerFlow()
        {

            string turnName;
            eGameStatus status = eGameStatus.succeedd;
            int colNumber;
            Board board = null;

            

            // Start the game flow until surrender, tie or a win.
            while (status != eGameStatus.tie || status != eGameStatus.win_player_a 
                || status != eGameStatus.win_player_b || status !=eGameStatus.surrender)
            {
                turnName = m_GameManager.GetTurnName();
                System.Console.WriteLine(string.Format(m_TurnMsg, turnName));
                colNumber = getNumFromUser(string.Format(m_AskForAMove, turnName));
                checkExitCondition(colNumber);

                board = m_GameManager.Insert(colNumber - 1, out status, out turnName);

                if (status == eGameStatus.failure)
                {
                    System.Console.WriteLine(m_FailureMsg);
                }
                else
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    m_Drawer.printBoard(board.getBoard());

                    // computer move

                    System.Console.WriteLine(string.Format(m_TurnMsg, m_GameManager.GetTurnName()));
                    Ex02.ConsoleUtils.Screen.Clear();
                    board = m_GameManager.Insert(-1, out status, out turnName);
                    m_Drawer.printBoard(board.getBoard());
                }

            }

            onGameEnd(status);

        }

        private void runTwoPlayersFlow()
        {

            string turnName;
            eGameStatus status = eGameStatus.succeedd;
            int colNumber;
            Board board = null;

           

            // Start the game flow until surrender tie or a win.
            while (status != eGameStatus.tie || status != eGameStatus.win_player_a 
                || status != eGameStatus.win_player_b || status != eGameStatus.surrender)
            {
                turnName = m_GameManager.GetTurnName();
                System.Console.WriteLine(string.Format(m_TurnMsg, turnName));
                colNumber = getNumFromUser(string.Format(m_AskForAMove, turnName));
                checkExitCondition(colNumber);

                board = m_GameManager.Insert(colNumber - 1, out status, out turnName);

                if (status == eGameStatus.failure)
                {
                    System.Console.WriteLine(m_FailureMsg);
                }
                else
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    m_Drawer.printBoard(board.getBoard());
                }
            }
            onGameEnd(status);
        }

        private void onGameEnd(eGameStatus i_GameStatus)
        {
            switch (i_GameStatus)
            {
                case eGameStatus.win_player_a:
                    System.Console.WriteLine(string.Format(m_WinMsg, m_PlayerAName));
                    break;
                case eGameStatus.win_player_b:
                    System.Console.WriteLine(string.Format(m_WinMsg, m_PlayerBName));
                    break;
                case eGameStatus.tie:
                    System.Console.WriteLine(m_TieMsg);
                    break;
                case eGameStatus.surrender:
                    System.Console.WriteLine(string.Format(m_SurrenderMsg, 
                        m_GameManager.OnPlayerSurrended()));
                    break;
            }

            System.Console.WriteLine(m_GameManager.GetGamesPoints());
            // asking the user if he wants to play another game

            System.Console.WriteLine(m_PlayAgainMsg);
            string input = System.Console.ReadLine();

            if (input.Equals('Q'))
            {
                Environment.Exit(0);
            }
            else
            {
                m_GameManager.NewGame();
                if (m_ComputerMode)
                {
                    runOnePlayerFlow();
                }
                else
                {
                    runTwoPlayersFlow();
                }
            }   
        }

        private void startFirstGame()
        {
            int numOfRows = 1;
            int numOfCols;
            int computerMode;


            // Getting the input for initializing the game 
            getNumFromUser(m_AskForRows);
            checkExitCondition(numOfRows);
            numOfCols = getNumFromUser(m_AskForCols);
            checkExitCondition(numOfCols);
            computerMode = getComputerMode();
            checkExitCondition(computerMode);
            parseComputerMode(computerMode);
            
            if (m_ComputerMode)
            {
                m_PlayerBName = "Computer";
            }

            m_GameManager = new GameManager(m_PlayerAName, m_PlayerBName,
                                m_ComputerMode, numOfRows, numOfCols);

        }

        private void parseComputerMode(int i_ComputerMode)
        {
            bool playInComputerMode = true;

            if (i_ComputerMode == 1)
            {
                m_ComputerMode = playInComputerMode;
            } else
            {
                m_ComputerMode = !playInComputerMode;
            }
        }

        private void checkExitCondition(int i_ExitCode)
        {
            if (i_ExitCode == -1)
            {
                System.Console.WriteLine("Hit any key to exit...");
                System.Console.ReadLine();
                Environment.Exit(0);
            }
        }

        private int getComputerMode()
        {
            bool succeedd = false;
            int result = 1;
            string input;

            while (!succeedd)
            {
                System.Console.WriteLine(m_AskForNumOfPlayers);
                input = System.Console.ReadLine();

                if (input.Equals('Q'))
                {
                    return -1;
                }
                succeedd = int.TryParse(input, out result);
                succeedd = succeedd && (result == 1 || result == 2);
            }

            return result;

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
