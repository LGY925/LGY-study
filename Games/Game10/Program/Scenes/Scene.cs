using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game10.Scenes
{
    public abstract class Scene
    {
        public abstract void Render();
        public abstract void Choice();
        public abstract void Result(in int sieneNo);
        public abstract void Wait();
        public abstract void Next(in int sieneNo);
    }
}
