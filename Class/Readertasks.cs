// Importo os namespaces necessários
using To_do_List_List;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using To_do_List_List.GUI;

// adiciona a classe a seguir dentro do namespace padrão da aplicação
namespace To_do_List_List
{
    // Crio a classe para conter o método ReadToPanel
    public class ReaderTasksMethods
    {
        public static async Task ReadToPanel(Panel panelTarefas, string connectionString)
        {
            // Instancio a classe GetData, passando a string de conexão
            GetData data = new GetData(connectionString);

            // Chamo o método GetdataForID, que retorna uma lista de arrays de strings
            SqlReaderObject tasks = await data.GetdataForID();

            // Abro a conexão com o banco de dados
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                // Para cada tarefa na lista
                foreach (var task in tasks.Nome)
                {
                    foreach (var status in tasks.Concluidp)
                    {
                        foreach (var category in tasks.Categoria)
                        {
                            addList add = new addList(panelTarefas);

                            switch (category)
                            {
                                case "Nulo":
                                    await add.Addtask(task, status, Categoria.Nulo, connectionString);
                                    break;

                                case "Relativa":
                                    await add.Addtask(task, status, Categoria.Relativa, connectionString);
                                    break;

                                case "Importante":
                                    await add.Addtask(task, status, Categoria.Importante, connectionString);
                                    break;

                                case "Muito Importante":
                                    await add.Addtask(task, status, Categoria.Muito_importante, connectionString);
                                    break;

                                case "BEI":
                                    await add.Addtask(task, status, Categoria.BEI, connectionString);
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
