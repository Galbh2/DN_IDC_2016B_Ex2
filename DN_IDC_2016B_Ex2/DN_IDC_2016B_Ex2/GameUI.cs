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
        private string m_WinMsg = "{0} Won !";
        private string m_TieMsg = "It's a Tie !";
        private string m_AntotherRoundMsg = "Another Round?";

        private GameManager m_GameManager;
        private MyButton[,] m_Board;
        private InsertButton[] m_InsertButtons;
        private Label m_PlayerAName, m_PlayerBName;
        private TextBox m_PlayerAScore, m_PlayerBScore;
        private const int BTN_SIZE = 40;
        private FlowLayoutPanel flowLayoutPanel1;
        Drawer drawer = new Drawer();

        public GameUI(GameManager i_GameManager)
        {
            m_GameManager = i_GameManager;
            m_GameManager.BoardChangeNotifier += this.OnBoardChangedListener;
            m_Board = new MyButton[m_GameManager.Rows, m_GameManager.Cols];
            init();
        }

        private void InitializeComponent()
        {

            this.ResumeLayout(false);

        }

        public void OnBoardChangedListener(Object i_Board, eGameStatus i_Status)
        {

            Board board = (Board)i_Board;
            Console.WriteLine("board changed");
            drawer.printBoard(board.getBoard());
            refreshUI(board);

            if (i_Status != eGameStatus.succeedd && i_Status != eGameStatus.failure)
            {
                onGameEnd(i_Status);
            }

        }

        private void onGameEnd(eGameStatus i_GameStatus)
        {
            switch (i_GameStatus)
            {
                case eGameStatus.win_player_a:
                        showDialog((string.Format(m_WinMsg, m_GameManager.PlayerA)));
                    break;
                case eGameStatus.win_player_b:
                        showDialog((string.Format(m_WinMsg, m_GameManager.PlayerB)));
                    break;
                case eGameStatus.tie:
                    showDialog(m_TieMsg);
                    break;
                default:
                    break;
            }

            m_PlayerAScore.Text = m_GameManager.PlayerAScore.ToString();
            m_PlayerBScore.Text = m_GameManager.PlayerBScore.ToString();

        }

        private void showDialog(string i_Msg) {

            string msg = i_Msg + Environment.NewLine + m_AntotherRoundMsg;

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            MessageBoxIcon icon = MessageBoxIcon.Question;

            DialogResult result = MessageBox.Show(msg, "?", buttons, icon);

            switch (result)
            {
                case DialogResult.Yes:
                    m_GameManager.NewGame();
                    refreshUI(m_GameManager.M_Board);
                    enableInsertButtons();
                    if (m_GameManager.GetTurn() == eTurn.turn_player_b)
                    {
                        play(-1);
                    }
                    break;
                case DialogResult.No:
                    Application.Exit();
                    break;
            }
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

        private void enableInsertButtons()
        {
            foreach (InsertButton b in m_InsertButtons)
            {
                b.Enabled = true;
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
                baseY + margin * 3 + space * 2 + m_GameManager.Rows * (margin + BTN_SIZE)
                );

            // Creates the insert buttons

            m_InsertButtons = new InsertButton[m_GameManager.Cols];

            for (int i = 0; i < m_GameManager.Cols; i++)
            {
                InsertButton b = new InsertButton(i, m_GameManager, this);
                b.Location = new Point(
                    baseX + i * (margin + BTN_SIZE),
                    baseY
                    );
                this.Controls.Add(b);
                m_InsertButtons[i] = b;
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

            int offset = 1;
          

            FlowLayoutPanel panel = new FlowLayoutPanel();

            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.SuspendLayout();

            panel.Controls.AddRange(new Control[]
                { m_PlayerAName, m_PlayerAScore,
                  m_PlayerBName, m_PlayerBScore});

            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.m_PlayerAName.AutoSize = true;
            this.m_PlayerAName.Location = new System.Drawing.Point(3, 0);
            this.m_PlayerAName.Name = "label1";
            this.m_PlayerAName.Size = new System.Drawing.Size(35, 13);
            this.m_PlayerAName.TabIndex = 0;
            this.m_PlayerAName.Text = m_GameManager.PlayerA;
            // 
            // label2
            // 
            this.m_PlayerBName.AutoSize = true;
            this.m_PlayerBName.Location = new System.Drawing.Point(150, 0);
            this.m_PlayerBName.Name = "label2";
            this.m_PlayerBName.Size = new System.Drawing.Size(35, 13);
            this.m_PlayerBName.TabIndex = 1;
            this.m_PlayerBName.Text = m_GameManager.PlayerB;
            // 
            // textBox1
            // 
            this.m_PlayerAScore.Location = new System.Drawing.Point(44, 3);
            this.m_PlayerAScore.Name = "textBox1";
            this.m_PlayerAScore.Size = new System.Drawing.Size(30, 20);
            this.m_PlayerAScore.TabIndex = 2;
            this.m_PlayerAScore.Text = "0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.m_PlayerAName);
            this.flowLayoutPanel1.Controls.Add(this.m_PlayerAScore);
            this.flowLayoutPanel1.Controls.Add(this.m_PlayerBName);
            this.flowLayoutPanel1.Controls.Add(this.m_PlayerBScore);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(95, 74);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(333, 36);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.m_PlayerBScore.Location = new System.Drawing.Point(191, 3);
            this.m_PlayerBScore.Name = "textBox2";
            this.m_PlayerBScore.Size = new System.Drawing.Size(30, 20);
            this.m_PlayerBScore.TabIndex = 3;
            this.m_PlayerBScore.Text = "0";
            // 
            // GameUI
            // 

            this.flowLayoutPanel1.Location = new Point(
                baseX,
                this.Height - 70);

            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GameUI";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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

                // This will notify the button if it need to be disabled
                m_GameManager.FullColNotifier += this.OnFullCol;

            }

            private void OnClick(object sender, EventArgs e)
            {
               m_UI.play(m_Index);
            }

            private void OnFullCol(int i_Index)
            {
                if (m_Index == i_Index)
                {
                    this.Enabled = false;
                }
            }

        }

        public void play(int i_Index)
        {
            string turnName;
            eGameStatus status;

            if (m_GameManager.GetTurn() == eTurn.turn_player_a || !m_GameManager.Computermode)
            {
                Board board = m_GameManager.Insert(i_Index, out status, out turnName);

                //   m_UI.OnBoardChanged(board, status);

                System.Console.WriteLine(status.ToString());
                System.Console.WriteLine(turnName);
            }

            if (m_GameManager.GetTurn() == eTurn.turn_player_b && m_GameManager.Computermode)
            {
                Board board = m_GameManager.Insert(-1, out status, out turnName);
                System.Console.WriteLine(status.ToString());
                System.Console.WriteLine(turnName);
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
