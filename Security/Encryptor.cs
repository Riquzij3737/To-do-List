using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace To_do_List_List.Security
{
    internal class Encryptor : ICipher
    {
        public byte[] key { get; set; }
        public byte[] IV { get; set; }

        public Encryptor()
        {
            generationkey();
        }

        public void generationkey()
        {
            Encryptor encryptor = new Encryptor();
            GenerationDatasKey generationDatasKey = new GenerationDatasKey();
            generationDatasKey.generationkey();
            encryptor.key = generationDatasKey.key;
            encryptor.IV = generationDatasKey.IV;
        }

        public string Encryp(string texto)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = IV;
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
