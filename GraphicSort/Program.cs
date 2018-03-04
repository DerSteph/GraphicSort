using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace GraphicSort
{
    class Program
    {
        public static string[] line = new string[40];
        public static Random rnd = new Random();
        public static int[] spalten = new int[40];
        public static string character = "███";
        public static string background = "░░░";
        public static string text = "";
        public static int swap = 0;
        public static int comparison = 0;
        public static Stopwatch stopWatch = new Stopwatch();
        static void Main(string[] args)
        {
            Console.SetWindowSize(124, 50);
            Console.Title = "GraphicSort";
            CreateScreen();
            while (true)
            {
                swap = 0;
                comparison = 0;
                spalten = Enumerable.Range(0, 40).OrderBy(c => rnd.Next()).ToArray();
                Console.SetCursorPosition(0, 0);
                string[] algorithms = new string[] {
                "BubbleSort",
                "InsertionSort",
                "SelectionSort",
                "StephSort"
                };
                PostScreen();
                CreateWindow();
                Console.SetCursorPosition(2 + 15 + 2 + 15, 2 + 12 + 1);
                Console.Write(" _____                 _     _      _____            _   ");
                Console.SetCursorPosition(2 + 15 + 2 + 15, 2 + 12 + 2);
                Console.Write("|  __ \\               | |   (_)    /  ___|          | |  ");
                Console.SetCursorPosition(2 + 15 + 2 + 15, 2 + 12 + 3);
                Console.Write("| |  \\/_ __ __ _ _ __ | |__  _  ___\\ `--.  ___  _ __| |_ ");
                Console.SetCursorPosition(2 + 15 + 2 + 15, 2 + 12 + 4);
                Console.Write("| | __| '__/ _` | '_ \\| '_ \\| |/ __|`--. \\/ _ \\| '__| __|");
                Console.SetCursorPosition(2 + 15 + 2 + 15, 2 + 12 + 5);
                Console.Write("| |_\\ \\ | | (_| | |_) | | | | | (__/\\__/ / (_) | |  | |_ ");
                Console.SetCursorPosition(2 + 15 + 2 + 15, 2 + 12 + 6);
                Console.Write(" \\____/_|  \\__,_| .__/|_| |_|_|\\___\\____/ \\___/|_|   \\__|");
                Console.SetCursorPosition(2 + 15 + 2 + 15, 2 + 12 + 7);
                Console.Write("                | |                                      ");
                Console.SetCursorPosition(2 + 15 + 2 + 15, 2 + 12 + 8);
                Console.Write("                |_|                                      ");
                Console.SetCursorPosition(2 + 15 + 2 + 20, 2 + 12 + 10);
                Console.Write("choose with arrow-up and arrow-down the algorithm");
                //Console.ReadLine();
                //ResetWindow();

                int choose = 0;
                while (true)
                {
                    Console.SetCursorPosition(2 + 15 + 38, 2 + 12 + 5 + 7);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (choose - 1 == -1)
                    {
                        Console.Write("  " + algorithms[algorithms.Length - 1] + "     ");
                    }
                    else
                    {
                        Console.Write("  " + algorithms[choose - 1] + "     ");
                    }
                    Console.SetCursorPosition(2 + 15 + 38, 2 + 12 + 5 + 1 + 7);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("> " + algorithms[choose] + "     ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(2 + 15 + 38, 2 + 12 + 5 + 2 + 7);
                    if (choose + 1 == algorithms.Length)
                    {
                        Console.Write("  " + algorithms[0] + "     ");
                    }
                    else
                    {
                        Console.Write("  " + algorithms[choose + 1] + "     ");
                    }
                    var ch = Console.ReadKey(false).Key;
                    if (ch == ConsoleKey.UpArrow)
                    {
                        if (choose != 0)
                        {
                            choose--;
                        }
                        else
                        {
                            choose = algorithms.Length - 1;
                        }
                    }
                    else if (ch == ConsoleKey.DownArrow)
                    {
                        if (choose == algorithms.Length - 1)
                        {
                            choose = 0;
                        }
                        else
                        {
                            choose++;
                        }
                    }
                    else if (ch == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                Console.SetCursorPosition(4, 45);
                Console.ResetColor();
                Console.WriteLine("algorithm: " + algorithms[choose]);
                PostScreen();
                stopWatch.Start();
                switch (choose)
                {
                    case 0:
                        bubblesort();
                        break;
                    case 1:
                        insertionsort();
                        break;
                    case 2:
                        selectionsort();
                        break;
                    case 3:
                        stephsort();
                        break;
                    default:
                        break;
                }
                stopWatch.Stop();
                stopWatch.Reset();
                Console.ReadLine();
                Console.SetCursorPosition(4, 45);
                Console.WriteLine("                                     ");
            }
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
                    ShowComparisons();
                    if (spalten[i] > spalten[i + 1])
                    {
                        solange = true;
                        ShowSwaps();
                        int h = spalten[i];
                        spalten[i] = spalten[i + 1];
                        spalten[i + 1] = h;
                        Console.Beep(5000 + 50 * spalten[i], 20);
                        ChangePosition(i, i+1);
                    }
                }
            }
            RunEndsound();
        }
        protected static void bubblesort()
        {
            for (int i = 0; i < spalten.Length; i++)
            {
                for (int j = 0; j < spalten.Length - 1 - i; j++)
                {
                    ShowComparisons();
                    if (spalten[j] > spalten[j + 1])
                    {
                        int h = spalten[j + 1];
                        spalten[j + 1] = spalten[j];
                        spalten[j] = h;
                        ShowSwaps();
                        Console.Beep(5000 + 50 * spalten[j], 20);
                        ChangePosition(j,j+1);
                    }
                }
            }
            RunEndsound();
        }
        protected static void insertionsort()
        {
            for (int i = 1; i < spalten.Length; i++)
            {
                int k = i;
                for (k = i; k > 0; k--)
                {
                    ShowComparisons();
                    if (spalten[k] < spalten[k - 1])
                    {
                        ShowSwaps();
                        int h = spalten[k];
                        spalten[k] = spalten[k - 1];
                        spalten[k - 1] = h;
                        Console.Beep(5000 + 50 * spalten[k], 20);
                        ChangePosition(k, k-1);
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
                    ShowComparisons();
                    if (spalten[j] < spalten[min])
                    {
                        min = j;
                    }
                }
                ShowSwaps();
                int h = spalten[min];
                spalten[min] = spalten[i];
                spalten[i] = h;
                Console.Beep(5000 + 50 * spalten[i], 20);
                ChangePosition(min,i);
            }
            RunEndsound();
        }


        /*
         * Graphical Stuff
         * 
         */

        static void CreateScreen()
        {
            for (int i = 0; i < line.Length; i++)
            {
                text = text + background;
            }
            for (int i = 0; i < line.Length; i++)
            {
                line[i] = text;
            }
            Console.SetCursorPosition(2, 1);
            for (int i = 0; i < 120; i++)
            {
                Console.SetCursorPosition(2 + i, 1);
                Console.Write("═");
                Console.SetCursorPosition(2 + i, 43);
                Console.Write("═");
            }
            Console.SetCursorPosition(1, 1);
            Console.Write("╔");
            Console.SetCursorPosition(122, 1);
            Console.Write("╗");
            for (int i = 0; i < line.Length + 1; i++)
            {
                Console.SetCursorPosition(1, 2 + i);
                Console.Write("║");
                Console.SetCursorPosition(122, 2 + i);
                Console.Write("║");
            }
            Console.SetCursorPosition(1, 43);
            Console.Write("╚");
            Console.SetCursorPosition(122, 43);
            Console.Write("╝");
            Console.WriteLine();
        }

        static void CreateWindow()
        {
            string background_window = "";
            for (int i = 0; i < 30; i++)
            {
                background_window = background_window + "   ";
            }
            for (int i = 0; i < 16; i++)
            {
                Console.SetCursorPosition(2 + 15, 2 + 12 + i);
                Console.Write(background_window);
            }
            for (int i = 0; i < 90; i++)
            {
                Console.SetCursorPosition(2 + 15 + i, 2 + 12);
                Console.Write("═");
                Console.SetCursorPosition(2 + 15 + i, 2 + 12 + 15);
                Console.Write("═");
            }
            for (int i = 0; i < 16; i++)
            {
                Console.SetCursorPosition(2 + 15, 2 + 12 + i);
                Console.Write("║");
                Console.SetCursorPosition(2 + 15 + 90, 2 + 12 + i);
                Console.Write("║");
            }
            Console.SetCursorPosition(2 + 15, 2 + 12);
            Console.Write("╔");
            Console.SetCursorPosition(2 + 15 + 90, 2 + 12);
            Console.Write("╗");
            Console.SetCursorPosition(2 + 15, 2 + 12 + 15);
            Console.Write("╚");
            Console.SetCursorPosition(2 + 15 + 90, 2 + 12 + 15);
            Console.Write("╝");
            Console.CursorVisible = false;
        }

        static void ResetWindow()
        {
            string background_window = "";
            for (int i = 0; i < 88; i++)
            {
                background_window = background_window + " ";
            }
            for (int i = 0; i < 14; i++)
            {
                Console.SetCursorPosition(2 + 16, 2 + 13 + i);
                Console.Write(background_window);
            }
        }
        static bool PostScreen()
        {
            // write the numbers
            for(int i = 0; i < spalten.Length; i++)
            {
                for (int k = 0; k < line.Length+1; k++)
                {
                    Console.SetCursorPosition(2 + 3 * i, 42 - k);
                    if(k == 0)
                    {
                        if (spalten[i] < 10)
                        {
                            Console.Write("0" + Convert.ToString(spalten[i]) + " ");
                        }
                        else
                        {
                            Console.Write(Convert.ToString(spalten[i]) + " ");
                        }
                    }
                    else if (k < spalten[i]+2)
                    {
                        Console.Write(character);
                    }
                    else
                    {
                        Console.Write(background);
                    }
                }
            }
            Console.SetCursorPosition(2, 42);
            // reset the graphical output
            Console.SetCursorPosition(101, 45);
            Console.Write("comparisons:        ");
            Console.SetCursorPosition(101, 46);
            Console.Write("      swaps:        ");
            Console.SetCursorPosition(101,47);
            Console.Write("       time:        ");
            Console.SetCursorPosition(0, 45);
            return true;
        }
        static bool ChangePosition(int zahl1, int zahl2)
        {

            for (int k = 0; k < line.Length+1; k++)
            {
                Console.SetCursorPosition(2 + 3 * zahl1, 42 - k);
                if (k == 0)
                {
                    if (spalten[zahl1] < 10)
                    {
                        Console.Write("0" + Convert.ToString(spalten[zahl1]) + " ");
                    }
                    else
                    {
                        Console.Write(Convert.ToString(spalten[zahl1]) + " ");
                    }
                }
                else if (k < spalten[zahl1] + 2)
                {
                    Console.Write(character);
                }
                else
                {
                    Console.Write(background);
                }
            }
            for(int k = 0; k < line.Length+1; k++)
            {
                Console.SetCursorPosition(2 + 3 * zahl2, 42 - k);
                if (k == 0)
                {
                    if (spalten[zahl2] < 10)
                    {
                        Console.Write("0" + Convert.ToString(spalten[zahl2]) + " ");
                    }
                    else
                    {
                        Console.Write(Convert.ToString(spalten[zahl2]) + " ");
                    }
                }
                else if (k < spalten[zahl2] + 2)
                {
                    Console.Write(character);
                }
                else
                {
                    Console.Write(background);
                }
            }
            return true;
        }
        static bool ShowComparisons()
        {
            comparison = comparison + 1;
            Console.SetCursorPosition(101, 45);
            Console.Write("comparisons: " + comparison);
            Console.SetCursorPosition(0, 45);
            TimeSpan ts = stopWatch.Elapsed;
            Console.SetCursorPosition(101, 47);
            Console.Write("       time: " + String.Format("{0:00}:{1:00}",
        ts.Minutes, ts.Seconds));
            Console.SetCursorPosition(0, 45);
            return true;
        }
        static bool ShowSwaps()
        {
            swap = swap + 1;
            Console.SetCursorPosition(101, 46);
            Console.Write("      swaps: " + swap);
            Console.SetCursorPosition(0, 45);
            TimeSpan ts = stopWatch.Elapsed;
            Console.SetCursorPosition(101, 47);
            Console.Write("       time: " + String.Format("{0:00}:{1:00}",
        ts.Minutes, ts.Seconds));
            Console.SetCursorPosition(0, 45);
            return true;
        }
        static void ShowTime()
        {
            /*while(stopWatch.IsRunning == true)
            {
                TimeSpan ts = stopWatch.Elapsed;
                Console.SetCursorPosition(101, 47);
                Console.Write("       time: "+ String.Format("{0:00}:{1:00}",
            ts.Minutes, ts.Seconds));
                Console.SetCursorPosition(0, 45);
                Thread.Sleep(1000);
            }*/
        }

        static bool RunEndsound()
        {
            for(int i = 0; i < spalten.Length; i++)
            {
                Console.Beep(5000 + 50 * spalten[i], 20);
            }
            return true;
        }
    }
}
