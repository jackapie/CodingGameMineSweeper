using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameMineSweeper
{
    public class GridBombFinder
    {
        public Grid Grid { get; set; }

        public List<Location> BombLocations { get; set; }



        public int BombsFound { get; set; }





        public void SearchGridForBombs()
        {
            foreach (var row in Grid.GridPattern)
            {
                foreach (var location in row)
                {
                    if (location.IsANumber() == true)
                    {
                        var locationBombFinder = new LocationBombFinder(Grid, location);

                        var bombLocations = locationBombFinder.CheckSurroundingLocations();

                        BombLocations.AddRange(bombLocations);
                    }
                }
            }
        }

        private void CompareBombsLeftCheck()
        {

            var possibleBombs = new List<Location>();
            foreach (var row in Grid.GridPattern)
            {
                foreach (var location in row)
                {
                    if (location.IsPossibleBomb() == true)
                    {
                        possibleBombs.Add(location);
                    }
                }
            }
            if (possibleBombs.Count == Grid.NumberOfBombs)
            {
                foreach (var loc in possibleBombs)
                {
                    if (loc.IsABomb == false)
                    {
                        loc.IsABomb = true;
                        BombLocations.Add(loc);
                    }
                }
            }
        }

        public void FindBombs()
        {
            BombLocations = new List<Location>();
            while (BombLocations.Count < Grid.NumberOfBombs)
            {
                SearchGridForBombs();
                CompareBombsLeftCheck();
            }

            BombsFound = BombLocations.Count;

        }

        public GridBombFinder(Grid grid)
        {
            Grid = grid;
        }



    }
}
