using System;
using System.IO;
using System.Security.Cryptography;
class StreamExam5
{        // 암호화 대상 파일 : infile,    암호화 결과 저장 파일 : outfile
    // 암호화 키(DES 알고리즘은 8byte) : desKey, 암호화 벡터(8byte) : desIV    
    private static void EncryptData(string infile, string outfile, byte[] desKey, byte[] desIV)
    {   	// 입출력 파일 스트림 생성
        FileStream fin = new FileStream(infile, FileMode.Open, FileAccess.Read);
        FileStream fout = new FileStream(outfile, FileMode.OpenOrCreate, FileAccess.Write);
        fout.SetLength(0);    // 출력 파일의 크기를 0으로 조정

        byte[] data = new byte[100];   // 한번에 100 바이트씩 읽기/쓰기
        long readlen = 0;                // 암호화시킬 파일을 읽어들인 크기
        long totallen = fin.Length;
        int len = 0;
        // DES 암호화 알고리즘 호출
        DES des = new DESCryptoServiceProvider();
        // 암호화 스트림 개체 생성
        CryptoStream stream = new CryptoStream(fout,
                                des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);

        Console.WriteLine("DES Encrypting...");  // 암호화 시작 메시지 출력...

        while (readlen < totallen)
        {
            len = fin.Read(data, 0, 100);  // infile에서 100바이트씩 읽어
            stream.Write(data, 0, len);    // 암호화 실행
            readlen = readlen + len;
            Console.WriteLine("{0} bytes 처리", readlen);
        }

        stream.Close();                         // 암호화 스트림 닫기
        fout.Close();                            // 출력파일(outfile) 닫기
        fin.Close();                             // 입력파일(infile) 닫기 
    }

    // 암호화 대상 파일 : infile,    암호화 결과 저장 파일 : outfile
    // 암호화 키(DES 알고리즘은 8byte) : desKey, 암호화 벡터(8byte) : desIV    
    private static void DecryptData(string infile, string outfile, byte[] desKey, byte[] desIV)
    {   	// 입출력 파일 스트림 생성
        FileStream fin = new FileStream(infile, FileMode.Open, FileAccess.Read);
        FileStream fout = new FileStream(outfile, FileMode.OpenOrCreate, FileAccess.Write);
        fout.SetLength(0);       // 출력 파일 크기 0으로 설정

        byte[] data = new byte[100];  // 100바이트씩 읽어서 복호화
        long readlen = 0;
        long totallen = fin.Length;
        int len = 0;
        // 복호화 개체 생성 (복호화는 CryptoStream 생성자의 
        // 두 번째 인자로 des.CreateDescrptyor() 메서드를 호출하면 됨
        DES des = new DESCryptoServiceProvider();
        CryptoStream stream = new CryptoStream(fout, des.CreateDecryptor(desKey, desIV),
                                                               CryptoStreamMode.Write);

        Console.WriteLine("DES Decrypting...");    // 복호화 처리 시작 메시지 출력

        while (readlen < totallen)
        {
            len = fin.Read(data, 0, 100);
            stream.Write(data, 0, len);
            readlen = readlen + len;
            Console.WriteLine("{0} bytes 처리", readlen);
        }
        stream.Close();
        fout.Close();
        fin.Close();
    }


    static void Main(string[] args)
    {
        byte[] Key = { 1, 2, 3, 4, 5, 6, 7, 8 };         // DES 암호화 키 설정(8byte)
        byte[] IV = { 20, 21, 10, 5, 7, 9, 10, 5 };     // DES 벡터 키 설정(8byte)
        // 암호화 처리를 위해 100개 아스키 문자가 포함된 Normal.txt 파일 생성
        FileStream fs = new FileStream("Normal.txt", FileMode.OpenOrCreate,
                                                     FileAccess.ReadWrite);
        for (int i = 25; i < 125; i++)
        {
            fs.WriteByte((byte)i);
        }
        fs.Close();

        // Normal.txt 파일을 Crypto.txt로 암호화 처리
        EncryptData("Normal.txt", "Crypto.txt", Key, IV);
        // 암호화된 Crypto.txt 파일을 복호화해 Decrypto.txt 파일로 출력
        DecryptData("Crypto.txt", "Decrypto.txt", Key, IV);
    }

}
