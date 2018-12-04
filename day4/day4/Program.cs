using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string text = System.IO.File.ReadAllText(@"X:\Sysvet\adventOfCode2018\day4\input.txt");
            Console.WriteLine(p.Schedule(text));
            Console.ReadKey();
        }

        public int Schedule(string text)
        {
            string[] timeTable = text.Split('\n');
            Array.Sort(timeTable, StringComparer.InvariantCulture);

            //int minutes = (int)Convert.ToDateTime(timeTable[timeTable.Length - 1].Split('[')[1].Split(']')[0]).Subtract(Convert.ToDateTime(timeTable[0].Split('[')[1].Split(']')[0])).TotalMinutes;
            int minutes = 60;
            List<int> guardList = new List<int>();
            foreach (string time in timeTable)
            {
                if (time.Split(' ')[2] == "Guard")
                {
                    guardList.Add(Int32.Parse(time.Split(' ')[3].Split('#')[1]));
                }
            }
            int currentGuard = 0;
            int min = 0;
            int sleepMin = min;
            int guardID = 0;
            int[,] guardTime = new int[minutes,guardList.Count];
            for (int i = 0; timeTable.Length > i ; i++)
            {

                if (timeTable[i].Split(' ')[2] == "Guard")
                {
                    currentGuard = Int32.Parse(timeTable[i].Split(' ')[3].Split('#')[1]);
                }
                guardID = guardList.FindIndex(a => a == currentGuard);
                min = (int)Convert.ToDateTime(timeTable[i].Split('[')[1].Split(']')[0]).Subtract(Convert.ToDateTime(timeTable[0].Split('[')[1].Split(']')[0])).TotalMinutes%60;

                if (timeTable[i].Split(' ')[2] == "falls")
                {
                    sleepMin = min;
                }
                if (timeTable[i].Split(' ')[2] == "wakes")
                {
                    for (int j = 0; min - sleepMin > j; j++)
                    {
                        guardTime[sleepMin + j, guardID]++;
                    }
                }
            }

            int sum = 0, sumTemp = 0;
            int sleepyGuard = 0;
            int highestNr = 0;
            int highest = 0;
            int highestSleepyGuard = 0;
            for (int k = 0; guardList.Count > k; k++)
            {
                for (int l = 0; minutes > l; l++)
                {
                    if ( guardTime[l,k] != 0)
                    {
                        sumTemp = sumTemp + guardTime[l, k];
                    }
                    if ( guardTime[l,k] > highest)
                    {
                        highest = guardTime[l, k];
                        highestSleepyGuard = k;
                        highestNr = l;
                    }
                }
                if (sum < sumTemp)
                {
                    sum = sumTemp;
                    sleepyGuard = k;
                }
                sumTemp = 0;
            }
            int snooziestMinute = 0;
            int actualMinute = 0;
            for (int m = 0; minutes > m; m++)
            {
                if (guardTime[m, sleepyGuard] > snooziestMinute)
                {
                    snooziestMinute = guardTime[m, sleepyGuard];
                    actualMinute = m;
                }
            }
            Console.WriteLine("part 2: " + highestNr * guardList[highestSleepyGuard]);
            return guardList[sleepyGuard]*actualMinute;
        }
    }
}
