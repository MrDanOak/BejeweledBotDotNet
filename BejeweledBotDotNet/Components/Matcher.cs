using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBejewelledBot
{
    public class Matcher
    {
        public bool[,] MatchMatrix { get; set; }
        public PieceMove Move { get; set; }
        public int Value { get; set; }
    }
}
