using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Game10.Util;

namespace Game10.Scenes
{
    public class Town : Scene
    {
        public override void Render()
        {
            Console.WriteLine("당신은 ");
        }
        public override void Choice()
        {
            
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
