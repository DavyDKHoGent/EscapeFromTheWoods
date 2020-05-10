using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EscapeFromTheWoods
{
    public class Log
    {
        public Log(Aap aap, Boom boom, TimeSpan elapsedTime, int seqNr)
        {
            Aap = aap;
            Boom = boom;
            ElapsedTime = elapsedTime;
            SeqNr = seqNr;
        }
        public Aap Aap { get; set; }
        public Boom Boom { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public int SeqNr { get; set; }
        public override string ToString()
        {
            return $"{Aap.Naam} is now in tree {Boom.Id} at location ({Boom.X}, {Boom.Y})";
        }
    }
}
