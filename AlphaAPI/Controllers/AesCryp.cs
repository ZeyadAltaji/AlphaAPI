using System;
using System.Security.Cryptography;
using System.Text;

namespace AlphaAPI.Controllers
{
    class AESCryp
    {
        public static string IV = "dhtPDj&194#0nSI3";
        public static string Key = "";
        public static string Encrypt(string decrypted)
        {
            byte[] textbytes = UTF8Encoding.ASCII.GetBytes(decrypted);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            encdec.Key = UTF8Encoding.ASCII.GetBytes(Key);
            encdec.IV = UTF8Encoding.ASCII.GetBytes(IV);
            encdec.Padding = PaddingMode.PKCS7;
            encdec.Mode = CipherMode.CBC;
            ICryptoTransform icrypt = encdec.CreateEncryptor(encdec.Key, encdec.IV);
            byte[] enc = icrypt.TransformFinalBlock(textbytes, 0, textbytes.Length);
            icrypt.Dispose();
            return Convert.ToBase64String(enc);
        }

        public static string Decrypt(string encrypted)
        {
            byte[] encbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            encdec.Key = UTF8Encoding.ASCII.GetBytes(Key);
            encdec.IV = UTF8Encoding.ASCII.GetBytes(IV);
            encdec.Padding = PaddingMode.PKCS7;
            encdec.Mode = CipherMode.CBC;
            ICryptoTransform icrypt = encdec.CreateDecryptor(encdec.Key, encdec.IV);
            byte[] dec = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();
            return UTF8Encoding.ASCII.GetString(dec);
        }
    }
}