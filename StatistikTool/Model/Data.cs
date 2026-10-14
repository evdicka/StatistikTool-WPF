using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StatistikTool
{
    public class Data
    {
        public String Bezeichnung { get; set; }
        public double Wert { get; set; }
        public Brush Farbe { get; set; }
        public Data()
        {
            Random r = new Random();
            this.Farbe = new SolidColorBrush(
             Color.FromRgb((byte)r.Next(0, 255), (byte)r.Next(0, 255), (byte)r.Next(0, 255)));
        }
        public Data(String bez, double wert, Brush farbe)
        {
            this.Bezeichnung = bez;
            this.Wert = wert;
            this.Farbe = farbe;
        }
        public static List<Data> AlleLesen()
        {
            // hier wird in der Realität aus der Datenbank gelesen!
            List<Data> lst = new List<Data>();
            lst.Add(new Data("Tony", 47.2, Brushes.Red));
            lst.Add(new Data("Lisa", 7.9, Brushes.Blue));
            lst.Add(new Data("Susi", 17.2, Brushes.Yellow));
            lst.Add(new Data("Fred", 67.8, Brushes.Orange));

            return lst;
        }
    }
}
