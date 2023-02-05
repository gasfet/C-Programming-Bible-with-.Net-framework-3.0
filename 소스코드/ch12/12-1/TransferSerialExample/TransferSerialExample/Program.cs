﻿using System;
using System.IO;
using System.Runtime.Serialization;                    // 직렬화 처리
using System.Runtime.Serialization.Formatters.Binary;  // BinaryFormatter 클래스 
using System.Runtime.Serialization.Formatters.Soap;   // SoapFormatter 클래스 
public class TransferSerialExample
{
    public static void Main()
    {
        SerialExample ex1 = new SerialExample();  // 직렬화 인스턴스 생성
        SerialExample ex2 = new SerialExample();  // 직렬화 인스턴스 생성

        ex1.id = 1;
        ex1.name = "홍길동";
        ex1.kor = 80;
        ex1.math = 50;
        ex1.eng = 100;

        ex2.id = 2;
        ex1.name = "최재규";
        ex1.kor = 100;
        ex1.math = 85;
        ex1.eng = 90;

        // 파일 스트림 생성
        Stream strm1 = new FileStream("binary.txt", FileMode.Create, FileAccess.ReadWrite);
        Stream strm2 = new FileStream("soap.txt", FileMode.Create, FileAccess.ReadWrite);

        IFormatter formatter = new BinaryFormatter();  // 바이너리 형태의 직렬화 처리
        formatter.Serialize(strm1, ex1);                  // 직렬화 인스턴스를 파일에 저장

        formatter = new SoapFormatter();     // XML 형태의 직렬화 클래스 생성
        formatter.Serialize(strm2, ex2);        // 직렬화 인스턴스를 파일에 저장

        strm1.Close();                         // 스트림 객체 닫기
        strm2.Close();
    }
}
