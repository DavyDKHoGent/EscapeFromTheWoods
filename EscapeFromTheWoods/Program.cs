using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace EscapeFromTheWoods
{
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            DatabaseManager dbm = new DatabaseManager(@"Data Source=LAPTOP-1U6AQSEQ\SQLEXPRESS;Initial Catalog=EscapeFromTheWoods;Integrated Security=True");
            int monkeyId = dbm.GetMonkeyId();
            List<Bos> bossen = new List<Bos>();
            Bos bos1 = BosGenerator.MaakBos(bossen.Count, 500, 500, 600);
            List<Aap> apen1 = new List<Aap>
            {
                new Aap(monkeyId, "Jeff", Color.Red),
                new Aap(monkeyId+1, "Kwak",  Color.Yellow),
                new Aap(monkeyId+2, "Azomopoirodovvody",  Color.Blue)
            };
            bos1.AddApen(apen1);
            bossen.Add(bos1);
            
            Bos bos2 = BosGenerator.MaakBos(bossen.Count, 1000, 1000, 1700);
            List<Aap> apen2 = new List<Aap>
            {
                new Aap(monkeyId+3, "Eduardo", Color.White),
                new Aap(monkeyId+4, "Ivan",  Color.Aqua),
                new Aap(monkeyId+5, "Hartje",  Color.DarkOrange)
            };
            bos2.AddApen(apen2);
            bossen.Add(bos2);

            MonkeyMadness mm = new MonkeyMadness();
            List<Task> tasks = new List<Task>();
            bossen.ForEach(bos => tasks.Add(Task.Run(() => mm.Escape(bos, stopwatch))));
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"finished at: {stopwatch.Elapsed }");
        }
    }
}
