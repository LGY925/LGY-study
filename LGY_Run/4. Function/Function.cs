namespace _250314
{
    internal class Function
    {
        #region 함수 (Function)

        /****************************************************************\
         * 함수 (Function)
         * 
         * 미리 정해진 동작을 수행하는 코드 묶음
         * 어떤 처리를 미리 함수로 만들어 두면 다시 반복적으로 사용 가능
        \****************************************************************/

        // <함수의 구성>
        //function 함수이름(매개변수1, 매개변수2,...)

        // <매개변수 (Parameter)>
        // 함수에 추가(입력할 데이터의 자료형과 변수명
        // 같은 함수에서도 매개변수 입력이 다름에 따라 다른처리가 가능


        // <반환형  (Return Type)>
        // 함수의 결과(출력) 데이터의 자료형
        // 함수가 끝나기 전까지 반드시 return으로 반환형에 맞는 데이터를 출력해야함
        // 함수 진행 중 return을 만나는 경우 그 즉시 결과 데이터를 반환하고 함구가 종료됨
        // 함수의 결과(출력)이 없는 경우 반환형은 void 이며 return을 생략가능

        #endregion
        static void NormalAttack()
        {
            Console.WriteLine("일반공격!");
        }

        static void TripleAttack(int power)  // 삼연타
        {
            Console.WriteLine("찌르기!   데미지{0}", power);
            Console.WriteLine("베기      데미지{0}", power + 5);
            Console.WriteLine("떄리기    데미지{0}", power + 3);
        }

        static string MakeFishCake(string taste, float time)
        {
            if (taste == "")
            {
                Console.WriteLine("앙금없는 붕어빵은 만들수 없습니다.");
                return ("오류");
            }

            Console.WriteLine("반죽을 틀에 붓습니다.");
            Console.WriteLine("{0}재료를 넣습니다.", taste);

            if (time < 20)
            {
                Console.WriteLine("{0} 초 동안 굽습니다.", time);
                Console.WriteLine("{0}붕어빵을 만들었습니다", taste);
                return "{taste}붕어빵";
            }

            else
            {
                Console.WriteLine("{0} 초 동안 굽습니다.", taste);
                Console.WriteLine("맛없는 붕어빵을 만들었습니다");
                return "맛없는 붕어빵";
            }

        }

        static int Divaid(int left, int right, out int remain)
        {
            remain = left / right;

            return left % right;
        }

        static void MainAttack()
        {
            SubAttack();
            Console.WriteLine("일반공격!");
            Console.WriteLine("일반공격!");
            Console.WriteLine("일반공격!");
            Console.WriteLine("일반공격!");
            SubAttack();
        }

        static void SubAttack()
        {
            Console.WriteLine("도트공격1!");
            Console.WriteLine("도트공격1!");
            Console.WriteLine("도트공격1!");
            Console.WriteLine("도트공격1!");
        }

        static void SwapTwoNumber(int a, int b)
        {                                                 // a = a, b = b, temp = 없음
            int temp = a;                                 // a = a, b = b, temp = a
            a = b;                                        // a = b, b = b, temp = a
            b = temp;                                     // a = b, b = a, temp = a
            Console.WriteLine("시행 {0},{1}",a, b);
        } // a = a , b = b 바뀐상황을 안보냄
        static void SwapTwoNumberRef(ref int a, ref int b)
        {                                                 // a = a, b = b, temp = 없음
            int temp = a;                                 // a = a, b = b, temp = a
            a = b;                                        // a = b, b = b, temp = a
            b = temp;                                     // a = b, b = a, temp = a
            Console.WriteLine("시행 {0},{1}", a, b);
        } // a = b , b = a 바뀐상황을 보냄 


        static void Main(string[] args)
        {

            //두 숫자를 교체하는 기능
            int tosup0 = 4;
            int tosup1 = 1;
            int temp;
            Console.WriteLine("시행전 {0},{1}", tosup0, tosup1);
            temp = tosup0; 
            Console.WriteLine("시행중 {0},{1},{2}", tosup0, tosup1, temp);
            tosup0 = tosup1;
            Console.WriteLine("시행중 {0},{1},{2}", tosup0, tosup1, temp);
            tosup1 = temp;
            Console.WriteLine("시행후 {0},{1},{2}", tosup0, tosup1, temp);

            Console.WriteLine("시행전 {0},{1}", tosup0, tosup1);   // a = a , b = b   
            
            SwapTwoNumber(tosup0, tosup1);                        //a = b , b = a 
            Console.WriteLine("시행후 {0},{1}",tosup0, tosup1);    // a = a , b = b 
            //
            SwapTwoNumberRef(ref tosup0, ref tosup1);             // a = b , b = a 
            Console.WriteLine("시행후 {0},{1}", tosup0, tosup1);   // a = b , b = a 







        }
    }
}
