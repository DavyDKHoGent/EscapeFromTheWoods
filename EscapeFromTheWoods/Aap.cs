using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace EscapeFromTheWoods
{
    public class Aap : IComparable<Aap>
    {
        public List<Boom> _touchedBomen;
        public List<string> _log;
        public Aap(int id, string naam, Graphics graphics, Pen pen)
        {
            Id = id;
            Naam = naam;
            Graphics = graphics;
            Pen = pen;
            _touchedBomen = new List<Boom>();
            _log = new List<string>();
        }
        public int Id { get; set; }
        public string Naam { get; set; }
        public Graphics Graphics { get; set; }
        public Pen Pen { get; set; }
        public void Touch(Boom b)
        {
            _touchedBomen.Add(b);
        }
        public void AddLog(string s)
        {
            _log.Add(s);
        }

        public int CompareTo([AllowNull] Aap other)
        {
            return Naam.CompareTo(other.Naam);
        }
    }
}
