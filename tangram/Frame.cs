using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tangram
{
    internal class Frame
    {
        public Turn Turn { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Frame (Turn turn, int x, int y)
        {
            Turn = turn;
            X = x;
            Y = y;
        }
    }
}
