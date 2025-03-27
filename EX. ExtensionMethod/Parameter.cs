using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX._Additional
{
    internal class Parameter
    {
        // <Named Parameter
        // 함수의 매개변수 순서와 무관하게 이름을 통해 호출

        public static void Profile(int id, string name, string phone) { }

        static void main1(string[] args)
        {
            Profile(10, "김전사", "010-1234-5678");
            // 함수 호출시 이름을 명명하고 순서와 상관없이 호출 가능
            Profile(name: "이규영", id: 15, phone: "010-6649-9133");

        }
        // <Optiobal Parameter>
        // 함수의 매개변수가 초기값을 갖고 있다면, 함수 호출시 생략하는 것을 허용하는 방법

        public static void AddStudent(string name, string home ="서울", int age= 7) { }
        // error : 초기값 있는 매개변수는 뒤부터 써주기
        public static void Main2()
        {
            AddStudent("철수");
            AddStudent("영희");
            AddStudent("민주","인천");
            AddStudent("미영",age:8);
        }

        // <Params Parameter>
        // 매개변수의 객수가 정해지지 않는 경우, 매개변수의 갯수를 유동적으로 사용하는 방법
        public static int Sum(params int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++){ sum += numbers[i]; }
            return sum;
        }

        public static void Main5()
        {
            int[] number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Sum(number);

            Sum(1, 2, 3);
            Sum();
        }

        // <in Parameter>
        // 매개변수를 입력전용으로 설정
        // 함수의 처음부터 끝까지 동일한 값을 보장하게 됨
        int Plus(in int left, in int right) {return left + right;}

        // <out Parameter>
        // 매개변수를 출력전용으로 설정
        // 함수의 반환값 외에 추가적인 출력이 필요할 경우 사용
        void Divide (int left, int right,out int quotient, out int remainder)
        {
            quotient = left / right;
            remainder = left % right;
        }

        // <ref Parameter>
        // 매개변수를 원본 참조로 전달
        // 매개변수가 값형식인 경우에도 함수를 통해 원본값을 변경하고 싶을경우 사용
        void Swap(ref int left, ref int right)
        {
            int temp = left;
            left = right;
            right = temp;
        }

    }
}
