using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using To_do_List_List.Security;

namespace To_do_List_List.Security
{
    internal class Encryptor 
    {
        public string Encryp(string texto)
        {           
            using (Aes aes = Aes.Create())
            {
                CipherKey cipher = new CipherKey();

                aes.Key = cipher.key;
                aes.IV = cipher.IV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainTextBytes = Encoding.UTF8.GetBytes(texto);
                        cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cs.FlushFinalBlock();

                        string texto_criptografado = Convert.ToBase64String(ms.ToArray());

                        return texto_criptografado;
                    }
                }
            }
        }
    }

    
}
