using Newtonsoft.Json;
using System;
using To_do_List_List;
using System.IO;

namespace To_do_List_List;

public class MakeMysqllKey
{
    public readonly string PathJson = ".\\Config\\settings.json";

    public object Desearilation()
    {
        try
        {
            string json = File.ReadAllText(PathJson);
            
            MySqlObject obj = JsonConvert.DeserializeObject<MySqlObject>(json);

            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static string MakeKey()
    {
        var obj = new MakeMysqllKey();
        var obj2 = (MySqlObject)obj.Desearilation();

        string key = $"Server={obj2.Host};Port={obj2.Port};Database=To_do_List;Uid={obj2.User};Pwd={obj2.Password};";

        return key;
    }

}