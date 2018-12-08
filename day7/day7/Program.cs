using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string text = System.IO.File.ReadAllText(@"X:\Sysvet\adventOfCode2018\day7\input.txt");
            Console.WriteLine("sorted list: " + p.TopoSort(text));
            Console.ReadKey();
        }
        public string TopoSort(string text)
        {
            string[] unsorted = text.Split('\n');
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string parts = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Dictionary<string, string> nodes = new Dictionary<string, string>();
            for (int i = 0; parts.Length > i; i++)
            {
                nodes.Add(parts[i].ToString(), "");
            }
            for (int i = 0; unsorted.Length > i; i++)
            {
                nodes[unsorted[i][36].ToString()] += unsorted[i][5].ToString();
            }
            string sorted = "";
            while (parts.Length > 0)
            {
                for (int i = 0; parts.Length > i; i++)
                {
                    if (nodes[parts[i].ToString()] == "")
                    {
                        sorted += parts[i].ToString();
                        for (int j = 0; letters.Length > j; j++)
                        {
                            if (nodes[letters[j].ToString()].Contains(parts[i]))
                            {
                                nodes[letters[j].ToString()] = nodes[letters[j].ToString()].Remove(nodes[letters[j].ToString()].IndexOf(parts[i].ToString()),1);
                            }
                        }
                        parts = parts.Remove(i, 1);
                        i = parts.Length;
                    }
                }
            }

            return sorted;
        }
    }
}
