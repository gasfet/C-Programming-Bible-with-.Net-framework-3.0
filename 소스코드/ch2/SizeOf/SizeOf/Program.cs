using System;
class SizeOf
{
    static void Main()
    {
        Console.WriteLine("bool    자료형 크기: {0}byte", sizeof(bool));
        Console.WriteLine("char    자료형 크기: {0}byte", sizeof(char));
        Console.WriteLine("sbyte   자료형 크기: {0}byte", sizeof(sbyte));
        Console.WriteLine("byte    자료형 크기: {0}byte", sizeof(byte));
        Console.WriteLine("short   자료형 크기: {0}byte", sizeof(short));
        Console.WriteLine("ushort  자료형 크기: {0}byte", sizeof(ushort));
        Console.WriteLine("int     자료형 크기: {0}byte", sizeof(int));
        Console.WriteLine("uint    자료형 크기: {0}byte", sizeof(uint));
        Console.WriteLine("long    자료형 크기: {0}byte", sizeof(long));
        Console.WriteLine("ulong   자료형 크기: {0}byte", sizeof(ulong));
        Console.WriteLine("float   자료형 크기: {0}byte", sizeof(float));
        Console.WriteLine("double  자료형 크기: {0}byte", sizeof(double));
        Console.WriteLine("decimal 자료형 크기: {0}byte", sizeof(decimal));
    }
}