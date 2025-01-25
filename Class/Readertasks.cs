using To_do_List_List;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class ReaderTasksMethods 
{   
    // Método para ler os dados e adicioná-los ao painel
    public static async void ReadToPanel(Panel panelTarefas, string connectionString)
    {
        GetData data = new GetData(connectionString);

        List<string> tasks = await data.GetdataForID();

        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            foreach (string task in tasks)
            {                                
                    addList add = new addList(panelTarefas);

                    await add.Addtask(task, connectionString);  // Adiciona cada tarefa ao painel                
            }
        }
    }
}
