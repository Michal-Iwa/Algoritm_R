using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Algoritm_R
{
    internal class Problem
    {
        public int countoftasks;
        public List<Task> listoftasks;
        public int countdone;
        public int seed;
        public ulong Cmax;
        public Problem()
        {
            Cmax = 0;
            countdone = 0;
            seed = 0;
            countoftasks = 0;
            listoftasks = new List<Task>();
        }
        public Problem(int s, int c)
        {
            Cmax = 0;
            seed = s;
            countdone = 0;
            countoftasks = c;
            listoftasks = new List<Task>();
        }
        public void RandomElements()
        {
            Random random = new Random(seed);
            int[] rpd = new int[3];

            for (int i = 1; i <= countoftasks; i++)
            {
                rpd[0] = random.Next(countoftasks) + 1;
                rpd[1] = random.Next(countoftasks) + 1;
                rpd[2] = random.Next(countoftasks) + 1;
                listoftasks.Add(new Task(i, rpd[0], rpd[1], rpd[2]));
            }
        }
        public void Read_tasks_from_file()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data/JACK3.DAT");
            //for different set of data change JACK3.DAT to JACK2.DAT or JACK1.DAT or change data in those files
            //Console.WriteLine(filePath); 
            string line;
            if (File.Exists(filePath))
            {
                StreamReader file = null;
                try
                {
                    file = new StreamReader(filePath);
                    countoftasks = int.Parse(file.ReadLine());
                    int i = 0;
                    while (i <= countoftasks && (line = file.ReadLine()) != null)
                    {
                        i++;
                        string[] bits = line.Split(' ');
                        listoftasks.Add(new Task(i, int.Parse(bits[0]), int.Parse(bits[1]), int.Parse(bits[2])));
                    }
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
        }
        static void Swap(List<Task> list, int indexA, int indexB)
        {
            Task tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        public void ScheduleTasks(List<Task> tasks)
        {
            QuickSort(tasks, 0, tasks.Count-1);
            ulong Cmax_tmp = 0;
            ulong time = 1;
            Cmax += 1;
            foreach (Task i in tasks)
            {
                while (Cmax < time) Cmax++;
                Cmax += (ulong) i.processing_time;
                if (Cmax > Cmax_tmp) Cmax_tmp = Cmax + (ulong) i.delivery_time;
            }
            if (Cmax_tmp > Cmax) Cmax = Cmax_tmp;
            
        }
        public static void QuickSort(List<Task> tasks, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = tasks[(left + right) / 2].relaese_date;
            while (i < j)
            {
                while (tasks[i].relaese_date < pivot) i++;
                while (tasks[j].relaese_date > pivot) j--;
                if (i <= j)
                {
                    Swap(tasks, i, j);
                    i++;
                    j--;
                }
            }
            if (left < j) QuickSort(tasks, left, j);
            if (i < right) QuickSort(tasks, i, right);
        }

    }
}
