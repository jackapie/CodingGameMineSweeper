using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameMineSweeper
{
    class Program
    {
        static List<Location> OrderBombs(List<Location> bombLocations)
        {
            return bombLocations.OrderBy((e) => e.Column).ThenBy((e) => e.Row).ToList();
        }

        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int h = int.Parse(inputs[0]);
            int w = int.Parse(inputs[1]);
            int nb = int.Parse(Console.ReadLine());

            var gridInput = new List<string>();
            for (int i = 0; i < h; i++)
            {
                string line = Console.ReadLine();
                gridInput.Add(line);
            }

            var grid = new Grid(gridInput);
            grid.NumberOfBombs = nb;

            var bombFinder = new BombFinder();
            bombFinder.Grid = grid;
            bombFinder.FindBombs();
            var bombList = OrderBombs(bombFinder.BombLocations);

            foreach (var bomb in bombList)
            {
                var col = bomb.Column.ToString();
                var row = bomb.Row.ToString();


                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                Console.WriteLine(col + " " + row);
            }
        }
    }
}
