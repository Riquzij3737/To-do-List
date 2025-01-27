// Aqui, Importo os namespaces utilizados no código
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq.Expressions;

// adiciona a classe a seguir dentro do namespace padrão da aplicação
namespace To_do_List_List
{
    // Crio a classe para conter o método Getdata
    public class GetData
    {
        // Propriedade connstring para armazenar a string de conexão
        public readonly string connstring;

        // Construtor da classe GetData
        public GetData(string connstring)
        {
            this.connstring = connstring;
        }

        // Método GetdataForID para obter dados do banco de dados
        public async Task<SqlReaderObject> GetdataForID()
        {            
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                await conn.OpenAsync(); // Abro a conexão com o banco de dados

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Nome, Concluida, Categoria FROM tarefas"; // Defino a query SQL
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        SqlReaderObject sqreader = new SqlReaderObject(); // Instancio a classe SqlReaderObject

                        int i = 0;

                        foreach (IDataRecord rdr in reader)
                        {                                                        

                            // Adiciono os dados do banco de dados à classe SqlReaderObject
                            sqreader.Nome[i] = rdr["Nome"].ToString();
                            sqreader.Concluidp[i] = rdr["Concluida"].ToString();
                            sqreader.Categoria[i] = rdr["Categoria"].ToString();                            
                            
                            i++;
                        }

                        await conn.CloseAsync(); // Fecho a conexão com o banco de dados

                        return sqreader;
                    }
                }
            }
        }

    }
}
