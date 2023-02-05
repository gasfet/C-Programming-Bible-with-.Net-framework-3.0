using System;
using System.Drawing;
using System.Drawing.Text;
class FontFamilyExam
{
    static void Main(string[] args)
    {
        InstalledFontCollection installfont = new InstalledFontCollection();
        FontFamily [] ff = installfont.Families;
        for (int i = 0; i < ff.Length; i++)
        {
            System.Console.WriteLine("FontName-[{0}] : {1}", i, ff[i].Name);
        }
    }
}
