using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace To_do_List_List.Security
{
    internal class Descryptor
    {
        public string DescryptText(string textCipherdBase64)
        {
            byte[] bufferCrip = Convert.FromBase64String(textCipherdBase64);

            CipherKey keys = new CipherKey();

            using (Aes aes = Aes.Create())
            {
                aes.Key = keys.key;
                aes.IV = keys.IV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream(bufferCrip))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs, Encoding.UTF8))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
