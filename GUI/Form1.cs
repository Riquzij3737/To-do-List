using System.Data.SQLite;
using To_do_List_List;

namespace To_do_List_List
{
    public partial class Form1 : Form
    {
        public readonly string connectionString = "Data Source=C:\\Visual Studio Projects\\_NetProjects\\C#\\To-do-List-List\\Data\\tasks.db;Version=3;";

        public Form1()
        {
            InitializeComponent();

            // Inicializa o painel com as tarefas salvas
            ReaderTasksMethods.ReadToPanel(panel2, connectionString);
        }
       

        private async void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection(connectionString);

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a task");
            }
            else
            {                          
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        // Adicionar a tarefa ao banco de dados
                        cmd.CommandText = "INSERT INTO Tarefas (Nome, Concluida) VALUES (@Nome, 'Não');";
                        cmd.Parameters.AddWithValue("@Nome", textBox1.Text);
                        cmd.ExecuteNonQuery();                      

                    }

                    addList taskManager = new addList(panel2);
                    await taskManager.Addtask($"{textBox1.Text}", "Não", connectionString);                    

                    conn.Close();

                
            }
        }
    }
}
