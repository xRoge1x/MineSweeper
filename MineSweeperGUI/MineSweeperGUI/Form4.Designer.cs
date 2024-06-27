namespace MineSweeperGUI
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnExit = new Button();
            listBoxLvl1Easy = new ListBox();
            label4 = new Label();
            listBoxLvl2Medium = new ListBox();
            label3 = new Label();
            label2 = new Label();
            listBoxLvl3Hard = new ListBox();
            btnPlayAgain = new Button();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Location = new Point(258, 474);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(126, 61);
            btnExit.TabIndex = 16;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // listBoxLvl1Easy
            // 
            listBoxLvl1Easy.FormattingEnabled = true;
            listBoxLvl1Easy.ItemHeight = 15;
            listBoxLvl1Easy.Location = new Point(85, 362);
            listBoxLvl1Easy.Name = "listBoxLvl1Easy";
            listBoxLvl1Easy.Size = new Size(351, 94);
            listBoxLvl1Easy.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Russo One", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(183, 343);
            label4.Name = "label4";
            label4.Size = new Size(123, 16);
            label4.TabIndex = 14;
            label4.Text = "Level 1 Best Time";
            // 
            // listBoxLvl2Medium
            // 
            listBoxLvl2Medium.FormattingEnabled = true;
            listBoxLvl2Medium.ItemHeight = 15;
            listBoxLvl2Medium.Location = new Point(85, 228);
            listBoxLvl2Medium.Name = "listBoxLvl2Medium";
            listBoxLvl2Medium.Size = new Size(351, 94);
            listBoxLvl2Medium.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Russo One", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(183, 209);
            label3.Name = "label3";
            label3.Size = new Size(126, 16);
            label3.TabIndex = 12;
            label3.Text = "Level 2 Best Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Russo One", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(183, 80);
            label2.Name = "label2";
            label2.Size = new Size(126, 16);
            label2.TabIndex = 11;
            label2.Text = "Level 3 Best Time";
            // 
            // listBoxLvl3Hard
            // 
            listBoxLvl3Hard.FormattingEnabled = true;
            listBoxLvl3Hard.ItemHeight = 15;
            listBoxLvl3Hard.Location = new Point(85, 99);
            listBoxLvl3Hard.Name = "listBoxLvl3Hard";
            listBoxLvl3Hard.Size = new Size(351, 94);
            listBoxLvl3Hard.TabIndex = 10;
            // 
            // btnPlayAgain
            // 
            btnPlayAgain.Location = new Point(126, 474);
            btnPlayAgain.Name = "btnPlayAgain";
            btnPlayAgain.Size = new Size(126, 61);
            btnPlayAgain.TabIndex = 17;
            btnPlayAgain.Text = "Play Again";
            btnPlayAgain.UseVisualStyleBackColor = true;
            btnPlayAgain.Click += btnPlayAgain_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(507, 619);
            Controls.Add(btnPlayAgain);
            Controls.Add(btnExit);
            Controls.Add(listBoxLvl1Easy);
            Controls.Add(label4);
            Controls.Add(listBoxLvl2Medium);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBoxLvl3Hard);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private ListBox listBoxLvl1Easy;
        private Label label4;
        private ListBox listBoxLvl2Medium;
        private Label label3;
        private Label label2;
        private ListBox listBoxLvl3Hard;
        private Button btnPlayAgain;
    }
}