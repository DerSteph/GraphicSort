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
        public static string character = "██";
        static void Main(string[] args)
        {
            Console.SetWindowSize(100,50);
            Random rnd = new Random();
            int[] spalten = Enumerable.Range(0, 40).OrderBy(c => rnd.Next()).ToArray();
            //int[] spalten = new int[20];
            string text = "";
            for(int i = 0; i < line.Length; i++)
            {
                text = text + "..";
            }
            for (int i = 0; i<line.Length; i++)
            {
                line[i] = text;
            }
            for (int i = 0; i < spalten.Length; i++)
            {
                Console.Write(Convert.ToString(spalten[i])+ ", ");
            }
            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();
            PostScreen();
            Console.ReadLine();
            for(int i = 0; i<line.Length; i++)
            {
                SetChar(character, i*2, spalten[i]);
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
                            SetChar(character, k*2, spalten[k]);
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
            for (int i = 0; i < spalten.Length; i++)
            {
                Console.Write(Convert.ToString(spalten[i])+ ", ");
            }
            Console.ReadLine();

        }
        static bool SetChar(string letter, int x, int groeße)
        {
            /*string text1 = line[y].Substring(0,x);
            string text2 = line[y].Substring(x+1,line[y].Length-x-1);*/
            for(int i = line.Length - groeße-1; i< line.Length; i++)
            {
                line[i] = line[i].Substring(0, x) + letter + line[i].Substring(x + 2, line[i].Length - x -2);
            }
            return true;
        }
        static bool PostScreen()
        {
            Console.SetCursorPosition(0,0);
            for (int i = 0; i < line.Length; i++)
            {
                Console.WriteLine(line[i]);
            }
            return true;
        }
    }
}
