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
                    ".1???1",
                    ".11211",
                    "11....",
                    "?2....",
                    "?2....",
                    "11...."
                };

            var grid = new Grid(gridInput);
            grid.NumberOfBombs = 4;
            

            Assert.Fail();
        }
    }
}