﻿namespace _2._List
{
    internal class Program
    {
        /****************************************************************\
         * 리스트 (List)
         * 
         * 런타임 중 크기를 확장할 수 있는 배열 기반의 자료구조
         * 배열요소의 갯수를 특정할 수 없는 경우 사용이 용이
        \****************************************************************/

        // <리스트 구현>
        // 리스트는 배열기반의 자료구조이며, 배열은 크기를 변경할 수 없는 자료구조
        // 리스트는 동작 중 크기를 확장하기 위해 포함한 데이터보다 더욱 큰 배열을 사용
        //
        // 크기 = 3, 용량 = 8       크기 = 4, 용량 = 8       크기 = 5, 용량 = 8
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│ │ │ │ │ │        │1│2│3│4│ │ │ │ │        │1│2│3│4│5│ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


        // <리스트 삽입>
        // 중간에 데이터를 추가하기 위해 이후 데이터들을 뒤로 밀어내고 삽입 진행
        //      ↓                        ↓                        ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│ │ │ │ │   =>   │1│2│ │3│4│ │ │ │   =>   │1│2│A│3│4│ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


        // <리스트 삭제>
        // 중간에 데이터를 삭제한 뒤 빈자리를 채우기 위해 이후 데이터들을 앞으로 당김
        //      ↓                        ↓
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐        ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│A│3│4│ │ │ │   =>   │1│2│ │3│4│ │ │ │   =>   │1│2│3│4│ │ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘        └─┴─┴─┴─┴─┴─┴─┴─┘


        // <리스트 용량>
        // 용량을 가득 채운 상황에서 데이터를 추가하는 경우
        // 더 큰 용량의 배열을 새로 생성한 뒤 데이터를 복사하여 새로운 배열을 사용
        //
        // 1. 리스트가 가득찬 상황에서 새로운 데이터 추가 시도
        // 크기 = 8, 용량 = 8
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│ ← A Add
        // └─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // 2. 새로운 더 큰 배열 생성
        // 크기 = 8, 용량 = 8          크기 = 0, 용량 = 16
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐           ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│ ← A Add   │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘           └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // 3. 새로운 배열에 기존의 데이터 복사
        // 크기 = 8, 용량 = 8          크기 = 8, 용량 = 16
        // ┌─┬─┬─┬─┬─┬─┬─┬─┐           ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│ ← A Add   │1│2│3│4│5│6│7│8│ │ │ │ │ │ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┘           └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // 4. 기본 배열 대신 새로운 배열을 사용
        // 크기 = 8, 용량 = 16
        // ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│ │ │ │ │ │ │ │ │ ← A Add
        // └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘
        //
        // 5. 빈공간에 데이터 추가
        // 크기 = 9, 용량 = 16
        // ┌─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┬─┐
        // │1│2│3│4│5│6│7│8│A│ │ │ │ │ │ │ │
        // └─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┴─┘


        // <리스트 시간복잡도>
        // 접근    탐색    삽입    삭제
        // O(1)    O(n)    O(n)    O(n)

        static void Main(string[] args)
        {
            // 구현
            List<string> list = new List<string>();
            // 필요에 따라 크기를 늘리면서 출이면서 사용

            // 추가
            list.Add("0번데이터");              // 맨뒤에 추가하기 : O(1)
            list.Add("1번데이터");
            list.Add("2번데이터");
            list.Add("3번데이터");
            list.Insert(2, "추가한 2번데이터"); // 중간에 끼워넣기 : O(n)
            list.Insert(0, "추가한 0번데이터");
            list.Add("삭제할데이터");
            list.Insert(0, "삭제할데이터");

            // 삭제
            list.Remove("0번데이터");           // 똑같은거 찾아서 삭제하기 : 0(n)
            list.Remove("2번데이터");           // 내부요소에 같은 요소가 있을경우 첫번째에 나온것을 삭제
            list.RemoveAt(0);                   // 특정 위치에 있는 요소 지우기 : 0(n)
            list.Remove("삭제할데이터");
            list.Remove("없는데이터");           // 찾아서 지울때 없었으면 무시 (반환은 false)

            // 접근 : O(1)
            list[1] = "바뀐1번데이터";           // 리스트는 배열로 구현되어 있기 때문에 
            string str = list[1];               // 인덱스를 통한 접근이 가능하다 
            Console.WriteLine("str 데이터 : {0}",str);
            
            // 탐색 : O(n)
            int index = list.IndexOf("바뀐1번데이터");        // 찾아서 인덱스 가져오기
            Console.WriteLine("\"바뀐1번데이터\"의 갯수 : {0}", index);
            bool contain = list.Contains("바뀐1번데이터");    // 찾아서 있으면 true, 없으면 false
            Console.WriteLine("\"바뀐1번데이터\"의 유무 :{0}", contain);
            int count = list.Count;                 // 크기
            for (int i =0; i < list.Count; i++) {Console.WriteLine(list[i]);}
            

            int volume = list.Capacity;             // 용량
            Console.WriteLine(volume);
            List<int> intList = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                intList.Add(i);
                Console.WriteLine("count = {0}, Capcity = {1}",intList.Count,intList.Capacity);
            }
            for (int i = 0; i < 20; i++)
            {
                intList.Remove(i);
                Console.WriteLine("count = {0}, Capcity = {1}", intList.Count, intList.Capacity);
            }
            intList.TrimExcess();                   // 용량 최적화시키기
            Console.WriteLine("count = {0}, Capcity = {1}", intList.Count, intList.Capacity);

        }
    }
}
