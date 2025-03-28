﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._Static_OOP
{
    class OOP_Abstraction
    {
        #region 추상화의 정의

        /*****************************************************************\
         * 추상화 (Abstraction)
         *
         * 클래스를 정의할 당시 구체화 시킬 수 없는 기능을 추상적 표현으로 정의
        \*****************************************************************/

        #endregion

        #region 접속사의 의미

        // abstract : 추상클래스를 정의할 때 사용

        #endregion

        #region 추상화 예시

        // <추상클래스 (abstract class)>
        // 하나 이상의 추상함수를 포함하는 클래스
        // 클래스가 추상적인 표현을 정의하는 경우 자식에서 구체화시켜 구현할 것을 염두하고 추상화 시킴
        // 추상클래스에서 내용을 구체화 할 수 없는 추상함수는 내용을 정의하지 않음
        // 추상클래스를 상속하는 자식클래스가 추상함수를 재정의하여 구체화한 경우 사용가능
        public abstract class Item
        {
            public abstract void Use();
       
        }
        // 추상클래스는 종속클래스는 꼭 만들어줘야함
        public class Potion : Item
        {
            public override void Use() 
            {
                Console.WriteLine("포션을 사용하여 체력을 회복합니다.");
            }
            
        }
        public class Herb : Item
        {
            public override void Use()
            {
                Console.WriteLine("해독초를 사용하며 독을 해제합니다");
            }
        }
        #endregion

        static void main1(string[] args)
        {
                // Item item = new Item(); 불가능
                Item hurb = new Herb();
                Item potion = new Potion();

        }

        #region 추상화 사용의미

        // <추상화 사용의미 1>
        // 객체들의 공통적인 특징을 도출하는데 의미
        // 구현을 구체화하기 어려운 상위클래스를 설계하기 위한 수단으로 사용
        abstract class Animal
        {
            public abstract void Cry();     // 상위클래스에서 구현하기 어려운 기능
        }

        class Cat : Animal
        {
            public override void Cry()
            {
                Console.WriteLine("야옹");   // 자식클래스에서 구체화
            }
        }

        class Dog : Animal
        {
            public override void Cry()
            {
                Console.WriteLine("멍멍");    // 자식클래스에서 구체화
            }
        }


        // <추상화 사용의미 2>
        // 상위클래스의 인터페이스를 구현하기 위한 수단으로 사용
        // 추상적인 기능을 구체화시키지 않은 경우 인스턴스 생성이 불가
        // 이를 통해 자식클래스에게 순수가상함수의 구현을 강제하여 실수를 줄임
        class Bird : Animal
        {
            public override void Cry() { }      // 구현하지 않을 경우 오류
        }

        #endregion
    }
}

