using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._Delegate
{
    internal class Delegate_Chain
    {
        /****************************************************************\
         * 델리게이트 체인
         * 
         * 델리게이트 변수에 여러개의 함수를 참조하는 방법
        \****************************************************************/
        public static void Main4(string[] args)
        {
            Action action;
            action = Func2;     // 델리게이트 인스턴스를 Func2 로 초기화
            action += Func1;    // 델리게이트 인스턴스에 Func1 추가 참조
            action += Func3;    // 델리게이트 인스턴스에 Func3 추가 참조
            action();           // Func2, Func1, Func3 이 호출됨

            Console.WriteLine();

            action -= Func1;    // 델리게이트 인스턴스에 Func1 참조 제거
            action -= Func1;    // 델리게이트 인스턴스에 참조되지 않은 함수를 제거하는 경우 해당 작업이 무시됨                   
            action();           // Func2, Func3 이 호출됨

            Console.WriteLine();

            action += Func2;    // 같은 함수를 여러번 참조한 경우 여러번 호출됨
            action += Func2;
            action();           // Func2 3회, Func3 1회 호출됨
            
            Console.WriteLine();

            if (action != null) // 델리게이트 인스턴스에서 참조를 제거할 경우 참조하고 있는 함수가 없는 경우 함수가 터짐
                action();       // 델리게이트 인스턴스 참조 확인작업

            Console.WriteLine();

            action = Func1;     // 델리게이트 인스턴스에 = 을 통해 할당할 경우 이전의 참조된 상황이 사라짐
            action();           // Func1 이 호출됨
        }
        public static void Func1() { Console.WriteLine("Func1"); }
        public static void Func2() { Console.WriteLine("Func2"); }
        public static void Func3() { Console.WriteLine("Func3"); }


    }
}
