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

// adiciono a classe do Form3 a seguir dentro do namespace de interfaces graficas padrão da aplicação

namespace To_do_List_List.GUI
{
    public partial class Form3 : Form // declaro a classe Form3 a herdo propriedades de Form
    {
        // Declaro a string de conexão, recebendo do metodo MakeKey, E insiro o banco de dados que quero acessar
        public readonly string connectionString = MakeMysqlKey.MakeKey("Users_Tasksoftwares");

        // inicio a interface no construtor da classe
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // botão de criação de conta
        private async void button2_Click(object sender, EventArgs e)
        {
            // verifico se a string de entrada estiver vazia
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                throw new ArgumentNullException("Por favor, forneça um nome de usuário e senha."); // caso esteja, lanço uma excessão de argumentos nulos
            }
            else // caso contrario
            {
                // crio uma nova conexão com o banco de dados
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    // abro ela
                    conn.Open();

                    // crio um novo comando SQL
                    using (MySqlCommand cmd = conn.CreateCommand()) 
                    {
                        // crio o acessor da tabela, que basicamente informa ao programa qual banco de dados usar para salvar as tarefas
                        string acessadortabela = textBox1.Text + "_Tsk";

                        // limpo os parametros e insiro os dados dentro da tabela de usuarios
                        cmd.Parameters.Clear();
                        cmd.CommandText = @" use users_tasksoftwares;
                        INSERT INTO users_tb (Nome, Senha, TBL_Tasks) VALUES (@Nome, @Senha, @TBL_Tasks);";

                        cmd.Parameters.AddWithValue("@Nome", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Senha", textBox2.Text);
                        cmd.Parameters.AddWithValue("@TBL_Tasks", acessadortabela);

                        await cmd.ExecuteNonQueryAsync(); // executo de forma assincrona, por motivos de desempenho

                        // crio a uma tabela dentro do banco de tarefas, com o nome do acessor, lembra doq eu falei dos acessores de tabela
                        // então, ta ai, vai ser por ai que todo o programa vai acessar e inserir os dados das tarefas
                        cmd.CommandText = $@"CREATE TABLE `tasks_db`.`{acessadortabela}` (
                                            `ID` INT NOT NULL AUTO_INCREMENT,
                                             `Nome` VARCHAR(45) NOT NULL,
                                             `Concluida` VARCHAR(3) NOT NULL,
                                             `Categoria` VARCHAR(45) NOT NULL,
                                             PRIMARY KEY (`ID`));
                                        ";

                        // abro um bloco try-catch
                        try 
                        {

                            // executo a query
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Conta criada com sucesso!", "To-Do-List", MessageBoxButtons.OK, MessageBoxIcon.Information); // aviso que a conta foi criada com sucesso

                            // instancio o form1 e inicio a interface do form1, alem de passar o acessor para ele
                            Form1 form = new Form1();
                            Form1.Acessor = acessadortabela;
                            form.ShowDialog();

                        } // caso de algum erro
                        catch (Exception ex)
                        {
                            // eu o aviso
                            MessageBox.Show($"Erro: {ex.Message}", "Tratamento de erros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        finally // e no finally, fecho o banco de dados
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }


        // aqui é onde eu configuro o botão de login
        private void button1_Click(object sender, EventArgs e)
        {
            // Verifico se os valores se não forem nulos
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                // caso forem, eu paro a aplicação, e eu aviso o usuário
                MessageBox.Show("Por favor, forneça um nome de usuário e senha.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new ArgumentNullException();
            }

            // caso funcione, bom, eu insiro os valores das textbox em variavie do tipo string
            string usuario = textBox1.Text;
            string senha = textBox2.Text;

            // abro um bloco try-catch
            try
            {
                // Estabelo conexão com o banco de dados
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open(); // abro ela

                    //  crio a query para pegar os valores da tabela de usuarios
                    string query = @" use users_tasksoftwares;
                    SELECT * FROM users_tb WHERE Nome = @Nome AND Senha = @Senha";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Adicionando parâmetros, para evitar sql injection, né pilantra
                        cmd.Parameters.AddWithValue("@Nome", usuario);
                        cmd.Parameters.AddWithValue("@Senha", senha);

                        // Executando a query e inciando uma reader
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {

                            // Verificando se houve resultados
                            if (reader.HasRows)
                            { // se houver

                                reader.Read(); // leio a primeira linha

                                // e aviso o usuário que o login foi feito com sucesso
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
            catch (MySqlException ex) // caso de algum erro relacionados ao mysql
            {
                // eu o aviso e paro a aplicação
                MessageBox.Show($"Erro ao acessar o banco de dados: {ex.Message}", "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex) // caso de algum erro em geral, tipo sla, Minecraft2.exe tentou manipular os bytes do programa
            {
                // eu o aviso e paro a aplicação
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }
        }
    }

}

