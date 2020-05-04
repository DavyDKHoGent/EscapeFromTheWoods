using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace EscapeFromTheWoods
{
    class Program
    {
        static void Main()
        {
            Bitmap bitmap = new Bitmap(1000, 1000);
            
            DatabaseManager dbm = new DatabaseManager(@"Data Source=LAPTOP-1U6AQSEQ\SQLEXPRESS;Initial Catalog=EscapeFromTheWoods;Integrated Security=True");
            int monkeyId = dbm.GetMonkeyId();

            List<Aap> apen = new List<Aap>
            {
                new Aap(monkeyId, "Jeff", Graphics.FromImage(bitmap), new Pen(Color.Red, 1)),
                new Aap(monkeyId+1, "Kwak", Graphics.FromImage(bitmap), new Pen(Color.Yellow, 1)),
                new Aap(monkeyId+2, "Azomopoirodovvody", Graphics.FromImage(bitmap), new Pen(Color.Blue, 1))
            };

            int aantalBomen = (bitmap.Width + bitmap.Height) / 2;
            int woodId = dbm.GetWoodId();
            Bos bos = new Bos(woodId, bitmap, apen, aantalBomen);

            Escape.Run(bos, new System.Diagnostics.Stopwatch());
            
            bos.Bitmap.Save(Path.Combine(@"C:\Users\davy\Documents\data\EscapeFromTheWoods", $"{bos.Id}_Escapethewoods.Jpeg"), ImageFormat.Jpeg);
        }
    }
}
