namespace EX.Additional
{
    internal class ExtensionMethod
    {
        

        static void Main(string[] args)
        {
            string test = "hell world";
            int count = test.WordCount();
            Console.WriteLine(count);

            int charCount =test.CharCount('l');
            Console.WriteLine(charCount);
            
            bool result = 1.IsOddNumber();
            if(result)
            {
                Console.WriteLine("홀수입니다");
            }
            else
            {
                Console.WriteLine("짝수입니다");
            }
        }
    }

    // <확장매서드>
    // 클래스의 원래 형식을 수정하지 않고도 기존 형식에 함수를 추가할 수 있음
    // 상속을 통하여 만들지 않고도 추가적인 함수를 구현 가능
    // 정적함수에 첫번째 매개변수를 this 키워드 후 확장하고자 하는 자료형을 작성

    public static class Extra
    {
        public static int WordCount(this string text)
        {
            string[] words = text.Split("");
            return text.Length;
        }
        public static int CharCount(this string text, char key)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == key)
                {
                    count++;
                }
            }
            return count;
        }
        public static bool IsOddNumber(this int number)
        {
            return number % 2 == 1;
        }
    }
}
