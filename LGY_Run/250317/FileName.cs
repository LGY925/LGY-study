using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250317
{
    class FileName
    {
        #region 열거형
        /********************************************************************
        * 열거형 (Enum)
        * 
        * 기본 정수 숫자의 형식의 명명된 상수 집합에 의해 정의되는 값 형식
        * 열거형 멤버의 이름으로 관리되어 코드의 가독성적인 측면에 도움이 됨
        ********************************************************************/
        enum RockPaperScissor
        {
            Rock = 1,
            Scissor,
            Paper,
           
        }
        enum Equipment
        {
            Head, Body, Foot, Arm, Size
        }
        #endregion
        #region 구조체
        /**************************************************
        * 구조체 (Struct)
        * 
        * 데이터와 관련 기능을 캡슐화할 수 있는 값 형식
        * 데이터를 저장하기 보관하기 위한 단위용도로 사용
        **************************************************/
        struct Skill
        {
            public string name;
            public float cooltime;
            public int cost;
            public float range;
            
        }

        enum Type { Normal,Elite,Boss}
        
        struct Monster
        {
            public string Name;
            public int attack;
            public int defens;
            public float speed;
            public string[] items;
            public Type Type;
            public string area;
        }

        #endregion


        static void Main(string[] args)
        {

            RockPaperScissor commend = RockPaperScissor.Rock;
            Console.WriteLine("묵찌빠!!!");
            Console.WriteLine("1. 묵, 2. 찌, 3. 빠");
            string input = Console.ReadLine();
            Enum.TryParse(input, out commend);


            switch (commend)
            {
                case RockPaperScissor.Rock:
                    Console.WriteLine("바위를 냅니다");
                    break;
                case RockPaperScissor.Paper:
                    Console.WriteLine("보를 냅니다");
                    break;
                case RockPaperScissor.Scissor:
                    Console.WriteLine("가위를 냅니다");
                    break;
                default:
                    Console.WriteLine("질못 냈습니다");
                    break;
            }
            // 장비 유형에 따라 여러 장비를 저장하는 배열을 만든다
            string[] equipments = new string[(int)Equipment.Size];

            // 머리부분을 사용하고 싶다면
            // 머리 : 0 번에 해당하는 공간에 저장&불러오기 할 필요가 있음
            // 여기서 0 번으로 쓰는 경우 햇갈릴 수 있지만
            // (int)로 형변환을 이용한다면 머리라는 이름으로 명확하며 실수하지 않게 사용이 가능
            // 또한 0부터 시작한다는 열거형의 특징상 배열의 0 ~ 장비유형 갯수 만큼 사용도 가능
            equipments[(int)Equipment.Body] = "철갑옷";

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("                 ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("                 ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("                 ");
            Console.ResetColor();

            Console.ReadKey();

            Skill[] skills = new Skill[4];

            Skill fireball;
            fireball.name = "파이어볼";
            fireball.cooltime = 2.5f;
            fireball.cost = 10;
            fireball.range = 3.5f;

            Skill smash;
            smash.name = "강타";
            smash.cooltime = 10f;
            smash.cost = 15;
            smash.range = 4.5f;

            Skill lance;
            lance.name = "창던지기";
            lance.cooltime = 1f;
            lance.cost = 0;
            lance.range = 1f;

            Skill ultimate;
            ultimate.name = "궁극기";
            ultimate.cooltime = 180f;
            ultimate.cost = 200;
            ultimate.range = 20f;

            skills[0]= fireball;
            skills[1]= smash;
            skills[2]= lance;
            skills[3]= ultimate;

            while (true)
            {
                Console.Write("사용할 스킬 :");
                string input0 = Console.ReadLine();
                int value = int.Parse(input0);

            }    






            Monster oak;
            oak.Name = "오크";
            oak.attack = 10;
            oak.defens = 5;
            oak.speed = 2.5f;
            oak.items = ["참나무방패", "무딘대검"];
            oak.Type = Type.Normal;
            oak.area = "숲";





        }
    }
}
