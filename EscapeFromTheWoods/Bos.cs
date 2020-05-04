using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EscapeFromTheWoods
{
    public class Bos
    {
        public Bos(int id, Bitmap bitmap, List<Aap> apen, int aantalBomen) 
        {
            Id = id;
            Bitmap = bitmap;
            Apen = apen;
            AantalBomen = aantalBomen;
            Bomen = MaakBomen();
        }
        public int Id { get; set; }
        public Bitmap Bitmap { get; set; }
        public List<Aap> Apen { get; set; }
        public int AantalBomen { get; set; }
        public List<Boom> Bomen { get; set; }
        private List<Boom> MaakBomen()
        {
            int id = 1;
            Random r = new Random();
            List<Boom> bomen = new List<Boom>();

            Graphics g = Graphics.FromImage(Bitmap);
            Pen pen = new Pen(Color.Green, 1);

            for (int i = 0; i < AantalBomen; i++)
            {
                Boom boom = new Boom(id, r.Next(0, Bitmap.Width), r.Next(0,Bitmap.Height));
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
