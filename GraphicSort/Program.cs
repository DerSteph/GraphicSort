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
        static void Main(string[] args)
        {
            Console.SetWindowSize(125,50);
            Console.WriteLine("GraphicSort - a cli-program to show sort algorithms");
            string text = "";
            for(int i = 0; i < line.Length; i++)
            {
                text = text + "░░░";
                //Console.Write(Convert.ToString(spalten[i]) + ", ");
            }
            for(int i = 0; i < line.Length; i++)
            {
                line[i] = text;
            }
            Console.ReadLine();
            Console.Clear();
            Console.CursorVisible = false;
            for(int i = 0; i<line.Length; i++)
            {
                SetChar(character, i*3, spalten[i]);
            }
            PostScreen();
            Console.ReadLine();
            bool solange = true;
            while(solange == true)
            {
                solange = false;
                for (int i = 0; i < spalten.Length-1; i++)
                {
                    if(spalten[i] > spalten[i+1])
                    {
                        solange = true;
                        int h = spalten[i];
                        spalten[i] = spalten[i + 1];
                        spalten[i + 1] = h;
                        for (int k = 0; k < line.Length; k++)
                        {
                            SetChar(character, k*3, spalten[k]);
                        }
                        PostScreen();
                        for (int k = 0; k < line.Length; k++)
                        {
                            line[k] = text;
                        }
                        Thread.Sleep(10);
                    }
                }
            }
            Console.ReadLine();

        }
        static bool SetChar(string letter, int x, int groeße)
        {
            /*string text1 = line[y].Substring(0,x);
            string text2 = line[y].Substring(x+1,line[y].Length-x-1);*/
            for(int i = line.Length - groeße-1; i< line.Length; i++)
            {
                line[i] = line[i].Substring(0, x) + letter + line[i].Substring(x + 3, line[i].Length - x -3);
            }
            return true;
        }
        static bool PostScreen()
        {
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
            return true;
        }
    }
}
