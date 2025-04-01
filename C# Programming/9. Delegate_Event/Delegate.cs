using System.Diagnostics;

namespace _9. Delegate_Event
{

    /****************************************************************\
     * 대리자 (Delegate)
     * 특정 매개 변수 목록 및 반환 형식이 있는 함수에 대한 참조
     * 대리자 인스턴스 를 통해 함스를 호출 할 수 있음
    \****************************************************************/

    // <델리게이트 정의>
    // delegate 반환형 델리게이트 이름(매개변수들);

    public delegate float DelegateMethod1(float left, float right);
    public delegate void DelegateMethod2(string str);


    internal class Delegate
    {

        public static float Plus(float left, float right) { return left + right; }

        public static float Minus(float left, float right) { return left - right; }

        public static float Multi(float left, float right) { return left * right; }
       
        public static float Divide(float left,float right) { return left / right; }

        public static void Message(string messge) { Console.WriteLine("메세지로 {0}을 전송합니다.", messge); }
        static void Main0(string[] args)
        {
            // 원리상 DelegateMethod1 delegate1 = new DelegateMethod1();
            DelegateMethod1 delegate1 = Plus;
            DelegateMethod2 delegate2 = Message;

            delegate1.Invoke(20f, 50f); // Invoke : 호출하기
            delegate1(20f, 10f);        // Invoke를 간략하고 직관적으로 사용하기 위한 문법허용

            
            //<델리게이트 사용>
            // 반환형과 매개변수가 일치하는 함수를 델리게이트 변수에 할당
            // 델리게이트 변수에 참조한 함수들 대리자를 통해 호출 가능

            delegate1 = Plus;
            Console.WriteLine(delegate1(20f, 10F));     //Plus(20f,10f)
            delegate1 = Minus;
            Console.WriteLine(delegate1(20f, 10F));     //Minus(20f,10f)
            delegate1 = Multi;
            Console.WriteLine(delegate1(20f, 10F));     //Multi(20f,10f)
            delegate1 = Divide;
            Console.WriteLine(delegate1(20f, 10F));     //Divide(20f,10f)
        }
    }
}
