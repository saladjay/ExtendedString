using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedString
{
    public class IntPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public IntPoint(int X,int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public IntPoint() : this(0, 0)
        {

        }

    }
}
