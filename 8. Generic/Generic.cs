using System.Numerics;

namespace _8.Generic_Interface
{
    internal class Generic
    {
        #region 일반화의 개념

        /****************************************************************\
         * 일반화 (Generic)
         * 
         * 클래스 또는 함수가 코드에 의해 선언되고 인스턴스화될 때까지 형식의 사양을 연기하는 디자인
         * 기능을 구현한 뒤 자료형을 사용 당시에 지정해서 사용
        \****************************************************************/

        #endregion

        #region objeck
        // object : 최상위 부모객체
        static void Main0(string[] args)
        {
            int value = 10;


            // 업캐스팅 : 암시적으로 사용가능
            // 박싱 : 값 형식 => 참조 형식
            object obj = value; // object 는 최상위 부모객채이다.


            // 다운 캐스팅 : 명시적으로 해야함
            // 언박싱 : 참조 형식 -> 값 형식 (힙영역으로 보내기)
            int resule = (int)value;

            // 왠만하면 느리니깐 거의 사용 하지말자고 한다.

        }
        #endregion

        static void Main1(string[] args)
        {
            int ia = 10;
            int ib = 5;

            float fa = 10.5f;
            float fb = 2.5f;
            
            bool ba = true;
            bool bb = false;

            Util.Swap(ref ia, ref ib);
            Util.Swap(ref fa, ref fb);
            Util.Swap(ref ba, ref bb);
            // 생략도 가능
            Console.WriteLine("a = {0}, b = {1}",ia,ib);
            Console.WriteLine("a = {0}, b = {1}", fa, fb);
            Console.WriteLine("a = {0}, b = {1}", ba, bb);
            
            Item item1 = new Item();
            item1.name = "포션";

            Item item2 = new Item();
            item2.name = "포션";

            
        }
        #region 일반화 자료형 제약
        // <일반화 자료형 제약>
        // 일반화 자료형을 선언할 때 제약조건을 선언하여, 사용 당시 쓸 수 있는 자료형을 제한
        class StructT<T> where T : struct { }           // T는 구조체만 사용 가능
        class ClassT<T> where T : class { }             // T는 클래스만 사용 가능
        class EnumT<T> where T : Enum { }               // T는 열거형만 사용 가능
        class NewT<T> where T : new() { }               // T는 매개변수 없는 생성자가 있는 자료형만 사용 가능

        class ParentT<T> where T : Parent { }           // T는 Parent 파생클래스만 사용 가능
        class InterfaceT<T> where T : IComparable { }   // T는 인터페이스를 포함한 자료형만 사용 가능

        class Parent { }
        class Child : Parent { }

        void Main2()
        {
            StructT<int> structT = new StructT<int>();          // int는 구조체이므로 struct 제약조건이 있는 일반화 자료형에 사용 가능
            // ClassT<int> classT = new ClassT<int>();          // error : int는 구조체이므로 class 제약조건이 있는 일반화 자료형에 사용 불가
            ClassT<string> classT = new ClassT<string>();       // string은 클래스이므로 class 제약조건이 있는 일반화 자료형에 사용 가능
            EnumT<ConsoleKey> enumT = new EnumT<ConsoleKey>();  // ConsoleKey는 열거형이므로 Enum 제약조건이 있는 일반화 자료형에 사용 가능
            NewT<int> newT = new NewT<int>();                   // int는 new int() 생성자가 있으므로 사용 가능

            ParentT<Parent> parentT = new ParentT<Parent>();    // Parent는 Parent 파생클래스이므로 사용 가능
            ParentT<Child> childT = new ParentT<Child>();       // Child는 Parent 파생클래스이므로 사용 가능
            InterfaceT<int> interT = new InterfaceT<int>();     // int는 IComparable 인터페이스를 포함하므로 사용 가능
        }
        #endregion

        #region 일반화 자료형의 사용법
        public static T Bigger<T>(T left, T right) where T : IComparable<T>
        {
            if (left.CompareTo(right) > 0 )
            {
                return left;
            }
            else
            {
                return right; 
            }
        }
        #endregion
    }
    public class Item
    {
        public string name;
    }

    public class Weapon : Item { }
    public class Potion : Item { }
    
    public class Util
    {
        // <일반화 함수>
        // 일반화는 자료형의 형식을 지정하지 않고 함수를 정의
        // 기능을 구현한 뒤 사용 당시에 자료형의 형식을 지정해서 사용
        public static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }

    }
}
