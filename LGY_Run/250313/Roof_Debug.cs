namespace _250313
{
    internal class Roof_Debug
    {
        static void Main(string[] args)
        {
            #region 반복문의 정의 (Roof)

            /*************************************************************************
             * 반복문 (Roof)
             * 
             * 컴퓨터에게 반복되는 행동을 지시하는 문장
             *************************************************************************/

            #endregion

            #region for 반복문

            /*************************************************************************
             * for 반복문
             * 
             * 초기화, 조건식, 증강 연산 으로 구성된 반복문
             *************************************************************************/

            //for (초기화; 조건식; 증강연산)
            //    전위 연산자 사용
            for (int i = 0; i < 10; ++i) // 10번 반복
            {
                Console.WriteLine("똑같은 작업 {0}", i);     // 반복할 내용
            }
            // for 반복문에 사용한 변수는 for 반복문 내에서만 사용됨
            Console.WriteLine();

            //후위 연산자 사용
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine("똑같은 작업 {0}", i);
            }

            // for 활용

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("{0} : 짝", i);
                }
                else
                {
                    Console.WriteLine("{0} : 홀", i);
                }
            }

            // 이중반복

            for (int i = 1; i < 4; i++)
            {
                Console.Clear();
                Console.ReadLine();
                Console.WriteLine("{0}루프", i);
                for (int j = 1; j <= 10; j++)
                {
                    Console.ReadLine();
                    Console.WriteLine("{0}루프 {1}회차", i, j);
                }
            }

            #endregion

            #region while 반복문

            /*************************************************************************
             * while 반복문
             * 
             * 조건식의 true, false에 따라 블록을 반복하는 반복문
             * *************************************************************************/


            // 동전교환기
             int coin = 400;
            while (coin > 0)
            {
                Console.WriteLine("100원 동전이 나옵니다");
                coin -= 100;
            }

            #endregion

            #region do while 반복문
            /*************************************************************************
             * do while 반복문
             * 
             * 블록을 한번 실행 후 조건식의 true, false 에 따라 블록을 반복하는 반복문
            *************************************************************************/
            int choice;
            do
            {
                Console.Write("1에서 9 사이의 수를 입력하시오 : ");
                string input = Console.ReadLine();
                int.TryParse(input, out choice);

            } while ((1 <= choice) && (choice <= 9));
            // 한번은 실행하게 되있다.
            // 예제
            Console.Write("1에서 9사이의 수를 입력하시오 : ");
            int choice0;
            string input0 = Console.ReadLine();
            bool notNumber0 = int.TryParse(input0, out choice0);
            if (!((1 <= choice0) && (choice0 <= 9) && (notNumber0 == true)))
            {
                do
                {
                    Console.WriteLine("틀렸습니다.다시입력하시오");
                    Console.Write("1에서 9사이의 수를 입력하시오 : ");
                    string input = Console.ReadLine();
                    int.TryParse(input, out choice0);

                } while (((1 <= choice0) && (choice0 <= 9)) == false);
            }
            Console.WriteLine("끝");

            #endregion

            #region break 제어문

            /*************************************************************************
             * break 제어문
             * 
             * 가장 가까운 반복문을 종료
             **************************************************************************/

            int potionPos = 3;
            for (int i = 1; i < 1000; i++)
            {
                Console.WriteLine("{0}번째칸에 포션이 있는지 확인합니다.");
                if (i == potionPos)
                {
                    Console.WriteLine("포션을 찾았습니다.");
                    Console.WriteLine("포션을 사용합니다.");
                    break;
                }

            }

            #endregion

            #region continue 제어문

            /*************************************************************************
             * continue 제어문
             * 
             * 가장 가까운 반복문의 새 반복을 시작
             **************************************************************************/

            //4번 플레이어가 무적이야, 6번 플레이어는 내 캐릭터 일때
            for (int i = 1; i <= 8; i++)
            {
                if (i == 4)
                {
                    Console.WriteLine("4번 플레이어는 무적이라 공격하지 못합니다.");
                    continue;
                }
                if (i == 6)
                {
                    Console.WriteLine("6번 플레이어는 내 캐릭터라서 공격하지 않습니다.");
                    continue;
                }
                Console.WriteLine("{0}번 플레이어를 공격합니다", i);

                continue;
            }

            #endregion

            #region 디버거의 정의(Debug)

            /*************************************************************************
             * 디버거 (Debug)
             * 
             * 단계단계 따라가며 찾아가 문제점을 찾는 기능
            *************************************************************************/

            #endregion

            #region 디버거

            // f11 스타트
            //  f9 시작점 지정
            //  f5 시작




            #endregion


        }
    }
}
