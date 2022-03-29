using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Algoritm_R
{
    public class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Problem p = new Problem(1, 10000000);
            p.RandomElements();
            //Problem p = new Problem();
            //p.Read_tasks_from_file();
            p.ScheduleTasks(p.listoftasks);
            string elapsedMs = watch.ElapsedMilliseconds.ToString();
            Debug.WriteLine("Program obliczal przez " + elapsedMs as string + " milisekund ");
            long memory = GC.GetTotalMemory(true);
            Debug.WriteLine("Program zajal " + memory as string + " bajtow pamieci ");
            //foreach (Task i in p.listoftasks)
            //{
            //    Console.WriteLine(i.ToString());
            //}
            Console.WriteLine("Cmax = " + p.Cmax as string);

            Console.ReadLine();
        }

    }
}
