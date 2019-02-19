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
    public class GridTests
    {
        [TestMethod()]
        public void GridPatternTest()
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

            
            Assert.AreEqual('?', grid.GridPattern[3][0].Value);
        }
    }
}