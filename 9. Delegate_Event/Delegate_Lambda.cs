using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _9.Delegate_Event;

namespace _9._Delegate
{
    internal class Delegate_Lambda
    {
        /****************************************************************\
         * 무명메서드와 람다식
         * 
         * 델리게이트 변수에 할당하기 위한 함수를 소스코드 구문에서 생성하여 전달
         * 전달하기 위한 함수가 간단하고 일회성으로 사용될 경우에 간단하게 작성
        \****************************************************************/

        public static void Main()
        {
            // <무명매서드>
            // 함수를 통한 연결은 함수가 직접적으로 선언되어 있어야 사용 가능
            // 할당하기 위한 함수가 간단하고 자주 사용될수록 비효율적
            // 간단한 표현식을 통해 함수를 즉시 작성하여 전달하는 방법
            Func<int, int, int> pow = delegate (int n, int x)
            {
                int result = 1;
                for (int i = 0; i < x; i++) result *= n;
                return result;
            };
            // <람다식>
            // 무명매서드의 간단한 표현식
            pow = (n, x) =>
            {
                int result = 1;
                for (int i = 0; i < x; i++) result *= n;
                return result;
            };

            //Action<string> action = delegate (string test) { Console.WriteLine(test); };
            //Action action = (text) => { Console.WriteLine(text); };

            Player player = new Player();

            SFX sfx = new SFX();

            player.OnTakeDamaged += (damage) => { sfx.HitSound();};

            

        }
        public class Player
        {
            private int hp = 100;
            public event Action<int> OnTakeDamaged;
            public void TakeDamage(int damage)
            {
                hp -= damage;
                Console.WriteLine("플래이어가 {0} 데미지를 받습니다.");
                if (OnTakeDamaged != null) OnTakeDamaged(damage);
            }

        }
    }
    public class SFX
    {
        public void HitSound()
        {
            Console.WriteLine("음악을 제시합니다");
        }
    }
}

