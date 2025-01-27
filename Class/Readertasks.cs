// Importo os namespaces necessários
using To_do_List_List;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using To_do_List_List.GUI;
using System.ComponentModel.Design;

// adiciona a classe a seguir dentro do namespace padrão da aplicação
namespace To_do_List_List
{
    // Crio a classe para conter o método ReadToPanel
    public class ReaderTasksMethods
    {
        public static async Task ReadToPanel(Panel panelTarefas, string connectionString, string acessor)
        {
            // Instancio a classe GetData, passando a string de conexão
            GetData data = new GetData(connectionString);

            // Chamo o método GetdataForID, que retorna uma lista de arrays de strings
            SqlReaderObject tasks = await data.GetdataForID(acessor);

            // Abro a conexão com o banco de dados
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                

                // Para cada tarefa na lista

                addList add = new addList(panelTarefas);

                for (int i = 0; i < 100; i++)
                {
                    switch (tasks.Categoria[i])
                    {
                        case "Nulo":
                            await add.Addtask(tasks.Nome[i], tasks.Concluidp[i], Categoria.Nulo, connectionString);
                            break;

                        case "Relativa":
                            await add.Addtask(tasks.Nome[i], tasks.Concluidp[i], Categoria.Relativa, connectionString);
                            break;
                        
                        case "Importante":
                            await add.Addtask(tasks.Nome[i], tasks.Concluidp[i], Categoria.Importante, connectionString);
                            break;
                        
                        case "Muito importante":
                            await add.Addtask(tasks.Nome[i], tasks.Concluidp[i], Categoria.Muito_importante, connectionString);
                            break;
                        
                        case "BEI":
                            await add.Addtask(tasks.Nome[i], tasks.Concluidp[i], Categoria.BEI, connectionString);
                            break;
                    }
                }

            }
        }
    }
}
