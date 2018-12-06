using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string text = System.IO.File.ReadAllText(@"X:\Sysvet\adventOfCode2018\day5\input.txt");
            Console.WriteLine("smallest form of polymer: " + p.AllPolymer(text));
            Console.WriteLine("smallest form of polymer without trouble type: " + p.BestPolymer(text));
            Console.ReadKey();
        }

        public int AllPolymer(string text)
        {
            string polymer = text;
            bool finished = false;
            int count = 0; 
            while (!finished)
            {
                count = 0;
                for (int i = 0; polymer.Length > i; i++)
                {
                    if (i + 1 < polymer.Length)
                    {
                        if (Char.IsUpper(polymer[i]))
                        {
                            if (polymer[i].ToString().ToLower() == polymer[i + 1].ToString())
                            {
                                polymer = polymer.Remove(i, 2);
                                count++;
                            }
                        }
                        else
                        {
                            if (polymer[i].ToString().ToUpper() == polymer[i + 1].ToString())
                            {
                                polymer = polymer.Remove(i, 2);
                                count++;
                            }
                        }
                    }
                }
                if (count == 0)
                {
                    finished = true;
                }
            }
            return polymer.Length;
        }
        public int BestPolymer(string text)
        {
            string[] polymerTypes = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            int bestLength = int.MaxValue;
            for (int type = 0; polymerTypes.Length > type; type++)
            {
                string polymer = text;
                polymer = polymer.Replace(polymerTypes[type], "");
                polymer = polymer.Replace(polymerTypes[type].ToUpper() , "");
                if (AllPolymer(polymer) < bestLength)
                {
                    bestLength = AllPolymer(polymer);
                }
            }
            return bestLength;
        }
    }
}
