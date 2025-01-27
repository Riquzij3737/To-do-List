using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace To_do_List_List.Security
{
    internal class Descryptor : ICipher
    {
        public byte[] key { get; set; }
        public byte[] IV { get; set; }

        public Descryptor()
        {
            generationkey();
        }

        public void generationkey()
        {
            using (Aes aes = Aes.Create())
            {
                key = aes.Key;
                IV = aes.IV;
            }
        }

        public string DescryptText(byte[] textCipherd)
        {
            using (Aes aes = Aes.Create())
            {
                aes.IV = IV;
                aes.Key = key;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(textCipherd, 0, textCipherd.Length);
                        cs.FlushFinalBlock();

                        string textodescriptografado = Encoding.UTF8.GetString(ms.ToArray());
                        return textodescriptografado;
                    }
                }
            }
        }
    }
   
}
