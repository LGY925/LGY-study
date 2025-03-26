using System.Text;

namespace _5.Array_Enum_Struct
{
    internal class Array
    {
        static void Main0(string[] args)
        {
            #region 배열   

            /****************************************************************\
             * 배열 (Array)
             * 
             * 동일한 자료형의 요소들로 구성된 데이터 집합
             * 인덱스를 통하여 배열요소(Element)에 접근할 수 있음
             * 배열의 처음 요소의 인덱스는 0부터 시작함
            \****************************************************************/


            // <배열 기본>
            // 배열을 만들기 위해 자료형과 크기를 정하여 생성
            // 배열의 Length 를 총해 크기를 확인

            // 자료형 [] 배열이름 = new 자료형[크기];
            int[] scores = new int[10];      // 크기 5의 배열 선언

            scores[0] = 10;                 // 0번째 요소 저장
            scores[1] = 20;                 // 1번쨰 요소 저장
            scores[2] = 30;                 // 2번쨰 요소 저장
            scores[3] = 40;                 // 3번째 요소 저장
            scores[4] = 50;                 // 4번쨰 요소 저장

            Console.WriteLine("{0}", scores[0]);
            Console.WriteLine("{0}", scores[1]);
            Console.WriteLine("{0}", scores[2]);
            Console.WriteLine("{0}", scores[3]);
            Console.WriteLine("{0}", scores[4]);

            Console.WriteLine("배열에 있는 int의 갯수는 : {0}", scores.Length);

            int totalScore = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = 10 + i * 10;

                Console.WriteLine("{0}", scores[i]);


            }
            #endregion

            #region foreach 반복문
            /****************************************************************\
             * foreach 반복문
             * 
             * 데이터집합의 처음부터 끝까지 반복
            \****************************************************************/


            foreach (int num in scores)
            {
                totalScore += num;
            }

            Console.WriteLine("{0}번째 {1}데이터", 5, scores[5]);
            Console.WriteLine("총합 스코어 : {0}", totalScore);

            string[,] shortCuts0;
            shortCuts0 = new string[3, 4];
            shortCuts0[0, 0] = "포션";
            shortCuts0[0, 1] = "폭탄";
            shortCuts0[0, 2] = "섬광";
            shortCuts0[0, 3] = "부적";

            shortCuts0[1, 0] = "작은부적";
            shortCuts0[1, 1] = "룬조각";
            shortCuts0[1, 2] = "큰부적";
            shortCuts0[1, 3] = "빨포";

            shortCuts0[2, 0] = "파포";
            shortCuts0[2, 1] = "수류탄";
            shortCuts0[2, 2] = "캡슐";
            shortCuts0[2, 3] = "이상한사탕";

            for (int i = 0; i < shortCuts0.GetLength(0); i++)
            {
                for (int j = 0; j < shortCuts0.GetLength(1); j++)
                    Console.WriteLine("{0}번쨰줄 {1}번째 아이템 : {2}", i, j, shortCuts0[i, j]);
            }
            Console.WriteLine("행 크기{0}", shortCuts0.GetLength(0));             //0열의 크기
            Console.WriteLine("열 크기{0}", shortCuts0.GetLength(1));             //1열의 크기
            Console.WriteLine("인벤토리 크기{0}", shortCuts0.Length);             //전체 크기

            int[,] array =
            {
                {1, 2, 3},
                {4, 5, 6},
                {6, 7, 8}
            };

            // var 자동완성기능

            string texts = "abcde";

            Console.WriteLine(texts[2]);
            Console.WriteLine(texts.Length);
            for (int i = 0; i < texts.Length; i++)
            {
                Console.WriteLine(texts[i]);
            }

            char[] test = texts.ToCharArray();
            Console.WriteLine(test);
            Console.WriteLine(test.Length);

            test[3] = 'a';

            test[0] = char.ToUpper(test[0]);

            texts = new string(test);
            Console.WriteLine(texts);
            int[] test0 = { 1, 2, 3, 4, 5 };
            Console.WriteLine("함수전 값 : {0}", test0[2]);
            Arraytest(test0);
            Console.WriteLine("함수후 값 : {0}", test0[2]);

            #endregion
        }

        static void Arraytest(int[] array)
        {
            array[2] = 999;
        }

        static void IntTest(ref int value)
        {
            value = value + 10;
        }
        
    }
}
