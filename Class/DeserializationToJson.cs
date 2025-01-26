using Newtonsoft.Json;
using System;
using System.IO;

namespace To_do_List_List
{
    public class MakeMysqlKey
    {
        public string PathJson = ".\\Config\\settings.json";

        public MySqlObject Deserialization()
        {
            try
            {
                string json = File.ReadAllText(PathJson);

                MySqlObject obj = JsonConvert.DeserializeObject<MySqlObject>(json);

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Error during deserialization: " + ex.Message);
            }
        }

        public static string MakeKey()
        {
            var obj = new MakeMysqlKey();
            var obj2 = obj.Deserialization(); // Sem necessidade de conversão explícita

            string key = $"Server={obj2.Host};Port={obj2.Port};Database=To_do_List;Uid={obj2.User};Pwd={obj2.Password};";

            return key;
        }
    }
}
