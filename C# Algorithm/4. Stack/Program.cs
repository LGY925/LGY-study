namespace _4._Stack
{
    internal class Program
    {
        /****************************************************************\
         * 스택 (Stack)
         * 
         * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
         * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
        \****************************************************************/

        // <스택 구현>
        // 스택은 리스트를 사용법만 달리하여 구현 가능
        //
        // - 삽입 -
        //         top                      top
        //          ↓                        ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐      ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│ │ │ │  =>  │1│2│3│4│5│6│ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘      └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // - 삭제 -
        //           top                  top
        //            ↓                    ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐      ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│ │ │  =>  │1│2│3│4│5│ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘      └─┴─┴─┴─┴─┴─┴─┴─┘

        
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            
            // 추가 : O(1) ,최악의 경우 O(N)
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            // 꺼내기 : O(1)
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            // 다음으로 꺼내질 요소 확인;
            Console.WriteLine(stack.Peek());

            stack.Push(6);
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);

            while (stack.Count > 0) {Console.WriteLine(stack.Pop());}

            // UI 쪽에서 많이 사용
            // 순서대로 실행순서 만들때 사용 DFS
            // Undo 도 스택 ( 취소 역활 )
            
        }
    }
}
