using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameMineSweeper
{
    public class BombFinder
    {
        public Grid Grid { get; set; }

        List<Location> BombLocations { get; set; }

        List<Location> PossibleBombs { get; set; }

        public int BombsFound { get; set; }

        int SurroundingBombsToFind { get; set; }

        public void Check(int row, int column)
        {
            if (Grid.GridPattern[row][column].IsABomb)
            {
                SurroundingBombsToFind -= 1;
            }
            else if (Grid.GridPattern[row][column].IsPossibleBomb())
            {
                PossibleBombs.Add(Grid.GridPattern[row][column]);
            }
        }

        public void CheckByColumn(int column, Location location)
        {
            Check(location.Row, column);//check location in centre row
            if (location.Row > 0)
            {
                Check(location.Row - 1, column);//check location above
            }
            if (location.Row + 1 < Grid.TotalRows)
            {
                Check(location.Row + 1, column);//check location below
            }
        }

        public void CheckSurroundingLocations(Location location)
        {
            PossibleBombs = new List<Location>();
            CheckByColumn(location.Column, location);//check centre colummn
            if (location.Column > 0)
            {
                CheckByColumn(location.Column - 1, location);//check left column
            }
            if (location.Column + 1 < Grid.TotalColumns)
            {
                CheckByColumn(location.Column + 1, location);//check right column
            }

            if (PossibleBombs.Count == SurroundingBombsToFind)
            {
                foreach (var loc in PossibleBombs)
                {
                    loc.IsABomb = true;
                    BombLocations.Add(loc);
                    
                }
            }

            if (SurroundingBombsToFind == 0)
            {
                foreach (var loc in PossibleBombs)
                {
                    loc.Value = '.';
                }
            }
            PossibleBombs.Clear();
        }

        public void SearchGridForBombs()
        {
            foreach (var row in Grid.GridPattern)
            {
                foreach (var location in row)
                {
                    if (location.IsANumber() == true)
                    {

                        SurroundingBombsToFind = int.Parse(location.Value.ToString());
                        CheckSurroundingLocations(location);
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
            }

            BombsFound = BombLocations.Count;
        }


    }
}
