using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Security.Cryptography;


/*
 * 本ソースは DOBON.NET 殿のテクニックを借用させていただきました
 * http://dobon.net/vb/dotnet/string/encryptstring.html
 * http://dobon.net/vb/dotnet/string/md5.html
 */


namespace NekoChat
{
    class CryptString
    {
        // 暗号化
        public static string EncryptString(string str, string key)
        {
            byte[] bytesIn = Encoding.UTF8.GetBytes(str);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] bytesKey = Encoding.UTF8.GetBytes(key);
            des.Key = ResizeBytesArray(bytesKey, des.Key.Length);
            des.IV = ResizeBytesArray(bytesKey, des.IV.Length);
            MemoryStream msOut = new MemoryStream();
            ICryptoTransform desencrypt = des.CreateEncryptor();
            CryptoStream cryptStreem = new CryptoStream(msOut, desencrypt, CryptoStreamMode.Write);
            cryptStreem.Write(bytesIn, 0, bytesIn.Length);
            cryptStreem.FlushFinalBlock();
            byte[] bytesOut = msOut.ToArray();
            cryptStreem.Close();
            msOut.Close();
            return System.Convert.ToBase64String(bytesOut);
        }

        // 復号化
        public static string DecryptString(string str, string key)
        {
            string result = "";

            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    byte[] bytesKey = Encoding.UTF8.GetBytes(key);
                    des.Key = ResizeBytesArray(bytesKey, des.Key.Length);
                    des.IV = ResizeBytesArray(bytesKey, des.IV.Length);
                    byte[] bytesIn = System.Convert.FromBase64String(str);
                    using (MemoryStream msIn = new MemoryStream(bytesIn))
                    {
                        ICryptoTransform desdecrypt = des.CreateDecryptor();
                        using (CryptoStream cryptStreem = new CryptoStream(msIn, desdecrypt, CryptoStreamMode.Read))
                        {
                            using (StreamReader srOut = new StreamReader(cryptStreem, System.Text.Encoding.UTF8))
                            {
                                result = srOut.ReadToEnd();

                                srOut.Close();
                                cryptStreem.Close();
                                msIn.Close();
                            }
                        }
                    }
                }
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                result = "";
            }

            return result;
        }
        
        // バイト配列のリサイズ
        private static byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            byte[] newBytes = new byte[newSize];
            if (bytes.Length <= newSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    newBytes[i] = bytes[i];
                }
            }
            else
            {
                // はみだし分はXORで折り返す
                int pos = 0;
                for (int i = 0; i < bytes.Length; i++)
                {
                    newBytes[pos++] ^= bytes[i];
                    if (pos >= newBytes.Length)
                        pos = 0;
                }
            }
            return newBytes;
        }
        
        
        // 文字列のハッシュ化
        public static string MakeMd5String(string s)
        {
            byte[] data = Encoding.ASCII.GetBytes(s);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bs = md5.ComputeHash(data);
            StringBuilder result = new StringBuilder();
            foreach (byte b in bs)
            {
                result.Append(b.ToString("x2"));
            }
            return result.ToString();
        }
    }
}

