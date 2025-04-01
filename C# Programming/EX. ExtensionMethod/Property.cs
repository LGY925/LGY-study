using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX._Additional
{
    internal class Property
    {
        public class Plater
        {
            public event Action OnHPChanged;
            private int hp;

            // <Getter Setter>
            // 맴버변수가 외부객체와 상호작용하는 경우 Get & Set 함수를 구현해 주는 것이 일반적
            // 1. Get & Set 함수의 접근제한자를 설정하여 외부에서 맴버변수의 접근을 캡슐화함
            // 2. Get & Set 함수를 거쳐 맴버변수에 접근할 경우 호출스택에 함수가 추가되어 변경시점을 확인가능

            public int GetHP()
            {
                return hp;
            }
            private void SetHP(int hp)
            {
                this.hp = hp;
            }

            // <속성 (Property)>
            // Get & Set 함수의 간소화 표현

            public int MP {  get; set; }  // 따로따로 쓸수있다

            private int ap;

            public int AP {  get { return ap; } set { ap = value; OnAPCanged?.Invoke(); } }
            public event Action OnAPCanged;

            public int  TotalDamge => hp *MP * AP;

            public bool IsAlive => hp > 0;
            public bool IsDead => hp <= 0;


        }

        public class NetworkGame
        {
            private bool isInRoom;
            private bool isReady;
            private bool isSelectChar;
            private bool isEqualteamMember;

            public bool IsSartable => isInRoom && isReady && isSelectChar && isSelectChar;
        }
        public static void Main()
        {
            Plater plater = new Plater();
            if (plater.IsAlive) { }
            else if (plater.IsDead) { }

        }
    }
}
