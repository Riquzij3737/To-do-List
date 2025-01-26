// Aqui, Importo os namespaces utilizados no codigo
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq.Expressions;

// adiciona a classe a seguir dentro do namespace padrão da aplicação
namespace To_do_List_List;

// Crio a classe para conter o metodo Getdata
public class GetData
{
    // Crio a propriedade connstring, que recebe a string de conexão
    public readonly string connstring;

    // Crio o construtor da classe GetData
    public GetData(global::System.String connstring)
    {
        this.connstring = connstring; // Atribuo a string de conexão a propriedade connstring
    }

    // Crio o metodo GetdataForID, Para pegar as informações do banco de dados
    public async Task<Dictionary<string, Dictionary<string, string>>> GetdataForID()
    {
        // Crio a conexão com o banco de dados, dentro de um bloco using, Para após o uso, fechar a conexão
        using (MySqlConnection conn = new MySqlConnection(this.connstring))
        {
            // abro a conexão de forma assincronica
            await conn.OpenAsync();

            // Crio o comando SQL, para selecionar todos os dados da tabela Tarefas
            using (MySqlCommand cmd = conn.CreateCommand())
            {
                // o comando para pegar os dados, armazenado em um commandtext
                cmd.CommandText = "SELECT * FROM \"Tarefas\"";

                // Executo o comando, e armazeno o resultado em um MySqlDataReader
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Crio um dicionario para armazenar as tarefas, e suas respectivas conclusões
                    Dictionary<string, Dictionary<string, string>> tasks = new Dictionary<string,Dictionary<string, string>>();                    

                    // Para cada registro no reader, adiciono a tarefa e sua conclusão ao dicionario
                    foreach (IDataRecord record in reader)
                    {
                        switch (record["Categoria"])
                        {
                            case "nulo":
                                tasks.Add(record["Nome"].ToString(), new Dictionary<string, string> { {record["Concluida"].ToString() , "Nulo"} });
                                break;
                            
                            case "Relativa":
                                tasks.Add(record["Nome"].ToString(), new Dictionary<string, string> { {record["Concluida"].ToString() , "Relativa"} });
                                break;
                            
                            case "Importante":
                                tasks.Add(record["Nome"].ToString(), new Dictionary<string, string> { {record["Concluida"].ToString() , "Importante"} });
                                break;
                            
                            case "Muito Importante":
                                tasks.Add(record["Nome"].ToString(), new Dictionary<string, string> { {record["Concluida"].ToString() , "Muito Importante"} });
                                break;
                            
                            case "BEI":
                                tasks.Add(record["Nome"].ToString(), new Dictionary<string, string> { {record["Concluida"].ToString() , "BEI"} });
                                break;
                            
                            
                        }
                    }

                    return tasks; // retorno o dicionario
                }
            }

        }
    }


}

