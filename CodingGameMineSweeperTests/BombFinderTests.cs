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

            var grid = new Grid(gridInput, 1);
            

            var bombFinder = new GridBombFinder(grid);
            
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

            var grid = new Grid(gridInput, 4);
           
            var bombFinder = new GridBombFinder(grid);
           
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

            var grid = new Grid(gridInput, 9);
            
            var bombFinder = new GridBombFinder(grid);
            
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

            var grid = new Grid(gridInput, 6);
           
            var bombFinder = new GridBombFinder(grid);
            
            bombFinder.FindBombs();

            Assert.AreEqual(6, bombFinder.BombsFound);

        }

        [TestMethod()]
        public void FindBombsTest5()
        {
            var gridInput = new List<string>()
                {
                    "?1....1??",
                    "?2....12?",
                    "?1.....11",
                    "11.......",
                    "12221..11",
                    "????2112?",
                    "????21???",
                    "????32???",
                    "????2????"
                };

            var grid = new Grid(gridInput, 12);
           
            var bombFinder = new GridBombFinder(grid);
            
            bombFinder.FindBombs();

            Assert.AreEqual(12, bombFinder.BombsFound);

        }
    }
}