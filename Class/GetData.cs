// Aqui, Importo os namespaces utilizados no codigo
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

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
    public async Task<Dictionary<string, string>> GetdataForID()
    {
        // Crio a conexão com o banco de dados, dentro de um bloco using, Para após o uso, fechar a conexão
        using (SQLiteConnection conn = new SQLiteConnection(this.connstring))
        {
            // abro a conexão de forma assincronica
            await conn.OpenAsync();

            // Crio o comando SQL, para selecionar todos os dados da tabela Tarefas
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                // o comando para pegar os dados, armazenado em um commandtext
                cmd.CommandText = "SELECT * FROM \"Tarefas\"";

                // Executo o comando, e armazeno o resultado em um SQLiteDataReader
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    // Crio um dicionario para armazenar as tarefas, e suas respectivas conclusões
                    Dictionary<string, string> tasks = new Dictionary<string, string>();

                    // Para cada registro no reader, adiciono a tarefa e sua conclusão ao dicionario
                    foreach (IDataRecord record in reader)
                    {
                        tasks.Add(record["Nome"].ToString(), record["Concluida"].ToString());
                    }

                    return tasks; // retorno o dicionario
                }
            }

        }
    }


}

