using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace To_do_List_List.Security
{
    internal class Encryptor : ICipher
    {
        byte[] ICipher.key { get; set; }
        byte[] ICipher.IV { get; set; }

        public Encryptor()
        {
            ICipher cipher = new Encryptor();

            cipher.generationkey();
        }

        public byte[] Encryp(string texto)
        {           
            ICipher cipher = new Encryptor();

            using (Aes aes = Aes.Create())
            {
                aes.Key = cipher.key;
                aes.IV = cipher.IV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.None;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        ms.Write(cipher.key, 0, texto.Length);

                        return ms.ToArray();
                    }

                }
            }
        }
    }
}
