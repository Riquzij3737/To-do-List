using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List_List.Security
{
    internal class Descryptor : ICipher
    {
        byte[] ICipher.IV {  get; set; }
        byte[] ICipher.key { get; set; }

        public Descryptor()
        {
            ICipher cipher = new Encryptor();

            cipher.generationkey();
        }

        public string DescryptText(byte[] textCipherd)
        {
            ICipher cipher = new Descryptor();

            using (Aes aes = Aes.Create())
            {
                aes.IV = cipher.IV;
                aes.Key = cipher.key;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.None;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        ms.Write(textCipherd, 0, textCipherd.Length);

                        string textodescriptografado = Convert.ToBase64String(ms.ToArray());

                        return textodescriptografado;
                    }

                }
            }
        }

    }
}
