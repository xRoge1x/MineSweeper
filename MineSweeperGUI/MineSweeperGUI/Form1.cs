using MinesweeperV4;

namespace MineSweeperGUI
{
    public partial class Form1 : Form
    {
        PlayerStats playerStats = new PlayerStats();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int difficulty = 0;

            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
            {
                if (radioButton1.Checked == true)
                {
                    difficulty = 1;
                }
                else if (radioButton2.Checked == true)
                {
                    difficulty = 2;
                }
                else if (radioButton3.Checked == true)
                {
                    difficulty = 3;
                }


                playerStats.Level = difficulty.ToString();

                Form2 form2 = new Form2(difficulty);
                this.Hide();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Please choose a difficulty setting.");
            }

        }
    }
}