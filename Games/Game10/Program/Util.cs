using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game10
{
    public static class Util
    {
        public static void Print(string context, ConsoleColor textColor = ConsoleColor.White, int delay = 0)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(context);
            Thread.Sleep(delay);
            Console.ResetColor();
        }
        public static void ReadKey(out int sieneNo)
        {
            ConsoleKey input;
            sieneNo = (int)SieneNo.None;
            input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    sieneNo += 1;
                    Console.WriteLine("1번 선택지를 골랐습니다");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    sieneNo += 2;
                    Console.WriteLine("2번 선택지를 골랐습니다");
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    sieneNo += 3;
                    Console.WriteLine("3번 선택지를 골랐습니다");
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    sieneNo += 4;
                    Console.WriteLine("4번 선택지를 골랐습니다");
                    break;
                default:
                    sieneNo += 5;
                    Console.WriteLine("다시 골라주세요");
                    break;
            }
        }

        public enum SieneNo
        {
            None,No1,No2,No3,No4,No5
        }
    }
}
