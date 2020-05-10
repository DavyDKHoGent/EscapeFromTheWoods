using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EscapeFromTheWoods
{
    public class BosGenerator
    {
        public Bos MaakBos(int bosId, int breedte, int hoogte, int aantalBomen)
        {
            Bitmap bitmap = new Bitmap(breedte, hoogte);
            List<Boom> bomen = MaakBomen(bitmap, aantalBomen);
            return new Bos(bosId, bitmap, bomen);
        }
        private List<Boom> MaakBomen(Bitmap bitmap, int aantalBomen)
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
