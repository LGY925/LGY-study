using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Generic_Interface
{

    internal class Interface
    {
        #region 인터페이스의 개념

        /****************************************************************\
         * 인터페이스 (Interface)
         * 
         * 인터페이스는 맴버를 가질 수 있지만 직접 구현하지 않음 단지 정의만을 가짐
         * 인터페이스를 가지는 클래스에서 반드시 인터페이스의 정의를 구현해야함
         * 이를 반대로 표현하자면 인터페이스를 포함하는 클래스는
         * 반드시 인터페이스의 구성 요소들을 구현했다는 것을 보장함
         * Can-a 관계 : 클래스가 해당 행동을 할 수 있는 경우 적합함
        \****************************************************************/

        #endregion

        #region 인터페이스 예시

        // <인터페이스 정의>
        // 일반적으로 인터페이스의 이름은 I로 시작함
        // 인터페이스의 함수는 직접 구현하지 않고 정의만 진행
        // ~~ 할수 있다.
        public interface IOpenable
        {
            public void Open();

        }

        public interface IEnterable
        {
            public void Enter();

        }


        public class Door : IOpenable, IEnterable
        {

            public void Open()
            {  
                Console.WriteLine("문를 엽니다");   
            }
            public virtual void Enter()
            {
                Console.WriteLine("문안으로 들어갑니다.");
            }

        }
        
        public class Dungeon : IEnterable
        {
            
            public void Enter()
            {
                Console.WriteLine("던전에 들어갑니다.");
            }
        }
        public class Chest : IOpenable
        {
            public void Open()
            {
                Console.WriteLine("상자를 엽니다.");
            }
        }

        public class Player 
        {
            public void Open(IOpenable openable)
            {
                openable.Open();
            }
            public void Enter(IEnterable enterable)
            {
                enterable.Enter();
            }
        }

        #endregion

        static void Main(string[] args)
        {
            Player player = new Player();
            Door door =new Door();
            Dungeon dungeon = new Dungeon();
            Chest chest = new Chest();

            player.Open(door);
            player.Open(chest);

            player.Enter(door);
            player.Enter(dungeon);
        }
    }
    
}
