using System;
using System.Runtime.InteropServices;

class AttributeExam1
{
    [DllImport("User32.dll")]
    public static extern int MessageBox(int handle, string msg, string title, int type);

    static void Main(string[] args)
    {
        MessageBox(0, "Win32 MessageBox 호출", "DllImport 사용하기", 3);
    }
}

