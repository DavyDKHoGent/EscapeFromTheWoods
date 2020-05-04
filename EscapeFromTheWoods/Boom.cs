using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EscapeFromTheWoods
{
    public class Boom 
    {
        public Boom(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}