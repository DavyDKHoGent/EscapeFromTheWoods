using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EscapeFromTheWoods
{
    public class BosGenerator
    {
        public static Bos MaakBos(int aantalBossen, int breedte, int hoogte, int aantalBomen)
        {
            DatabaseManager dbm = new DatabaseManager(@"Data Source=LAPTOP-1U6AQSEQ\SQLEXPRESS;Initial Catalog=EscapeFromTheWoods;Integrated Security=True");
            int woodId = dbm.GetWoodId();
            Bitmap bitmap = new Bitmap(breedte, hoogte);
            List<Boom> bomen = MaakBomen(bitmap, aantalBomen);
            return new Bos(woodId + aantalBossen, bitmap, bomen);
        }
        private static List<Boom> MaakBomen(Bitmap bitmap, int aantalBomen)
        {
            int id = 1;
            Random r = new Random();
            List<Boom> bomen = new List<Boom>();

            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Green, 1);

            for (int i = 0; i < aantalBomen; i++)
            {
                Boom boom = new Boom(id, r.Next(0, bitmap.Width), r.Next(0, bitmap.Height));
                if (!bomen.Contains(boom))
                {
                    bomen.Add(boom);
                    g.DrawCircle(pen, boom.X, boom.Y, 3);
                    id++;
                }
                else
                    i--;
            }
            return bomen;
        }
    }
}
