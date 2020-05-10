using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace EscapeFromTheWoods
{
    public class MonkeyMadness
    {
        public async Task Escape(Bos bos, Stopwatch stopwatch)
        {
            Console.WriteLine($"start escape wood {bos.Id}");
            DatabaseManager dbm = new DatabaseManager(@"Data Source=LAPTOP-1U6AQSEQ\SQLEXPRESS;Initial Catalog=EscapeFromTheWoods;Integrated Security=True");
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => dbm.AddWoodRecords(bos)));
            Random rnd = new Random();
            
            for (int i = 0; i < bos.Apen.Count; i++)
            {
                Console.WriteLine($"{bos.Apen[i].Naam} starts escape");
                Aap aap = bos.Apen[i];
                stopwatch.Start();
                Boom beginboom = bos.Bomen[rnd.Next(1, bos.Bomen.Count - 1)];
                bos.Graphics.FillCircle(new SolidBrush(aap.Color), beginboom.X, beginboom.Y, 3);

                aap.TouchedBomen.Add(beginboom);
                int seqNr = 1;
                while (beginboom != null)
                {
                    Log log = new Log(aap, beginboom, stopwatch.Elapsed, seqNr);
                    aap.Logs.Add(log);

                    Boom nieuweBoom = bos.Bomen.OrderBy(boom => BerekenAfstand(boom, beginboom)).Except(aap.TouchedBomen).First();
                    if (DistanceToBorder(beginboom, bos.Bitmap) > BerekenAfstand(beginboom, nieuweBoom))
                    {
                        bos.Graphics.DrawLine(aap.Pen, beginboom.X, beginboom.Y, nieuweBoom.X, nieuweBoom.Y);
                        aap.TouchedBomen.Add(nieuweBoom);
                        beginboom = nieuweBoom;
                    }
                    else
                        beginboom = null;
                    Console.WriteLine(log.ToString());
                    tasks.Add(Task.Run(() => dbm.AddLogs(bos.Id, log)));
                    tasks.Add(Task.Run(() => dbm.AddMonkeyRecords(bos.Id, log)));
                    seqNr++;
                }
                Console.WriteLine($"{bos.Apen[i].Naam} has escaped");
            }
            Writer writer = new Writer();
            tasks.Add(Task.Run(() => writer.WriteLogs(bos)));
            Task.WaitAll(tasks.ToArray());
            bos.Bitmap.Save(Path.Combine(@"C:\Users\davy\Documents\data\EscapeFromTheWoods", $"{bos.Id}_Escapethewoods.Jpeg"), ImageFormat.Jpeg);
            Console.WriteLine($"Stop escape wood {bos.Id}");
        }
        private double DistanceToBorder(Boom boom, Bitmap bitmap)
        {
            return (new SortedSet<double>()
            {
                bitmap.Width - boom.Y,
                bitmap.Height - boom.X,
                boom.Y-0,
                boom.X-0
            }).Min;
        }
        private double BerekenAfstand(Boom b1, Boom b2)
        {
            double afstand = Math.Sqrt(Math.Pow(b1.X - b2.X, 2) + Math.Pow(b1.Y - b2.Y, 2));
            return afstand;
        }
    }
}
