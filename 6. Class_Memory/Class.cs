namespace _250324
{
    internal class Class
    {
        #region 전체적인 개념
        /****************************************************************\
         * 객체 (Object)
         * 개념적으로나 물리적으로 존재하는 것
         * 
         * 클래스(Class)
         * 설계도 정보+기능
         * 
         * 인스턴스(Instance)
         * 실체화 결과물
        \****************************************************************/

        /****************************************************************\
         * 객체지항 프로그래밍 (OOP)
         * 
         * 추상화 (Abstraction) : 복잡한 것을 단순화
         * 
         * 캡슐화(Encapsulation) : 객체의 정보와 기능을 하나로 묶는 것
         * 
         * 상속 (Inheritance) : 부모 클래스의 정보와 기능을 자식 클래스가 물려받는 것
         * 
         * 다형성 (Polymorphism) : 객체의 속성이나 기능이 상황에 따라 여러 형태로 나타내는 것
        \****************************************************************/

        /*****************************************************************\
         * SOLID 원칙 (권장사항)
         * 
         * S : 단일 책임 원칙 (Single Responsibility Principle)
         * 클래스는 단 하나의 책임만 가져야 한다.
         * 쪼개서 여러개의 클래스로 만들어야 한다.
         * 
         * O : 개방 폐쇄 원칙 (Open Closed Principle)
         * 확장에는 열려있고 수정에는 닫혀 있어야 한다.
         * 기능을  추가할 때는 기존 코드를 수정하지 않고 새로운 코드를 추가해야 한다.
         * 
         * L : 리스코프 치환 원칙 (Liskov Substitution Principle)
         * 자식 객체는 언제나 부모 객체를 대체할 수 있어야 한다.
         * 상위 클래스의 인스턴스 대신 하위 클래스의 인스턴스로 대체해도 프로그램의 의미는 변하지 않아야 한다.
         * 
         * I : 인터페이스 분리 원칙 (Interface Segregation Principle)
         * 하나의 큰 인터페이스보다는 여러개의 작은 인터페이스가 낫다.
         * 인터페이스의 분리나 수정으로 인한 영향을 최소화 할 수 있다.
         * 
         * D : 의존 역전 원칙 (Dependency Inversion Principle)
         * 고수준 모듈은 저수준 모듈에 의존하면 안된다.
         * 객체간의 의존 관계를 최소화하여 유연한 코드를 작성할 수 있다.
        \*****************************************************************/


        #endregion


        #region 클래스
        /*****************************************************************\
         * 클래스 (class) 
         * 
         * 데이터와 관련 기능을 캡슐화할 수 있는 참조 형식
         * 객체지향 프로그래밍에 객체를 만들기 위한 설계도
         * 클래스는 객체를 만들기 위한 설계도 이며 만들어진 객체는 인스턴스라고 한다.
         * 참조 : 원본을 가리키고 있음 == 원본의 주소를 가지고 있음
        \*****************************************************************/




        class Player
        {
            // 변수(명사) : 정보
            private int Level=1;
            private int attackPoint=10;

            Skill qskill;
            // 함수(동사) : 행동
            public void Attack(Monster monster)
            {
                Console.WriteLine("플레이어가 공격합니다.");
                monster.TakeHit(attackPoint);
            }

        }
       
        class Skill
        {

        }

        class Monster
        {
           
            private int hp = 10;
        
            
            public void TakeHit(int attackPoint)
            {
                Console.WriteLine("몬스터가 공격받았습니다.");

                hp -= attackPoint;
                Console.WriteLine("몬스터의 체력 : {0}", hp);
                if (hp <= 0)
                {
                    Die();
                }
            }



            private void Die()
            {
                Console.WriteLine("몬스터가 죽었습니다.");
            }
        }



        #endregion


        static void Main(string[] args)
        {
            
            Player player = new Player();
            Monster monster = new Monster();
            
            player.Attack(monster);     //player가 monster를 공격
            player.Attack(monster);

        }
    }
}
