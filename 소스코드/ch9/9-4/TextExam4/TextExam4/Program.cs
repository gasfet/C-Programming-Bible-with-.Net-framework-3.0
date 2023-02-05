using System;
using System.Drawing;
public class TextExam4
{
    static void Main()
    {
        float ascent = 0.0f;
        float descent = 0.0f;
        float linespacing = 0.0f;
        float height = 0.0f;
        string format = "{0,-30}{1,10}{2,10},{3,10},{4,15}";

        FontFamily[] ff = FontFamily.Families;
        System.Console.WriteLine(format, "FontName", "Ascent", "Descent", "Height", "Linespacing");

        for (int i = 0; i < ff.Length; i++)
        {
            ascent = ff[i].GetCellAscent(FontStyle.Regular);
            descent = ff[i].GetCellDescent(FontStyle.Regular);
            linespacing = ff[i].GetLineSpacing(FontStyle.Regular);
            height = ff[i].GetEmHeight(FontStyle.Regular);
            System.Console.WriteLine(format, ff[i].Name, ascent, descent, height, linespacing);
        }
    }
}
