namespace _9._Recursion
{
    internal class Program
    {
        /****************************************************************\
         * 재귀 (Recursion)
         * 
         * 어떠한 것을 정의할 때 자기 자신을 참조하는 것
         * 함수를 정의할 때 자기자신을 이용하여 표현하는 방법
        \****************************************************************/

        // <재귀함수 조건>
        // 1. 함수내용 중 자기자신함수를 다시 호출해야함
        // 2. 종료조건이 있어야 함
        

        // <재귀함수 사용>
        // Factorial : 정수를 1이 될 때까지 차감하며 곱한 값
        // x! = x * (x-1)!;
        // 1! = 1;
        // ex) 5! = 5 * 4!
        //        = 5 * 4 * 3!
        //        = 5 * 4 * 3 * 2!
        //        = 5 * 4 * 3 * 2 * 1!
        //        = 5 * 4 * 3 * 2 * 1

        int Factorial(int x)
        {
            if (x == 1)
                return 1;
            else
                return x * Factorial(x - 1);
        }


        // 폴더 삭제

        public class Folder
        {
            
            public List<Folder> children;
        }
        public void RrmoveFolder(Folder folder)
        {
            foreach (Folder Child in folder.children)
            {
                RrmoveFolder(Child); 
            }
        }
        static int Stecking(int x, int y)
        {
            for (int i = 1; i<y; i++)
            {
                return x*Stecking(x, y - i);
            }
            return x;
        }
        // 피보나치 수열 
        // 최악의 알고리즘 O(n²)
        int Fibonachi(int x)
        {
            if (x == 1) return 1; else if (x == 2) return 1;

            return Fibonachi(x - 1) + Fibonachi(x - 2);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Stecking(2, 12);
        }
    }
}
