// Importo os namespaces nescessários

using System.Data.SQLite;
using To_do_List_List;

// adiciona a classe a seguir dentro do namespace padrão da aplicação
namespace To_do_List_List
{
    // Crio a classe para conter eventos e metodos do formulario principal
    public partial class Form1 : Form // herdo propriedades e metodos da classe Form
    {
        // crio a string de conexão com o banco de dados
        public readonly string connectionString = "Data Source=C:\\Visual Studio Projects\\_NetProjects\\C#\\To-do-List-List\\Data\\tasks.db;Version=3;";

        // No construtor da classe, inicializo o formulario
        public Form1()
        {
            InitializeComponent();

            // Inicializa o painel com as tarefas salvas
            ReaderTasksMethods.ReadToPanel(panel2, connectionString);
        }

        // Evento para adicionar uma nova tarefa
        private async void button1_Click(object sender, EventArgs e)
        {
            // Crio uma nova conexão com o banco de dados
            SQLiteConnection conn = new SQLiteConnection(connectionString);

            // Verifico se o campo de texto está vazio
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a task","Form1",MessageBoxButtons.OK,MessageBoxIcon.Error); // Se estiver, exibo uma mensagem de erro
                throw new NullReferenceException("A string tava vazia, queria q eu fizesse oq?"); // e lanço uma exceção
            }
            else // caso o contrario
            {
                // Abro a conexão com o banco de dados
                conn.Open();

                // Crio um novo comando SQL
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    // Adicionar a tarefa ao banco de dados
                    cmd.CommandText = "INSERT INTO Tarefas (Nome, Concluida) VALUES (@Nome, 'Não');";
                    cmd.Parameters.AddWithValue("@Nome", textBox1.Text);
                    cmd.ExecuteNonQuery(); // executo o comando

                }

                // Instancio a classe addList
                addList taskManager = new addList(panel2);

                // Adiciono a tarefa ao painel de modo assincrono
                await taskManager.Addtask($"{textBox1.Text}", "Não", connectionString);

                conn.Close(); // E fecho a conexão


            }
        }
    }
}
