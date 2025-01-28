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
        public readonly string connectionString = MakeMysqlKey.MakeKey("tasks_db");
        public static string Acessor { get; set; }

        // No construtor da classe, inicializo o formulario
        public Form1()
        {
            InitializeComponent();

            // Inicializa o painel com as tarefas salvas

        }

        // Evento para adicionar uma nova tarefa
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(panel2,Acessor);

            form.ShowDialog();
        }

        // evento para ler e adicionar as tarefas no panel

        private async void Form1_Load(object sender, EventArgs e)
        {
            await ReaderTasksMethods.ReadToPanel(panel2, connectionString, Form1.Acessor);
        }
    }
}
