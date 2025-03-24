namespace _250312
{
    internal class Operator_Ifstatements
    {
        static void Main(string[] args)
        {

            #region 연산자의 정의 (Operator)

            /*************************************************************************
              * 연산지 (Operator)
              * 
              * 프로그래밍 언어에서는 일반적인 수학 연산과 유사한 연산자들이 지원됨
              * C#는 여러 연산자를 제공하며 기본 연산을 수행할 수 있음
              *************************************************************************/

            #endregion

            #region 산술 연산자
            /*************************************************************************
             * 산술 연산자
             *************************************************************************/
            // <이진연산자>
            Console.WriteLine(1 + 3);   // +(가산)
            Console.WriteLine(3 - 1);   // -(감산)
            Console.WriteLine(4 * 2);   // *(승산)
            Console.WriteLine(5 / 3f);  // /(제산) 주의!  int의 나눗셈은 소수점을 버림
            Console.WriteLine(14 % 4);  // %(나머지)


            int award = 9;
            int paryMember = 4;
            Console.WriteLine((float)award / paryMember);

            float defense = 1.5f;
            int attackPower = 1;
            Console.WriteLine(attackPower / (int)defense);

            Console.WriteLine(1.1f + 0.3f);
            // 오차가 있을수있다 1.1000003+0.2999998=1.4000001

            // 1의 자리 숫자
            Console.WriteLine(5938643637 % 10);

            // 10의 자리 숫자
            Console.WriteLine(5938643637 / 10 % 10);

            // 100의 자리 숫자
            Console.WriteLine(5938643637 / 100 % 10);

            // <단항 연산자>
            int level = 1;
            level = +level;         // + 단항 연산자(양수) : 값을 그대로 두기
            level = -level;         // - 단항 연산자(음수) : 값을 반전하여 바꾸기
            ++level;                // 전위 증가 연산자 : 값을 1 증가
            level++;                // 후위 증가 연산자 : 값을 1 증가
            --level;                // 전위 감소 연산자 : 값을 1 감소 
            level--;                // 후위 감소 연산자 : 값을 1 감소

            // <전위연산자와 후위연산자>
            // 전위연산자 : 값을 변환하기 전에 연산
            int iValue = 0;
            Console.WriteLine(iValue);      //output : 0
            Console.WriteLine(++iValue);    //output : 1
            Console.WriteLine(iValue);      //output : 1
            // 후위연산자 : 값을 변환한 후에 연산
            iValue = 0;
            Console.WriteLine(iValue);      //output : 0
            Console.WriteLine(iValue++);    //output : 0
            Console.WriteLine(iValue);      //output : 1
            #endregion

            #region 대입 연산자
            /*************************************************************************
             * 대입(할당) 연산자
             *************************************************************************/
            // <대입 연산자>
            int value = 10;
            // 복합 대입 연산자
            // 이진연산자(op)의 경우
            // x op =y는 X = X op y 와 동일

            //$는 문자열 보간 문자열 에서 숫자를 문자데이터에서 숫자데이터로 바꿔줌
            string number1 = "1";

            int exp = 0;
            exp = exp + 100;
            exp += 100;

            int help = 100;
            int mont = 20;

            help -= mont;

            Console.Write("캐릭터의 이름을 입력해주세요 : ");
            string name = Console.ReadLine();
            Console.WriteLine("당신의 이름은 {0}", name);

            Console.Write("당신의 나이를 입력해주세요 : ");
            string input = Console.ReadLine();
            int age = int.Parse(input);
            Console.WriteLine("입력하신 나이 : {0}", age);

            Console.WriteLine("다음년도의 나이 : {0}", age + 1);

            Console.Write("잔고를 입력해주세요 : ");
            string input1 = Console.ReadLine();
            int gold;
            bool success = int.TryParse(input1, out gold);

            Console.WriteLine("입력의 유효 여부 : {0}", success);
            Console.WriteLine("입력하신 잔고 : {0}", gold);
            Console.WriteLine("만원 입금후 잔고 : {0}", gold + 10000);
            #endregion

            #region 논리 연산자
            /*************************************************************************
             * 논리 연산자
             *************************************************************************/
            bool bValue;
            // <논리 연산자>
            bValue = !false;            // !(Not) : 피연산자의 논리 부정을 반환
            bValue = true && false;     // &&(And) : 두 피연산자가 모두 true 일 경우 true
            bValue = true || true;      // ||(Or) : 두 피연산자가 모두 false 일 경우 false

            #endregion

            #region 조건문의 정의 (Conditional)

            /*************************************************************************
             * 조건문 (Conditional)
             * 
             * 조건에 따라 실행이 달라지게 할 때 사용하는 문장
             *************************************************************************/

            #endregion

            #region if 조건문
            /*************************************************************************
             * if 조건문
             * 
             * 조건식의 ture, false에 따라 실행할 블록이 결정하는 조건문
             *************************************************************************/

            // if 조건문 : 조건식의 ture, false에 따라 실행할 블록이 결정하는 조건문
            // else if 조건문 : if 조건식 이후 ture, false에 따라 실행할 블록이 결정하는 조건문
            // else 조건문 : 나머지 false에 따라 실행할 블록이 결정하는 조건문
            int hp0 = 100;
            string input0 = Console.ReadLine();
            int damage0;
            bool success0 = int.TryParse(input, out damage0);

            int alive = hp0 - damage0;

            if (success0 == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("다시입력해주세요");
                Console.ResetColor();
            }
            else if (alive > 50)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("당신은 건강한 상태입니다");
                Console.ResetColor();
            }
            else if (alive > 00)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("당신은 부상인 상태입니다");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("당신은 죽었습니다");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("현재 채력은 {0}입니다.", alive);
            Console.ResetColor();

            #endregion

            #region switch 조건문

            /*************************************************************************
             * swich 조건문
             * 
             * 조건 밧에 따라 '실행할 시작지점을 결정하는 조건문
             *************************************************************************/

            //<switch 조건문 기본>
            int value0 = 'w';
            switch(value0)
            {
                case 'w':
                case 'b':
                case 's':
                    Console.WriteLine("w 입니다");
                    break;
                case 2:
                    Console.WriteLine("2 입니다");
                    break;
                case 3:
                    Console.WriteLine("3 입니다");
                    break;
                default :
                    Console.WriteLine("어느것도 아닙니다");
                    break;
            }

            #endregion

        }
    }
}
