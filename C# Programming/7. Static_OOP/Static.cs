using System.Diagnostics.Contracts;

namespace _7._Static_OOP
{
    internal class Static
    {

        class Player
        {
            public void Attack()
            {
                
                Console.WriteLine("{0} 크기로 사운드 이펙트 재생!",Util.volum);
            }
            public void InventorySwap(int left, int right)
            {
                Util.Swap (ref left, ref right);
            }
        }

        class Monster
        {
            public static int totalCount = 0;
            public static int hp = 100;

            public Monster()
            {
                totalCount++;
            }
            public void TakeDamage(int damage)
            {
                Console.WriteLine("몬스터가 데미지를 받았습니다.");
                hp -= damage;
                Console.WriteLine("몬스터의 체력은 {0}", hp);
                Console.WriteLine("{0} 크기로 피격음 재생", Util.volum);
            }
            public void weapinSwap(int left, int right)
            {
                Util.Swap(ref left, ref right);
            }
            public void Die()
            {
                
                totalCount--;
            }
        }

        static void Main0(string[] args)
        {
            Console.WriteLine("현재 시스템 볼륨은 {0} 입니다", Util.volum);
            Player player = new Player();

            player.Attack();

            Monster monster = new Monster();

            monster.TakeDamage(20);         // hp 는 공통이여서 같은 수가 깎임

            Monster monster0 = new Monster();
            Console.WriteLine("현재 게임에서 있는 몬스터수 {0}마리",Monster.totalCount);
            monster0.TakeDamage(10);
            monster.Die();
            Console.WriteLine("현재 게임에서 있는 몬스터수 {0}마리", Monster.totalCount);

        }
    }
    #region 정적 키워드

    /*****************************************************************\
     * 정적 키워드(Static)
     * 
     * 프로그램이 종료될 때 까지 할당 해제되지 않고 고정된 영역의 메모리의 공간을 할당할때 사용
     * 단순 변수의 개념부터 클래스와 같은 참조 타입까지 선언이 가능하다.
     * 메서드에 붙인다면 프로그램 내에서 간편하게 호출할 수 있는 정적 메서드로도 활용할 수 있어 편리함
    \*****************************************************************/

    // 주의사항
    // 메모리 상주로 인해 메모리 낭비가 발생할 수 있음 (1회성 데이터는 안쓰는게 좋음)
    // 정적 객체 생성 시점이 프로그램 시작 시점이기 때문에 다른 객체에 의존성이 발생할 수 있음

    // static 변수 : 고정적인 위치에서 프로그램 시작부터 끝까지 남아있는 메모리
    // 1. 프로그램 시작부터 끝까지 유지되야 하는 데이터
    // 2. 어디든 가져갈수있다.(전역적인 접근이 가능하다)

    // 시스템 설정 : 볼륨 , 화면 해상도, 시간 등

    // static 함수 : 전역적으로 사용이 가능한 함수
    // 1. 지역변수는 사용불가

    // static 클래스 : 모든 지역 변수와 지역 함수가 static 클래스
    // 1. 정적 인스턴스는 사용하지못한다

    #endregion
    #region 정적 키워드 예시

    static class Util
    {
        public static int volum = 70;
        public static void Swap(ref int left, ref int right)
        {
            int temp = left;    // temp = 1회용 변수
            left = right;   // 지역변수로 사용하는게 좋음
            right = temp;
        }

    }
    #endregion
}

