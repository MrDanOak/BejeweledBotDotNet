using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBejewelledBot
{
    public class ResultMove
    {
        public PieceMove Move { get; set; }
        public int Value { get; set; }
        public int XOffset { get; set; }
        public int YOffset { get; set; }
        public bool[,] MatchMatrix { get; set; }
    }
}
