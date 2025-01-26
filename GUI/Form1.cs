// Importo os namespaces nescessários

using MySql.Data.MySqlClient;
using To_do_List_List;
using To_do_List_List.GUI;

// adiciona a classe a seguir dentro do namespace padrão da aplicação
namespace To_do_List_List
{
    // Crio a classe para conter eventos e metodos do formulario principal
    public partial class Form1 : Form // herdo propriedades e metodos da classe Form
    {
        // crio a string de conexão com o banco de dados
        public readonly string connectionString = MakeMysqlKey.MakeKey();

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
            Form2 form = new Form2(panel2);

            form.ShowDialog();
        }
    }
}
