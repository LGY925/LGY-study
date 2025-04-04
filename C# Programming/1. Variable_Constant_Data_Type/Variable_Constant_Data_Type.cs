﻿namespace _1.Variable_Constant_Data_Type
{
    internal class Variable_Constant_Data_Type
    {
        static void Main(string[] args)
        {

            #region 변수 (variable)

            /****************************************************************\
             * 변수 (variable)
             * 
             * 데이터를 저장하기 위해 프로그램에 의해 이름을 할당받은 메모리 공간
             * 데이터를 저장할 수있는 메모리 공간을 의미하여, 저장된 값을 변경 가능
            \****************************************************************/

            // <변수 선언 및 초기화>
            // 자료형의 선언하고 빈칸 뒤에 변수이름을 작성하여 변수 선언
            // 선언한 변수에 값을 처음 할당하는 과정을 초기화라고 함
            // 변수 선언과 초기화 과정을 동시에 진행할 수 있음
            int ivalue = 10;                    //int 자료형의 이름이 intValue인 변수에 10의 데이터를 초기화
            float fValue;                       //float 자료형의 이름이 floatValue인 변수를 선언하지만 값을 초기화하지  않음
            // int intValue;                    //error : 같은 이름의 변수는 사용 불가
            // Console.WriteLine(floatValue)    //error : 선언한 변수에 값을 초기화하기 전까지 사용 불가

            // <변수명의 규칙>
            // #1. 변수명은 유의미한 단어를 쓰자!#
            // 2. 띄어쓰기 불가능 (#카멜표기법 : 띄어쓰기 대신 단어의 시작마다 대문자로 표현을 해줌#)
            // 3. 특수문자 불가능
            // 4. 숫자부터 시작 불가능 (숫자 중간 끝에 쓰기가능)
            int attackDelayTime = 20;

            int level = 1;
            Console.WriteLine("게임 시작시 레벨은 {0}입니다.", level);
            Console.WriteLine("플레이가 전투에서 승리했습니다.");
            Console.WriteLine("레벨이 올랐습니다!!!");

            #endregion

            #region 상수 (Constant)

            /****************************************************************\
             * 상수 (Constant)
             * 
             * 프로그램이 실행되는 동안 변경할 수 없는 데이터
             * 프로그램에서 값이 변경되기를 원하지 않는 데이터가 있을 경우 사용
             * 저장된 값은 프로그램 종료시까지 변경 불가능
            \****************************************************************/

            const string gameName = "레전드 RPG";
            int maxPlayer = 8;

            // gameName = "다른 게임 이름";

            Console.WriteLine("{0} 시작!", gameName);

            #endregion

            #region 자료형 (Data Type)

            /****************************************************************\
             * 자료형 (Data Type)
             * 
             * 자료(데이터)의 형태를 지정
             * 데이터가 메모리에 저장되는 형태와 처리되는 방식을 명시하는 역할
             * 0과 1만으로 구성된 컴퓨터에게 여러 형태의 자료를 저장하기 위함
            \****************************************************************/

            // 자료형 이름   자료형 형태              메모리 크기         표현 범위
            // - 논리형 -
            // bool         논리자료형                1btye              true,false
            //
            // - 정수형 -
            // byte         부호없는 정수형            1btye           0 ~ 255
            // sbyte        부호있는 정수형            1btye           -128 ~ 127
            //
            // short        부호있는 정수형            2btye           -2^15 ~ 2^15 - 1        =>      -32,768 ~ 32,767
            // int          부호있는 정수형            4btye           -2^31 ~ 2^31 - 1        =>      -2,147,483,648 ~ 2,147,483,647
            // long         부호있는 정수형            8btye           -2^63 ~ 2^63 - 1        =>      -9,223,372,036,854,775,808 ~ 9,223,372,036,854,775,807
            //
            // ushort       부호있는 정수형            2btye           0 ~ 2^16 -1             =>      0 ~ 65,535
            // uint         부호있는 정수형            4btye           0 ~ 2^32 -1             =>      0 ~ 4,294,967,295
            // ulong        부호있는 정수형            8btye           0 ~ 2^64 -1             =>      0 ~ 18,446,744,073,709,551,615
            //
            // - 실수형 - 
            // float        부동소수점 실수            4byte           3.4e-38 ~ 3.4e+38       =>      약 소수점 7자리
            // double       부동소수점 실수            8byte           1.7e-308 ~ 1.7e+308     =>      약 소수점 15자리
            //
            // - 문자형 -
            // char         유니코드 문자형            2byte           'a', 'b', '한', ...
            // string       유니코드 문자열              X             "abcde", "안녕", ...

            // float 소수점 쓸때는 항상 f 붙이기

            #endregion

        }
    }
}
