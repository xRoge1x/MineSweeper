using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGUI
{
    public partial class Form3 : Form
    {
        PlayerStats playerStats = new PlayerStats();
        private static int Difficulty;
        private static string ElapsedTime;
        public Form3(string elapsedTime, int difficulty)
        {
            InitializeComponent();
            Difficulty = difficulty;
            ElapsedTime = elapsedTime;
        }

        // Add the player name, time, and level to a file and then call the method to populate the listboxes with that files data
        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList players = new ArrayList
            {
                // Adding player objects to the ArrayList
                new PlayerStats { Name = textBox1.Text, Level = Difficulty.ToString(), Time = ElapsedTime }
            };

            // Sorting the ArrayList based on time
            var sortedPlayers = players.Cast<PlayerStats>().OrderBy(s => s).ToList();

            // Creating a List of type string to hold the lines to output to the file.
            List<string> outputLines = new List<string>();

            // Add the sortedPlayers to the List
            foreach (var player in sortedPlayers)
            {
                outputLines.Add(player.Name + "," + player.Level + "," + player.Time);
            }

            // Creating the file to store the stats in
            string filePath = @"C:\Demos\PlayerStats.txt";

            // Check if the file already exists
            if (File.Exists(filePath))
            {
                // Read the existing lines from the file
                List<string> existingLines = File.ReadAllLines(filePath).ToList();

                // Add the new lines of text to the existing lines
                existingLines.AddRange(outputLines);

                // Write all the lines (existing + new) back to the file
                File.WriteAllLines(filePath, existingLines);
            }
            else
            {
                // The file doesn't exist, write the outputLines directly to the file
                File.WriteAllLines(filePath, outputLines);
            }

            // Populate the list boxes with the file contents.
            loadStats();

            // Clear the text box
            textBox1.Text = "";

            // Disables button so user can not make multiple entries.
            button1.Enabled = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Populate the listBoxes with player stats
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

                // loops to grab list items and if statements to ensure only 5 items are displayed in each listBox
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

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
