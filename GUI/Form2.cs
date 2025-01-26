using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_do_List_List.GUI
{
    public partial class Form2 : Form
    {
        public readonly string connectionString = MakeMysqllKey.MakeKey(); // Crio a string de conexão com o banco de dados        
        public Panel Panelmanager;

        public Form2(Panel form)
        {
            Panelmanager = form;

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Crio uma nova conexão com o banco de dados
            MySqlConnection conn = new MySqlConnection(connectionString);

            // Verifico se o campo de texto está vazio
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a task", "Form1", MessageBoxButtons.OK, MessageBoxIcon.Error); // Se estiver, exibo uma mensagem de erro
                throw new NullReferenceException("A string tava vazia, queria q eu fizesse oq?"); // e lanço uma exceção
            }
            else // caso o contrario
            {
                // Abro a conexão com o banco de dados
                conn.Open();

                // Crio um novo comando SQL
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    // Adicionar a tarefa ao banco de dados
                    cmd.CommandText = "INSERT INTO Tarefas (Nome, Concluida, Categoria) VALUES (@Nome, 'Não', @Categoria);";
                    cmd.Parameters.AddWithValue("@Nome", textBox1.Text);
                    
                    // Instancio a classe addList
                    addList taskManager = new addList(Panelmanager);

                    // Adiciono a tarefa ao painel de modo assincrono
                    switch (checkedListBox1.Text)
                    {
                        case "Nulo":
                            await taskManager.Addtask(textBox1.Text, "Não", Categoria.Nulo, connectionString);
                            cmd.Parameters.AddWithValue("@Categoria", "Nulo");
                            cmd.ExecuteNonQuery(); // executo o comando
                            break;

                        case "Relativa":
                            await taskManager.Addtask(textBox1.Text, "Não", Categoria.Relativa, connectionString);
                            cmd.Parameters.AddWithValue("@Categoria", "Relativa");
                            cmd.ExecuteNonQuery(); // executo o comando
                            break;

                        case "Importante":
                            await taskManager.Addtask(textBox1.Text, "Não", Categoria.Importante, connectionString);
                            cmd.Parameters.AddWithValue("@Categoria", "Importante");
                            cmd.ExecuteNonQuery(); // executo o comando
                            break;

                        case "Muito importante":
                            await taskManager.Addtask(textBox1.Text, "Não", Categoria.Muito_importante, connectionString);
                            cmd.Parameters.AddWithValue("@Categoria", "Muito importante");
                            cmd.ExecuteNonQuery(); // executo o comando
                            break;

                        case "Big exterm importance(BEI)":
                            await taskManager.Addtask(textBox1.Text, "Não", Categoria.BEI, connectionString);
                            cmd.Parameters.AddWithValue("@Categoria", "BEI");
                            cmd.ExecuteNonQuery(); // executo o comando
                            break;

                    }

                    conn.Close(); // E fecho a conexão

                }
            }
        }
    }
}
