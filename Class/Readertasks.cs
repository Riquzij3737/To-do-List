// Importo os namespaces nescessários

using To_do_List_List;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

// adiciona a classe a seguir dentro do namespace padrão da aplicação
namespace To_do_List_List;

// Crio a classe para conter o metodo ReadToPanel
public class ReaderTasksMethods 
{   
    // Método para ler os dados e adicioná-los ao painel
    public static async void ReadToPanel(Panel panelTarefas, string connectionString)
    {
        // Instancio a classe GetData, passando a string de conexão
        GetData data = new GetData(connectionString);

        // Chamo o método GetdataForID, que retorna um dicionário com as tarefas e suas conclusões
        Dictionary<string,string> tasks = await data.GetdataForID();

        // Abro a conexão com o banco de dados
        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            conn.Open();

            // Para cada tarefa no dicionário
            foreach (var task in tasks)
            {                                

                    // Instancio a classe addList                    
                    addList add = new addList(panelTarefas);

                    await add.Addtask(task.Key, task.Value, connectionString);  // Adiciono ao painel                
            }
        }
    }
}
