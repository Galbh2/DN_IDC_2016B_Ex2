using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DN_IDC_2016B_Ex2
{
    class OptionsForm : Form
    {
        private Label Players;
        private Label PlayerA;
        private Label PlayerB;
        private TextBox PlayerANameText;
        private TextBox PlayerBNameText;
        private Label BoardSize;
        private Label Rows;
        private NumericUpDown RowsNum;
        private Label Cols;
        private NumericUpDown ColsNum;
        private Button StartButton;
        private CheckBox PlayerBCheckBox;

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Players = new System.Windows.Forms.Label();
            this.PlayerA = new System.Windows.Forms.Label();
            this.PlayerB = new System.Windows.Forms.Label();
            this.PlayerBCheckBox = new System.Windows.Forms.CheckBox();
            this.PlayerANameText = new System.Windows.Forms.TextBox();
            this.PlayerBNameText = new System.Windows.Forms.TextBox();
            this.BoardSize = new System.Windows.Forms.Label();
            this.Rows = new System.Windows.Forms.Label();
            this.RowsNum = new System.Windows.Forms.NumericUpDown();
            this.Cols = new System.Windows.Forms.Label();
            this.ColsNum = new System.Windows.Forms.NumericUpDown();
            this.StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RowsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColsNum)).BeginInit();
            this.SuspendLayout();
            // 
            // Players
            // 
            this.Players.AutoSize = true;
            this.Players.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Players.Location = new System.Drawing.Point(25, 20);
            this.Players.Name = "Players";
            this.Players.Size = new System.Drawing.Size(85, 26);
            this.Players.TabIndex = 0;
            this.Players.Text = "Players";
            // 
            // PlayerA
            // 
            this.PlayerA.AutoSize = true;
            this.PlayerA.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.PlayerA.Location = new System.Drawing.Point(60, 59);
            this.PlayerA.Name = "PlayerA";
            this.PlayerA.Size = new System.Drawing.Size(98, 26);
            this.PlayerA.TabIndex = 0;
            this.PlayerA.Text = "Player 1:";
            // 
            // PlayerB
            // 
            this.PlayerB.AutoSize = true;
            this.PlayerB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.PlayerB.Location = new System.Drawing.Point(86, 97);
            this.PlayerB.Name = "PlayerB";
            this.PlayerB.Size = new System.Drawing.Size(98, 26);
            this.PlayerB.TabIndex = 0;
            this.PlayerB.Text = "Player 2:";
            // 
            // PlayerBCheckBox
            // 
            this.PlayerBCheckBox.AutoSize = true;
            this.PlayerBCheckBox.Location = new System.Drawing.Point(65, 105);
            this.PlayerBCheckBox.Name = "PlayerBCheckBox";
            this.PlayerBCheckBox.Size = new System.Drawing.Size(15, 14);
            this.PlayerBCheckBox.TabIndex = 1;
            this.PlayerBCheckBox.UseVisualStyleBackColor = true;
            // 
            // PlayerANameText
            // 
            this.PlayerANameText.Location = new System.Drawing.Point(201, 59);
            this.PlayerANameText.Name = "PlayerANameText";
            this.PlayerANameText.Size = new System.Drawing.Size(186, 20);
            this.PlayerANameText.TabIndex = 2;
            // 
            // PlayerBNameText
            // 
            this.PlayerBNameText.Enabled = false;
            this.PlayerBNameText.Location = new System.Drawing.Point(201, 97);
            this.PlayerBNameText.Name = "PlayerBNameText";
            this.PlayerBNameText.Size = new System.Drawing.Size(186, 20);
            this.PlayerBNameText.TabIndex = 3;
            this.PlayerBNameText.Text = "[Computer]";
            // 
            // BoardSize
            // 
            this.BoardSize.AutoSize = true;
            this.BoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BoardSize.Location = new System.Drawing.Point(25, 169);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(125, 26);
            this.BoardSize.TabIndex = 4;
            this.BoardSize.Text = "Board Size:";
            // 
            // Rows
            // 
            this.Rows.AutoSize = true;
            this.Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Rows.Location = new System.Drawing.Point(71, 232);
            this.Rows.Name = "Rows";
            this.Rows.Size = new System.Drawing.Size(62, 24);
            this.Rows.TabIndex = 4;
            this.Rows.Text = "Rows:";
            // 
            // RowsNum
            // 
            this.RowsNum.Location = new System.Drawing.Point(140, 235);
            this.RowsNum.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.RowsNum.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.RowsNum.Name = "RowsNum";
            this.RowsNum.Size = new System.Drawing.Size(61, 20);
            this.RowsNum.TabIndex = 5;
            this.RowsNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Cols
            // 
            this.Cols.AutoSize = true;
            this.Cols.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.Cols.Location = new System.Drawing.Point(243, 232);
            this.Cols.Name = "Cols";
            this.Cols.Size = new System.Drawing.Size(47, 24);
            this.Cols.TabIndex = 4;
            this.Cols.Text = "Cols";
            // 
            // ColsNum
            // 
            this.ColsNum.Location = new System.Drawing.Point(312, 235);
            this.ColsNum.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ColsNum.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ColsNum.Name = "ColsNum";
            this.ColsNum.Size = new System.Drawing.Size(61, 20);
            this.ColsNum.TabIndex = 5;
            this.ColsNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(30, 296);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(357, 47);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // OptionsForm
            // 
            this.ClientSize = new System.Drawing.Size(418, 368);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ColsNum);
            this.Controls.Add(this.RowsNum);
            this.Controls.Add(this.Cols);
            this.Controls.Add(this.Rows);
            this.Controls.Add(this.BoardSize);
            this.Controls.Add(this.PlayerBNameText);
            this.Controls.Add(this.PlayerANameText);
            this.Controls.Add(this.PlayerBCheckBox);
            this.Controls.Add(this.PlayerB);
            this.Controls.Add(this.PlayerA);
            this.Controls.Add(this.Players);
            this.Name = "OptionsForm";
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.RowsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColsNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            GameManager manager = new GameManager(
                    PlayerANameText.Text,
                    PlayerBNameText.Text,
                    !PlayerBCheckBox.Checked,
                    (int)RowsNum.Value,
                    (int)ColsNum.Value
                );

            GameUI gameUI = new GameUI(manager);
            this.Close();
            this.Dispose();
            gameUI.ShowDialog();
            
        }
    }
}
