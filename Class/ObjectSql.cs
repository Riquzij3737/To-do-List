using System.Security.Cryptography;

namespace To_do_List_List;

public class MySqlObject
{
    public string? Host { get; set; }
    public string? Port { get; set; }
    public string? User { get; set; }
    public string? Password { get; set; }
    public CryptoConfig cryptoConfig { get; set; }

    public MySqlObject()
    {
        cryptoConfig = new CryptoConfig();
    }
}

public class CriptConfig
{
    public string? PadingMode { get; set; }
    public string? CipherMode {  get; set; }
    public int KeySize { get; set; }
    public int IvSize { get; set; }
}