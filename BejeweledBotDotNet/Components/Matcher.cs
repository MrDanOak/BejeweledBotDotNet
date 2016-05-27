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
        public int Priority { get; set; }
        public int Id { get; set; }
        private bool _reversible;
        public bool Reversible
        {
            get
            {
                return !_reversible;
            }
            set
            {
                _reversible = !value;
            }
        }
    }
}
