using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperV4
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Visited { get; set; }
        public bool LiveBomb { get; set; }
        public int LiveNeighbors { get; set; }


        public Cell()
        {
            Row = -1;
            Column = -1;
            LiveNeighbors = 0;
            Visited = false;
            LiveBomb = false;
        }

    }
}
