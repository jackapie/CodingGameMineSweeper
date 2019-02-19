using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameMineSweeper
{
    class LocationBombFinder
    {
        //List<Location> PossibleBombs { get; set; }

        Location Location { get; set; }

        public Grid Grid { get; set; }

        int SurroundingBombsToFind { get; set; }

        public Location Check(int row, int column)
        {
            var possibleBomb = new Location();

            if (Grid.GridPattern[row][column].IsABomb)
            {
                SurroundingBombsToFind -= 1;
            }
            else if (Grid.GridPattern[row][column].IsPossibleBomb())
            {
                return Grid.GridPattern[row][column];
            }

            return null;

        }

        public List<Location> CheckByColumn(int column, Location location)
        {
            var possibleBombs = new List<Location>();

            var centreBomb = Check(location.Row, column);
            if (centreBomb != null)
            {
                possibleBombs.Add(centreBomb);
            }

            if (location.Row > 0)
            {
                var topBomb = Check(location.Row - 1, column);
                if (topBomb != null)
                {
                    possibleBombs.Add(topBomb);
                }
            }
            if (location.Row + 1 < Grid.TotalRows)
            {
                var bottomBomb = Check(location.Row + 1, column);
                if (bottomBomb != null)
                {
                    possibleBombs.Add(bottomBomb);
                }
            }

            return possibleBombs;
        }

        public List<Location> CheckSurroundingLocations()
        {
            var possibleBombs = new List<Location>();

            var bombLocations = new List<Location>();

            var centreBombs = CheckByColumn(Location.Column, Location);
            possibleBombs.AddRange(centreBombs);

            if (Location.Column > 0)
            {
                var leftBombs = CheckByColumn(Location.Column - 1, Location);
                possibleBombs.AddRange(leftBombs);
            }
            if (Location.Column + 1 < Grid.TotalColumns)
            {
                var rightBombs = CheckByColumn(Location.Column + 1, Location);
                possibleBombs.AddRange(rightBombs);
            }

            if (possibleBombs.Count == SurroundingBombsToFind)
            {
                foreach (var loc in possibleBombs)
                {
                    loc.IsABomb = true;
                    bombLocations.Add(loc);

                }
            }

            if (SurroundingBombsToFind == 0)
            {
                foreach (var loc in possibleBombs)
                {
                    loc.Value = '.';
                }
            }


            return bombLocations;
        }

        public LocationBombFinder(Grid grid, Location location)
        {
            Grid = grid;
            Location = location;
            SurroundingBombsToFind = int.Parse(location.Value.ToString());

        }
    }
}
