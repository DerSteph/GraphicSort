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
        public static string background = "░░░";
        public static string text = "";
        public static int swap = 0;
        public static int comparison = 0;
        static void Main(string[] args)
        {
            Console.SetWindowSize(125, 50);
            for (int i = 0; i < line.Length; i++)
            {
                text = text + background;
            }
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = text;
            }
            PostScreen();
            Console.WriteLine(" GraphicSort - a cli-program to show sort algorithms");
            Console.WriteLine(" type in one algorithm: (B)ubbleSort, (I)nsertionSort, (S)electionSort, (St)ephSort");
            Console.SetCursorPosition(1, Console.CursorTop);
            Console.CursorVisible = false;
            switch(Console.ReadLine())
            {
                case "st":
                    stephsort();
                    break;
                case "b":
                    bubblesort();
                    break;
                case "i":
                    insertionsort();
                    break;
                case "s":
                    selectionsort();
                    break;
                default:
                    break;
            }
            Console.ReadLine();

        }

        /*
         * Sort Algorithms
         * 
         */
        protected static void stephsort()
            {
            bool solange = true;
            while (solange == true)
            {
                solange = false;
                for (int i = 0; i < spalten.Length - 1; i++)
                {
                    comparison = comparison + 1;
                    if (spalten[i] > spalten[i + 1])
                    {
                        solange = true;
                        swap = swap + 1;
                        int h = spalten[i];
                        spalten[i] = spalten[i + 1];
                        spalten[i + 1] = h;
                        Console.Beep(5000 + 50 * spalten[i], 30);
                        PostScreen();
                        Thread.Sleep(10);
                    }
                }
            }
        }
        protected static void bubblesort()
        {
            for(int i=0; i< spalten.Length; i++)
            {
                for(int j =0; j < spalten.Length -1 -i; j++)
                {
                    comparison = comparison + 1;
                    if (spalten[j] > spalten[j+1])
                    {
                        int h = spalten[j +1];
                        spalten[j + 1] = spalten[j];
                        spalten[j] = h;
                        swap = swap + 1;
                        Console.Beep(5000 + 50 * spalten[j], 30);
                        PostScreen();
                        Thread.Sleep(10);
                    }
                }
            }
        }
        protected static void insertionsort()
        {
            for(int i = 1; i < spalten.Length; i++)
            {
                int k = i;
                for(k = i; k > 0; k--)
                {
                    comparison = comparison + 1;
                    if (spalten[k] < spalten[k - 1])
                    {
                        swap = swap + 1;
                        int h = spalten[k];
                        spalten[k] = spalten[k - 1];
                        spalten[k - 1] = h;
                        Console.Beep(5000 + 50 * spalten[k], 30);
                        PostScreen();
                        Thread.Sleep(10);
                        }
                    }
            }
        }
        protected static void selectionsort()
        {
            for (int i = 0; i < spalten.Length - 1; i++)
            {
                int min = i;
                for (int j = i; j < spalten.Length; j++)
                {
                    comparison = comparison + 1;
                    if (spalten[j] < spalten[min])
                    {
                        min = j;
                    }
                }
                swap = swap + 1;
                int h = spalten[min];
                spalten[min] = spalten[i];
                spalten[i] = h;
                Console.Beep(5000 + 50 * spalten[i], 30);
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
                line[i] = line[i].Substring(0, x) + letter + line[i].Substring(x + 3, line[i].Length - x - 3);
            }
            return true;
        }
        static bool PostScreen()
        {
            // set the new positions in the lines
            for (int i = 0; i < line.Length; i++)
            {
                SetChar(character, i * 3, spalten[i]);
            }
            Console.SetCursorPosition(0,1);

            // graphical Output
            for (int i = 0; i < line.Length; i++)
            {
                Console.WriteLine(" " + line[i]);
            }
            Console.Write(" ");

            // write the numbers
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

            // reset the graphical output
            for (int j = 0; j < line.Length; j++)
            {
                line[j] = text;
            }
            Console.SetCursorPosition(100, 43);
            Console.Write("comparisons: " + comparison);
            Console.SetCursorPosition(100, 44);
            Console.Write("      swaps: " + swap);
            Console.SetCursorPosition(0, 43);
            return true;
        }
    }
}
