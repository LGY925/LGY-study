namespace _6.Class_Memory_Namespace
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

        #region 접속사의 의미

        // public : 모든 클래스에서 허락
        // private : 외부 클래스에서 변경 불가

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

        #endregion

        #region 클래스 생성자

        // <클래스 구성>
        // class 클래스이름 { 클래스내용 }
        // 클래스 내용으로는 변수와 함수가 포함 가능

        public class Monster
        {
            public string name;
            public int hp;
            
            // <클래스 생성자>
            // 반환형이 없는 클래스이름의 함수를 생성자라 하며 클래스의 인스턴스를 만들 때 호출 되는 역활로 사용
            // 인스턴스 의 생성자는 new 키워드를 사용하여 호출
            //기본 생성자
            public Monster()
            {
                Console.WriteLine("몬스터가 생성되었습니다.");
                name = "몬스터";
                hp = 100;
                Console.WriteLine("{0}의 체력 : {1}",name, hp);
            }
            // 자동 생성

            public Monster(string name0, int hp0) 
            {
                Console.WriteLine("몬스터가 생성되었습니다.");
                name = name0;
                hp = hp0;
                Console.WriteLine("{0}의 체력 : {1}", name, hp);
            }

            public Monster(string _name)
            {
                Console.WriteLine("몬스터가 생성되었습니다.");
                name = _name;
                switch (_name)
                {
                    case "슬라임":                        
                        hp = 50;
                        break;
                    case "오크":                        
                        hp = 200;
                        break;
                    case "드래곤":                        
                        hp = 500;
                        break;
                    case "보스":                        
                        hp = 1000;
                        break;
                }
                Console.WriteLine("{0}의 체력 : {1}", name, hp);
            }

            // 무조건 지정해야 생성
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

        #region 클래스와 구조체 차이
        class ClassType
        {
            public int value;
        }

        struct structType
        {
            public int value;
        }

        #endregion

        static void Main(string[] args)
        {
            Namespace player;                      //지역변수를 생성하고 null(아무것도 없음) 참조)
            player = new Namespace();              //Player 클래스의 인스턴스를 생성하고 player에 대입
            player.name = "플레이어";            //player의 name에 "플레이어" 대입
            Monster monster = new Monster();
            Monster slime = new Monster("슬라임");
            Monster orc = new Monster("오크");
            Monster dragon = new Monster("드래곤");
            Monster boss = new Monster("보스");

            player.Attack();

        }
        
        #region 클래스와 구조체 차이 예시
        static void Main0(string[] args)
        {
            ClassType classType1 = new ClassType();
            ClassType classType2 = classType1;
            classType1.value = 10;
            classType2.value = 20;
            Console.WriteLine("classType1.value : {0}", classType1.value);
            Console.WriteLine("classType2.value : {0}", classType2.value);
            structType structType1 = new structType();
            structType structType2 = structType1;
            structType1.value = 10;
            structType2.value = 20;
            Console.WriteLine("structType1.value : {0}", structType1.value);
            Console.WriteLine("structType2.value : {0}", structType2.value);
        }
        #endregion

    }
}
