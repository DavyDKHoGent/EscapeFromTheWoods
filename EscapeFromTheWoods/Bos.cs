using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EscapeFromTheWoods
{
    public class Bos
    {
        public Bos(int id, Bitmap bitmap, List<Boom> bomen) 
        {
            Id = id;
            Bitmap = bitmap;
            Bomen = bomen;
        }
        public int Id { get; set; }
        public Bitmap Bitmap { get; set; }
        public Graphics Graphics { get { return Graphics.FromImage(Bitmap); } }
        public List<Aap> Apen { get; set; }
        public List<Boom> Bomen { get; set; }
        public void AddApen(List<Aap> apen)
        {
            Apen = apen;
        }
    }
}
