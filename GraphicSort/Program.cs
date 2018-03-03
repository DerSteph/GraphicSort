using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GraphicSort
{
    class Program
    {
        public static string[] line = new string[40];
        public static Random rnd = new Random();
        public static int[] spalten = Enumerable.Range(0, 40).OrderBy(c => rnd.Next()).ToArray();
        public static string character = "███";
        public static string text = "";
        static void Main(string[] args)
        {
            Console.SetWindowSize(125, 50);
            for (int i = 0; i < line.Length; i++)
            {
                text = text + "░░░";
                //Console.Write(Convert.ToString(spalten[i]) + ", ");
            }
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = text;
            }
            PostScreen();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" GraphicSort - a cli-program to show sort algorithms");
            Console.WriteLine(" type in one algorithm: (B)ubbleSort, (I)nsertionSort, (S)electionSort, (St)ephSort");
            Console.SetCursorPosition(1, Console.CursorTop);
            string choose = Console.ReadLine();
            Console.CursorVisible = false;
            if (choose == "st")
            {
                stephsort(text);
            }
            else if (choose == "b")
            {
                bubblesort(text);
            }
            else if(choose == "i")
            {
                insertionsort(text);
            }
            else if(choose == "s")
            {
                selectionsort(text);
            }
            Console.ReadLine();

        }

        /*
         * Sort Algorithms
         * 
         */
        static void stephsort(string text)
            {
            bool solange = true;
            while (solange == true)
            {
                solange = false;
                for (int i = 0; i < spalten.Length - 1; i++)
                {
                    if (spalten[i] > spalten[i + 1])
                    {
                        solange = true;
                        int h = spalten[i];
                        spalten[i] = spalten[i + 1];
                        spalten[i + 1] = h;
                        PostScreen();
                        Thread.Sleep(10);
                    }
                }
            }
        }
        static void bubblesort(string text)
        {
            for(int i=0; i< spalten.Length; i++)
            {
                for(int j =0; j < spalten.Length -1 -i; j++)
                {
                    if(spalten[j] > spalten[j+1])
                    {
                        int h = spalten[j +1];
                        spalten[j + 1] = spalten[j];
                        spalten[j] = h;
                        PostScreen();
                        Thread.Sleep(10);
                    }
                }
            }
        }
        static void insertionsort(string text)
        {
            for(int i = 1; i < spalten.Length; i++)
            {
                int k = i;
                    for(k = i; k > 0; k--)
                    {
                        if(spalten[k] < spalten[k - 1])
                        {
                            int h = spalten[k];
                            spalten[k] = spalten[k - 1];
                            spalten[k - 1] = h;
                            PostScreen();
                            Thread.Sleep(10);
                        }
                    }
            }
        }
        static void selectionsort(string text)
        {
            for (int i = 0; i < spalten.Length - 1; i++)
            {
                int min = i;
                for (int j = i; j < spalten.Length; j++)
                {
                    if (spalten[j] < spalten[min])
                    {
                        min = j;
                    }
                }
                int h = spalten[min];
                spalten[min] = spalten[i];
                spalten[i] = h;
                PostScreen();
                Thread.Sleep(10);
            }
        }


        /*
         * Graphical Stuff
         * 
         */

        static bool SetChar(string letter, int x, int groeße)
        {
            for(int i = line.Length - groeße-1; i< line.Length; i++)
            {
                line[i] = line[i].Substring(0, x) + letter + line[i].Substring(x + 3, line[i].Length - x -3);
            }
            return true;
        }
        static bool PostScreen()
        {
            for (int i = 0; i < line.Length; i++)
            {
                SetChar(character, i * 3, spalten[i]);
            }
            Console.SetCursorPosition(0,1);
            for (int i = 0; i < line.Length; i++)
            {
                Console.WriteLine(" " + line[i]);
            }
            Console.Write(" ");
            for (int k = 0; k < spalten.Length; k++)
            {
                if (spalten[k] < 10)
                {
                    Console.Write("0" + Convert.ToString(spalten[k]) + " ");
                }
                else
                {
                    Console.Write(Convert.ToString(spalten[k]) + " ");
                }
            }
            for (int j = 0; j < line.Length; j++)
            {
                line[j] = text;
            }
            return true;
        }
    }
}
