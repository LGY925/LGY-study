using System.Threading;
using System.Transactions;

namespace _7._Static_OOP
{
    internal class OOP_Inheritance
    {

        #region 상속의 의미

        /*****************************************************************\
         * 상속 (Inheritance)
         *
         * 부모클래스의 모든 기능을 가지는 자식클래스를 설계하는 방법
         * is-a 관계 : 부모클래스가 자식클래스를 포함하는 상위개념일 경우 상속관계가 적합함
        \*****************************************************************/

        #endregion

        #region 접속사의 의미

        // protected : 자식클래스한테는 허락하지만 외부 클래스에서 변경을 허락안하는 접속사
        // sealed : 상속 사용못하게 막음

        #endregion

        #region 상속 예시

        // <상속>
        // 부모클래스를 상속하는 자식클래스에게 부모클래스의 모든 기능을 부여
        // class 자식클래스 : 부모클래스

        class Monster
        {
            protected string name;
            public int hp;
            protected float speed;
            
            
            public void Move(Monster monster)
            {
                Console.WriteLine("{0} 이/가 움직입니다.",monster.name);
            }                                                                           
            public void TakeDamege(int damage)                                          
            {                                                                           
                hp -= damage;                                                           
            }                                                                           
                                                                                        
        }                                                                               
                                                                                        

        class Slime : Monster
        {
            public Slime()
            {
                name = "슬라임";
                hp = 10;
                speed = 1.5f;
            }


                public void Split()
            {
                Console.WriteLine("분열합니다.");
                
            }
        }
        
        class Dragon : Monster
        {                                                                               
            public float speed;                                                         
            public Dragon()                                                             
            {                                                                           
                name = "드래곤";                                                         
                hp = 100;
                base.speed = 10f;
                this.speed = 5.2f;
            }
            public void Brath()
            {
                Console.WriteLine("브래스를 뿜습니다.");
            }
        }


        #endregion

        static void Main3(string[] args)
        {
            Slime slime = new Slime();
            Dragon dragon = new Dragon();
            Player player = new Player();
            
            // 부모클래스의 상속한 자식클래스는 부모클래스의 기능을 가져와 표현을 할수있다
            slime.Move(slime);
            dragon.Move(dragon);

            // 자식클래스는 자식클래스 마다 기능을 표현 할수있다
            slime.Split();
            dragon.Brath();
            

            
            // 업캐스팅 : 자식클래스는 부모클래스 자료형으로 암시적 형변환 가능 (자동으로 가능)
            Monster monster = new Slime();
            monster.Move(monster);
            
            // 다운캐스팅 (불가능한경우가 있기 때문에 확인후에 변환가능)
            // is : 형 변환이 가능하면 true, 아니면 false
            if (monster is Slime)
            {
                Slime slime0 = (Slime)monster;
                slime.Move(slime);
                slime.Split();

            }
            else if (monster is Dragon)
            {
                Dragon dragon0 = (Dragon)monster;
                dragon.Brath();
            }

            // as : 형변환이 가능하면 바꿔서 주고 아니면 null
            Dragon dragon1 = monster as Dragon;
            


        }

        #region 오버로딩

        sealed class Player
        {
            public int damage = 5;
            public void hit(Monster monitor)
            {
                monitor.TakeDamege(damage);
            }

            // 함수 오버로딩 : 같은 이름의 함수여도 뒤에 들어오는것에 따라 달아짐
            public void Test(float value) { }
            public void Test(int value) { }
            public void Use(Item item) { }
            public void Use(skill skill) { }

            public class Item
            {
                public void Use(Item item) { }
            }
            public class skill
            {
                public void Use(skill skill) { }
            }
        }
        #endregion

        #region 상속 생성원리
        // 생성원리
        //  ┌─────────────┐
        //  │ Monster     │
        //  │             │
        //  │─────────────│
        //  │.............│
        //  │ Dragon      │
        //  └─────────────┘
        #endregion

        #region 상속 사용의미
        // <상속 사용의미 1>
        // 상속을 진행하는 경우 부모클래스의 소스가 자식클래스에서 모두 적용됨
        // 부모클래스와 자식클래스의 상속관계가 적합한 경우 부모클래스에서의 기능 구현이 자식클래스에서도 어울림
        class Building
        {
            // 부모클래스에서 기능을 구현할 경우 모든 부모를 상속하는 자식클래스에 기능을 구현하는 효과
        }

        class Home : Building
        {
            // 자식클래스에서 자식클래스만의 기능을 구현
        }

        class School : Building
        {
            // 자식클래스에서 자식클래스만의 기능을 구현
        }


        // <상속 사용의미 2>
        // 업캐스팅을 통해 자식클래스는 부모클래스로 형변환이 가능함
        // 자식클래스는 부모클래스를 요구하는 곳에서 동일한 기능을 수행할 수 있음
        class Parent
        {
            public void Func() { }
        }
        class Child1 : Parent { }
        class Child2 : Parent { }
        class Child3 : Parent { }

        void UseParent(Parent parent) { parent.Func(); }
        void Main2()
        {
            Child1 child1 = new Child1();
            Child2 child2 = new Child2();
            Child3 child3 = new Child3();

            UseParent(child1);
            UseParent(child2);
            UseParent(child3);
        }
        #endregion
    }
}

    

