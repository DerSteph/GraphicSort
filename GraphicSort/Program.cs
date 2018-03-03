﻿using System;
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
        public static int[] spalten = new int[40];
        public static string character = "███";
        public static string background = "░░░";
        public static string text = "";
        public static int swap = 0;
        public static int comparison = 0;
        static void Main(string[] args)
        {
            Console.SetWindowSize(124, 50);
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
                Console.ReadLine();
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
                    comparison = comparison + 1;
                    if (spalten[i] > spalten[i + 1])
                    {
                        solange = true;
                        swap = swap + 1;
                        int h = spalten[i];
                        spalten[i] = spalten[i + 1];
                        spalten[i + 1] = h;
                        Console.Beep(5000 + 50 * spalten[i], 20);
                        PostScreen();
                    }
                }
            }
        }
        protected static void bubblesort()
        {
            for (int i = 0; i < spalten.Length; i++)
            {
                for (int j = 0; j < spalten.Length - 1 - i; j++)
                {
                    comparison = comparison + 1;
                    if (spalten[j] > spalten[j + 1])
                    {
                        int h = spalten[j + 1];
                        spalten[j + 1] = spalten[j];
                        spalten[j] = h;
                        swap = swap + 1;
                        Console.Beep(5000 + 50 * spalten[j], 20);
                        PostScreen();
                    }
                }
            }
        }
        protected static void insertionsort()
        {
            for (int i = 1; i < spalten.Length; i++)
            {
                int k = i;
                for (k = i; k > 0; k--)
                {
                    comparison = comparison + 1;
                    if (spalten[k] < spalten[k - 1])
                    {
                        swap = swap + 1;
                        int h = spalten[k];
                        spalten[k] = spalten[k - 1];
                        spalten[k - 1] = h;
                        Console.Beep(5000 + 50 * spalten[k], 20);
                        PostScreen();
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
                Console.Beep(5000 + 50 * spalten[i], 20);
                PostScreen();
            }
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

        static bool SetChar(string letter, int x, int groeße)
        {
            for (int i = line.Length - groeße - 1; i < line.Length; i++)
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

            // graphical Output
            for (int i = 0; i < line.Length; i++)
            {
                Console.SetCursorPosition(2, 2 + i);
                Console.Write(line[i]);
            }
            Console.SetCursorPosition(2, 42);
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
            // write the numbers

            // reset the graphical output
            for (int j = 0; j < line.Length; j++)
            {
                line[j] = text;
            }
            Console.SetCursorPosition(101, 45);
            Console.Write("comparisons: " + comparison);
            Console.SetCursorPosition(101, 46);
            Console.Write("      swaps: " + swap);
            Console.SetCursorPosition(0, 45);
            return true;
        }
    }
}
