using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._Delegate
{
    internal class Delegate_Callback
    {
        /****************************************************************\
         * 콜백 함수(Callback Function)
         * 
         * 델리게이트를 이용하여 특정조건에서 반응하는 함수를 구현
         * 함수의 호출(Call)이 아닌 역으로 호출받을때 반응을 참조하여 역호출(Callback)
        \****************************************************************/

        public class File
        {

            public void Save()
            {
                Console.WriteLine("저장하기 합니다.");
            }
            public void Load()
            {
                Console.WriteLine("불러오기 합니다.");
            }
        }
        public class Button
        {

            public delegate void ClickListener();
            public ClickListener clickListener;

            public void Click()
            {
                if (clickListener != null)
                {
                    Console.WriteLine("버튼이 눌립니다");
                    clickListener(); 
                }
                
            }

        }

        static void Main1(string[] args)
        {
            File file = new File();

            Button saveButton = new Button();
            saveButton.clickListener = file.Save;

            Button loadButton = new Button();
            loadButton.clickListener = file.Load;

            saveButton.Click();     // 저장하기
            loadButton.Click();     // 불러오기
        }
    }
}
