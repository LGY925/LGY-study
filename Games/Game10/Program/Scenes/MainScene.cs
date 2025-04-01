using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Game10.Util;

namespace Game10.Scenes
{
    public class MainScene : Scene
    {
        public override void Render()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("*          레전드 RPG            *");
            Console.WriteLine("**********************************");
        }
        public override void Choice()
        {
            Console.WriteLine("1. 게임시작");
            Console.WriteLine("2. 불러오기(미구현)");
            Console.WriteLine("3. 게임종료");
        }
        public override void Result(in int sieneNo)
        {

        }
        public override void Wait()
        {

        }
        public override void Next(in int sieneNo)
        {
            switch (sieneNo)
            {
                case (int)SieneNo.No1:
                    
                    break;
                case (int)SieneNo.No3:
                    Game.EndSwich();
                    break;

            }
        }
    }
}
