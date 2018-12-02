using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string text = System.IO.File.ReadAllText(@"X:\Sysvet\adventOfCode2018\day1\input.txt");
            Console.WriteLine(p.Prg1(text));
            Console.WriteLine(p.Prg2(text));
            Console.ReadKey();
        }

        public int Prg1(string text)
        {
            string[] splitText = text.Split('\n');
            int ans = 0;
            foreach (string t in splitText) {
                ans = ans + Int32.Parse(t);
            }
            return ans;
        }

        public int Prg2(string text)
        {
            int ans = 0;
            List<int> list = new List<int>() { ans };
            string[] splitText = text.Split('\n');
            List<int> repeats = new List<int>();
            while (repeats.Count < 1)
            {
                foreach (string t in splitText)
                {
                    int cur = Int32.Parse(t);
                    ans = ans + cur;
                    if (list.Contains(ans))
                    {
                        repeats.Add(ans);
                    }
                    else
                    {
                        list.Add(ans);
                    }
                }
            }
            return repeats[0];
        }
    }
}