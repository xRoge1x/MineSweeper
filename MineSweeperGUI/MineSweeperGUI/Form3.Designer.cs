namespace MineSweeperGUI
{
    partial class Form3
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
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            listBoxLvl3Hard = new ListBox();
            label2 = new Label();
            label3 = new Label();
            listBoxLvl2Medium = new ListBox();
            label4 = new Label();
            listBoxLvl1Easy = new ListBox();
            btnExit = new Button();
            btnPlayAgain = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Russo One", 14.2499981F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(53, 47);
            label1.Name = "label1";
            label1.Size = new Size(404, 23);
            label1.TabIndex = 0;
            label1.Text = "Please enter your name to log your time.";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 87);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(204, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(217, 116);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBoxLvl3Hard
            // 
            listBoxLvl3Hard.FormattingEnabled = true;
            listBoxLvl3Hard.ItemHeight = 15;
            listBoxLvl3Hard.Location = new Point(87, 175);
            listBoxLvl3Hard.Name = "listBoxLvl3Hard";
            listBoxLvl3Hard.Size = new Size(351, 94);
            listBoxLvl3Hard.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Russo One", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(185, 156);
            label2.Name = "label2";
            label2.Size = new Size(126, 16);
            label2.TabIndex = 4;
            label2.Text = "Level 3 Best Time";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Russo One", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(185, 285);
            label3.Name = "label3";
            label3.Size = new Size(126, 16);
            label3.TabIndex = 5;
            label3.Text = "Level 2 Best Time";
            // 
            // listBoxLvl2Medium
            // 
            listBoxLvl2Medium.FormattingEnabled = true;
            listBoxLvl2Medium.ItemHeight = 15;
            listBoxLvl2Medium.Location = new Point(87, 304);
            listBoxLvl2Medium.Name = "listBoxLvl2Medium";
            listBoxLvl2Medium.Size = new Size(351, 94);
            listBoxLvl2Medium.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Russo One", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(185, 419);
            label4.Name = "label4";
            label4.Size = new Size(123, 16);
            label4.TabIndex = 7;
            label4.Text = "Level 1 Best Time";
            // 
            // listBoxLvl1Easy
            // 
            listBoxLvl1Easy.FormattingEnabled = true;
            listBoxLvl1Easy.ItemHeight = 15;
            listBoxLvl1Easy.Location = new Point(87, 438);
            listBoxLvl1Easy.Name = "listBoxLvl1Easy";
            listBoxLvl1Easy.Size = new Size(351, 94);
            listBoxLvl1Easy.TabIndex = 8;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(266, 553);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(126, 61);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnPlayAgain
            // 
            btnPlayAgain.Location = new Point(119, 553);
            btnPlayAgain.Name = "btnPlayAgain";
            btnPlayAgain.Size = new Size(126, 61);
            btnPlayAgain.TabIndex = 10;
            btnPlayAgain.Text = "Play Again";
            btnPlayAgain.UseVisualStyleBackColor = true;
            btnPlayAgain.Click += btnPlayAgain_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(520, 637);
            Controls.Add(btnPlayAgain);
            Controls.Add(btnExit);
            Controls.Add(listBoxLvl1Easy);
            Controls.Add(label4);
            Controls.Add(listBoxLvl2Medium);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBoxLvl3Hard);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private ListBox listBoxLvl3Hard;
        private Label label2;
        private Label label3;
        private ListBox listBoxLvl2Medium;
        private Label label4;
        private ListBox listBoxLvl1Easy;
        private Button btnExit;
        private Button btnPlayAgain;
    }
}