using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGUI
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        // Populate the listBoxes with player stats
        private void Form4_Load(object sender, EventArgs e)
        {
            loadStats();
        }
        // Populate the listBoxes with player stats from the file
        private void loadStats()
        {
            string filePath = @"C:\Demos\PlayerStats.txt";

            List<PlayerStats> player = new List<PlayerStats>();
            List<String> lines = File.ReadAllLines(filePath).ToList();

            if (lines.Count > 0)
            {
                foreach (string line in lines)
                {
                    string[] entries = line.Split(',');

                    PlayerStats p = new PlayerStats();
                    p.Name = entries[0];
                    p.Level = entries[1];
                    p.Time = entries[2];

                    player.Add(p);

                }

                // Sorting the ArrayList based on time
                var sortedPlayers = player.Cast<PlayerStats>().OrderBy(s => s).ToList();

                int countLvl3 = 0;
                int countLvl2 = 0;
                int countLvl1 = 0;

                // Foreach loop used to place the string of the file in the correct best time box based on their level of difficulty
                foreach (PlayerStats p in sortedPlayers)
                {
                    if (p.Level == "3")
                    {
                        if (countLvl3 < 5)
                        {
                            listBoxLvl3Hard.Items.Add("Name: " + p.Name + ", Level: " + p.Level + ", Time: " + p.Time);
                            countLvl3++;
                        }
                    }
                    else if (p.Level == "2")
                    {
                        if (countLvl2 < 5)
                        {
                            listBoxLvl2Medium.Items.Add("Name: " + p.Name + ", Level: " + p.Level + ", Time: " + p.Time);
                            countLvl2++;
                        }
                    }
                    else if (p.Level == "1")
                    {
                        if (countLvl1 < 5)
                        {
                            listBoxLvl1Easy.Items.Add("Name: " + p.Name + ", Level: " + p.Level + ", Time: " + p.Time);
                            countLvl1++;
                        }
                    }
                }

                // Fill remaining slots with "No best time recorded"
                for (int i = countLvl3; i < 5; i++)
                {
                    listBoxLvl3Hard.Items.Add("No best time recorded");
                }

                for (int i = countLvl2; i < 5; i++)
                {
                    listBoxLvl2Medium.Items.Add("No best time recorded");
                }

                for (int i = countLvl1; i < 5; i++)
                {
                    listBoxLvl1Easy.Items.Add("No best time recorded");
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    listBoxLvl3Hard.Items.Add("No best time recorded");
                    listBoxLvl2Medium.Items.Add("No best time recorded");
                    listBoxLvl1Easy.Items.Add("No best time recorded");
                }
            }
        }

        // CLose the application
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Restart the application
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
