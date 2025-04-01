using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Game10.Scenes;

namespace Game10
{
    public static class Game
    {
        private static bool gameEnd;

        private static Dictionary<string, Scene> sceneDic;
        private static Scene curScene;

        private static Player player;

        public static Player Player { get { return player; } }

        public static int sieneNo;


        public static void Start()
        {
            sceneDic = new Dictionary<string, Scene>();
            sceneDic.Add("MainScene", new MainScene());

            curScene = sceneDic["MainScene"];

            player =new Player();
            player.Power = 10;
            player.Speed = 5;

        }
        public static void Run() 
        {
            while(gameEnd==false)
            {
                Console.Clear();
                curScene.Render();
                Console.WriteLine();
                curScene.Choice();
                Util.ReadKey(out sieneNo);
                curScene.Result(sieneNo);
                curScene.Wait();
                curScene.Next(sieneNo);
                
            }
        }
        public static void EndSwich()
        {
            gameEnd = true;
        }
        public static void End()
        {
            Console.Clear() ;
            Console.WriteLine("게임이 끝났습니다 ");
            Console.WriteLine("수고하셨습니다");
        }
        public static void ChangeScene(string sceneName)
        {
            curScene = sceneDic[sceneName];
        }

        public static void GameOver(string reason)
        {
            Console.Clear();
            Console.WriteLine("**********************************");
            Console.WriteLine("*          You Died...           *");
            Console.WriteLine("**********************************");
            Console.WriteLine();
            Console.WriteLine(reason);
            Console.WriteLine();
            Console.WriteLine("처음으로 돌아갑니다.");

        }
        public static void GameWin(string reason)
        {
            Console.Clear();
            Console.WriteLine("**********************************");
            Console.WriteLine("*          You Win !!!!          *");
            Console.WriteLine("**********************************");
            Console.WriteLine();
            Console.WriteLine("게임을 클리어 했습니다.");
            Console.WriteLine();
            Console.WriteLine("처음으로 돌아갑니다.");

        }

    }
}
