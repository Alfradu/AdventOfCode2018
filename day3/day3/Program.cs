using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            string text = System.IO.File.ReadAllText(@"X:\Sysvet\adventOfCode2018\day3\input.txt");
            Console.WriteLine(p.CheckOrders(text));
            Console.ReadKey();
        }
        public int CheckOrders(string text)
        {
            string[] ordersRAW = text.Split('\n');
            int[,] orders = new int[ordersRAW.Length,4];
            int x = 0, y = 0;
            for (int i = 0; ordersRAW.Length > i; i++)
            {
                string withoutNumber = ordersRAW[i].Split(new[] { "#" + (i + 1).ToString() + " @ " }, StringSplitOptions.None)[1];
                orders[i, 0] = Int32.Parse(withoutNumber.Split(',')[0]); //left
                orders[i, 1] = Int32.Parse(withoutNumber.Split(',')[1].Split(':')[0]); //top
                orders[i, 2] = Int32.Parse(withoutNumber.Split(' ')[1].Split('x')[0]); //width
                orders[i, 3] = Int32.Parse(withoutNumber.Split('x')[1]); //height

                //calc fabric size
                if (x < orders[i, 0] + orders[i, 2])
                {
                    x = orders[i, 0] + orders[i, 2];
                }
                if (y < orders[i, 1] + orders[i, 3])
                {
                    y = orders[i, 1] + orders[i, 3];
                }
            }
            int[,] fabric = new int[x, y];
            int count = 0;
            List<string> overlap = new List<string>();

            for (int j = 0; ordersRAW.Length > j; j++)
            {
                for (int w = 0; orders[j,2] > w; w++)
                {
                    for (int h = 0; orders[j, 3] > h; h++)
                    {
                        if (fabric[orders[j,0]+w,orders[j,1]+h] == 0)
                        {
                            fabric[orders[j, 0] + w, orders[j, 1] + h] = j+1;
                        }
                        else
                        {
                            if (!overlap.Contains((orders[j, 0] + w).ToString() + "," + (orders[j, 1] + h).ToString()))
                            {
                                count++;
                                fabric[orders[j, 0] + w, orders[j, 1] + h] = -1;
                            }
                            overlap.Add((orders[j, 0] + w).ToString() + "," + (orders[j, 1] + h).ToString());
                        }
                    }
                }
            }
            bool overlapping = false;
            int fullOrder = 0;
            for (int checkj = 0; ordersRAW.Length > checkj; checkj++)
            {
                for (int checkw = 0; orders[checkj, 2] > checkw; checkw++)
                {
                    for (int checkh = 0; orders[checkj, 3] > checkh; checkh++)
                    {
                        if (fabric[orders[checkj, 0] + checkw, orders[checkj, 1] + checkh] != checkj+1)
                        {
                            overlapping = true;
                        }
                    }
                }
                if (!overlapping)
                {
                    fullOrder = checkj + 1;
                    Console.WriteLine("found non-overlapping order: " + fullOrder.ToString());
                }
                else
                {
                    overlapping = false;
                }
            }
            return count;
        }
    }
}
