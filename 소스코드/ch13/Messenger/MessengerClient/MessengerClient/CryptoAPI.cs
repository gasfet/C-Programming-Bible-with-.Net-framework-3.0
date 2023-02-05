using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace MessengerClient
{
    /// <summary>
    /// 암호화 클래스
    /// </summary>
    public class CryptoAPI
    {
        private string KEY = "kr-magicsoft2004";
        private string IV = "youngjin.com2004";

        byte[] key;
        byte[] iv;

        public CryptoAPI()
        {
            this.key = Encoding.Default.GetBytes(this.KEY);
            this.iv = Encoding.Default.GetBytes(this.IV);
        }

        public CryptoAPI(string KEY, string IV)
        {
            this.key = Encoding.Default.GetBytes(KEY.Trim());
            this.iv = Encoding.Default.GetBytes(IV.Trim());
        }

        public byte[] Encryptor(string data)
        {
            byte[] buffer = Encoding.Default.GetBytes(data);
            MemoryStream mem = new MemoryStream();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            CryptoStream csw = new CryptoStream(mem, tdes.CreateEncryptor(this.key, this.iv), CryptoStreamMode.Write);

            csw.Write(buffer, 0, buffer.Length);
            csw.FlushFinalBlock();

            csw.Close();
            mem.Close();

            return mem.ToArray();
        }

        public string Decryptor(byte[] cryptdata)
        {
            MemoryStream mem = new MemoryStream(cryptdata);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            CryptoStream csr = new CryptoStream(mem, tdes.CreateDecryptor(this.key, this.iv), CryptoStreamMode.Read);

            byte[] temp = new byte[cryptdata.Length];
            int recv = csr.Read(temp, 0, temp.Length);
            string data = Encoding.Default.GetString(temp, 0, recv);

            csr.Close();
            mem.Close();

            return data;
        }

    }
}
