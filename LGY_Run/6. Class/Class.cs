namespace _250324
{
    internal class Class
    {

        #region 클래스
        /*********************************************************
            * 클래스 (class) 
            * 
            * 데이터와 관련 기능을 캡슐화할 수 있는 참조 형식
            * 객체지향 프로그래밍에 객체를 만들기 위한 설계도
            * 클래스는 객체를 만들기 위한 설계도 이며 만들어진 객체는 인스턴스라고 한다.
            * 참조 : 원본을 가리키고 있음 == 원본의 주소를 가지고 있음
            *********************************************************/


        class Player
        {
            // 변수(명사) : 정보
            private int Level=1;
            public int attackPoint=10;
            // 함수(동사) : 행동
            public void Attack(Monster monster)
            {
                Console.WriteLine("플레이어가 공격합니다.");
                monster.TakeHit(attackPoint);
            }

        }
       

        class Monster
        {
            private int hp=20;
        
            
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
            #endregion
        }
        static void Main(string[] args)
        {
            
            Player player = new Player();
            Monster monster = new Monster();
            
            player.Attack(monster);     //player가 monster를 공격
            player.Attack(monster);

        }
    }
}
