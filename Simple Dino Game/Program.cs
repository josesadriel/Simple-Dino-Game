using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Perbaikan
{
    class Contoh
    {
        public static int musuh = 0;
        public static int main = 7;
        public static bool jump = true;
    }
    class Program
    {
        static Thread ene;
        static void enemy(int x, int y, string karakter)
        {
            Contoh.musuh = x;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(karakter);
            Console.SetCursorPosition(x + 1, y);
            Console.WriteLine(" ");
        }

        static void display(int left, int top, string x)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(x);
            Thread.Sleep(70);
        }
        static void hero(string karakter, bool loncat)
        {
            display(3, 7, karakter);
            display(3, 7, " ");
            display(3, 6, karakter);
            display(3, 6, " ");
            display(3, 5, karakter);
            display(3, 5, " ");

            Contoh.main = 5;
            display(3, 6, karakter);
            display(3, 6, " ");

            Contoh.main = 7;
            display(3, 7, karakter);
        }
        static void jalan()
        {
            int x = 0;
            for (int i = 20; i >= 0; i--)
            {
                if (i != 0)
                {
                    ene = new Thread(() => enemy(i, 7, "Y"));
                    ene.Start();
                    x = i;
                    if (Contoh.musuh == 3 && Contoh.main == 6)
                    {
                        Console.SetCursorPosition(Contoh.musuh, 7);
                        Console.Write(" ");

                        Console.SetCursorPosition(Contoh.musuh - 1, 7);
                        Console.Write(" ");
                        Contoh.jump = false;
                        break;
                    }
                    else if (Contoh.musuh == 3 && Contoh.main == 7)
                    {
                        Console.SetCursorPosition(i, 7);
                        Console.Write(" ");
                        Contoh.jump = false;
                        break;
                    }
                    Thread.Sleep(310);
                }
                else if (i == 0)
                {
                    ene = new Thread(() => enemy(i, 7, " "));
                    ene.Start();
                    x = i;
                    Thread.Sleep(310);
                    i = 20;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Project Akhir PBO";
            bool loncat = true;
            Console.CursorVisible = false;
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("X");
            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(i, 8);
                Console.WriteLine("¯");
            }
            // enemy
            Thread cib = new Thread(jalan);
            cib.Start();
            ConsoleKeyInfo tekan;
            do
            {
                tekan = Console.ReadKey(true);
                switch (tekan.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Contoh.jump == true)
                        {
                            hero("X", loncat);
                        }
                        break;
                }

            } while (Contoh.jump != false);
            Console.Clear();
            Thread.Sleep(100);
            Console.WriteLine("Game Over");
            Console.ReadKey();
        }
    }
}
