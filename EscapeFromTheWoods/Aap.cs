using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace EscapeFromTheWoods
{
    public class Aap : IComparable<Aap>
    {
        public Aap(int id, string naam, Color color)
        {
            Id = id;
            Naam = naam;
            Color = color;
            TouchedBomen = new List<Boom>();
            Logs = new List<Log>(); 
        }
        public int Id { get; set; }
        public string Naam { get; set; }
        public Color Color { get; set; }
        public Pen Pen { get { return new Pen(Color, 1); } }
        public List<Boom> TouchedBomen { get; set; }
        public List<Log> Logs { get; set; }
        public int CompareTo([AllowNull] Aap other)
        {
            return Naam.CompareTo(other.Naam);
        }
    }
}
