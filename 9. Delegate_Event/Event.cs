using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Delegate_Event
{   /****************************************************************\
     * 이벤트 (Event)
     * 
     * 일련의 사건이 발생했다는 사실을 다른 객체에게 전달
     * 델리게이트의 일부기능을 제한하여 이반드의 용도로 사용
    \****************************************************************/
    
    public class Plater
    {
        public int Hp = 100;
        
        // <이벤트 선언>
        // 델리게이트 변수 앞에 event 키워드를 추가하여 이벤트로 선언

        public event Action<int> OnHpChanged;
        public event Action OnDying;  //진행형
        public event Action OnDied;   //과거형

        public void SetHp(int hp)
        {
            this.Hp = hp;

            if (OnHpChanged != null) OnHpChanged(hp);
        }

        public void Die()
        {
            Console.WriteLine("플레이어가 쓰러집니다.");
           if(OnDied != null) OnDied();
        }
    }

    public class HpBar
    {
        public void SetHpBar(int hp)
        {
            Console.WriteLine("체력표시를 {0} 으로 변경합니다",hp);
        }
    }


    public class Monstar
    {
        public void Stop()
        {
            Console.WriteLine("몬스터가 더이상 플레이어를 쫓아가지 않습니다.");
        }
    }

    public class SFX
    {
        public void DieSound()
        {
            Console.WriteLine("슬픈 음악이 재생됩니다.");
        }
    }
    public class Game
    {
        public void GameOver()
        {
            Console.WriteLine("게임오버 UI를 띄웁니다.");
        }
        internal class Event
        {
            static void Main(string[] args)
            {
                Plater player = new Plater();
                Monstar monstar1 = new Monstar();
                Monstar monstar2 = new Monstar();
                Game game = new Game();
                SFX sfx = new SFX();

                // <이벤트 등록 & 해제>
                // 이벤트에 반응할 객체의 추가할 함수를 += 연산자를 통해 참조 추가
                // 이벤트에 반응할 객체의 제거할 함수를 -= 연산자를 통해 참조 제거
                player.OnDied += monstar1.Stop;
                player.OnDied += monstar2.Stop;
                player.OnDied += game.GameOver;
                player.OnDied += sfx.DieSound;
                
                //몬스터 1이 죽었을때
                player.OnDied -= monstar1.Stop;

                Monstar bossMoster = new Monstar();
                //player.OnDied = bossMoster.Stop;     //새로운 이벤트 추가시 실수로 대입한경우 앞에넣은겄들은 다날아감
                //
                //
                //player.OnDied();                     // 죽지도 않았는데 이벤트가 실행했을경우

                // event 키워드 붙여준다
                // 대입 불가 , 외부콜 불가능

                player.Die();


                HpBar hpBar = new HpBar();

                player.OnHpChanged += hpBar.SetHpBar;
                player.SetHp(10);
                player.SetHp(50);
                player.SetHp(70);
                player.SetHp(100);

            }
            
            // <델리게이트 체인과 이벤트의 차이점>
            // 델리게이트 또한 체인을 통하여 이벤트로서 구현이 가능
            // 하지만 델리게이트는 두가지 사항 때문에 이벤트로서 사용하기 적합하지 않음
            // 1. = 대입연산을 통해 기존의 이벤트에 반응할 객체 상황이 초기화 될 수 있음
            // 2. 클래스 외부에서 이벤트를 발생시켜 원하지 않는 상황에서 이벤트 발생 가능
            // event 키워드를 추가할 경우 델리게이트에서 위 두가지 기능을 제한하여 이벤트 전용으로 사용을 유도할 수 있음
            // 즉, event 변수는 델리게이트에서 기능을 제한하여 이벤트 전용의 기능만으로 사용하는 기능

        }
    }
}
