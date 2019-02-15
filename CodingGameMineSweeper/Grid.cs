using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameMineSweeper
{
    public class Grid
    {
        public int NumberOfBombs { get; set; }

        public List<Location> GridPattern { get; set; }

        int BombsFound = 0;
    }
}
