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
                Console.WriteLine("Erro ao deserializar o arquivo Json", ex);
                return null;
            }
        }

        public static string MakeKey()
        {
            var obj = new MakeMysqlKey();
            MySqlObject obj2 = obj.Deserialization(); // Sem necessidade de conversão explícita

            string key = $"Server={obj2.Host};Port={obj2.Port};Database=tasks_db;Uid={obj2.User};Pwd={obj2.Password};";

            return key;
        }
    }
}
