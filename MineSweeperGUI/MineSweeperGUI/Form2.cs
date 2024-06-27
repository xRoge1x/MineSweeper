using MinesweeperV4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeperGUI
{
    public partial class Form2 : Form
    {
        static public Board myBoard = new Board(10);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        private static int Difficulty;
        public static Stopwatch watch = new Stopwatch();

        public Form2(int difficulty)
        {
            InitializeComponent();
            createBoard();
            Difficulty = difficulty;
        }

        public void createBoard()
        {

            // function to fill board with buttons
            int buttonSize = panel1.Width / myBoard.Size; //myBoard will be myBoard.Size once this info is passed to Form2.

            panel1.Height = panel1.Width;// set grid to be square.

            // Creat buttons and place them in the panel
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c] = new Button();

                    // make each button square
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;
                    btnGrid[r, c].BackColor = Color.CornflowerBlue;

                    // Allow for left click and right click events
                    btnGrid[r, c].MouseDown += Grid_Button_MouseDown;

                    panel1.Controls.Add(btnGrid[r, c]);// place button on panel
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c);

                    btnGrid[r, c].Tag = r.ToString() + " , " + c.ToString();
                }
            }

        }

        private void Grid_Button_MouseDown(object sender, MouseEventArgs a)
        {
            Bitmap image = new Bitmap("C:\\Users\\Broge\\source\\CST-250\\MineSweeperGUI\\MineSweeperGUI\\Flag.png");

            // Get row and column of button just clicked
            string[] strArr = (sender as Button).Tag.ToString().Split(',');

            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            // get current grid coordinate for the clicked button
            Cell currentCell = myBoard.Grid[r, c];

            if (a.Button == MouseButtons.Right)
            {
                // toggle flag image on or off with each right click
                if (btnGrid[r, c].BackgroundImage == null)
                {
                    btnGrid[r, c].BackgroundImage = image;
                }
                else
                {
                    btnGrid[r, c].BackgroundImage = null;
                }
            }
            else if (a.Button == MouseButtons.Left)
            {
                myBoard.UserVisitedStatus(r, c);
                myBoard.floodFill(r, c);
                updateButtons();

                if (currentCell.LiveBomb == true)
                {
                    gameOverLose();
                    this.Hide();
                    string elapsedTime = getTime();
                    Form4 form4 = new Form4();
                    form4.Show();
                }
                else if (myBoard.checkEndGame() == false)
                {
                    gameOverWin();
                    this.Hide();
                    string elapsedTime = getTime();
                    Form3 form3 = new Form3(elapsedTime, Difficulty);
                    form3.Show();
                }
            }
        }

        // Updates the GUI to display current state of the game.
        public void updateButtons()
        {
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c].Text = "";

                    if (myBoard.Grid[r, c].Visited != true)
                    {
                        btnGrid[r, c].Text = " ";
                    }
                    else if (myBoard.Grid[r, c].Visited == true)
                    {
                        btnGrid[r, c].BackColor = Color.AliceBlue;

                        if (myBoard.Grid[r, c].LiveNeighbors > 0 && myBoard.Grid[r, c].LiveNeighbors <= 9)
                        {
                            btnGrid[r, c].Text = " " + myBoard.Grid[r, c].LiveNeighbors + " ";
                        }
                    }
                }
            }
        }

        // Changes board and buttons if user loses.
        public void gameOverLose()
        {
            Bitmap image = new Bitmap("C:\\Users\\Broge\\source\\CST-250\\MineSweeperGUI\\MineSweeperGUI\\Bomb.png");
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    myBoard.Grid[r, c].Visited = true;
                    btnGrid[r, c].BackColor = Color.AliceBlue;
                    if (myBoard.Grid[r, c].LiveBomb == true)
                    {
                        btnGrid[r, c].BackgroundImage = image;
                    }
                    else if (myBoard.Grid[r, c].LiveNeighbors > 0 && myBoard.Grid[r, c].LiveNeighbors <= 9)
                    {
                        btnGrid[r, c].Text = " " + myBoard.Grid[r, c].LiveNeighbors + " ";
                    }
                    else
                    {
                        btnGrid[r, c].BackgroundImage = null;
                    }
                }
            }
            string elapsedTime = getTime();
            MessageBox.Show("Oh no! You hit a Bomb \nGAME OVER\n" + "Time elapsed: " + elapsedTime);
        }

        // Changes board if user wins.
        public void gameOverWin()
        {
            Bitmap image = new Bitmap("C:\\Users\\Broge\\source\\CST-250\\MineSweeperGUI\\MineSweeperGUI\\Flag.png");
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    myBoard.Grid[r, c].Visited = true;
                    btnGrid[r, c].BackColor = Color.AliceBlue;
                    if (myBoard.Grid[r, c].LiveBomb == true)
                    {
                        btnGrid[r, c].BackgroundImage = image;
                    }
                    else if (myBoard.Grid[r, c].LiveNeighbors > 0 && myBoard.Grid[r, c].LiveNeighbors <= 9)
                    {
                        btnGrid[r, c].Text = " " + myBoard.Grid[r, c].LiveNeighbors + " ";
                    }
                    else
                    {
                        btnGrid[r, c].BackgroundImage = null;
                    }
                }
            }
            string elapsedTime = getTime();
            MessageBox.Show("WINNER \nYou found all the bombs!\n" + "Time elapsed: " + elapsedTime);
        }

        public string getTime()
        {
            // Get elapsed time as a TimeSpan value.
            TimeSpan ts = watch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

            watch.Stop();
            return elapsedTime;
        }

        // On load set up the difficulty and board randomly.
        private void Form2_Load(object sender, EventArgs e)
        {
            myBoard.setDifficulty(Difficulty);
            myBoard.calculateLiveNeighbors();
            watch.Start();
        }
    }
}
