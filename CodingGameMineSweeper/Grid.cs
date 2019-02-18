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
                
        public List<List<Location>> GridPattern { get; set; }

        public int TotalColumns { get; set; }
        
        public int TotalRows { get; set; }
        

        public Grid(List<string> gridInput)
        {
            TotalRows = gridInput.Count;
            TotalColumns = gridInput[0].Length;
            GridPattern = new List<List<Location>>();

            for (int i = 0; i < TotalRows; i++)
            {
                var patternRow = new List<Location>();
                for (int j = 0; j < TotalColumns; j++)
                {
                    var location = new Location()
                    {
                        Row = i,
                        Column = j,
                        Value = gridInput[i][j]
                    };
                    patternRow.Add(location);
                }
                GridPattern.Add(patternRow);
            }
        }
    }
}
