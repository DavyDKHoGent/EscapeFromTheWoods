using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace EscapeFromTheWoods
{
    public class Escape
    {
        public static void Run(Bos bos , Stopwatch stopwatch)
        {
            DatabaseManager dbm = new DatabaseManager(@"Data Source=LAPTOP-1U6AQSEQ\SQLEXPRESS;Initial Catalog=EscapeFromTheWoods;Integrated Security=True");

            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => dbm.AddWoodRecords(bos)));

            foreach (Aap aap in bos.Apen)
            {
                Random rnd = new Random();
                stopwatch.Start();
                Boom beginboom = bos.Bomen[rnd.Next(1, bos.Bomen.Count - 1)];
                int seqNr = 0;
                aap.Graphics.FillCircle(new SolidBrush(aap.Pen.Color), beginboom.X, beginboom.Y, 3);

                aap.Touch(beginboom);
                while (beginboom != null)
                {
                    string message = $"{aap.Naam} is now in tree {beginboom.Id} at location ({beginboom.X}, {beginboom.Y})";
                    
                    if (beginboom == null)
                        Console.WriteLine("here");
                    
                    tasks.Add(Task.Run(() => dbm.AddMonkeyRecords(aap, beginboom, bos.Id, seqNr)));
                    tasks.Add(Task.Run(() => dbm.AddLogs(aap.Id, bos.Id, message)));

                    Boom nieuweBoom = bos.Bomen.OrderBy(boom => BerekenAfstand(boom, beginboom)).Except(aap._touchedBomen).First();
                    aap.AddLog(aap.Naam + ", " + beginboom.Id + ", " + stopwatch.Elapsed);
                    if (DistanceToBorder(beginboom, bos.Bitmap) > BerekenAfstand(beginboom, nieuweBoom))
                    {
                        aap.Graphics.DrawLine(aap.Pen, beginboom.X, beginboom.Y, nieuweBoom.X, nieuweBoom.Y);
                        aap.Touch(nieuweBoom);
                        beginboom = nieuweBoom;
                        Console.WriteLine(aap.Naam + ", " + stopwatch.Elapsed);
                    }
                    else
                        beginboom = null;
                    seqNr++;

                }
            }
            Task.WaitAll(tasks.ToArray());
        }
        private static double DistanceToBorder(Boom boom, Bitmap bitmap)
        {
            return (new SortedSet<double>()
            {
                bitmap.Width - boom.Y,
                bitmap.Height - boom.X,
                boom.Y-0,
                boom.X-0
            }).Min;
        }
        private static double BerekenAfstand(Boom b1, Boom b2)
        {
            double afstand = Math.Sqrt(Math.Pow(b1.X - b2.X, 2) + Math.Pow(b1.Y - b2.Y, 2));
            return afstand;
        }
    }
}
