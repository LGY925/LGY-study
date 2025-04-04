using System.Diagnostics;

namespace _11._Searching
{
    internal class Program
    {
        // <순차 탐색>
        // 자료구조에서 순차적으로 찾고자 하는 데이터를 탐색
        // 시간복잡도 -  0(n)

        public static int LinearSeach(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                { 
                    return i; 
                }
            }
            return -1;
        }

        // <이진 탐색>
        // 정렬이 되어있는 자료구조에서 2분할을 통해 데이터를 탐색
        // 단, 이진 탐색은 정렬이 되어 있는 자료에만 적용 가능
        // 시간복잡도 O(logn)

        public static int BinarySearch(int[] array, int target)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                // 중간위치를 mid로 잡는다;
                int mid = (low + high) / 2;

                if (array[mid] > target)
                {
                    high = mid - 1;
                }
                else if (array[mid] < target) 
                {
                     low = mid + 1;
                }
                else
                {
                    return mid;
                }
     
            }
            return -1;
        }

        // <너비 우선 탐색(BFS)>
        // 그래프의 분기를 만났을 때 모든 분기들을 탐색한 후에,
        // 다음 깊이의 분기들을 탐색
        // 큐를 통해 탐색
        // 장점 : 최단 경로를 보장함
        // 단점 : 지금 탐색상황에서 필요하지 않은 정점데이터도 큐에 보관할 필요가 있다.

        // 일반적으로 그래프에 사용을 선호함
        public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            int size =graph.GetLength(0);      
            visited = new bool[size];          
            parents = new int[size];           
                                               
            for (int i = 0; i < size; i++)    
            {                                  
                visited[i] = false;            
                parents[i] = -1;               
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0) 
            { 
                int next = queue.Dequeue();

                for (int vertex = 0; vertex < size; vertex++)
                {                   
                    if (graph[next,vertex] == true &&   // 연결이 되어있는 정점이면서
                        // parents[vertex] == -1       // 같은 효과 가본적이 없다
                        visited[vertex] == false)       // 방문한 적 없는 정점
                    {
                        queue.Enqueue(vertex);
                        visited[vertex] = true;
                        parents[vertex] = next;
                    }
                }
            }
        }

        // <깊이 우선 탐색(DFS)>
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 분기의 탐색을 마쳤을 때 다음 분기를 탐색
        // 스택을 통해 구현
        // 단점 : 지금 탐색상황에 필요한 정점 데이터만 보관 가능하고 탐색이 끝나면 버려도 무관하다.
        // 단점 : 최단거리를 보장하지 않음

        // 일반적으로 트리에 사용을 선호함

        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            parents = new int[size];

            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            // 함수 호출 스택 쓰는방법
            SearchNode(graph, start, visited, parents);
        }
        private static void SearchNode(bool[,] graph, int vertex,in bool[] visited,in int[] parents)
        {
            int size =graph.GetLength(0);
            visited[vertex] =true;
            for (int i = 0;i < size;i++)
            {
                if (graph[vertex,i] == true && 
                    visited[i] == false)
                {
                    parents[i] = vertex;
                    SearchNode(graph,i, visited, parents);
                }
                       
            }
        }  
        public static void DFS0(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            parents = new int[size];

            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }
            
            Stack<int> stack = new Stack<int>();
            int vertex;
            vertex = start;

            stack.Push(vertex);
            visited[vertex] = true;
            do
            {
                for (int i = 0; i < size; i++ )
                {
                    if(graph[vertex,i] == true &&
                        visited[i] == false)
                    {
                        parents[i] = vertex;
                        vertex = i;
                        visited[vertex] = true;
                        stack.Push(vertex);
                    }
                }
                vertex = stack.Pop();
            }while (stack.Count > 0);
        }

        // <다익스트라 알고리즘>
        // 특정한 노드에서 출발하여 다른 노드까지 가는 각각의 최단 경로를 구하는 알고리즘
        // 1. 방문하지 않는 노드 중에서 가장 가까운 노드를 선택한 후,
        // 2. 선택한 노드를 거쳐서 더 짧아지는 경로가 있는 경우 대체

        const int INF = 999999;
        public static void Dijkstra(int[,] graph, int start, out  bool[] visited, out int[] parents, out int[] cost)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            parents = new int[size];
            cost = new int[size];
            
            for (int i = 0; i<size; i++)
            {
                cost[i] = INF;
                parents[i] = -1;
                visited[i] = false;
            }
            cost[start] = 0;

            for (int i = 0;i < size;i++)
            {
                // 1. 방문하지 않은 정점 중 가장 가까운 정점 선택
                int minIndex = -1;
                int minCost = INF;
                for (int j = 0; j < size; j++)
                {
                    if (visited[j] == false && 
                        cost[j] < minCost)
                    {
                        minIndex = j;
                        minCost = cost[j];
                    }
                }
                if (minIndex < 0)
                    break;
                visited[minIndex] = true;

                // 2. 직접 연결된 거리보다 거쳐서 더 짧아지면 대체
                for (int j = 0; j < size; j++)
                {
                    // cost[j] :            목적지까지 직접 연결된거리              (AB)
                    // cost[minIndex] :     중간점까지의 직접 연결된 거리           (AC) 
                    // graph[minIndex, j] : 중간점부터 복적지까지 거리              (CB)
                    if (cost[j]> cost[minIndex] + graph[minIndex,j])
                    {
                        cost[j] = cost[minIndex] + graph[minIndex,j];
                        parents[j] = minIndex;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Stopwatch sw0 = new Stopwatch();
            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();
            Stopwatch sw3 = new Stopwatch();

            int[] linearArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int[] binaryArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            sw.Start();
            int linerIndex = LinearSeach(linearArray, 14);
            sw.Stop();
            
            sw0.Start();
            int binaryIndex = BinarySearch(binaryArray, 14);
            sw0.Stop();

            Console.WriteLine("선형탐색 결과 : {0}", linerIndex);
            Console.WriteLine("이진탐색 결과 : {0}", binaryIndex);

            bool[,] graph = new bool[8, 8];
            MakeGraph(graph);

            // BFS 탐색
            Console.WriteLine("<BFS>");
            sw1.Start();
            BFS(graph, 0, out bool[] BFSvisited, out int[] BFSparents);
            sw1.Stop();
            Console.WriteLine("{0} {1} {2}", "vertex", "visited", "parent");
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.WriteLine("{0}      {1}     {2}", i, BFSvisited[i], BFSparents[i]);
            }

            // DFS 탐색
            Console.WriteLine("<DFS>");
            sw2.Start();
            DFS0(graph, 0, out bool[] DFSvisited, out int[] DFSparents);
            sw2.Stop();
            Console.WriteLine("{0} {1} {2}", "vertex", "visited", "parent");
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.WriteLine("{0}      {1}     {2}", i, DFSvisited[i], DFSparents[i]);
            }
            #region 가중치 그래프
            
            int[,] weightGraph = new int[9, 9]
            {
                {   0, INF,   1,   7, INF, INF, INF,   5, INF},
                { INF,   0, INF, INF, INF,   4, INF, INF, INF},
                { INF, INF,   0, INF, INF, INF, INF, INF, INF},
                {   5, INF, INF,   0, INF, INF, INF, INF, INF},
                { INF, INF,   9, INF,   0, INF, INF, INF,   2},
                {   1, INF, INF, INF, INF,   0, INF,   6, INF},
                { INF, INF, INF, INF, INF, INF,   0, INF, INF},
                {   1, INF, INF, INF,   4, INF, INF,   0, INF},
                { INF,   5, INF,   2, INF, INF, INF, INF,   0}
            };

            #endregion

            Console.WriteLine("<Dijkstra>");
            sw3.Start();
            Dijkstra(weightGraph, 0, out bool[] dijVisited, out int[] dijParents, out int[] cost);
            sw3.Stop();
            Console.WriteLine("{0} {1} {2} {3}", "vertex", "visited", "parent","cost");
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                Console.WriteLine("{0}      {1}     {2}    {3}", i, dijVisited[i], dijParents[i], cost[i]);
            }

            Console.WriteLine("{0} / 걸린시간 : {1}", "선형탐색", sw.ElapsedTicks);
            Console.WriteLine("{0} / 걸린시간 : {1}", "이진탐색", sw0.ElapsedTicks);
            Console.WriteLine("{0} / 걸린시간 : {1}", "BPS", sw1.ElapsedTicks);
            Console.WriteLine("{0} / 걸린시간 : {1}", "DPS", sw2.ElapsedTicks);
            Console.WriteLine("{0} / 걸린시간 : {1}", "다엑스트라", sw3.ElapsedTicks);
        }
        public static void MakeGraph(in bool[,] graph)
        {
            graph[0, 1] = true;
            graph[0, 2] = true;
            graph[0, 3] = true;
            graph[1, 0] = true;
            graph[1, 2] = true;
            graph[1, 3] = true;
            graph[2, 0] = true;
            graph[2, 4] = true;
            graph[2, 6] = true;
            graph[3, 0] = true;
            graph[3, 1] = true;
            graph[3, 7] = true;
            graph[4, 2] = true;
            graph[4, 6] = true;
            graph[4, 7] = true;
            graph[5, 6] = true;
            graph[6, 2] = true;
            graph[6, 4] = true;
            graph[6, 5] = true;
            graph[7, 3] = true;
            graph[7, 4] = true;
        }


    }
}
