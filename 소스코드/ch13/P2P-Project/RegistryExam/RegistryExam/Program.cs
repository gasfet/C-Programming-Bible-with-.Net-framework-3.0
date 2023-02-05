using System;
using Microsoft.Win32;  // 레지스트리를 사용하기 위해 포함한 네임스페이스

namespace RegistryExam
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            string strReg = "Software\\MagicSoft\\RegEXAM";

            /// 레지스트리에 값 저장하기			
            RegistryKey reg = Registry.CurrentUser;
            reg = reg.OpenSubKey(strReg, true);  // 쓰기 설정을 위해 true로 설정
            //RegistryKey reg = Registry.CurrentUser.OpenSubKey(strReg, true);

            if (reg == null)  // 만약 읽어올 레지스트리 정보가 없다면
            {  // 레지스트리를 새롭게 만듬
                reg = Registry.CurrentUser.CreateSubKey(strReg);
            }

            reg.SetValue("id", "magic");                 // 레지스트리에 id 값 저장
            reg.SetValue("datetime", DateTime.Now);    // 레지스트리에 datetime 값 저장
            reg.SetValue("email", "magicsoft@empal.com"); // 레지스트리에 email 값 저장

            reg.Close();  // 레지스트리 닫기

            /// 레지스트리 값 읽어오기
            reg = Registry.CurrentUser.OpenSubKey(strReg);  // 읽기 전용

            // 값을 읽어올 때 object 형태이므로 Convert 클래스를 이용해 형 변환 필요
            string id = Convert.ToString(reg.GetValue("id"));
            DateTime datetime = Convert.ToDateTime(reg.GetValue("datetime"));
            string email = Convert.ToString(reg.GetValue("email"));

            reg.Close();

            Console.WriteLine("아이디:{0}, 저장날짜:{1}, 메일주소:{2}", id, datetime, email);
        }
    }
}
