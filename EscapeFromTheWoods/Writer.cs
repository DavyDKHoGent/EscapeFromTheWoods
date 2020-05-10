using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EscapeFromTheWoods
{
    public class Writer
    {
        public async Task WriteLogs(Bos bos)
        {
            Console.WriteLine("start creating TxtFile");
            int maxLogI = bos.Apen.OrderByDescending(aap => aap.Logs.Count).First().Logs.Count();
            bos.Apen.Sort();

            using (StreamWriter writer = File.CreateText(Path.Combine(@"C:\Users\davy\Documents\data\EscapeFromTheWoods", $"{bos.Id}_log.txt")))
            {
                for (int logI = 0; logI < maxLogI; logI++)
                {
                    for (int aapI = 0; aapI < bos.Apen.Count; aapI++)
                    {
                        if (bos.Apen[aapI].Logs.Count > logI)
                            writer.WriteLine(bos.Apen[aapI].Logs[logI].ToString());
                    }
                }
            }
            Console.WriteLine("stop creating TxtFile");
        }
    }
}
