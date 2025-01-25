using System.Data;
using System.Data.SQLite;

public class GetData 
{    
    public readonly string connstring;

    public GetData(global::System.String connstring)
    {        
        this.connstring = connstring;
    }

    public async Task<List<string>> GetdataForID()
    {
        using (SQLiteConnection conn = new SQLiteConnection(this.connstring))
        {
            await conn.OpenAsync();
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT \"Nome\" FROM \"Tarefas\"";
                

                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    List<string> tasks = new List<string>();

                    foreach (IDataRecord record in reader)
                    {
                        tasks.Add(record["Nome"].ToString());
                    }

                    return tasks;
                }
            }            

        }
    }

    
}

