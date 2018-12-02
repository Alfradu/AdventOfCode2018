using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string text = System.IO.File.ReadAllText(@"X:\Sysvet\adventOfCode2018\day2\input.txt");

            Console.WriteLine(p.Prg1(text));
            Console.WriteLine(p.Prg2(text));
            Console.ReadKey();
        }

        public int Prg1(string text)
        {
            int doubles = 0;
            int triples = 0;
            bool doubleFound = false;
            bool tripleFound = false;
            string[] splitText = text.Split('\n');
            foreach ( string box in splitText )
            {
                char[] boxLetters = box.ToCharArray();
                for (int i = 0; boxLetters.Length > i; i++)
                {
                    int count = boxLetters.Count(c => c == boxLetters[i]);
                    if (count == 2 && !doubleFound)
                    {
                        doubles = doubles + 1;
                        doubleFound = true;
                    }
                    if (count == 3 && !tripleFound)
                    {
                        triples = triples + 1;
                        tripleFound = true;
                    }
                }
                doubleFound = false;
                tripleFound = false;
            }
            return doubles*triples;
        }

        public string Prg2(string text)
        {
            string packCheck= "";
            string send = "";
            List<string> packs = new List<string>();
            string[] splitText = text.Split('\n');
            for (int i = 0; splitText.Length > i; i++)
            {
                char[] boxA = splitText[i].ToCharArray();
                for (int j = 0; splitText.Length > j; j++)
                {
                    if (i != j)
                    {
                        char[] boxB = splitText[j].ToCharArray();
                        for (int k = 0; boxA.Length > k; k++)
                        {
                            if (boxA[k] == boxB[k])
                            {
                                packCheck = packCheck + boxA[k];
                            }
                        }
                        packs.Add(packCheck);
                        packCheck = "";
                    }
                }
            }
            foreach(string pack in packs)
            {
                if (pack.Length > send.Length)
                {
                    send = pack;
                }
            }
            return send;
        }
    }
}
