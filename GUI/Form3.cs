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
using To_do_List_List;

namespace To_do_List_List.GUI
{
    public partial class Form3 : Form
    {
        public readonly string connectionString = MakeMysqlKey.MakeKey("Users_Tasksoftwares");

        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                throw new ArgumentNullException("Por favor, forneça um nome de usuário e senha.");
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = conn.CreateCommand())
                    {
                        string acessadortabela = textBox1.Text + "_Tsk";

                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO Users_tb (Nome, Senha, TBL_Tasks) VALUES (@Nome, @Senha, @TBL_Tasks)";

                        cmd.Parameters.AddWithValue("@Nome", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Senha", textBox2.Text);
                        cmd.Parameters.AddWithValue("@TBL_Tasks", acessadortabela);
                        cmd.CommandText = $@"CREATE TABLE `tasks_db`.`{acessadortabela}` (
                                            `ID` INT NOT NULL AUTO_INCREMENT,
                                             `Nome` VARCHAR(45) NOT NULL,
                                             `Concluida` VARCHAR(3) NOT NULL,
                                             `Categoria` VARCHAR(45) NOT NULL,
                                             PRIMARY KEY (`ID`));
                                        ";

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Conta criada com sucesso!", "To-Do-List", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Form1 form = new Form1();

                            Form1.Acessor = acessadortabela;

                            form.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro: {ex.Message}", "Tratamento de erros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Validação dos campos de entrada
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, forneça um nome de usuário e senha.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string usuario = textBox1.Text;
            string senha = textBox2.Text;

            try
            {
                // Estabelecendo conexão com o banco de dados
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Usando parâmetros para evitar SQL Injection
                    string query = "SELECT * FROM users_tb WHERE Nome = @Nome AND Senha = @Senha";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Adicionando parâmetros
                        cmd.Parameters.AddWithValue("@Nome", usuario);
                        cmd.Parameters.AddWithValue("@Senha", senha);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read(); // Ler o primeiro resultado

                                MessageBox.Show("Conta acessada com sucesso!", "To-Do-List", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Abrir o próximo formulário e passar o valor necessário
                                Form1 form = new Form1();
                                Form1.Acessor = usuario + "_Tsk";
                                form.ShowDialog();
                            }
                            else
                            {
                                // Se nenhuma linha foi encontrada
                                MessageBox.Show("Acesso negado! Usuário ou senha incorretos.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro ao acessar o banco de dados: {ex.Message}", "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}

