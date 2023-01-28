using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows.Media;

namespace HW_WpfApp_Snowman
{
   static class ColorsSnowman
    {
        public static System.Windows.Media.SolidColorBrush GetColor (int random = 0)
        {
            switch (random)
            {
                case 1:
                    return Brushes.Red;
                case 2:
                    return Brushes.Green;
                case 3:
                    return Brushes.Yellow;
                case 4:
                    return Brushes.Blue;
                case 5:
                    return Brushes.DarkBlue;
                case 6:
                    return Brushes.Aqua;
                case 7:
                    return Brushes.Coral;
                case 8:
                    return Brushes.Crimson;
                case 9:
                    return Brushes.Brown;
                case 10:
                    return Brushes.DarkGray;
                case 11:
                    return Brushes.Orange;
                case 12:
                    return Brushes.OrangeRed;
                case 13:
                    return Brushes.Purple;
                case 14:
                    return Brushes.Pink;
                case 15:
                    return Brushes.Coral;
                case 16:
                    return Brushes.Chocolate;
                case 17:
                    return Brushes.Gold;
                case 18:
                    return Brushes.DarkOliveGreen;
                case 19:
                    return Brushes.CornflowerBlue;
                case 20:
                    return Brushes.Fuchsia;
                default:
                    return Brushes.Black;
            }
            
        }
        
    }
}
