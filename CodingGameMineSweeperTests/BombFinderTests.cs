using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingGameMineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameMineSweeper.Tests
{
    [TestClass()]
    public class BombFinderTests
    {
        [TestMethod()]
        public void FindBombsTest()
        {
            var gridInput = new List<string>()
                {
                    "1?1",
                    "111"

                };

            var grid = new Grid(gridInput);
            grid.NumberOfBombs = 1;

            var bombFinder = new BombFinder();
            bombFinder.Grid = grid;
            bombFinder.FindBombs();

            Assert.AreEqual(1, bombFinder.BombsFound);

        }

        [TestMethod()]
        public void FindBombsTest2()
        {
            var gridInput = new List<string>()
                {
                    ".1???1",
                    ".11211",
                    "11....",
                    "?2....",
                    "?2....",
                    "11...."
                };

            var grid = new Grid(gridInput);
            grid.NumberOfBombs = 4;

            var bombFinder = new BombFinder();
            bombFinder.Grid = grid;
            bombFinder.FindBombs();

            Assert.AreEqual(4, bombFinder.BombsFound);

        }

        [TestMethod()]
        public void FindBombsTest3()
        {
            var gridInput = new List<string>()
                {
                    ".................",
                    "11112211232222211",
                    "?????????????????"
                 };

            var grid = new Grid(gridInput);
            grid.NumberOfBombs = 9;

            var bombFinder = new BombFinder();
            bombFinder.Grid = grid;
            bombFinder.FindBombs();

            Assert.AreEqual(9, bombFinder.BombsFound);

        }

        [TestMethod()]
        public void FindBombsTest4()
        {
            var gridInput = new List<string>()
                {
                    ".....",
                    "..122",
                    "..2??",
                    "..3??",
                    "..2??"
                };

            var grid = new Grid(gridInput);
            grid.NumberOfBombs = 6;

            var bombFinder = new BombFinder();
            bombFinder.Grid = grid;
            bombFinder.FindBombs();

            Assert.AreEqual(6, bombFinder.BombsFound);

        }
    }
}