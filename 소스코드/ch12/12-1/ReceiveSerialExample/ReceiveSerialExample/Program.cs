﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
public class ReceiveSerialExample
{
    public static void Main()
    {
        Stream strm1 = new FileStream("binary.txt", FileMode.Open, FileAccess.ReadWrite);
        Stream strm2 = new FileStream("soap.txt", FileMode.Open, FileAccess.ReadWrite);

        IFormatter formatter1 = new BinaryFormatter();
        SerialExample ex1 = (SerialExample)formatter1.Deserialize(strm1);
        Console.WriteLine("학번: ex1.id    = {0}", ex1.id);
        Console.WriteLine("이름: ex1.name  = {0}", ex1.name);
        Console.WriteLine("국어: ex1.kor   = {0}", ex1.kor);
        Console.WriteLine("수학: ex1.math  = {0}", ex1.math);
        Console.WriteLine("영어: ex1.eng   = {0}", ex1.eng);
        Console.WriteLine("입력날짜 :  {0}", ex1.date);

        IFormatter formatter2 = new SoapFormatter();
        SerialExample ex2 = (SerialExample)formatter2.Deserialize(strm2);
        Console.WriteLine("학번: ex2.id    = {0}", ex2.id);
        Console.WriteLine("이름: ex2.name  = {0}", ex2.name);
        Console.WriteLine("국어: ex2.kor   = {0}", ex2.kor);
        Console.WriteLine("수학: ex2.math  = {0}", ex2.math);
        Console.WriteLine("영어: ex2.eng   = {0}", ex2.eng);
        Console.WriteLine("입력날짜 :  {0}", ex2.date);

        strm1.Close();
        strm2.Close();
    }
}
