using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._Delegate
{
    internal class Delegate_Generic
    {
        /****************************************************************\
         * 일반화 델리게이트
         * 
         * 개발과정에서 많이 사용되는 델리게이트의 경우 일반화된 델리게이트를 사용
        \****************************************************************/

        // <Func 델리게이트>
        // 반환형과 매개변수를 지정한 델리게이트
        // Func<매개변수1, 매개변수2, ..., 반환형> 총 31개까지
        int Plus(int left, int right) { return left + right; }
        int Minus(int left, int right) { return left - right; }
        
        void Main1()
        {
            Func<int, int, int> func;
            func = Plus;
            func = Minus;
        }

        public static float Test(int value1,string value2) { return 0.1f; }
        public static string Test(float value) { return "안녕하세요"; }
        
        // <Action 델리게이트>
        // 반환형이 void 이며 매개변수를 지정한 델리게이트
        // Action<매개변수1, 매개변수2, ...>
        void Message(string message) { Console.WriteLine(message); }

        void Main2()
        {
            Action<string> action;
            action = Message;
        }

        static void Test(string str)
        {
            Console.WriteLine(str);
            Console.WriteLine("안녕하세요");
        }

        public static void Main3(string[] args)
        {
            Func<int, string, float> test;
            test = Test;
            
            Func<float, string> test1;
            test1 = Test;
            
            Action<string> test2;
            test2 = Test;
        }
    }
}
