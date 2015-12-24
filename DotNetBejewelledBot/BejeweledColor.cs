using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DotNetBejewelledBot
{
    public class BejeweledColor
    {
        public static List<Color> Collection;

        public static Color Green
        {
            get
            {
                return Color.FromArgb(255, 7, 190, 26);
            }
        }

        public static Color Blue
        {
            get
            {
                return Color.FromArgb(255, 12, 136, 254);
            }
        } 

        public static Color Red
        {
            get
            {
                return Color.FromArgb(255, 240, 25, 51);
            }
        }

        public static Color Yellow
        {
            get
            {
                return Color.FromArgb(255, 254, 234, 33);
            }
        }

        public static Color Orange
        {
            get
            {
                return Color.FromArgb(255, 240, 96, 20);
            }
        }

        public static Color White
        {
            get
            {
                return Color.FromArgb(255, 238, 238, 238);
            }
        }

        public static Color Purple
        {
            get
            {
                return Color.FromArgb(255, 233, 14, 233);
            }
        }
    }
}
