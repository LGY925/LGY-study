using System.Linq.Expressions;

namespace _250318
{
    internal class Program
    {
        #region 좌표
        struct Position
        {
            public int x;
            public int y;
        }
        struct Way
        {
            public int x;
            public int y;
        }

        #endregion
        #region 타일
        enum Tile
        {
            None, Wall, Box, Cross, Goal, Mob, Key
        }
        enum Player
        {
            N, P, C, R
        }

        #endregion
        static void Main(string[] args)
        {

            bool gameOver = false;
            int[,] map;
            Player player;
            Position playerPos;
            Cover();
            Start(out playerPos, out map, out player);
            while (gameOver == false)
            {
                Render(playerPos, map, out player);
                ConsoleKey key = Input();
                Update(key, map, ref playerPos, ref gameOver, player);
            }
            End();
        }
        #region 커비
        static void Cover()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("::                                                                                               ::");
            Console.WriteLine("::                                                                                               ::");
            Console.WriteLine("::                                                                                               ::");
            Console.WriteLine("===================================================================================================");
            Console.ReadKey(true);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("::                                                                                               ::");
            Console.WriteLine("::                                                                                               ::");
            Console.WriteLine("::                                                                                               ::");
            Console.WriteLine("===================================================================================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     *규칙*    ");
            Console.WriteLine(":ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ:");
            Console.WriteLine(":  오브젝트 설명  :  벽  :   #   :  상자  :   □   :  십자가  :   †   :  키  :   K   :  골  :   G   : ");
            Console.WriteLine(":ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ:");
            Console.WriteLine(":    상태 설명    :   P   :  기본 상태   :   C   :  십자가 장착한 상태  :   R   : 도망갈 준비상태  :");
            Console.WriteLine(":ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ:");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("아무키나 눌러서 시작하시오");
            Console.ReadKey(true);
            Console.ResetColor();
            Console.Clear();
        }
        #endregion
        #region 시작부
        static void Start(out Position playerPos, out int[,] map, out Player player)
        {
            Console.CursorVisible = true;


            playerPos.x = 1;
            playerPos.y = 1;


            map = new int[8, 9]

            {   //0.None, 1.Wall, 2.Box, 3.Knife, 4.Goal, 5.Mob, 6. key
                { 1,1,1,1,1,1,1,1,1},
                { 1,0,0,0,1,0,0,0,1},
                { 1,0,0,2,5,0,1,6,1},
                { 1,0,0,0,1,1,1,1,1},
                { 1,0,1,1,1,0,0,0,1},
                { 1,0,1,1,1,0,1,0,1},
                { 1,3,0,0,0,0,1,4,1},
                { 1,1,1,1,1,1,1,1,1}
            };

            PrintMap(map);
            PrintPlayer(map, playerPos, out player);
        }
        static void PrintMap(int[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == (int)Tile.Wall)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("#");
                        Console.ResetColor();
                    }
                    else if (map[y, x] == (int)Tile.Box)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('□');
                        Console.ResetColor();
                    }
                    else if (map[y, x] == (int)Tile.Key)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('K');
                        Console.ResetColor();
                    }
                    else if (map[y, x] == (int)Tile.Goal)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write('G');
                        Console.ResetColor();
                    }
                    else if (map[y, x] == (int)Tile.Cross)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write('†');
                        Console.ResetColor();
                    }
                    else if (map[y, x] == (int)Tile.Mob)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write('M');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }

        }
        static void PrintPlayer(int[,] map, Position playrPos, out Player player)
        {
            Console.SetCursorPosition(playrPos.x, playrPos.y);
            player = Player.P;
            int countKey = 0;
            int countCross = 0;
            foreach (int tile in map)
            {
                if (tile == (int)Tile.Key)
                {
                    countKey++;
                }
                else if (tile == (int)Tile.Cross)
                {
                    countCross++;
                }

            }

            if (countCross == 0)
            {
                player = Player.C;
                if (countKey == 0)
                {
                    player = Player.R;
                }
            }


            if (player == Player.P)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("P");
                Console.ResetColor();
            }
            else if (player == Player.R)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("R");
                Console.ResetColor();
            }
            else if (player == Player.C)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("C");
                Console.ResetColor();
            }


        }
        #endregion
        #region 입력부
        static void Render(Position playrPos, int[,] map, out Player player)
        {
            Console.Clear();
            PrintMap(map);
            PrintPlayer(map, playrPos, out player);
        }

        static ConsoleKey Input()
        {
            ConsoleKey input = Console.ReadKey(true).Key;
            return input;
        }
        #endregion
        #region 출력부
        static void Update(ConsoleKey key, int[,] map, ref Position playerPos, ref bool gameOver, Player player)
        {
            Way way;

            MoveKey(key, out way);
            MoveMunt(way, map, ref playerPos, player);

            gameOver = IsCear(map);
        }
        static void MoveKey(ConsoleKey key, out Way way)
        {
            way.y = 0;
            way.x = 0;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    way.x = -1;
                    break;
                case ConsoleKey.RightArrow:
                    way.x = 1;
                    break;
                case ConsoleKey.UpArrow:
                    way.y = -1;
                    break;
                case ConsoleKey.DownArrow:
                    way.y = 1;
                    break;

            }
        }
        static void MoveMunt(Way way, int[,] map, ref Position PlayerPos, Player player)
        {
            Way back;
            back.y = -way.y + PlayerPos.y;
            back.x = -way.x + PlayerPos.x;

            Way front;
            front.y = way.y + PlayerPos.y;
            front.x = way.x + PlayerPos.x;

            Way box;
            box.y = front.y + way.y;
            box.x = front.x + way.x;

            if (player == Player.P)
            {
                if (map[front.y, front.x] == (int)Tile.None)
                {
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Goal)
                {
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Box)
                {
                    if (map[box.y, box.x] == (int)Tile.None)
                    {
                        map[front.y, front.x] = (int)Tile.None;
                        map[box.y, box.x] = (int)Tile.Box;
                        PlayerPos.y = front.y;
                        PlayerPos.x = front.x;
                    }
                }
                else if (map[front.y, front.x] == (int)Tile.Key)
                {
                    map[front.y, front.x] = (int)Tile.None;
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Key)
                {
                    map[front.y, front.x] = (int)Tile.None;
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Cross)
                {
                    map[front.y, front.x] = (int)Tile.None;
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Mob)
                {

                    PlayerPos.y = back.y;
                    PlayerPos.x = back.x;
                }

            }
            else if (player == Player.C)
            {
                if (map[front.y, front.x] == (int)Tile.None)
                {
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Goal)
                {
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Mob)
                {
                    map[front.y, front.x] = (int)Tile.None;
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Box)
                {
                    if (map[box.y, box.x] == (int)Tile.None)
                    {
                        map[front.y, front.x] = (int)Tile.None;
                        map[box.y, box.x] = (int)Tile.Box;
                        PlayerPos.y = front.y;
                        PlayerPos.x = front.x;
                    }
                }
                else if (map[front.y, front.x] == (int)Tile.Key)
                {
                    map[front.y, front.x] = (int)Tile.None;
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
            }
            else if (player == Player.R)
            {
                if (map[front.y, front.x] == (int)Tile.None)
                {
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Goal)
                {
                    map[front.y, front.x] = (int)Tile.None;
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
                else if (map[front.y, front.x] == (int)Tile.Box)
                {
                    if (map[box.y, box.x] == (int)Tile.None)
                    {
                        map[front.y, front.x] = (int)Tile.None;
                        map[box.y, box.x] = (int)Tile.Box;
                        PlayerPos.y = front.y;
                        PlayerPos.x = front.x;
                    }
                }
                else if (map[front.y, front.x] == (int)Tile.Key)
                {
                    map[front.y, front.x] = (int)Tile.Key;
                    PlayerPos.y = front.y;
                    PlayerPos.x = front.x;
                }
            }

        }
        static bool IsCear(int[,] map)
        {
            foreach (var tile in map)
            {
                if (tile == (int)Tile.Goal)
                {
                    return false;
                }

            }
            return true;
        }

        #endregion
        #region 마무리
        static void End()
        {
            Console.Clear();
            Console.WriteLine("수고하셨습니다");
        }
        #endregion
    }
}
