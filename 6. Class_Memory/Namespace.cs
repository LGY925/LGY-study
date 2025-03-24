using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _6.Class_Memory_Namespace.Class;

namespace _6.Class_Memory_Namespace
{
   public class Namespace
   {
        // 변수(명사) : 정보
        private int Level = 1;          //private : 외부에서 접근 불가
        private int attackPoint = 10;
        public string name;             //public : 외부에서 접근 가능

        // 함수 (동사) : 기능
        public void Attack()
        {
            Console.WriteLine("플레이어가 공격합니다.");
            Console.WriteLine("같은 namespcace 내의 다른 클래스에 접근 가능");
        }

    }
}
