using MinesweeperV4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperV4
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] Grid { get; set; }
        public double Difficulty { get; set; }



        public Board(int size)
        {
            Size = size;

            // initialize array to avoid Null Exception errors
            Grid = new Cell[Size, Size];

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new Cell();
                }
            }
        }
        // Used to check the index for the floodFill method.
        public bool withinBounds(int row, int col)
        {
            if (row >= 0 && row < Size && col >= 0 && col < Size)
                return true;

            else
                return false;
        }

        // Method to set status/view of all connecting cells from user selected cell.
        public void floodFill(int row, int col)
        {
            Grid[row, col].Visited = true;

            if (Grid[row, col].LiveBomb != true)// If the cell is not a bomb then continue
            {

                if (withinBounds(row - 1, col) == true && !Grid[row - 1, col].LiveBomb == true)// If the next cell is not a bomb and it is within bounds of the grid then continue
                {
                    if (Grid[row - 1, col].LiveNeighbors > 0 && Grid[row - 1, col].LiveNeighbors <= 8)// if the cell has a live neighbor value then set visited status to true
                    {
                        Grid[row - 1, col].Visited = true;
                    }

                    if (!Grid[row - 1, col].Visited == true)// If the cell is not visited then continue, but if the floodFill method hits a liveNeighbor then it stops going in that direction
                    {
                        floodFill(row - 1, col);// Up
                    }
                }

                if (withinBounds(row, col + 1) == true && !Grid[row, col + 1].LiveBomb == true)
                {
                    if (Grid[row, col + 1].LiveNeighbors > 0 && Grid[row, col + 1].LiveNeighbors <= 8)
                    {
                        Grid[row, col + 1].Visited = true;
                    }

                    if (!Grid[row, col + 1].Visited == true)
                    {
                        floodFill(row, col + 1);// Right
                    }
                }

                if (withinBounds(row + 1, col) == true && !Grid[row + 1, col].LiveBomb == true)
                {
                    if (Grid[row + 1, col].LiveNeighbors > 0 && Grid[row + 1, col].LiveNeighbors <= 8)
                    {
                        Grid[row + 1, col].Visited = true;
                    }

                    if (!Grid[row + 1, col].Visited == true)
                    {
                        floodFill(row + 1, col);// Down
                    }
                }

                if (withinBounds(row, col - 1) == true && !Grid[row, col - 1].LiveBomb == true)
                {
                    if (Grid[row, col - 1].LiveNeighbors > 0 && Grid[row, col - 1].LiveNeighbors <= 8)
                    {
                        Grid[row, col - 1].Visited = true;
                    }
                    if (!Grid[row, col - 1].Visited == true)
                    {
                        floodFill(row, col - 1);// Left
                    }
                }

            }
            else
            {
                return;
            }
        }

        public void setupLiveBomb()
        {
            // setup at random the placement of the bombs on the board.
            Random ran = new Random();
            Random ran1 = new Random();
            int rand1 = ran.Next(0, Size);
            int rand2 = ran1.Next(0, Size);

            try
            {   // if the cell is not live then set it to live.
                // If it finds a cell that is already live then run the function again until it finds a inert cell.
                if (!Grid[rand1, rand2].LiveBomb)
                {
                    Grid[rand1, rand2].LiveBomb = true;
                }
                else
                {
                    setupLiveBomb();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool checkEndGame()
        {
            int visitedCells = 0;
            int remainingInertCells = TotalInertCells();

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (Grid[row, col].Visited == true && Grid[row, col].LiveBomb != true)
                    {
                        visitedCells++;// Get total number of visited cells at this time.
                    }
                }
            }

            if (visitedCells == remainingInertCells)// Check to see if the number of visited cells matches the total number of cells that can be visited then end the game.
            {
                return false;// Set while loop to false ending the game.
            }

            return true;// if it is not false then keep playing.
        }

        public int TotalInertCells()// Method to see how many cells are inert.
        {
            int totalInertCells = 0;

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (Grid[row, col].LiveBomb != true)
                    {
                        totalInertCells++;
                    }
                }
            }
            return totalInertCells;
        }

        
        public void calculateLiveNeighbors()// Used to set the numbers on the board.
        {
            Cell cell = new Cell();
            // Get the length of the rows and columns to iterate over. 
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (Grid[row, col].LiveBomb == true)
                    {
                        // Set the live bomb LiveNeighbors count to 9
                        Grid[row, col].LiveNeighbors = 9;

                        // Iterate over the neighboring cells
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                int neighborRow = row + i;
                                int neighborColumn = col + j;
                                int liveNeighborCount = 0;

                                // Check if the neighbor is within the grid boundaries
                                if (neighborRow >= 0 && neighborRow < Size &&
                                    neighborColumn >= 0 && neighborColumn < Size)
                                {
                                    // check if the neighbor is a bomb
                                    if (Grid[neighborRow, neighborColumn].LiveBomb != true)
                                    {
                                        // If a bomb then increment liveNeighborCount by 1 and assign that grid point the number.
                                        if (Grid[neighborRow, neighborColumn].LiveNeighbors == 0)
                                        {
                                            liveNeighborCount++;
                                            Grid[neighborRow, neighborColumn].LiveNeighbors = liveNeighborCount;
                                        }
                                        else if (Grid[neighborRow, neighborColumn].LiveNeighbors == 1)
                                        {
                                            Grid[neighborRow, neighborColumn].LiveNeighbors++;
                                        }
                                        else if (Grid[neighborRow, neighborColumn].LiveNeighbors == 2)
                                        {
                                            Grid[neighborRow, neighborColumn].LiveNeighbors++;
                                        }
                                        else if (Grid[neighborRow, neighborColumn].LiveNeighbors == 3)
                                        {
                                            Grid[neighborRow, neighborColumn].LiveNeighbors++;
                                        }
                                        else if (Grid[neighborRow, neighborColumn].LiveNeighbors == 4)
                                        {
                                            Grid[neighborRow, neighborColumn].LiveNeighbors++;
                                        }
                                        else if (Grid[neighborRow, neighborColumn].LiveNeighbors == 5)
                                        {
                                            Grid[neighborRow, neighborColumn].LiveNeighbors++;
                                        }
                                        else if (Grid[neighborRow, neighborColumn].LiveNeighbors == 6)
                                        {
                                            Grid[neighborRow, neighborColumn].LiveNeighbors++;
                                        }
                                        else if (Grid[neighborRow, neighborColumn].LiveNeighbors == 7)
                                        {
                                            Grid[neighborRow, neighborColumn].LiveNeighbors++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // Used to see if the grid point is visited or not.
        public void UserVisitedStatus(int userRow, int userCol)
        {
            Grid[userRow, userCol].Visited = true;
        }

        // Method to set the difficulty of the game based on the users selection.
        public void setDifficulty(double difficulty)
        {
            if (difficulty == 1)// Calculate the difficulty based on the user choice.
            {
                difficulty = 0.3;
                for (int i = 0; i < (Size + Size) * difficulty; i++)
                {
                    setupLiveBomb();
                }
            }
            else if (difficulty == 2) // Calculate the difficulty based on the user choice.
            {
                difficulty = 0.5;
                for (int i = 0; i < (Size + Size) * difficulty; i++)
                {
                    setupLiveBomb();
                }

            }
            else if (difficulty == 3) // Calculate the difficulty based on the user choice.
            {
                difficulty = 0.7;
                for (int i = 0; i < (Size + Size) * difficulty; i++)
                {
                    setupLiveBomb();
                }

            }
        }
    }
}