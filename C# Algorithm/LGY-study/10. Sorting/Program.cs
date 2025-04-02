using System.Diagnostics;

namespace _10._Sorting
{
    internal class Program
    {


        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬하는 방식
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 불안정 정렬
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap (array, i, minIndex);
            }
        }


        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자로 중 적합한 위치에 정렬하는 방식
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정 정렬

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(array, j - 1, j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }


        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정 정렬

        public static void BubbleSort(int[] array)
        {
            for(int i = 1; i < array.Length; i++)
            {
                for(int j = 0; j < array.Length - i ; j++)
                {
                    if(array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }


        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 병합
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(n)
        // 안정 정렬
        public static void MergeSort(int[] array) => MergeSort(array, 0, array.Length - 1);
        private static void MergeSort(int[] array, int start, int end)
        {
            if (start == end)
                return;
            int mid = (start + end) / 2;
            MergeSort(array, start, mid);
            MergeSort(array, mid + 1, end);
            
            Merge(array,start,mid, end);
        }
        private static void Merge(int[] array,int start,int mid, int end)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            while (leftIndex <= mid && rightIndex <= end)
            {
                if (array[leftIndex] < array[rightIndex])
                {
                    sortedList.Add(array[leftIndex]);
                    leftIndex++;
                }
                else 
                { 
                    sortedList.Add (array[rightIndex]);
                    rightIndex++;
                }
            }
            if(leftIndex <= mid)
            {
                while(leftIndex <= mid)
                {
                    sortedList.Add(array[leftIndex]);
                    leftIndex++;
                }
            }
            else
            {
                while (rightIndex <= end)
                {
                    sortedList.Add(array[rightIndex]);
                    rightIndex++;
                }
            }
            for (int i = 0; i < sortedList.Count; i++)
            {
                array[start + i] = sortedList[i];
            }

        }

        // <퀵정렬>
        // 하나의 기준(피벗)으로 작은값과 큰값을 2분할하여 정렬
        // 시간복잡도 -  평균 O(nlogn)        최악의경우 O(n²)
        // 공간복잡도 -  O(n)
        // 불안정 정렬

        public static void QuickSort(int[] array) => QuickSort(array,0,array.Length-1);

        private static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;
            int pivot = start;
            int left = pivot + 1;
            int right = end;
            while (left <= right)
            {
                while (array[pivot] >= array[left] && left < right)
                {
                    left++;
                }
                while (array[pivot] < array[right] && left <= right)
                {
                    right--;
                }

                if(left < right)
                {
                    Swap(array, left, right);
                }
                else
                {
                    Swap(array, pivot, right);
                    break;
                }    
            }
            QuickSort(array, start, right - 1);
            QuickSort(array, right + 1, end);
        }

        // <힙정렬>
        // 힘을 이용하여 우선순위가 가장 높은가 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 벼열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 시간 복잡도 -  O(nlogn)
        // 공간 복잡도 -  O(1)
        // 불안정 정렬

        public static void HeapSort(int[] array)
        {
            int size = array.Length;

            for (int i = size / 2 - 1; i >= 0; i--)
                Heapify(array, size, i);

            for (int i = size - 1; i > 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }
        }

        private static void Heapify(int[] array, int size, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < size && array[left] > array[largest])
                largest = left;

            if (right < size && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                Swap(array, i, largest);

                Heapify(array, size, largest);
            }
        }

        static void Main(string[] args)
        {
            Random random = new Random ();
            int size = random.Next(1000);
            int lazy = random.Next(0,10);
            
            int[] selectArray = new int[size];
            int[] insertionArray= new int[size];
            int[] bubleArray= new int[size];
            int[] mergeArray = new int[size];
            int[] quickArray = new int[size];
            int[] heapArray = new int[size];
            int[] introArray = new int[size];
            

            Console.WriteLine("렌덤데이터");
            for (int i = 0; i < size; i++)
            {
                int read = random.Next (1, lazy);
                Console.Write("{0} ",read);
                selectArray[i] = read;
                insertionArray[i] = read;
                bubleArray[i] = read;
                mergeArray[i] = read;
                quickArray[i] = read;
                heapArray[i] = read;
                introArray[i] = read;
            }
            Console.WriteLine();
            Console.WriteLine();

            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            SelectionSort(selectArray);
            sw.Stop();

            Console.WriteLine("선택 정렬 결과");
            foreach (int value in selectArray)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            Stopwatch sw0= Stopwatch.StartNew();
            sw0.Start();
            InsertionSort(insertionArray);
            sw0.Stop();

            Console.WriteLine("삽입 정렬 결과");
            foreach (int value in insertionArray)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            Stopwatch sw1 = Stopwatch.StartNew();
            sw1.Start();
            BubbleSort(bubleArray);
            sw1.Stop();

            Console.WriteLine("버블 정렬 결과");
            foreach (int value in bubleArray)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            Stopwatch sw2 = Stopwatch.StartNew();
            sw2.Start();
            MergeSort(mergeArray);
            sw2.Stop();

            Console.WriteLine("병합 정렬 결과");
            foreach (int value in mergeArray)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            Stopwatch sw3 = Stopwatch.StartNew();
            sw3.Start();
            QuickSort(quickArray);
            sw3.Stop();

            Console.WriteLine("퀵 정렬 결과");
            foreach (int value in quickArray)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            Stopwatch sw4 = Stopwatch.StartNew();
            sw4.Start();
            HeapSort(heapArray);
            sw4.Stop();

            Console.WriteLine("힙 정렬 결과");
            foreach (int value in heapArray)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            Stopwatch sw5 = Stopwatch.StartNew();
            sw5.Start();
            Array.Sort(introArray);
            sw5.Stop();

            Console.WriteLine("인트로 정렬 결과");
            foreach (int value in introArray)
            {
                Console.Write("{0} ", value);
            }
            Console.WriteLine();

            Time("선택정렬", sw);
            Time("삽입정렬", sw0);
            Time("버블정렬", sw1);
            Time("병합정렬", sw2);
            Time("퀵정렬", sw3);
            Time("힙정렬", sw4);
            Time("인트로정렬", sw5);
        }

        public static void Swap(int[] array, int left, int right)
        {
            int temp= array[left];
            array[left] = array[right];
            array[right] = temp;
        }
        public static void Time(string name,Stopwatch sw)
        {
            Console.WriteLine("{0}이 걸린시간 {1}",name ,sw.ElapsedTicks);   
        }
    }
}
