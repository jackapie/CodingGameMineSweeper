using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingGameMineSweeper
{
    public class Location
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public char Value { get; set; }

        bool IsPossibleBomb()
        {
            if(Value == '?')
            {
                return true;
            }
            return false;
        }

        string Numbers = "12345678";

        bool IsANumber()
        {
            if (Numbers.Contains(Value))
            {
                return true;
            }
            return false;
        }

        public bool IsABomb { get; set; }
    }
}
