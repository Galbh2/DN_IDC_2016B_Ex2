using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DN_IDC_2016B_Ex2
{
    class GameUI : Form
    {

        private GameManager m_GameManager;
        private MyButton[,] m_Board;
        private InsertButton[] m_InsertButton;
        private Label m_PlayerAName, m_PlayerBName;
        private TextBox m_PlayerAScore, m_PlayerBScore;
        private const int BTN_SIZE = 40;

        public GameUI(GameManager i_GameManager)
        {
            m_GameManager = i_GameManager;
            m_Board = new MyButton[m_GameManager.Rows, m_GameManager.Cols];
            init();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // 
            // GameUI
            // 
            this.ClientSize = new System.Drawing.Size(635, 501);
            this.Name = "GameUI";
            this.ResumeLayout(false);

        }

        public void OnBoardChanged(Board i_Board, eGameStatus i_Status)
        {
            refreshUI(i_Board);

        }

        private void refreshUI(Board board)
        {

            char[,] b = board.getBoard();

            for (int i = 0; i < m_GameManager.Rows; i++)
            {
                for (int j = 0; j <m_GameManager.Cols; j++)
                {
                    m_Board[i, j].Text = b[i, j].ToString();
                }
            }
        }

        private void init()
        {
            int baseX = 30;
            int baseY = 30;
            int margin = 10;
            int space = 30;

            // Sets the size of the window

            this.ClientSize = new System.Drawing.Size(

                baseX + margin * 2 + m_GameManager.Cols * (margin + BTN_SIZE),
                baseY + margin * 2 + space * 2 + m_GameManager.Rows * (margin + BTN_SIZE)
                );

            // Creates the insert buttons

            for (int i = 0; i < m_GameManager.Cols; i++)
            {
                InsertButton b = new InsertButton(i, m_GameManager, this);
                b.Location = new Point(
                    baseX + i * (margin + BTN_SIZE),
                    baseY
                    );
                this.Controls.Add(b);
            }


            // Creates the board
            for (int i = 0; i < m_GameManager.Rows; i++)
            {
                for (int j = 0; j < m_GameManager.Cols; j++)
                {
                    MyButton b = new MyButton(i, j);
                    b.Location = new Point(
                        baseX + j * (BTN_SIZE + margin),
                        baseY + space + margin + i * (margin + BTN_SIZE)
                        );
                    this.Controls.Add(b);
                    m_Board[i, j] = b;
                }
            }

            m_PlayerAName = new Label();
            m_PlayerBName = new Label();
            m_PlayerAScore = new TextBox();
            m_PlayerBScore = new TextBox();

            m_PlayerAName.Location = new Point(
                baseY,    
                this.ClientSize.Height - 10
                );
            m_PlayerAName.Text = m_GameManager.PlayerA;

            m_PlayerAScore.Location = new Point(
                this.ClientSize.Height - 10,
                baseX + margin
                );

            m_PlayerAScore.Text = "0";

            m_PlayerBName.Location = new Point(
                this.ClientSize.Height - 10,
                baseX + margin * 2
                );

            m_PlayerBName.Text = m_GameManager.PlayerB;

            m_PlayerBScore.Location = new Point(
                this.ClientSize.Height - 10,
                baseX + margin * 3
                );

            m_PlayerBScore.Text = "0";

            this.Controls.AddRange(new Control[]
                { m_PlayerAName, m_PlayerAScore,
                  m_PlayerBName, m_PlayerBScore});
        }

        private class InsertButton : Button
        {
            int m_Index;
            GameManager m_GameManager;
            GameUI m_UI;

            public InsertButton(int i_Index, GameManager i_GameManager, GameUI i_UI) : base()
            {

                m_UI = i_UI;

                m_Index = i_Index;
                m_GameManager = i_GameManager;
                this.Width = BTN_SIZE;
                this.Text = (i_Index + 1).ToString();

                // Events
                this.Click += new System.EventHandler(this.OnClick);
                m_GameManager.FullColNotifier += this.OnFullCol;
            }

            private void OnClick(object sender, EventArgs e)
            {
                string turnName;
                eGameStatus status;
                Board board = m_GameManager.Insert(m_Index, out status, out turnName);
                m_UI.OnBoardChanged(board, status);

                System.Console.WriteLine(status.ToString());
                System.Console.WriteLine(turnName);
        

                if (m_GameManager.Computermode && status == eGameStatus.succeedd)
                {
                    m_GameManager.Insert(-1, out status, out turnName);
                    m_UI.OnBoardChanged(board, status);


                    System.Console.WriteLine(status.ToString());
                    System.Console.WriteLine(turnName);
                }
                
            }

            private void OnFullCol(int i_Index)
            {
                if (m_Index == i_Index)
                {
                    this.Enabled = false;
                }
            }

        }
        

        private class MyButton : Button 
        {
            int m_X;
            int m_Y;

            public MyButton(int i_X, int i_Y) : base()
            {
                m_X = i_X;
                m_Y = i_Y;
                this.Height = BTN_SIZE;
                this.Width = BTN_SIZE;
                this.Enabled = false;
            }

        }
    }


}
