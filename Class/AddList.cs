// IMporto o Mysql e o namespace padrão da aplicação
using MySql.Data.MySqlClient;
using To_do_List_List;

// adiciona a classe a seguir dentro do namespace padrão da aplicação
namespace To_do_List_List
{

    // Crio a classe para conter o metodo AddList
    public class addList
    {
        // Crio um objeto global para o painel utilizado
        public Panel panelTarefas;


        // Crio o construtor da classe addList
        public addList(Panel panel)
        {
            panelTarefas = panel; // Atribuo o painel passado ao construtor ao objeto global panelTarefas
        }

        // Crio o metodo Addtask, para adicionar uma tarefa ao painel
        public async Task Addtask(string task, string Concluida, string connectionString)
        {
            MySqlConnection conn = new MySqlConnection(connectionString); // Crio a conexão com o banco de dados

            // Criar um novo painel para a nova tarefa
            Panel newTaskPanel = new Panel
            {
                BackColor = Color.LightGoldenrodYellow,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(289, 70)
            };

            // Criar o CheckBox para a tarefa
            CheckBox newTaskCheckBox = new CheckBox
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 11F),
                Text = task,
                Location = new Point(3, 20)
            };

            // verifico se o parametro concluido é igual a sim, se for, marco o checkbox como marcado
            if (Concluida == "Sim")
            {
                newTaskCheckBox.Checked = true;
                newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Strikeout);
            }
            else // se não, marco o checkbox como desmarcado
            {
                newTaskCheckBox.Checked = false;
                newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Regular);
            }

            // Adiciono um evento ao checkbox, para marcar a tarefa como concluida ou não
            newTaskCheckBox.CheckedChanged += async (sender, e) =>
            {
                await conn.OpenAsync(); // abro uma conexão com o banco de dados

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Parameters.Clear();  // Limpar parçãmetros anteriores
                    if (newTaskCheckBox.Checked)
                    {
                        // atualizo as informações no banco de dados                        
                        newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Strikeout);
                        cmd.CommandText = "UPDATE Tarefas SET Concluida = \"Sim\" WHERE Nome = @Nome"; // marcando sim, se a checkbox for marcada
                    }
                    else // caso contrario
                    {
                        newTaskCheckBox.Font = new Font(newTaskCheckBox.Font, FontStyle.Regular);
                        cmd.CommandText = "UPDATE Tarefas SET Concluida = \"Não\" WHERE Nome = @Nome"; // marcando não, se a checkbox não for marcada
                    }

                    // adiciono o parametro nome ao comando e o executo no banco de dados
                    cmd.Parameters.AddWithValue("@Nome", task);
                    await cmd.ExecuteNonQueryAsync();
                }

                await conn.CloseAsync();
            };

            // Criar o botção para remover a tarefa
            Button removeButton = new Button
            {
                BackColor = Color.Brown,
                FlatStyle = FlatStyle.Popup,
                Font = new Font("Showcard Gothic", 10.2F, FontStyle.Bold),
                Text = "X",
                Size = new Size(25, 27),
                Location = new Point(265, 0)
            };

            // Adiciono um evento ao botção, para remover a tarefa
            removeButton.Click += async (sender, e) =>
            {
                await conn.OpenAsync();

                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    panelTarefas.Controls.Remove(newTaskPanel); // Remove o painel da lista

                    cmd.Parameters.Clear(); // Limpar parâmetros anteriores

                    cmd.CommandText = "DELETE FROM Tarefas WHERE Nome = @Nome";
                    cmd.Parameters.AddWithValue("@Nome", task);

                    // executo o comando no banco de dados
                    await cmd.ExecuteNonQueryAsync();
                }

                await conn.CloseAsync(); // fecho a conexão
            };

            // Adicionar o CheckBox e o boção ao painel da nova tarefa
            newTaskPanel.Controls.Add(newTaskCheckBox);
            newTaskPanel.Controls.Add(removeButton);

            int taskCount;

            // Determinar a posição do novo painel baseado nas tarefas já existentes
            try
            {
                taskCount = panelTarefas.Controls.Count;
                newTaskPanel.Location = new Point(13, 17 + (taskCount * 75)); // Ajusta a posição para a próxima tarefa

            }
            catch (NullReferenceException)
            {
                newTaskPanel.Location = new Point(13, 17);
            }

            // Adicionar o painel da nova tarefa ao painel principal
            panelTarefas.Controls.Add(newTaskPanel);

            // fechando a conexão
            conn.Close();

        }
    }
}
