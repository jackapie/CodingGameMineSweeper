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

        int BombsFound = 0;

        List<Location> BombLocations { get; set; }

        List<Location> PossibleBombs { get; set; }

        int SurroundingBombsToFind { get; set; }

        public void Check(int column, int row, Location location)
        {
            if (Grid.GridPattern[row][column].IsABomb)
            {
                SurroundingBombsToFind -= 1;
            }
            else if(Grid.GridPattern[row][column].IsPossibleBomb())
            {
                PossibleBombs.Add(location);
            }
        }

        public void CheckColumn(int column, Location location)
        {
            Check(column, location.Row, location);//check location in centre row
            if(location.Row > 0)
            {
                Check(column, location.Row - 1, location);//check location above
            }
            if(location.Row < Grid.TotalRows)
            {
                Check(column, location.Row + 1, location);//check location below
            }
        }

        public void CheckSurroundingLocations(Location location)
        {
            CheckColumn(location.Column, location);//check centre colummn
            if (location.Column > 0)
            {
                CheckColumn(location.Column - 1, location);//check left column
            }
            if(location.Column < Grid.TotalColumns)
            {
                CheckColumn(location.Column - 1, location);//check right column
            }

            if(PossibleBombs.Count == SurroundingBombsToFind)
            {
                foreach(var loc in PossibleBombs)
                {
                    loc.IsABomb = true;
                    BombLocations.Add(location);
                    BombsFound++;
                }
            }
            PossibleBombs.Clear();
        }

        public void SearchGridForBombs()
        {
            foreach(var row in Grid.GridPattern)
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
            while(BombsFound < Grid.NumberOfBombs)
            {
                SearchGridForBombs();
            }


        }
    }
}
