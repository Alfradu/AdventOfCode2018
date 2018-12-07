using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string text = System.IO.File.ReadAllText(@"X:\Sysvet\adventOfCode2018\day6\input.txt");
            Console.WriteLine("Largest finite area: " + p.CalcArea(text));
            Console.WriteLine("Largest total area with constraint 10000: " + p.CalcArea(text,10000));
            Console.ReadKey();
        }
        public int CalcArea(string text)
        {
            string[] coordUnsorted = text.Trim(' ').Split('\n');
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwx.";
            int[] coordX = new int[coordUnsorted.Length];
            int[] coordY = new int[coordUnsorted.Length];
            for (int i = 0; coordUnsorted.Length > i; i++)
            {
                coordX[i] = Int32.Parse(coordUnsorted[i].Split(',')[0]);
                coordY[i] = Int32.Parse(coordUnsorted[i].Split(',')[1]);
            }

            string[,] matrix = new string[coordX.Max()+1, coordY.Max()+1];

            for (int j = 0; coordX.Length > j; j++)
            {
                matrix[coordX[j], coordY[j]] = letters[j].ToString();
            }

            for (int matrixX = 0; coordX.Max() > matrixX; matrixX++)
            {
                for (int matrixY = 0; coordY.Max() > matrixY; matrixY++)
                {
                    int returned = ManhattanDistanceComp(matrixX, matrixY, coordX, coordY);
                    matrix[matrixX, matrixY] = letters[returned].ToString();
                }
            }

            for (int k = 0; coordX.Max()+1 > k; k++)
            {
                if (matrix[k, 0] != null)
                {
                    letters = letters.Replace(matrix[k, 0], "."); //top left -> top right
                }
                if (matrix[k, coordX.Length - 1] != null)
                {
                    letters = letters.Replace(matrix[k, coordX.Length - 1], "."); //bottom left -> bottom right
                }
                if (matrix[0, k] != null)
                {
                    letters = letters.Replace(matrix[0, k], "."); //top left -> bottom left
                }
                if (matrix[coordX.Length - 1, k] != null)
                {
                    letters = letters.Replace(matrix[coordX.Length - 1, k], "."); //top right -> bottom right
                }
            }
            letters = letters.Replace(".", "");

            int[] count = new int[letters.Length];
            for (int let = 0; letters.Length > let; let++)
            {
                for (int l = 0; coordX.Max()+1 > l; l++)
                {
                    for (int m = 0; coordY.Max()+1 > m; m++)
                    {
                        if (letters[let].ToString() == matrix[l, m])
                        {
                            count[let] = count[let] + 1;
                        }
                    }
                }
            }
            return count.Max();
        }
        public int CalcArea(string text, int constraint)
        {
            string[] coordUnsorted = text.Trim(' ').Split('\n');
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwx.";
            int[] coordX = new int[coordUnsorted.Length];
            int[] coordY = new int[coordUnsorted.Length];
            for (int i = 0; coordUnsorted.Length > i; i++)
            {
                coordX[i] = Int32.Parse(coordUnsorted[i].Split(',')[0]);
                coordY[i] = Int32.Parse(coordUnsorted[i].Split(',')[1]);
            }
            string[,] matrixGood = new string[coordX.Max() + 1, coordY.Max() + 1];

            for (int j = 0; coordX.Length > j; j++)
            {
                matrixGood[coordX[j], coordY[j]] = letters[j].ToString();
            }

            for (int matrixX = 0; coordX.Max() > matrixX; matrixX++)
            {
                for (int matrixY = 0; coordY.Max() > matrixY; matrixY++)
                {
                    string returnedGood = ManhattanDistanceComp(matrixX, matrixY, coordX, coordY, 10000);
                    matrixGood[matrixX, matrixY] = returnedGood;
                }
            }
            int count2 = 0;
            for (int l = 0; coordX.Max() + 1 > l; l++)
            {
                for (int m = 0; coordY.Max() + 1 > m; m++)
                {
                    if (matrixGood[l, m] == "#")
                    {
                        count2++;
                    }
                }
            }
            return count2;
        }

        public int ManhattanDistanceComp(int pointX, int pointY, int[] x, int[] y)
        {
            int distance = int.MaxValue;
            int selectedLetter = 50;
            for (int i = 0; x.Length > i; i++)
            {
                int manhatDistance = Math.Abs(pointX - x[i]) + Math.Abs(pointY - y[i]);
                if (manhatDistance < distance)
                {
                    distance = manhatDistance;
                    selectedLetter = i;
                }
                else if (manhatDistance == distance)
                {
                    selectedLetter = 50;
                }
            }
            return selectedLetter;
        }

        public string ManhattanDistanceComp(int pointX, int pointY, int[] x, int[] y, int constraint)
        {
            int totDistance = 0;
            for (int i = 0; x.Length > i; i++)
            {
                int manhatDistance = Math.Abs(pointX - x[i]) + Math.Abs(pointY - y[i]);
                totDistance = totDistance + manhatDistance;
            }
            return totDistance < constraint ? "#" : ".";
        }
    }
}
