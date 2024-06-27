using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperGUI
{
    public class PlayerStats : IComparable<PlayerStats>
    {
        public string Name { get; set; }
        public string Time { get; set; }
        public string Level { get; set; }

        public int CompareTo(PlayerStats other)
        {
            return Time.CompareTo(other.Time);  
        }
    }
}
