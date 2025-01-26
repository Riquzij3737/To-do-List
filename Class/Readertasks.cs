// Importo os namespaces nescessários

using To_do_List_List;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using To_do_List_List.GUI;

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
        Dictionary<string,Dictionary<string, string>> tasks = await data.GetdataForID();

        // Abro a conexão com o banco de dados
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();

            // Para cada tarefa no dicionário
            foreach (var task in tasks)
            {                                

                    // Instancio a classe addList                    
                    addList add = new addList(panelTarefas);

                    switch (task.Value.Values.ToString())
                    {
                        case "Nulo":
                            await add.Addtask(task.Key, task.Value.Keys.ToString(), Categoria.Nulo, connectionString);
                            break;
                        
                        case "Relativa":
                            await add.Addtask(task.Key, task.Value.Keys.ToString(), Categoria.Relativa, connectionString);
                            break;

                        case "Importante":
                            await add.Addtask(task.Key, task.Value.Keys.ToString(), Categoria.Importante, connectionString);
                            break;

                        case "Muito Importante":
                            await add.Addtask(task.Key, task.Value.Keys.ToString(), Categoria.Muito_importante, connectionString);
                            break;

                        case "BEI":
                            await add.Addtask(task.Key, task.Value.Keys.ToString(), Categoria.BEI, connectionString);
                            break;
                        
                    }
            }
        }
    }
}
