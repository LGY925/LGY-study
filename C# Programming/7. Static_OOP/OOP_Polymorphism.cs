namespace _7._Static_OOP
{
    internal class OOP_Polymorphism
    {

        #region 다형성의 원리
        /*****************************************************************\
         * 다형성 (Polymorphism)
         *
         * 객체의 속성이나 기능이 상황에 따라 여러가지 형태를 가질 수 있는 성질
        \*****************************************************************/

        #endregion
        
        #region 접속사의 의미

        //virtual : 자식클래스에서 재정의 가능한 함수를 지정
        //override : 부모클래스의 가상함수를 재정의하여 자식클래스의 다른 반응을 구현

        #endregion

        #region 다형성 예시
        // <다형성>
        // 부모클래스의 멤버를 자식클래스가 상황에 따라 여러가지 형태를 가질 수 있는 성질
        class Car
        {
            protected string name;
            protected int speed;

            public void Move()
            {
                Console.WriteLine($"{name} 이/가 {speed} 의 속도로 이동합니다.");
            }
        }

        class Truck : Car
        {
            public Truck()
            {
                name = "트럭";
                speed = 30;
            }
        }

        class SportCar : Car
        {
            public SportCar()
            {
                name = "스포츠카";
                speed = 100;
            }
        }
        #endregion

        #region 오버라이딩

        // <가상함수와 오버라이딩>
        // 가상함수   : 부모클래스의 함수 중 자식클래스에 의해 재정의 할 수 있는 함수를 지정
        // 오버라이딩 : 부모 클래스의 가상함수를 같은 함수이름과 같은 매개변수로 재정의하여 자식만의 반응을 구현(재정의)
        public class Skill
        {
            public string name;
            public float coolTime;

            public virtual void Execute()
            {
                Console.WriteLine("{0} 스킬을 사용합니다", name);
                Console.WriteLine("{0} 쿨타임이 진행합니다", coolTime);
            }
        }

        public class FireBall : Skill
        {
            public FireBall()
            {
                name = "파이어볼";
                coolTime = 1.5f;
            }

            public void Execute()
            {
                Console.WriteLine("화염구 발사!!");
            }
        }

        public class Smash : Skill
        {
            public Smash()
            {
                name = "강타";
                coolTime = 1.0f;
            }

            public override void Execute()
            {
                base.Execute(); // 부모에 있는 함수 가져오기
                Console.WriteLine("전방에 강력한 타격");
            }
        }
        #endregion

        static void Main4(string[] args)
        {
            //다형성
            Car car1 = new Truck();
            Car car2 = new SportCar();

            car1.Move();    // 트럭 이/가 30 의 속도로 이동합니다.
            car2.Move();    // 스포츠카 이/가 100 의 속도로 이동합니다.
            // 오버라이딩
            Skill skill = new FireBall();
            Skill skill1 = new Smash();
            skill.Execute();
            skill1.Execute();
        }

        #region 다형성 사용의미
        // <다형성 사용의미 1>
        // 새로운 클래스를 추가하거나 확장할 때 기존 코드에 영향을 최소화함
        // 새로운 클래스를 만들 때 기존의 소스를 수정하지 않아도 됨
        class Player
        {
            Skill skill;

            public void SetSkill(Skill skill)
            {
                this.skill = skill;
            }

            public void UseSkill()
            {
                skill.Execute();    // skill 클래스의 다형성을 확보한 결과 진행
            }
        }


        // <다형성 사용의미 2>
        // 클래스 간의 의존성을 줄여 확장성은 높임
        class SkillContents : Skill
        {
            public override void Execute()
            {
                base.Execute();
                // 프로그램의 확장을 위해 상위클래스를 상속하는 클래스를 개발
            }
        }
        #endregion
    }
}
